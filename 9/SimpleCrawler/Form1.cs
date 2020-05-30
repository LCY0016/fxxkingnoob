using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCrawler
{
    public partial class Form1 : Form
    {
        public SimpleCrawler crawler = new SimpleCrawler();
        public Thread t;
        public Form1()
        {
            InitializeComponent();
            crawler.PageLoad += PageDownLoad;
        }
        
        public void PageDownLoad(string url)
        {
            if(this.LtbxInfo.InvokeRequired)
            {
                Action<string> a = this.AddUrl;
                this.Invoke(a, new object[] { url });
            }
            else
            {
                AddUrl(url);
            }
        }

        public void AddUrl(string url)
        {
            LtbxInfo.Items.Add(url);
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            crawler.StartUrl = TbxStartUrl.Text;
            
            LtbxInfo.Items.Clear();
            t = new Thread(crawler.Start);
            t.Start();
        }

        [Obsolete]
        private void BtnPause_Click(object sender, EventArgs e)
        {
            t.Suspend();
            LtbxInfo.Items.Add("Paused");
        }

        [Obsolete]
        private void BtnContinue_Click(object sender, EventArgs e)
        {
            t.Resume();
            LtbxInfo.Items.Add("Continued");
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            t.Abort();
            LtbxInfo.Items.Add("Aborted");
        }
    }
}
