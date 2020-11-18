using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            labelVersionTime.Text = "";
            labelMultiProgress.Text = "";
            btnCancelDownload.Visible = false;

            if (Define.VersionDic.Count > 0) // 每次启动时自动打开最新版本
            {
                Define.GameVersion = Define.VersionDic.Last().Key;
                Define.IndexName = Define.VersionDic.Last().Value;
            }
        }

        #region 按钮操作

        private void btnGameVersionChange_Click(object sender, EventArgs e)
        {
            if (IndexDownloadWorker.IsBusy || AssetDowloadWorker.IsBusy)
            {
                MessageBox.Show("正在下载文件，不能进行其他操作。", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            GameVersionChange dialogVersionChange = new GameVersionChange();
            dialogVersionChange.ShowDialog();
        }

        private void btnIndexDownload_Click(object sender, EventArgs e)
        {
            if (IndexDownloadWorker.IsBusy || AssetDowloadWorker.IsBusy)
            {
                MessageBox.Show("正在下载文件，不能进行其他操作。", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            btnAssetDownLoad.Visible = false;
            btnCancelDownload.Visible = true;

            labelDownLoadInfo.Text = "正在下载索引文件，这需要数秒至数分钟的时间...期间请勿退出程序";
            IndexDownloadWorker.RunWorkerAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string input = txtBoxSearch.Text;
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            if (Define.IndexDic.Count == 0)
            {
                DialogResult dr = MessageBox.Show("尚未获取该版本的索引文件。是否立即进行下载？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    btnIndexDownload_Click(null, null);
                }
                return;
            }

            listBoxResult.Items.Clear();
            foreach (var info in Define.IndexDic)
            {
                if (info.Value.name.IndexOf(input) >= 0)
                {
                    listBoxResult.Items.Add(info.Value.name);
                }
            }

            if (listBoxResult.Items.Count == 0)
            {
                MessageBox.Show("未找到符合关键字的文件。", "查找结果", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.Show();
        }

        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            if (IndexDownloadWorker.IsBusy)
            {
                IndexDownloadWorker.CancelAsync();
            } 
            
            if (AssetDowloadWorker.IsBusy)
            {
                AssetDowloadWorker.CancelAsync();
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (IndexDownloadWorker.IsBusy || AssetDowloadWorker.IsBusy)
            {
                MessageBox.Show("正在下载文件，不能进行其他操作。", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (listBoxResult.SelectedItems.Count < 1)
            {
                labelDownLoadInfo.Text = "尚未选择要下载的资源。\n通过检索关键字或版本对比功能展示资源列表，" +
                                         "点击选择某项或多项资源，再从此处开始下载。";
                return;
            }

            btnAssetDownLoad.Visible = false;
            btnCancelDownload.Visible = true;

            StringBuilder sb = new StringBuilder("开始下载：");
            List<string> selectedNames = new List<string>();

            foreach (var item in listBoxResult.SelectedItems)
            {
                string name = item.ToString();
                if (name.IndexOf(":") >= 0) // 这里假定要下载的资源名里一定不会出现英文冒号这个符号。但愿土豆程序员不会搞我。
                {
                    if (name.Split(':')[0].Equals("Delete "))
                    {
                        continue;  // 当前版本已被移除的资源仅供显示用，不加入下载列表，不进行下载
                    }
                    name = name.Split(':')[1];
                }
                selectedNames.Add(name);
            }
            if (selectedNames.Count == 0)
            {
                labelDownLoadInfo.Text = "未选择下载项或选择了已被移除的资源。";
                return;
            }

            if (selectedNames.Count == 1)
            {
                float size = int.Parse(Define.IndexDic[selectedNames[0]].size);
                sb.Append(selectedNames[0] + ", 文件大小: " + Math.Round(size/1024,2) + "kb. ");
            }
            else
            {
                string str;
                float size = 0;
                foreach (var name in selectedNames)
                {
                    size = size + int.Parse(Define.IndexDic[name].size);
                }
                if (size > 1024)
                {
                    size = size/1024;
                    str = "kb";
                    if (size > 1024)
                    {
                        size = size/1024;
                        str = "mb";
                    }
                }
                else
                {
                    str = "byte";
                }
                sb.Append(selectedNames[0] + "等" + selectedNames.Count + "个文件, 合计大小: " + Math.Round(size,2) + str + ". ");
            }
            labelDownLoadInfo.Text = sb.ToString();

            AssetDowloadWorker.RunWorkerAsync(selectedNames);

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
            FileManager.ReadVersionFile();

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
                                              "内容改动对比", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                listBoxResult.Items.Clear();
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
                    else // 原版本中未包含该key，则是新增资源
                    {
                        listBoxResult.Items.Add("Add :" + info.Value.name);
                    }
                    //此处未考虑旧版本存在Key而新版本不存在的逻辑。从实际情况看，土豆目前没有清理旧版本资源的先例，因此尚无该需求。
                }
            }
        }

        private void btnCheckName_Click(object sender, EventArgs e)
        {
            FileManager.ReadVersionFile();

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
            }

            if (!isCheckReady(lastVersion, curVersion))
            {
                return;
            }

            DialogResult dr = MessageBox.Show("将进行文件名称对比" +
                                              "\n\n\t当前版本：" + curVersion +
                                              "\n\n\t前个版本：" + lastVersion +
                                              "\n\n是否确定？" +
                                              "\n\n用于版本更新时，检查并显示新版本修改的文件。" +
                                              "\n\n与“改动对比”的区别在于不会检测文件大小，只检查文件名称" +
                                              "\n\n两个版本之间的" +
                                              "差距不宜过大。建议两个版本号之间数字差距不超过500。",
                                              "文件名称对比", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                listBoxResult.Items.Clear();
                FileManager.ReadIndexCacheFile(Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[lastVersion]);

                foreach (var info in Define.IndexDic)
                {
                    if (Define.IndexDicCache.ContainsKey(info.Key))
                    {
                        continue; //未发生改变
                    }
                    else // 原版本中未包含该key，则是新增资源
                    {
                        listBoxResult.Items.Add("Add :" + info.Value.name);
                    }
                }

                foreach (var info in Define.IndexDicCache)
                {
                    if (Define.IndexDic.ContainsKey(info.Key))
                    {
                        continue; //未发生改变
                    }
                    else // 原版本中的key丢失，则是资源被删除
                    {
                        listBoxResult.Items.Add("Delete :" + info.Value.name);
                    }
                }
            }
        }


        #endregion

        #region UI操作

        private void RefreshPanel(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Define.VersionUpdateTime))
            {
                labelVersionTime.Text = "版本更新时间：" + Define.VersionUpdateTime;
            }

            // to do : 这里逻辑有些乱，有待改进
            if (Define.IndexDic.Count == 0)
            {
                ResetPanel();
            }

            if (labelGameVersion.Text == Define.GameVersion.ToString())
            {
                return;
            }

            ResetPanel();
        }

        private void ResetPanel()
        {
            listBoxResult.Items.Clear();
            labelGameVersion.Text = Define.GameVersion.ToString();
            if (Define.CurrentServer == SERVER_TYPE.JP)
            {
                labelLanguage.Text = "日服";
            }
            else if (Define.CurrentServer == SERVER_TYPE.CNT)
            {
                labelLanguage.Text = "繁中服";
            }

            string indexPath = Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[Define.GameVersion];
            if (File.Exists(indexPath))
            {
                if (!IndexDownloadWorker.IsBusy && !AssetDowloadWorker.IsBusy && !FileManager.ReadIndexFile(indexPath) )
                {
                    //弹出对话框导致原窗口失焦，文件损坏时易产生无限循环弹窗的bug，因此先弃用该对话框。
                    //MessageBox.Show("索引文件读取发生异常。\n\n该错误由当前版本的索引文件引起，可能是文件下载过程中由于网络" +
                    //                "原因导致文件损坏而产生。\n重新下载索引文件或许能解决该问题。如果该问题依然存在，请联系开发者。",
                    //    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    labelDownLoadInfo.Text = "索引文件读取发生异常。可能是读取过程出错，或在下载过程中损坏。\n" +
                                             "尝试重启程序或重新下载索引文件。";

                    return;
                }
                labelIndex.Text = "就绪";
                labelDownLoadInfo.Text = "索引文件就绪。";
            }
            else
            {
                labelIndex.Text = "未就绪";
                labelDownLoadInfo.Text = "每个版本需要对应的索引文件以查找资源。\n点击上方“下载索引文件”按钮以获取。";
            }
        }

        #endregion

        #region 其他方法

        private bool isCheckReady(int lastVersion, int curVersion)
        {
            if (curVersion == 1)
            {
                MessageBox.Show("已是最早版本，不需要对比。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (lastVersion == 0)
            {
                MessageBox.Show("已是本地检测到的最早版本。\n\n" +
                                "需通过版本查询功能找到前个版本，并下载索引文件，然后进行版本对比。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string lastVersionPath = Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[lastVersion];
            string curVersionPath = Define.LocalPath + Define.IndexPath + @"\" + Define.VersionDic[curVersion];

            if (!File.Exists(lastVersionPath))
            {
                MessageBox.Show("未在本地检测到前个版本: " + lastVersion + " 的索引。\n\n" +
                                "需先切换至前个版本，并下载索引文件，然后进行版本对比。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!File.Exists(curVersionPath))
            {
                MessageBox.Show("未在本地检测到当前版本: " + curVersion + " 的索引。\n\n" +
                                "需先下载当前版本的索引文件，然后进行版本对比。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;

        }

        #endregion



        private void IndexDownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Define.GetIndexUrl());
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Stream fileStream = new FileStream(Define.GetFullIndexPath(), FileMode.Create);

            long countSize = 0;
            long originSize = response.ContentLength / 100;
            byte[] bArr = new byte[10000];
            int size = responseStream.Read(bArr, 0, bArr.Length);

            while (size > 0)
            {
                if (IndexDownloadWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                fileStream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, bArr.Length);

                countSize = countSize + size;
                long result = countSize/originSize;
                IndexDownloadWorker.ReportProgress((int)result);
            }

            fileStream.Close();
            responseStream.Close();
            IndexDownloadWorker.ReportProgress(100);

            if (e.Cancel)
            {
                IndexDownloadWorker.ReportProgress(0);
                File.Delete(Define.GetFullIndexPath());
            }

        }

        private void IndexDownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressDownload.Value = e.ProgressPercentage;
        }

        private void IndexDownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAssetDownLoad.Visible = true;
            btnCancelDownload.Visible = false;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("CANCELLED. \n取消索引文件下载。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("SUCCEED !\n索引文件下载完成。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            labelDownLoadInfo.Text = "";
            ResetPanel();
            progressDownload.Value = 0;
        }


        private string assetProgress;
        private void AssetDowloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> nameList;
            nameList = (List<string>)e.Argument;
            if (!Directory.Exists(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion))
            {
                Directory.CreateDirectory(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion);
            }
            int total = nameList.Count;
            int progress = 0;
            long currntSize = 0;
            long totalSize = 0;
            assetProgress = total > 1 ? "已完成：0/" + total : "";

            foreach (var name in nameList)
            {
                totalSize += long.Parse(Define.IndexDic[name].size);
            }
            totalSize = totalSize / 100;

            foreach (var name in nameList)
            {
                if (e.Cancel)
                {
                    return;
                }

                string fullPathName = Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion + "/" + name;
                string url = Define.GetAssetUrl(name);
                
                ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                Stream stream = new FileStream(fullPathName, FileMode.Create);
                    
                byte[] bArr = new byte[10000];
                int size = responseStream.Read(bArr, 0, bArr.Length);

                while (size > 0)
                {
                    if (AssetDowloadWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, bArr.Length);

                    currntSize = currntSize + size;
                    long result = currntSize / totalSize;
                    AssetDowloadWorker.ReportProgress((int)result);
                }

                stream.Dispose();
                responseStream.Dispose();

                if (e.Cancel)
                {
                    File.Delete(fullPathName); // 下载到一半的文件无法使用，需作删除处理
                    assetProgress = "";
                    AssetDowloadWorker.ReportProgress(0);
                }
                else
                {
                    progress = progress + 1;
                    assetProgress = total > 1 ? "已完成：" + progress + "/" + total : "";
                }
            }
        }

        private void AssetDowloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressDownload.Value = e.ProgressPercentage;
            if (assetProgress != "")
            {
                labelMultiProgress.Text = assetProgress;
            }
        }

        private void AssetDowloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAssetDownLoad.Visible = true;
            btnCancelDownload.Visible = false;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                labelDownLoadInfo.Text = "取消文件下载。";
            }
            else
            {
                MessageBox.Show("SUCCEED !\n所选文件下载完成。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelDownLoadInfo.Text = "下载完成！";
            }
            labelMultiProgress.Text = "";
            progressDownload.Value = 0;
        }
    }
}
