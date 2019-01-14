using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoDownloader
{
    //各类基础内容的定义。
    public static class Define
    {
        public const string SourceUrl = "https:/" + "/t" + "d-a" + "ss" + "ets.bn7" + "65.c" + "om/";
        public const string IndexPath = @"\index";
        public const string AssetPath = @"\asset";
        public static int GameVersion = 1;
        public static string IndexName = "";
        public static string UnityVersion = "2017.3";
        public static string LocalPath;
        public static string VersionUpdateTime = "";
        public static Dictionary<int, string> VersionDic = new Dictionary<int, string>();
        public static Dictionary<string, IndexInfo> IndexDic = new Dictionary<string, IndexInfo>();
        public static Dictionary<string, IndexInfo> IndexDicCache = new Dictionary<string, IndexInfo>(); // 目前仅用于版本对比


        // todo : 将来如果土豆更新了Unity版本，则需要修改下列几个UnityVersion函数以进行适配
        public static double GetUnityVersion()
        {
            return (GameVersion > 14580 ? 2017.3 : 5.6);
        }

        public static double GetUnityVersion(int gameVer)
        {
            return (gameVer > 14580 ? 2017.3 : 5.6);
        }

        public static double GetUnityVersion(double gameVer)
        {
            return (gameVer > 14580 ? 2017.3 : 5.6);
        }

        /// <summary>
        /// 从IndexDic中查找输入名称对应的资源文件，获取其下载链接
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetAssetUrl(string name)
        {
            if (IndexDic.ContainsKey(name))
            {
                return SourceUrl + GameVersion + "/production/" + GetUnityVersion() + "/Android/" + IndexDic[name].url;
            }
            return null;
        }

        /// <summary>
        /// 获取当前版本索引文件的下载链接
        /// </summary>
        /// <returns></returns>
        public static string GetIndexUrl()
        {
           return SourceUrl + GameVersion + "/production/" + GetUnityVersion() + "/Android/" + IndexName;
        }

        public static string GetFullIndexPath()
        {
            return LocalPath + IndexPath + "/" + IndexName;
        }
    }

    

    /// <summary>
    /// 资源索引中单个资源文件的相关信息
    /// </summary>
    public class IndexInfo
    {
        /// <summary>
        /// 该资源文件的名称
        /// </summary>
        public string name;
        /// <summary>
        /// （可能是用来进行标识的）16进制字符串。目前没有用到。
        /// </summary>
        public string identifier;
        /// <summary>
        /// 该资源文件的url。用于连接服务器下载该资源。
        /// </summary>
        public string url;
        /// <summary>
        /// 该资源文件的大小。单位为byte。同时用于版本对比中检测资源是否发生变化。
        /// </summary>
        public string size;
    }
}
