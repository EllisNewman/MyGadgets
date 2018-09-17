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
            this.StartPosition =  FormStartPosition.CenterScreen;
            this.Activated += RefreshPanel;
            labelIndexDownload.Text = "";

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

        private void RefreshPanel(object sender, EventArgs e)
        {
            labelGameVersion.Text = Define.GameVersion.ToString();
            if (File.Exists(Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[Define.GameVersion]))
            {
                labelIndex.Text = "就绪";
            }
            else
            {
                labelIndex.Text = "未下载";                
            }
        }

        private void btnIndexDownload_Click(object sender, EventArgs e)
        {
            labelIndexDownload.Text = "请求下载索引文件...期间程序可能会无响应，请耐心等待";
            if(DownloadIndex())
                MessageBox.Show("SUCCEED !\n索引文件下载完成。"
                    ,"", MessageBoxButtons.OK, MessageBoxIcon.Information);

            labelIndexDownload.Text = "";
            RefreshPanel(null, null);
        }

        private static bool DownloadIndex()
        {
            string url = "ht" + "tps:/" + "/td-a" +"ssets.b" + "n" +"76" + "5.com/" + Define.GameVersion + "/production/" + (Define.GameVersion>14580?2017.3:5.6) + "/Android/" + Define.IndexName;
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                Stream stream = new FileStream(Define.LocalPath + Define.IndexPath + "/" + Define.IndexName, FileMode.Create);
                byte[] bArr = new byte[4096];
                int size = responseStream.Read(bArr, 0, bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, bArr.Length);
                }
                stream.Close();
                responseStream.Close();

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR !\n下载失败。网络出现错误，或者访问的版本号不允许下载索引文件。"
                    , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如果你是初次使用该程序，建议按以下操作步骤进行：" +
                                "\n\n1、在主界面中，点击“版本号切换”按钮" +
                                "\n\n2、在弹出的窗口中依次选择“自动查询最新版本”和“保存并切换”按钮" +
                                "\n\n3、回到主界面，点击“下载索引文件”按钮，并等待下载完成。" +
                                "\n\n完成之后，即可开始使用。",
                    "使用说明", MessageBoxButtons.OK);
        }
    }
}
