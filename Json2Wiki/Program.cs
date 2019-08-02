//-------------------------------------------
//by Excel
//
//ver alpha 0.4
//
//-------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace Json2Wiki
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Define.init();
            Console.WriteLine("输入id号查询对应卡片信息并转换为wiki语言格式。输入0可清屏。");

            while (true)
            {
                Console.WriteLine("输入要查询的卡片的id：");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.Clear();
                    continue;
                }

                string result = GetWebRequest("http" + "s://a" + "pi.mat" + "suri" + "hi.me/ml" + "td/v" + "1/c" + "ards/" + input);
                result = System.Text.RegularExpressions.Regex.Replace(result, "[\r\n\t]", "");
                
                if (result == "[]")
                {
                    Console.WriteLine("ERROR! 查询错误");
                    Console.WriteLine();
                    continue;
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                List<CardInfo> infoList = js.Deserialize<List<CardInfo>>(result);

                foreach (var info in infoList)
                {
                    result = GetString(info);
                    Console.WriteLine();
                    Console.WriteLine(result);
                    Console.WriteLine();
                }
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
                "{{CardPic | CardID =  | SmallPicNum = 4 | BigPicNum = 0 | ClothPicNum = 0 }}\n" + 
                "{{CardData" +
                " | CardName = " + info.name +
                " | CardNameCN = " +
                " | Rarity = " + Define.idolRarity[info.rarity] +
                " | Type = " + Define.idolType[info.idolId] +
                " | CharaName = " + Define.idolName[info.idolId] +
                " | Li1 = " + Define.GetLifeByRarity(info.rarity) + " | Vo1 = " + info.vocalMax + " | Da1 = " + info.danceMax + " | Vi1 = " + info.visualMax +
                " | Li2 = " + Define.GetLifeByRarity(info.rarity) + " | Vo2 = " + info.vocalMaxAwakened + " | Da2 = " + info.danceMaxAwakened + " | Vi2 = " + info.visualMaxAwakened +
                " | Li3 = " + Define.GetLifeByRarity(info.rarity) + " | Vo3 = " + (info.vocalMasterBonus * 4 + info.vocalMaxAwakened) + " | Da3 = " + (info.danceMasterBonus * 4 + info.danceMaxAwakened) + " | Vi3 = " + (info.visualMasterBonus * 4 + info.visualMaxAwakened) +
                " | LeaderSkillName = " + info.centerEffectName +
                " | LeaderSkillNameCN = " +
                " | LeaderSkill = " + (info.centerEffect == null ? "" : info.centerEffect.description) +
                " | LeaderSkillCN = " +
                " | CardSkillName = " + info.skillName +
                " | CardSkillNameCN = " +
                " | CardSkill = " + (info.skill == null ? "" : string.Format(info.skill[0].description, info.skill[0].probability < 31 ? 40 : 45)) +
                " | CardSkillCN = " +
                " | Category = " + 
                " | FirstShown = " +
                " | }}";

            return origin;
        }
    }
}
