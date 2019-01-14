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
    //包括urls.json文件和各个版本的索引文件的存取。
    public static class FileManager
    {
        //urls.json文件不存在时，判定为用户首次使用该程序。新建该文件并预先新建好各个目录。
        public static void CheckVersionFile()
        {
            if (!File.Exists(Define.LocalPath + @"\urls.json"))
            {
                StreamWriter sw = new StreamWriter(Define.LocalPath + @"\urls.json");
                sw.Write("[\n\t\"" + Define.SourceUrl + "46800/pro" + "duction/2017.3/Android/b1cddebec761f474fb499f43896acefaad877404.data\"\n]");
                sw.Close();

                MessageBox.Show("初次使用该程序时，需要先在主界面中点击“版本号切换”获取最新版本号。详细内容可在主界面中点击右上角“使用说明”查看。" +
                                "\n\n原downloader的urls.json文件可直接继承，放至本程序所在目录即可。原data目录下的索引文件，需放置在本程序所在目录下index文件夹中，即可使用。",
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

        //读取urls.json文件，将里面所有url保存至字典中。
        public static void ReadVersionFile()
        {
            StreamReader srUrlFile = new StreamReader(Define.LocalPath + @"\urls.json");
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
        public static void SaveVersionFile()
        {
            Dictionary<int, string> newDic = Define.VersionDic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n\t\"");
            foreach (var url in newDic)
            {
                sb.Append(Define.SourceUrl + url.Key + "/production/" + Define.GetUnityVersion(url.Key) +
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

        //按照当前游戏版本查询对应索引文件并下载。废弃。
        //public static bool DownloadIndex()
        //{
        //    string url = "ht" + "tps:/" + "/td-a" + "ssets.b" + "n" + "76" + "5.com/" + Define.GameVersion + "/production/" + (Define.GameVersion > 14580 ? 2017.3 : 5.6) + "/Android/" + Define.IndexName;
        //    ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        Stream responseStream = response.GetResponseStream();
        //        Stream stream = new FileStream(Define.LocalPath + Define.IndexPath + "/" + Define.IndexName, FileMode.Create);
        //        byte[] bArr = new byte[4096];
        //        int size = responseStream.Read(bArr, 0, bArr.Length);
        //        while (size > 0)
        //        {
        //            stream.Write(bArr, 0, size);
        //            size = responseStream.Read(bArr, 0, bArr.Length);
        //        }
        //        stream.Close();
        //        responseStream.Close();

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("ERROR !\n下载失败。网络出现错误，或者访问的版本号不允许下载索引文件。" +
        //                        "\n\n注意！\t如果下载较长时间后出现该提示，则有可能是下载过程被中断。" +
        //                        "\n建议打开index文件夹进行检查。正常的索引文件大小会在1MB以上。如果存在某一文件只" +
        //                        "有几百kb大小，请将其删除，否则可能会导致本程序发生异常，报错并崩溃。"
        //            , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    return false;
        //}

        //根据传入的素材名和对应url下载该素材，并保存至对应版本的目录。


        //public static bool DownLoadAsset(string assetName, string urlName)
        //{
        //    if (!Directory.Exists(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion))
        //    {
        //        Directory.CreateDirectory(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion);
        //    }

        //    string url = "ht" + "tps:/" + "/td-a" + "ssets.b" + "n" + "76" + "5.com/" + Define.GameVersion + "/production/" + (Define.GameVersion > 14580 ? 2017.3 : 5.6) + "/Android/" + urlName;
        //    ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        Stream responseStream = response.GetResponseStream();
        //        Stream stream = new FileStream(Define.LocalPath + Define.AssetPath + "/" + Define.GameVersion + "/" + assetName, FileMode.Create);
        //        byte[] bArr = new byte[4096];
        //        int size = responseStream.Read(bArr, 0, bArr.Length);
        //        while (size > 0)
        //        {
        //            stream.Write(bArr, 0, size);
        //            size = responseStream.Read(bArr, 0, bArr.Length);
        //        }
        //        stream.Close();
        //        responseStream.Close();

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("ERROR !\n下载失败。网络出现错误，或者访问的版本号不允许下载索引文件。"
        //            , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    return false;
        //}

    }
}
