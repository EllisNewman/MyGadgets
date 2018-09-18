using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SimpleMsgPack;

namespace NeoDownloader
{
    public static class FileManager
    {
        public static void CheckVersionFile()
        {
            if (!File.Exists(Define.LocalPath + @"\urls.json"))
            {
                StreamWriter sw = new StreamWriter(Define.LocalPath + @"\urls.json");
                sw.Write("[\n\t\"ht" + "tps://t" + "d-as" + "sets.bn7" + "65.c" + "om/1/pro" + "duction/5.6/Android/6b976a4c875a1984592a66b621872ce44c944e72.data\"\n]");
                sw.Close();

                MessageBox.Show("初次使用该程序时，需要先在主界面中点击“版本号切换”获取最新版本号。详细内容可在主界面中点击右上角“使用说明”查看。" +
                                "\n\n原downloader的urls.json文件可直接继承，放至本程序所在目录即可。原data目录下的索引文件，则需在本程序所在目录下新建index文件夹并放置进去，即可使用。" +
                                "\n\n各种查询、下载过程中程序未响应是正常现象，持续时间由网速决定。（甩锅）",
                    "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!Directory.Exists(Define.LocalPath + Define.IndexPath))
            {
                Directory.CreateDirectory(Define.LocalPath + Define.IndexPath);
            }

            if (!Directory.Exists(Define.LocalPath + Define.AssetPath))
            {
                Directory.CreateDirectory(Define.LocalPath + Define.AssetPath);
            }
        }

        public static void ReadVersionFile()
        {
            StreamReader sr = new StreamReader(Define.LocalPath + @"\urls.json");
            string str = sr.ReadToEnd();
            str = System.Text.RegularExpressions.Regex.Replace(str, "[\r\n\t]", "");


            JavaScriptSerializer js = new JavaScriptSerializer();
            List<string> urlList = js.Deserialize<List<string>>(str);

            foreach (var url in urlList)
            {
                string strVersion = url.Split('/')[3];
                string strName = url.Split('/')[7];
                int version;
                int.TryParse(strVersion, out version);
                if (!Define.VersionDic.ContainsKey(version))
                {
                    Define.VersionDic.Add(version, strName);
                }
            }

            sr.Close();
        }

        public static void SaveVersionFile()
        {
            Dictionary<int, string> newDic = Define.VersionDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n\t\"");
            foreach (var url in newDic)
            {
                sb.Append("ht" + "tps://t" + "d-ass" + "ets.b" + "n" + "7" + "65.c" + "om/" + url.Key + "/production/" + (url.Key > 14575 ? 2017.3 : 5.6) +
                          "/Android/" + url.Value + "\"");

                if (url.Key != newDic.Last().Key)
                {
                    sb.Append(",\n\t\"");
                }
                else
                {
                    sb.Append("\n]");
                }
            }

            string str = sb.ToString();
            StreamWriter sw = new StreamWriter(Define.LocalPath + @"\urls.json");
            sw.Write(str);
            sw.Close();
        }

        public static void ReadIndexFile(string path)
        {
            Define.IndexDic.Clear();
            MsgPack msgpack = new MsgPack();
            FileStream fs = new FileStream(path, FileMode.Open);
            msgpack.DecodeFromStream(fs);
            fs.Close();

            if (msgpack.children.Count == 1)
                msgpack = msgpack.children[0];

            for (int i = 0; i < msgpack.children.Count; i++)
            {
                IndexInfo info = new IndexInfo();
                MsgPack item = msgpack.children[i];

                info.name = item.name;
                info.identifier = item.children[0].AsString;
                info.url = item.children[1].AsString;
                info.size = item.children[2].AsString;

                Define.IndexDic.Add(info.name, info);
            }

            if (Define.IndexDic.Count > 0)
                Define.IndexDic = Define.IndexDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
        }

        public static bool DownloadIndex()
        {
            string url = "ht" + "tps:/" + "/td-a" + "ssets.b" + "n" + "76" + "5.com/" + Define.GameVersion + "/production/" + (Define.GameVersion > 14580 ? 2017.3 : 5.6) + "/Android/" + Define.IndexName;
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
                MessageBox.Show("ERROR !\n下载失败。网络出现错误，或者访问的版本号不允许下载索引文件。" +
                                "\n\n注意！\t如果下载较长时间后出现该提示，则有可能是下载过程被中断。" +
                                "\n建议打开index文件夹进行检查。正常的索引文件大小会在1MB以上。如果存在某一文件只" +
                                "有几百kb大小，请将其删除，否则可能会导致本程序发生异常，报错并崩溃。"
                    , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public static bool DownLoadAsset(string assetName, string urlName)
        {
            if (!Directory.Exists(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion))
            {
                Directory.CreateDirectory(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion);
            }

            string url = "ht" + "tps:/" + "/td-a" + "ssets.b" + "n" + "76" + "5.com/" + Define.GameVersion + "/production/" + (Define.GameVersion > 14580 ? 2017.3 : 5.6) + "/Android/" + urlName;
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                Stream stream = new FileStream(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion + "/" + assetName, FileMode.Create);
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

    }
}
