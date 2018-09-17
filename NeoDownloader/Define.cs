using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoDownloader
{
    public static class Define
    {
        // example: https://td-assets.bn765.com/26125/production/2017.3/Android/a0f3735dd8de5ae6566cc103345659dd1a27dfbc.unity3d";
        // SourceUrl + GameVersion + /production/ + UnityVersion + /Android/ + xxx.unity3d
        public const string SourceUrl = "https://td-assets.bn765.com/";
        public static int GameVersion = 1;
        public static string IndexName = "";
        public static string UnityVersion = "2017.3";
        public static string LocalPath;
        public const string IndexPath = @"\index";
        public const string AssetPath = @"\asset";
        public static Dictionary<int, string> VersionDic = new Dictionary<int, string>(); 

        public static string GetTargetUrl(string itemName)
        {
            return SourceUrl + GameVersion + "/production/" + UnityVersion + "/Android/" + itemName;
        }


    }

}
