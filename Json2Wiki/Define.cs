using System;
using System.Collections.Generic;

namespace Json2Wiki
{
    public static class Define
    {
        public static void init()
        {
            idolName.Add(1, "天海春香");
            idolType.Add(1, "Princess");

            idolName.Add(2, "如月千早");
            idolType.Add(2, "Fairy");

            idolName.Add(3, "星井美希");
            idolType.Add(3, "Angel");

            idolName.Add(4, "萩原雪歩");
            idolType.Add(4, "Princess");

            idolName.Add(5, "高槻やよい");
            idolType.Add(5, "Angel");

            idolName.Add(6, "菊地真");
            idolType.Add(6, "Princess");

            idolName.Add(7, "水瀬伊織");
            idolType.Add(7, "Fairy");

            idolName.Add(8, "四条貴音");
            idolType.Add(8, "Fairy");

            idolName.Add(9, "秋月律子");
            idolType.Add(9, "Fairy");

            idolName.Add(10, "三浦あずさ");
            idolType.Add(10, "Angel");

            idolName.Add(11, "双海亜美");
            idolType.Add(11, "Angel");

            idolName.Add(12, "双海真美");
            idolType.Add(12, "Angel");

            idolName.Add(13, "我那覇響");
            idolType.Add(13, "Princess");

            idolName.Add(14, "春日未来");
            idolType.Add(14, "Princess");

            idolName.Add(15, "最上静香");
            idolType.Add(15, "Fairy");

            idolName.Add(16, "伊吹翼");
            idolType.Add(16, "Angel");

            idolName.Add(17, "田中琴葉");
            idolType.Add(17, "Princess");

            idolName.Add(18, "島原エレナ");
            idolType.Add(18, "Angel");

            idolName.Add(19, "佐竹美奈子");
            idolType.Add(19, "Princess");

            idolName.Add(20, "所恵美");
            idolType.Add(20, "Fairy");

            idolName.Add(21, "徳川まつり");
            idolType.Add(21, "Princess");

            idolName.Add(22, "箱崎星梨花");
            idolType.Add(22, "Angel");

            idolName.Add(23, "野々原茜");
            idolType.Add(23, "Angel");

            idolName.Add(24, "望月杏奈");
            idolType.Add(24, "Angel");

            idolName.Add(25, "ロコ");
            idolType.Add(25, "Fairy");

            idolName.Add(26, "七尾百合子");
            idolType.Add(26, "Princess");

            idolName.Add(27, "高山紗代子");
            idolType.Add(27, "Princess");

            idolName.Add(28, "松田亜利沙");
            idolType.Add(28, "Princess");

            idolName.Add(29, "高坂海美");
            idolType.Add(29, "Princess");

            idolName.Add(30, "中谷育");
            idolType.Add(30, "Princess");

            idolName.Add(31, "天空橋朋花");
            idolType.Add(31, "Fairy");

            idolName.Add(32, "エミリー");
            idolType.Add(32, "Princess");

            idolName.Add(33, "北沢志保");
            idolType.Add(33, "Fairy");

            idolName.Add(34, "舞浜歩");
            idolType.Add(34, "Fairy");

            idolName.Add(35, "木下ひなた");
            idolType.Add(35, "Angel");

            idolName.Add(36, "矢吹可奈");
            idolType.Add(36, "Princess");

            idolName.Add(37, "横山奈緒");
            idolType.Add(37, "Princess");

            idolName.Add(38, "二階堂千鶴");
            idolType.Add(38, "Fairy");

            idolName.Add(39, "馬場このみ");
            idolType.Add(39, "Angel");

            idolName.Add(40, "大神環");
            idolType.Add(40, "Angel");

            idolName.Add(41, "豊川風花");
            idolType.Add(41, "Angel");

            idolName.Add(42, "宮尾美也");
            idolType.Add(42, "Angel");

            idolName.Add(43, "福田のり子");
            idolType.Add(43, "Princess");

            idolName.Add(44, "真壁瑞希");
            idolType.Add(44, "Fairy");

            idolName.Add(45, "篠宮可憐");
            idolType.Add(45, "Angel");

            idolName.Add(46, "百瀬莉緒");
            idolType.Add(46, "Fairy");

            idolName.Add(47, "永吉昴");
            idolType.Add(47, "Fairy");

            idolName.Add(48, "北上麗花");
            idolType.Add(48, "Angel");

            idolName.Add(49, "周防桃子");
            idolType.Add(49, "Fairy");

            idolName.Add(50, "ジュリア");
            idolType.Add(50, "Fairy");

            idolName.Add(51, "白石紬");
            idolType.Add(51, "Fairy");

            idolName.Add(52, "桜守歌織");
            idolType.Add(52, "Angel");

            idolName.Add(201, "詩花");
            idolType.Add(201, "Ex");

            idolRarity.Add(1, "N");
            idolRarity.Add(2, "R");
            idolRarity.Add(3, "SR");
            idolRarity.Add(4, "SSR");
        }

        public static int GetLifeByRarity(int rarity)
        {
            int life;
            switch (rarity)
            { 
                case 1: life = 25; break;
                case 2: life = 30; break;
                case 3: life = 35; break;
                case 4: life = 40; break;
                default:life = 25; break;
            }
            return life;
        }

        public static Dictionary<int, string> idolName   = new Dictionary<int, string>();
        public static Dictionary<int, string> idolType   = new Dictionary<int, string>();
        public static Dictionary<int, string> idolRarity = new Dictionary<int, string>();
 
    }

}
