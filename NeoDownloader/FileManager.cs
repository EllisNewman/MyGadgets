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
    //静态类，处理所有与文件存取相关的操作。
    //包括url文件和各个版本的索引文件的存取。
    public static class FileManager
    {
        //urls文件不存在时，判定为用户首次使用该程序。新建该文件并预先新建好各个目录。
        public static void CheckVersionFile()
        {
            if (!File.Exists(Define.LocalPath + @"\urls.json"))
            {
                StreamWriter sw = new StreamWriter(Define.LocalPath + @"\urls.json");
                sw.Write("[\n\t\"" + Define.SourceUrl_JP + "46800/pro" + "duction/2017.3/Android/b1cddebec761f474fb499f43896acefaad877404.data\"\n]");
                sw.Close();

                MessageBox.Show("初次使用该程序时，推荐先在主界面中点击“区服&版本号”获取最新版本号。详细内容可在主界面 “使用说明” 中查看。" +
                                "\n\n原downloader的url文件可直接继承，放至本程序所在目录即可。原data目录下的索引文件，需放置在本程序所在目录下index文件夹中，即可使用。",
                    "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!File.Exists(Define.LocalPath + @"\urls_cn.json"))
            {
                StreamWriter sw = new StreamWriter(Define.LocalPath + @"\urls_cn.json");
                sw.Write("[\n\t\"" + Define.SourceUrl_CNT + "1/pro" + "duction/2017v1/Android/4f2cc63f358f7e09fbb158ef28dff6cc4ff0ce4a.data\"\n]");
                sw.Close();
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

        //读取urls.json文件，将里面所有url保存至字典中。
        public static void ReadVersionFile()
        {
            string urlPath = "";
            if(Define.CurrentServer == SERVER_TYPE.JP)
            {
                urlPath = Define.LocalPath + @"\urls.json";
            }
            else if (Define.CurrentServer == SERVER_TYPE.CNT)
            {
                urlPath = Define.LocalPath + @"\urls_cn.json";
            }
            StreamReader srUrlFile = new StreamReader(urlPath);
            string strUrl = System.Text.RegularExpressions.Regex.Replace(srUrlFile.ReadToEnd(), "[\r\n\t]", "");

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<string> urlList = js.Deserialize<List<string>>(strUrl);

            foreach (var url in urlList)
            {
                string strVersion = url.Split('/')[3];
                string strName = url.Split('/')[7];
                int version;
                if (!int.TryParse(strVersion, out version)) continue;

                if (!Define.VersionDic.ContainsKey(version))
                {
                    Define.VersionDic.Add(version, strName);
                }
            }

            srUrlFile.Close();
        }

        //覆盖保存urls.json文件。正常情况下新文件中url的数量总是会大于等于旧文件，因此覆盖不会产生数据丢失。
        //注意：但在切换区服时会清除缓存中的url数据，因此需先使用该函数进行保存，再进行切换，否则会产生数据丢失。
        public static void SaveVersionFile(SERVER_TYPE currentServer)
        {
            Dictionary<int, string> newDic = Define.VersionDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n\t\"");
            foreach (var url in newDic)
            {
                sb.Append(Define.GetSourceUrlByServer() + url.Key + "/production/" + Define.GetUnityVersion(url.Key) +
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
            StreamWriter sw;

            if (Define.CurrentServer == SERVER_TYPE.JP)
            {
                sw = new StreamWriter(Define.LocalPath + @"\urls.json");
                sw.Write(str);
                sw.Close();
            }
            else if (Define.CurrentServer == SERVER_TYPE.CNT)
            {
                sw = new StreamWriter(Define.LocalPath + @"\urls_cn.json");
                sw.Write(str);
                sw.Close();
            }
        }

        //按指定版本路径读取索引文件，将每一条内容存入字典中。
        public static bool ReadIndexFile(string path)
        {
            Define.IndexDic.Clear(); // 首先清理字典
            MsgPack msgpack = new MsgPack();
            FileStream fs = new FileStream(path, FileMode.Open);
            msgpack.DecodeFromStream(fs);
            fs.Close();

            if (msgpack.children.Count != 1)
            {
                return false;
            }
            msgpack = msgpack.children[0];

            foreach (MsgPack item in msgpack.children)
            {
                if (item.children.Count < 3) // 如果小于3则说明发生错误，需重新下载。一种常见原因是文件本身在下载过程中发生缺失。
                    return false;

                IndexInfo info = new IndexInfo
                {
                    name = item.name,
                    identifier = item.children[0].AsString,
                    url = item.children[1].AsString,
                    size = item.children[2].AsString
                };

                Define.IndexDic.Add(info.name, info);
            }

            if (Define.IndexDic.Count > 0)
                Define.IndexDic = Define.IndexDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

            return true;
        }

        //按指定版本路径读取索引文件，将每一条内容存入缓存字典中。目前仅用于版本对比
        public static void ReadIndexCacheFile(string path)
        {
            Define.IndexDicCache.Clear();
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

                Define.IndexDicCache.Add(info.name, info);
            }

            if (Define.IndexDicCache.Count > 0)
                Define.IndexDicCache = Define.IndexDicCache.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
        }
        
    }
}
