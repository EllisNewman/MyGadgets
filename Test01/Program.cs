using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test01
{
    class Program
    {

        static string path = System.Environment.CurrentDirectory;
        static void Main(string[] args)
        {
            for(int i = 1; i < 14; i++)
            {
                for ( int j = 1; i + j <=13; j++)
                {
                    System.Console.Write('*');
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
       /* {
            List<FileInfo> listFile = new List<FileInfo>();
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            listFile.AddRange(dirInfo.GetFiles());

            foreach (var file in listFile)
            {
                if(file.Name.Split('.').Last() != "txt")
                {
                    continue;
                }

                string url = ReadFile(file.FullName);
                Console.WriteLine(url);

                Image image = RequestPic(url);

                StringBuilder fileBuilder = new StringBuilder(file.FullName);
                fileBuilder.Append(".jpg");
                image.Save(fileBuilder.ToString(), ImageFormat.Jpeg);

            }

            System.Console.ReadLine();
        }*/

        static string ReadFile(string filePath)
        {
            StreamReader fileStreamReader = new StreamReader(filePath);
            string fileString = fileStreamReader.ReadToEnd();

            return fileString;
        }

        static Image RequestPic(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Image image;
            using ( Stream responseStream = response.GetResponseStream() )
            {
                image = Image.FromStream(responseStream);
            }

            return image;
        }
    }
}
