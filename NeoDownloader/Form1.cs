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
            this.MaximizeBox = false;
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
            labelDownLoadInfo.Text = "请求下载索引文件，这需要数十秒至数分钟的时间...期间程序可能会无响应，请耐心等待";
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
            About aboutBox = new About();
            aboutBox.Show();
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
            List<string> selectedNames = new List<string>();

            foreach (var item in listBoxResult.SelectedItems)
            {
                string name = item.ToString();
                if (name.IndexOf(":") >= 0) // 这里假定要下载的资源名里一定不会出现英文冒号这个符号。但愿土豆程序员不会搞我。
                {
                    name = name.Split(':')[1];
                }
                selectedNames.Add(name);
                sb.Append(name + ", 大小: " + Define.IndexDic[name].size + "byte. ");
                labelDownLoadInfo.Text = sb.ToString();
            }

            //todo : 两个foreach的实现不好，但又不清楚怎么优化。有待改进。

            foreach (var name in selectedNames)
            {
                FileManager.DownLoadAsset(name, Define.IndexDic[name].url);
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

            int lastVersion = 0;
            int curVersion = Define.GameVersion;
            int[] versions = new int[Define.VersionDic.Count];
            Define.VersionDic.Keys.CopyTo(versions, 0);

            for (int i = 0; i < versions.Length; i++)
            {
                if (curVersion > versions[i])
                {
                    lastVersion = versions[i];
                }
                else if (curVersion <= versions[i])
                {
                    break;
                }
            }

            if (!isCheckReady(lastVersion, curVersion))
            {
                return;
            }
            
            DialogResult dr = MessageBox.Show("将进行版本更新内容对比" +
                                              "\n\n\t当前版本：" + curVersion +
                                              "\n\n\t前个版本：" + lastVersion +
                                              "\n\n是否确定？" +
                                              "\n\n用于版本更新时，检查并显示新版本修改的内容。\n\n两个版本之间的" +
                                              "差距不宜过大。建议两个版本号之间数字差距不超过500。", 
                                              "版本对比", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                FileManager.ReadIndexCacheFile(Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[lastVersion]);
                
                foreach (var info in Define.IndexDic)
                {
                    if (Define.IndexDicCache.ContainsKey(info.Key))
                    {
                        if (Define.IndexDicCache[info.Key].size == info.Value.size)
                        {
                            continue; //size相同，则该资源未发生改变
                        }
                        else // size不同，则发生修改
                        {
                            listBoxResult.Items.Add("Change :" + info.Value.name);
                        }
                    }
                    else
                    {
                        listBoxResult.Items.Add("Add :" + info.Value.name);
                    }
                }
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

        private bool isCheckReady(int lastVersion, int curVersion)
        {
            string lastVersionPath = Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[lastVersion];
            string curVersionPath = Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[curVersion];

            if (!File.Exists(lastVersionPath))
            {
                MessageBox.Show("未在本地检测到前个版本: " + lastVersion +" 的版本号。\n\n" +
                                "需先切换至前个版本，并下载索引文件，然后进行版本对比。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!File.Exists(curVersionPath))
            {
                MessageBox.Show("未在本地检测到当前版本: " + curVersion + " 的版本号。\n\n" +
                                "需先下载当前版本的索引文件，然后进行版本对比。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;

        }
    }
}
