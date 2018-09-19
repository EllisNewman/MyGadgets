using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoDownloader
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            label10.Visible = false;
            linkLabelBlog.Visible = false;
        }

        private void linkLabelMatsu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://matsurihi.me");
        }

        private void linkLabelGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/EllisNewman/MyGadgets/tree/master/NeoDownloader");
        }

        private void linkLabelBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://hoshiumi.cc");
        }
    }
}
