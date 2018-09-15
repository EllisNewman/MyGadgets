using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace testJsonAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Define.init();
            Console.WriteLine("输入id号查询对应卡片信息并转换为wiki语言格式。输入0则退出。");

            while (true)
            {
                Console.WriteLine("输入要查询的卡片的id：");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    break;
                }

                string result = GetWebRequest("http" + "s://a" + "pi.mat" + "suri" + "hi.me/ml" + "td/v" + "1/c" + "ards/" + input);

                if (result == "[]")
                {
                    Console.WriteLine("查询错误");
                }
                else
                {
                    result = GetString(GetCardInfo(result));
                    Console.WriteLine();
                    Console.WriteLine(result);
                }
                Console.WriteLine();
            }
        }

        private static string GetWebRequest(string url)
        {
            Uri uri = new Uri(url);
            WebRequest myReq = WebRequest.Create(uri);
            WebResponse result = myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, Encoding.GetEncoding("utf-8"));
            
            string strHTML = readerOfStream.ReadToEnd();

            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }

        static string GetString(CardInfo info)
        {
            string origin =
                "{{CardData" +
                " | CardName = " + info.cardName +
                " | CardNameCN = " +
                " | Rarity = " + info.rarity +
                " | Type = " + info.idolType +
                " | CharaName = " + info.charaName +
                " | Li1 = " + info.life + " | Vo1 = " + info.vo1 + " | Da1 = " + info.da1 + " | Vi1 = " + info.vi1 +
                " | Li2 = " + info.life + " | Vo2 = " + info.vo2 + " | Da2 = " + info.da2 + " | Vi2 = " + info.vi2 +
                " | Li3 = " + info.life + " | Vo3 = " + info.vo3 + " | Da3 = " + info.da3 + " | Vi3 = " + info.vi3 +
                " | LeaderSkillName = " + info.leaderSkillName +
                " | LeaderSkillNameCN = " +
                " | LeaderSkill = " + info.leaderSkill +
                " | LeaderSkillCN = " +
                " | CardSkillName = " + info.cardSkillName +
                " | CardSkillNameCN = " +
                " | CardSkill = " + info.cardSkill +
                " | CardSkillCN = " +
                " | }}";

            return origin;
        }



        static CardInfo GetCardInfo(string input)
        {
            CardInfo info = new CardInfo();

            string[] strings;
            strings = input.Split(',');

            for (int i = 0; i < strings.Length; i++)
            {
                string str = strings[i];
                str = System.Text.RegularExpressions.Regex.Replace(str, "[\r\n\t]", "");
                str = str.Replace(" ", "");

                string[] strs = str.Split(':');
                string key = strs[0];

                if (key.Contains("\""))
                    key = key.Split('"')[1];


                string value = str;
                
                if(strs.Length > 1)
                    value = strs[1];

                if (key == "name" && string.IsNullOrEmpty(info.cardName))
                    info.cardName = value.Replace("\"","");

                if (key == "idolId")
                {
                    info.charaName = Define.idolName[value];
                    info.idolType = Define.idolType[value];
                }

                if (key == "rarity")
                    switch (value)
                    {
                        case "1":
                            info.rarity = "N";
                            break;
                        case "2":
                            info.rarity = "R";
                            break;
                        case "3":
                            info.rarity = "SR";
                            break;
                        case "4":
                            info.rarity = "SSR";
                            break;
                    }


                if (key == "centerEffectName")
                    info.leaderSkillName = value.Replace("\"", "");

                if (key == "description" && string.IsNullOrEmpty(info.leaderSkillName))
                    info.leaderSkill = value.Replace("\"", "");

                else if (key == "description") info.cardSkill = value.Replace("\"", "");

                if (key == "skillName")
                    info.cardSkillName = value.Replace("\"", "");

                if (key == "life")
                    info.life = value;

                if (key == "visualMax")
                    info.vi1 = value;

                if (key == "visualMaxAwakened")
                    info.vi2 = value;

                if (key == "visualMasterBonus")
                    info.vi3 = (Int32.Parse(value) * 4 + Int32.Parse(info.vi2)).ToString();

                if (key == "vocalMax")
                    info.vo1 = value;

                if (key == "vocalMaxAwakened")
                    info.vo2 = value;

                if (key == "vocalMasterBonus")
                    info.vo3 = (Int32.Parse(value) * 4 + Int32.Parse(info.vo2)).ToString();

                if (key == "danceMax")
                    info.da1 = value;

                if (key == "danceMaxAwakened")
                    info.da2 = value;

                if (key == "danceMasterBonus")
                    info.da3 = (Int32.Parse(value) * 4 + Int32.Parse(info.da2)).ToString();

 
            }


            return info;
        }
    }

    class CardInfo
    {
        public string cardName;
        public string rarity;
        public string idolType;
        public string charaName;
        public string vi1;
        public string vi2;
        public string vi3;
        public string da1;
        public string da2;
        public string da3;
        public string vo1;
        public string vo2;
        public string vo3;
        public string life;
        public string leaderSkill;
        public string leaderSkillName;
        public string cardSkill;
        public string cardSkillName;
    }

    /*
    class CardInfo
    {
        public int id;
        public string cardName;
        public int sortId;
        public int idolId;
        public string resourceId;
        public int rarity;
        public int extraType;
        public Costume costume;
        public BonusCostume bonusCostume;
        public string flavorText;
        public string flavorTextAwakened;
        public int levelMax;
        public int levelMaxAwakened;
        public int vocalMin;
        public int vocalMax;
        public int vocalMinAwakened;
        public int vocalMaxAwakened;
        public int vocalMasterBonus;
        public int danceMin;
        public int danceMinAwakened;
        public int danceMaxAwakened;
        public int danceMasterBonus;
        public int visualMin;
        public int visualMax;
        public int visualMinAwakened;
        public int visualMaxAwakened;
        public int visualMasterBonus;
        public int life;
        public CenterEffect centerEffect;
        public string centerEffectName;
        public Skill[] skill;
        public string skillName;
        public string addDate;
    }

    class Costume
    {
        public long id;
        public string cardName;
        public string description;
    }

    class BonusCostume
    {
        public long id;
        public string cardName;
        public string description;
    }

    class CenterEffect
    {
        public int id;
        public string description;
        public int idolType;
        public int attribute;
        public int value;
    }

    class Skill
    {
        public int id;
        public string description;
        public int effectId;
        public int evaluation;
        public int duration;
        public int interval;
        public int probability;
        public int[] value;
    }*/
}
