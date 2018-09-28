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

        public static string GetTargetUrl(string itemName)
        {
            return SourceUrl + GameVersion + "/production/" + UnityVersion + "/Android/" + itemName;
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
