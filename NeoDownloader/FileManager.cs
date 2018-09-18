using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

                MessageBox.Show("初次使用该程序时，建议在使用之前，先在主界面中点击右上角“使用说明”查看操作流程。" +
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

                Define.IndexList.Add(info);
            }
        }

    }
}
