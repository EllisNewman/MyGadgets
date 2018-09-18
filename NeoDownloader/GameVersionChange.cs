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
using System.Web.Script.Serialization;

namespace NeoDownloader
{
    public partial class GameVersionChange : Form
    {
        private Res cacheVersionInfo;

        public GameVersionChange()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
        }

        private void btnLatest_Click(object sender, EventArgs e)
        {
            labelResult.Text = "正在查询...";
            string result = GetWebRequest("https://api.matsurihi.me/mltd/v1/version/latest");

            if (isResultError(result))
            {
                labelResult.Text = "查询错误！";
                return;
            }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            LatestVersionInfo info = js.Deserialize<LatestVersionInfo>(result);

            cacheVersionInfo = info.res;
            labelResult.Text = "更新成功！" +
                               "\n现在的最新版本是：" + info.res.version +
                               "\n更新时间是：" + info.res.updateTime;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string input = txtBoxGameVersion.Text;
            if (input == "")
                return;

            labelResult.Text = "正在查询...";
            string result = GetWebRequest("https://api.matsurihi.me/mltd/v1/version/assets/" + input);

            if (isResultError(result))
            {
                labelResult.Text = "查询错误！\n不存在该版本号";
                return;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Res info = js.Deserialize<Res>(result);

            cacheVersionInfo = info;
            labelResult.Text = "查询成功！" +
                               "\n查询版本是：" + info.version +
                               "\n更新时间是：" + info.updateTime;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cacheVersionInfo == null)
                return;

            Define.GameVersion = cacheVersionInfo.version;
            Define.IndexName = cacheVersionInfo.indexName;

            if (!Define.VersionDic.ContainsKey(cacheVersionInfo.version))
            {
                Define.VersionDic.Add(cacheVersionInfo.version, cacheVersionInfo.indexName);
            }

            FileManager.SaveVersionFile();

            Close();
            Define.IndexDic.Clear();
        }

        private bool isResultError(string result)
        {
            if (string.IsNullOrEmpty(result))
                return true;

            result = result.Split(':')[0];
            int index = result.IndexOf("error");

            if (index < 0) // 小于0表示无error，大于等于0表示含error
            {
                return false;
            }

            return true;
        }

        private static string GetWebRequest(string url)
        {
            string strResult = "";

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
                MessageBox.Show("ERROR !\n查询失败。网络出现错误，或者查询的对象不存在。"
                    , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return strResult;
        }

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
            public App app { get; set; }
            public Res res { get; set; }
        }

        public class VersionInfo
        {
            public int version { get; set; }
            public string updateTime { get; set; }
            public string indexName { get; set; }
        }
    }
}
