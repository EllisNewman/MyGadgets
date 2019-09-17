using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

namespace NeoDownloader
{
    public partial class GameVersionChange : Form
    {
        private Res cacheVersionInfo;
        private delegate void SetTextCallBack(string text);
        private Thread checkLatestThread;
        private Thread checkInputThread;
        private SERVER_TYPE chosenServer;

        public GameVersionChange()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            chosenServer = Define.CurrentServer;

            switch (Define.CurrentServer)
            {
                case SERVER_TYPE.JP:
                {
                    radioBtnJP.Checked = true;
                    radioBtnCNT.Checked = false;
                    return;
                }
                case SERVER_TYPE.CNT:
                {
                    radioBtnJP.Checked = false;
                    radioBtnCNT.Checked = true;
                    return;
                }
            }
        }

        private void btnLatest_Click(object sender, EventArgs e)
        {
            if (checkLatestThread == null && checkInputThread == null)
            {
                checkLatestThread = new Thread(CheckLatest);
                checkLatestThread.Start();
            }
        }

        private void CheckLatest()
        {
            SetResultText("正在查询...");
            string result = "";

            if (chosenServer == SERVER_TYPE.JP) // 查询日服
            {
                result = GetWebRequest("https://api.matsurihi.me/mltd/v1/version/latest");

                if (isResultError(result))
                {
                    SetResultText("查询错误！");
                    return;
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                LatestVersionInfo info = js.Deserialize<LatestVersionInfo>(result);

                cacheVersionInfo = info.res;
                SetResultText("更新成功！" +
                                   "\n现在的最新版本是：" + info.res.version +
                                   "\n更新时间是：" + info.res.updateTime);

                checkLatestThread = null;
            }
            else if(chosenServer == SERVER_TYPE.CNT) // 查询繁中服
            {
                result = GetWebRequest("https://redive.estertion.win/db/mltd/current.json");
                
                if (isResultError(result))
                {
                    SetResultText("查询错误！");
                    return;
                }
                
                JavaScriptSerializer js = new JavaScriptSerializer();
                Res_CNT info = js.Deserialize<Res_CNT>(result);

                cacheVersionInfo = new Res();
                cacheVersionInfo.indexName = info.asset_index_name;
                cacheVersionInfo.updateTime = info.update_time;
                cacheVersionInfo.version = info.asset_version;

                SetResultText("更新成功！" +
                                   "\n现在的最新版本是：" + info.asset_version +
                                   "\n更新时间是：" + info.update_time);

                checkLatestThread = null;
            }
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            string input = txtBoxGameVersion.Text;
            if (input == "")
                return;

            if (checkLatestThread == null && checkInputThread == null)
            {
                checkInputThread = new Thread((ob) => {CheckInput(ob as string);});
                checkInputThread.Start(input);
            }

        }

        private void CheckInput(string input)
        {
            SetResultText("正在查询...");

            if (chosenServer == SERVER_TYPE.JP) // 查询日服
            {
                string result = GetWebRequest("https://api.matsurihi.me/mltd/v1/version/assets/" + input);

                if (isResultError(result))
                {
                    SetResultText("查询错误！\n不存在该版本号");
                    return;
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Res info = js.Deserialize<Res>(result);

                cacheVersionInfo = info;
                SetResultText("查询成功！" +
                                   "\n查询版本是：" + info.version +
                                   "\n更新时间是：" + info.updateTime);

                checkInputThread = null;
            }
            else if (chosenServer == SERVER_TYPE.CNT) // 查询繁中服
            {
                string result = GetWebRequest("https://redive.estertion.win/db/mltd/" + input + ".json");

                if (isResultError(result))
                {
                    SetResultText("查询错误！\n不存在该版本号");
                    return;
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                Res_CNT info = js.Deserialize<Res_CNT>(result);

                if (info.asset_version == 0)
                {
                    SetResultText("查询错误！\n不存在该版本号");
                    checkInputThread = null;
                    return;
                }
                
                cacheVersionInfo = new Res();
                cacheVersionInfo.indexName = info.asset_index_name;
                cacheVersionInfo.updateTime = info.update_time;
                cacheVersionInfo.version = info.asset_version;
                SetResultText("查询成功！" +
                                   "\n查询版本是：" + info.asset_version +
                                   "\n更新时间是：" + info.update_time);

                checkInputThread = null;
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cacheVersionInfo == null)
                return;

            Define.GameVersion = cacheVersionInfo.version;
            Define.IndexName = cacheVersionInfo.indexName;
            Define.VersionUpdateTime = cacheVersionInfo.updateTime;
            Define.ChangeServerTo(chosenServer);

            if (!Define.VersionDic.ContainsKey(cacheVersionInfo.version))
            {
                Define.VersionDic.Add(cacheVersionInfo.version, cacheVersionInfo.indexName);
            }

            FileManager.SaveVersionFile(Define.CurrentServer);

            Define.IndexDic.Clear();
            Close();

        }

        void SetResultText(string text)
        {
            if (this.labelResult.InvokeRequired)
            {
                SetTextCallBack call = new SetTextCallBack(SetResultText); // 来自MSDN文档，递归思想
                this.Invoke(call, new object[] { text });
            }
            else
            {
                this.labelResult.Text = text;
            }
        }

        private bool isResultError(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                return true;
            }

            int index = result.Split(':')[0].IndexOf("error");
            if (index < 0) // 小于0表示无error，大于等于0表示含error
            {
                return false;
            }

            return true;
        }

        private string GetWebRequest(string url)
        {
            string strResult = "";
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            try
            {
                Uri uri = new Uri(url);
                WebRequest myReq = WebRequest.Create(uri);
                WebResponse webResult = myReq.GetResponse();
                Stream receviceStream = webResult.GetResponseStream();
                StreamReader readerOfStream = new StreamReader(receviceStream, Encoding.GetEncoding("utf-8"));

                strResult = readerOfStream.ReadToEnd();
                strResult = System.Text.RegularExpressions.Regex.Replace(strResult, "[\r\n\t]", "");
                readerOfStream.Close();
                receviceStream.Close();
                webResult.Close();
            }
            catch (WebException)
            {
                checkInputThread = null;
                checkLatestThread = null;
                MessageBox.Show("ERROR !\n查询失败。网络出现错误，或者查询的对象不存在。"
                    , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return strResult;
        }

        #region json解析用
        public class App
        {
            public string version { get; set; }
            public string updateTime { get; set; }
            public int revision { get; set; }
            public string versionHash { get; set; }
        }

        public class Res
        {
            public int version { get; set; }
            public string updateTime { get; set; }
            public string indexName { get; set; }
        }

        public class LatestVersionInfo
        {
            // app、res均为json解析格式要求所命名
            public App app { get; set; }
            public Res res { get; set; }
        }

        public class Res_CNT
        {
            public int asset_version { get; set; }
            public string update_time { get; set; }
            public string asset_index_name { get; set; }
        }

        public class VersionInfo
        {
            public int version { get; set; }
            public string updateTime { get; set; }
            public string indexName { get; set; }
        }


        #endregion

        private void radioBtnJP_CheckedChanged(object sender, EventArgs e)
        {
            if(radioBtnJP.Checked)
            {
                chosenServer = SERVER_TYPE.JP;
            }
        }

        private void radioBtnCNT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCNT.Checked)
            {
                chosenServer = SERVER_TYPE.CNT;
            }
        }
    }
}
