using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace PicDownloader
{
    class Program
    {
        static string picDir = @"D:\output";
        static string picUrl = "http" + "s://i" + "dollist.idolmaster-official.jp/images/character_main/{0}_{1}.jpg";
        static List<string> nameList = new List<string>();
        static List<string> urlList = new List<string>();
        static List<string> existList = new List<string>();

        static void Main(string[] args)
        {

            //Download
            StreamReader srFile = new StreamReader(@"D:\name.txt");

            while (srFile.Peek() > 0)
            {
                string name = srFile.ReadLine();

                nameList.Add(name);
                nameList.Add(name);
                urlList.Add(string.Format(picUrl, name, "01"));
                urlList.Add(string.Format(picUrl, name, "02"));
            }

            for (int i = 0; i < urlList.Count; i++)
            {
                try
                {
                    string url = urlList[i];
                    string outputPath = @"D:/output/" + nameList[i] + "_0" + ((i % 2) == 0 ? 1 : 2) + ".jpg";

                    ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    Stream responseStream = response.GetResponseStream();
                    Stream fileStream = new FileStream(outputPath, FileMode.CreateNew);

                    byte[] bArr = new byte[10000];
                    int size = responseStream.Read(bArr, 0, bArr.Length);

                    while (size > 0)
                    {
                        fileStream.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, bArr.Length);

                    }

                    fileStream.Close();
                    responseStream.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception at No. " + i);
                    continue;
                }
            }
        }

        private void DebugLog()
        {
            /*
            using (StreamReader srFile = new StreamReader(@"D:\name.txt"))
            {
                while(srFile.Peek() > 0)
                {
                    string name = srFile.ReadLine();
                    nameList.Add(name);
                    nameList.Add(name);
                    urlList.Add(string.Format(picUrl, name, "01"));
                    urlList.Add(string.Format(picUrl, name, "02"));
                }
            }*/
            DirectoryInfo folder = new DirectoryInfo(picDir);

            foreach (FileInfo file in folder.GetFiles())
            {
                //if(file.Name.IndexOf("02") > 0)
                existList.Add(file.Name);
                //Console.WriteLine(file.Name);
            }

            StreamReader srFile = new StreamReader(@"D:\name.txt");


            int m = 0, n = 0;
            while (srFile.Peek() > 0)
            {
                string name = srFile.ReadLine();

                nameList.Add(name);
                //nameList.Add(name);

                if (!existList.Exists(t => t.Equals(name + "_01.jpg")))
                {
                    Console.WriteLine(string.Format(picUrl, name, "01"));
                }

                if (!existList.Exists(t => t.Equals(name + "_02.jpg")))
                {
                    Console.WriteLine(string.Format(picUrl, name, "02"));
                }

                urlList.Add(string.Format(picUrl, name, "01"));
                urlList.Add(string.Format(picUrl, name, "02"));
            }


            Console.WriteLine(existList.Count);
        }
    }
}
