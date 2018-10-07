using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImageComposer
{
    public partial class Form1 : Form
    {
        private List<ERROR_TYPE> resultList = new List<ERROR_TYPE>();

        //初始化
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            panelRareUpright.Visible = false;
            panelGasha.Visible = false;
            panelGashaInfo.Visible = false;
            labelWhiteBoard.Visible = false;
        }

        //点击“打开文件”按钮时执行的操作
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择要打开的文件";
            ofd.Multiselect = true;
            ofd.Filter = "图像文件|*.jpeg;*.jpg;*.png";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labelProcessing.Visible = true; // todo : 目前无用，有待改进
                foreach (var fileName in ofd.FileNames)
                {
                    resultList.Add(FileManager.ImageCompose(fileName));
                }
                labelProcessing.Visible = false;
                ShowResult();
            }
        }

        //根据返回的错误类型显示结果
        private void ShowResult()
        {
            bool allGreen = true;
            ERROR_TYPE error = ERROR_TYPE.Succeed;

            foreach (var result in resultList)
            {
                if(result != ERROR_TYPE.Succeed)
                    error = result;
            }

            switch (error)
            {
                case ERROR_TYPE.Succeed:
                    break;
                case ERROR_TYPE.SizeError:
                    MessageBox.Show("文件大小不符合拼接需求。请核对原文件。", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    allGreen = false;
                    break;
                case ERROR_TYPE.FileError:
                    MessageBox.Show("文件读写出现错误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allGreen = false;
                    break;
                case ERROR_TYPE.Unknown:
                    MessageBox.Show("未知错误。万策尽きた！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allGreen = false;
                    break;
            }

            if (allGreen)
            {
                MessageBox.Show("拼接操作完成。生成的文件在源文件同目录下。", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("拼接操作终止。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //选择不同功能时，控制相关参数选项的显影，同时记录所选功能
        private void CheckToggleChanged(object sender, EventArgs e)
        {
            if (tglRareWide.Checked)
            {
                FileManager.funcType = FUNC_TYPE.SSRWide; ;
                panelCard.Visible = true;
                panelRareUpright.Visible = false;
                panelGasha.Visible = false;
                panelGashaInfo.Visible = false;
                labelWhiteBoard.Visible = false;
            }

            if (tglRareUpright.Checked)
            {
                FileManager.funcType = FUNC_TYPE.SSRUpright;
                panelCard.Visible = false;
                panelRareUpright.Visible = true;
                panelGasha.Visible = false;
                panelGashaInfo.Visible = false;
                labelWhiteBoard.Visible = false;
            }

            if (tglGasha.Checked)
            {
                FileManager.funcType = FUNC_TYPE.Gasha;
                panelCard.Visible = false;
                panelRareUpright.Visible = false;
                panelGasha.Visible = true;
                panelGashaInfo.Visible = false;
                labelWhiteBoard.Visible = false;
            }

            if (tglGashaInfo.Checked)
            {
                FileManager.funcType = FUNC_TYPE.GashaInfo;
                panelCard.Visible = false;
                panelRareUpright.Visible = false;
                panelGasha.Visible = false;
                panelGashaInfo.Visible = true;
                labelWhiteBoard.Visible = false;
            }

            if (tglWhiteBoard.Checked)
            {
                FileManager.funcType = FUNC_TYPE.WhiteBoard;
                panelCard.Visible = false;
                panelRareUpright.Visible = false;
                panelGasha.Visible = false;
                panelGashaInfo.Visible = false;
                labelWhiteBoard.Visible = true;
            }
        }

        //卡面拼接功能内的参数选择
        private void CheckCardChanged(object sender, EventArgs e)
        {
            if (radioCardOrigin.Checked)
            {
                FileManager.cardType = CARD_TYPE.Origin;
            }

            if (radioCardWide.Checked)
            {
                FileManager.cardType = CARD_TYPE.Wide;
            }

            if (radioCardBoth.Checked)
            {
                FileManager.cardType = CARD_TYPE.Both;
            }
        }

        //竖版卡图拼接功能内的参数选择
        private void UprightTypeChanged(object sender, EventArgs e)
        {
            if (radioNoFrame.Checked)
            {
                FileManager.uprightType = UPRIGHT_TYPE.NoFrame;
            }

            if (radioWithFrame.Checked)
            {
                FileManager.uprightType = UPRIGHT_TYPE.WithFrame;
            }

            if (radioBoth.Checked)
            {
                FileManager.uprightType = UPRIGHT_TYPE.Both;
            }
        }

        //卡池图片拼接功能内的参数选择
        private void CheckGashaChanged(object sender, EventArgs e)
        {
            if (radioOrigin.Checked)
            {
                FileManager.gashaType = GASHA_TYPE.Origin;
            }

            if (radioWide.Checked)
            {
                FileManager.gashaType = GASHA_TYPE.Wide;
            }

            if (radioGashaBoth.Checked)
            {
                FileManager.gashaType = GASHA_TYPE.Both;
            }
        }

        //卡池信息图拼接功能内的参数选择
        private void GashaInfoChanged(object sender, EventArgs e)
        {
            if (radioNewReso.Checked)
            {
                FileManager.gashaInfoType = GASHAINFO_TYPE.New;
            }

            if (radioOldReso.Checked)
            {
                FileManager.gashaInfoType = GASHAINFO_TYPE.Old;
            }

        }

        //点击“使用说明”按钮时执行
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("1. 用于将某种形式的图片变成另一种形式。本程序假定你已经知道它是用来干什么的。 \n\n" +
                            "2. 点击“打开文件”选择图片后，将立即开始转换操作。此时程序可能会无响应，请耐心等待。\n\n" +
                            "3. 在打开文件对话框中多选文件，即可进行批量转换。可能会占用较高CPU、内存和硬盘读写率。\n\n" +
                            "4. 生成适配宽屏的长图，需将原图两张素材放在同一目录下。打开文件时，只需选择大图部分，即1024x1024那张图片。\n\n" +
                            "5. 图片拼接时请注意是否出现图片错位的情况。如有错位，请尝试同类型其他拼图功能进行拼接。如果错位情况仍然存在，请手动进行拼接，并联系开发者。 \n\n" +
                            "6. 关于卡池信息图，自tb02活动起，信息介绍图的分辨率提高了，因此拼接算法有改动。若要" +
                            "拼接tb02之前的活动卡池图，需选择「低分辨率旧版」选项进行操作。\n\n" +
                            "最后，报错信息可能会误报……最终结果以是否成功生成图片为准。\n\n" + 
                            "\t\t\t\t\tBUG提交和反馈请联系Excel。",
                            "使用说明");
        }

    }

}
