using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Activated += RefreshPanel;
            labelDownLoadInfo.Text = "";

            if (Define.VersionDic.Count > 0)
            {
                Define.GameVersion = Define.VersionDic.Last().Key;
                Define.IndexName = Define.VersionDic.Last().Value;
            }
        }

        private void btnGameVersionChange_Click(object sender, EventArgs e)
        {
            GameVersionChange dialogVersionChange = new GameVersionChange();
            dialogVersionChange.ShowDialog();
        }

        private void btnIndexDownload_Click(object sender, EventArgs e)
        {
            labelDownLoadInfo.Text = "请求下载索引文件...期间程序可能会无响应，请耐心等待";
            if (FileManager.DownloadIndex())
            {
                MessageBox.Show("SUCCEED !\n索引文件下载完成。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            labelDownLoadInfo.Text = "";
            ResetPanel();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listBoxResult.Items.Clear();
            string input = txtBoxSearch.Text;
            if (string.IsNullOrEmpty(input))
                return;

            foreach (var info in Define.IndexDic)
            {
                if (info.Value.name.IndexOf(input) >= 0)
                {
                    listBoxResult.Items.Add(info.Value.name);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如果你是初次使用该程序，建议按以下操作步骤进行：" +
                                "\n\n\t1、在主界面中，点击“版本号切换”按钮" +
                                "\n\n\t2、在弹出的窗口中选择“查询最新版本”，待完成后点击“保存并确认”按钮" +
                                "\n\n\t3、回到主界面，点击“下载索引文件”按钮，并等待下载完成。" +
                                "\n\n\t完成之后，即可开始使用。" +
                            "\n\n如有意外报错和崩溃，请先尝试将程序目录下urls.json和index文件夹备份后删除，然后" +
                            "重新运行程序。如果问题依然存在，请联系开发者。" +
                            "\n\n查询、下载中可能会出现程序未响应的情况，请耐心等待直至程序提示结果。" +
                            "\n\n改进或了解程序原理可到github.com/EllisNewman/MyGadgets/处查看。意见反馈和报错请联系Excel。",
                    "使用说明", MessageBoxButtons.OK);
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (listBoxResult.SelectedItems.Count < 1)
            {
                labelDownLoadInfo.Text = "尚未选择要下载的资源。通过检索关键字或版本对比功能展示资源列表后，" +
                                         "点击选择某项或某几项资源，再从此处开始下载。";
                return;
            }

            StringBuilder sb = new StringBuilder("开始下载：");

            foreach (var item in listBoxResult.SelectedItems)
            {
                sb.Append(item + ", 大小: " + Define.IndexDic[item.ToString()].size + "byte. ");
                labelDownLoadInfo.Text = sb.ToString();
            }

            //todo : 两个foreach的实现不好，但又不清楚怎么优化。有待改进。

            foreach (var item in listBoxResult.SelectedItems)
            {
                FileManager.DownLoadAsset(item.ToString(), Define.IndexDic[item.ToString()].url);
            }

            labelDownLoadInfo.Text = "下载完成！";
        }

        private void btnOpenDownloadPath_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion))
            {
                Directory.CreateDirectory(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion);
            }

            System.Diagnostics.Process.Start("Explorer.exe", Define.LocalPath + Define.AssetPath);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (Define.VersionDic.Count < 2)
            {
                MessageBox.Show("在本地仅检测到一个版本号，无法进行对比。\n\n可先通过“版本号切换”功能查找版本号，然后" +
                                "下载相应索引文件，即可进行版本对比。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            DialogResult dr = MessageBox.Show("将进行版本更新内容对比" +
                                              "\n\n当前版本：" + Define.GameVersion +
                                              "\n\n前个版本：" + 
                                              "\n\n是否确定？" +
                                              "\n\n用于版本更新时，检查并显示新版本修改的内容。两个版本之间的" +
                                              "差距不宜过大。\n\n进行对比的两个版本都需要备好各自的索引文件。需先" +
                                              "通过“版本号切换”功能查找所需版本，并下载索引文件。", 
                                              "版本对比", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                
            }
        }

        private void RefreshPanel(object sender, EventArgs e)
        {
            if (labelGameVersion.Text == Define.GameVersion.ToString())
            {
                return;
            }

            ResetPanel();
            
        }

        private void ResetPanel()
        {
            listBoxResult.Items.Clear();
            string indexPath = Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[Define.GameVersion];
            if (File.Exists(indexPath))
            {
                labelIndex.Text = "就绪";
                labelDownLoadInfo.Text = "已成功打开该版本所需的索引文件。";
                FileManager.ReadIndexFile(indexPath);
            }
            else
            {
                labelIndex.Text = "未下载";
                labelDownLoadInfo.Text = "每个版本需要对应的索引文件以查找资源。下载索引文件后才能继续使用。";
            }
            labelGameVersion.Text = Define.GameVersion.ToString();
        }


    }
}
