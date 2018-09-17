﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoDownloader
{
    public static class Define
    {
        public const string SourceUrl = "https:/" + "/t" + "d-a" + "ss" + "ets.bn7" + "65.c" + "om/";
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