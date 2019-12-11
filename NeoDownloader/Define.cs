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
        public static SERVER_TYPE CurrentServer = SERVER_TYPE.JP; // 首选默认为日服
        public static string SourceUrl_JP = "https:/" + "/t" + "d-a" + "ss" + "ets.bn7" + "65.c" + "om/";
        public static string SourceUrl_CNT = "https://d3k5923sb1sy5k.cloudfront.net/";
        public static string IndexPath = @"\index";
        public static string AssetPath = @"\asset";
        public static string IndexName = "";
        public static string UnityVersion = "2017.3";
        public static string LocalPath;
        public static string VersionUpdateTime = "";
        public static int    GameVersion = 1;
        public static Dictionary<int, string> VersionDic = new Dictionary<int, string>();
        public static Dictionary<string, IndexInfo> IndexDic = new Dictionary<string, IndexInfo>();
        public static Dictionary<string, IndexInfo> IndexDicCache = new Dictionary<string, IndexInfo>(); // 目前仅用于版本对比


        // todo : 将来如果某个区服的土豆更新了Unity版本，则需要修改下列函数中对应的数值以进行适配
        public static string GetUnityVersion()
        {
            if (CurrentServer == SERVER_TYPE.JP) // JP
            {
                if (GameVersion > 14580)
                    if (GameVersion > 115990)
                    {
                        return "2018";
                    }
                    else  //  14580和115990之间
                    {
                        return "2017.3";
                    }
                else      //  14580及以前
                {
                    return "5.6";
                }
                
            }
            else return "2017v1"; // CNT。有其他区服时再追加判断（偷懒
        }

        public static string GetUnityVersion(int gameVer)
        {
            if (CurrentServer == SERVER_TYPE.JP)
            {
                return (gameVer > 14580 ? "2017.3" : "5.6");
            }
            else return "2017v1";
        }
        
        public static string GetSourceUrlByServer()
        {
            if(CurrentServer == SERVER_TYPE.JP)
            {
                return SourceUrl_JP;
            }
            else
            {
                return SourceUrl_CNT;
            }    
        }

        public static void ChangeServerTo(SERVER_TYPE latestServer) // 对不同区服使用不同目录管理
        {
            FileManager.SaveVersionFile(CurrentServer);
            VersionDic = new Dictionary<int, string>(); // !

            CurrentServer = latestServer;
            if(CurrentServer == SERVER_TYPE.JP)
            {
                IndexPath = @"\index";
                AssetPath = @"\asset";
            }

            if(CurrentServer == SERVER_TYPE.CNT)
            {
                IndexPath = @"\index_cn";
                AssetPath = @"\asset_cn";
            }
            FileManager.CheckVersionFile();
            FileManager.ReadVersionFile();
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
                return GetSourceUrlByServer() + GameVersion + "/production/" + GetUnityVersion() + "/Android/" + IndexDic[name].url;
            }
            return null;
        }

        /// <summary>
        /// 获取当前版本索引文件的下载链接
        /// </summary>
        /// <returns></returns>
        public static string GetIndexUrl()
        {
           return GetSourceUrlByServer() + GameVersion + "/production/" + GetUnityVersion() + "/Android/" + IndexName;
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

    /// <summary>
    /// 服务器类型。不同服务器将使用不同来源的api。
    /// </summary>
    public enum SERVER_TYPE
    {
        /// <summary>
        /// 日服
        /// </summary>
        JP,
        /// <summary>
        /// 繁中服
        /// </summary>
        CNT
    } // to do : 将来可能支持的韩服KR？
}
