using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimpleCrawler
{
    public partial class Form1 : Form
    {
        BindingSource bindingSource = new BindingSource();
        public SimpleCrawler crawler = new SimpleCrawler();
        public Thread t;
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            dgvResult.DataSource = bindingSource;
            crawler.CrawlerStopped += Crawler_CrawlerStopped;
            crawler.PageDownloaded += Crawler_PageDownloaded;
        }

        private void Crawler_CrawlerStopped(SimpleCrawler obj)
        {

            Action action = () =>
            {
                sw.Stop();
                LblInfo.Text = $"爬虫已停止 用时{sw.ElapsedMilliseconds}";
            };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        public void Crawler_PageDownloaded(SimpleCrawler crawler,string url,string info)
        {
            var pageInfo = new { Index = bindingSource.Count + 1, URL = url, Status = info };
            Action action = () => { bindingSource.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            
            crawler.StartUrl = TbxStartUrl.Text;
            if (crawler.StartUrl != "")
            {
                Match match = Regex.Match(crawler.StartUrl, SimpleCrawler.urlParseRegex);
                if (match.Length == 0)
                {
                    LblInfo.Text = "invaild input";
                    return;
                }
                string host = match.Groups["host"].Value;
                crawler.HostFilter = @"^" + host + "$";
                crawler.FileFilter = @".html?$";

                LblInfo.Text = "Start";
                t = new Thread(crawler.Start);
                sw.Restart();
                t.Start();
            }
            else
            {
                LblInfo.Text = "Input url";
            }
        }

        [Obsolete]
        private void BtnPause_Click(object sender, EventArgs e)
        {
            try
            {
                t.Suspend();
                LblInfo.Text = "Paused";
            }catch
            {
                LblInfo.Text = "Paused error";
            }
        }

        [Obsolete]
        private void BtnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                t.Resume();
                LblInfo.Text = "Continued";
            }
            catch
            {
                LblInfo.Text = "Continued error";
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                t.Abort();
                LblInfo.Text = "Aborted";
            }
            catch
            {
                LblInfo.Text = "Aborted error";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
            crawler.StartUrl = TbxStartUrl.Text;
            if (crawler.StartUrl != "")
            {
                Match match = Regex.Match(crawler.StartUrl, SimpleCrawler.urlParseRegex);
                if (match.Length == 0)
                {
                    LblInfo.Text = "invaild input";
                    return;
                }
                string host = match.Groups["host"].Value;
                crawler.HostFilter = @"^" + host + "$";
                crawler.FileFilter = @".html?$";

                LblInfo.Text = "Start parallel";
                t = new Thread(crawler.ParallelStart);
                sw.Start();
                t.Start();
                t.IsBackground = true;
            }
            else
            {
                LblInfo.Text = "Input url";
            }
        }
    }
}
