using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleMsgPack;

namespace NeoDownloader
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Define.LocalPath = Application.StartupPath;
            FileManager.CheckVersionFile();
            FileManager.ReadVersionFile();

            Application.Run(new Form1());
        }
    }
}
