using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    public class SimpleCrawler
    {

        public event Action<SimpleCrawler,string,string> PageDownloaded;
        public event Action<SimpleCrawler> CrawlerStopped;
        
        //存放url，并表示其状态
        private Dictionary<string,bool> urls = new Dictionary<string, bool>();
        
        //待下载队列
        private Queue<string> pending = new Queue<string>();
        private Queue<string> Parallelpending = new Queue<string>();
        //起始地址
        public string StartUrl { set; get; }
        
        //文本中检测url
        private string strRef = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
       
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";

        private int MaxUrl { set; get; }
        public string HostFilter { set; get; }
        public string FileFilter { set; get; }
        public SimpleCrawler()
        {
            MaxUrl = 100;
        }
        public void Crawl()
        {
            while (urls.Count < MaxUrl && pending.Count > 0)
            {
                string currentUrl = pending.Dequeue();
                try
                {
                    string html = DownLoad(currentUrl); // 下载
                    urls[currentUrl] = true;
                    Parse(html,currentUrl);//解析,并加入新的链接
                    PageDownloaded(this, currentUrl, $"success");
                }
                catch(Exception ex)
                {
                    PageDownloaded(this, currentUrl, $"\terror:{ex.ToString()}");
                }
            }
            CrawlerStopped(this);
        }

       

        public void Start()
        {
            urls.Clear();
            pending.Clear();
            Parallelpending.Clear();
            pending.Enqueue(StartUrl);
            Crawl();
        }
        public void ParallelStart()
        {
            urls.Clear();
            pending.Clear();
            Parallelpending.Clear();
            urls.Add(StartUrl, false);
            pending.Enqueue(StartUrl);
            Parallelpending.Enqueue(StartUrl);
            while (urls.Count < MaxUrl && Parallelpending.Count > 0)
            {
                ParallelDownLoad();
            }
            CrawlerStopped(this);
        }

        public string DownLoad(string url)
        {
            lock (this)
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = urls.Count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
        }


        public void ParallelDownLoad()
        {
            int count = Parallelpending.Count;
            Task<string>[] tasks = new Task<string>[count];
            
            string[] s = new string[count];
            for (int i = 0; i < count ; i++)
            {
                try
                {
                    s[i] = Parallelpending.Dequeue();
                }
                catch
                {
                   
                }
                if (s[i] == null)
                    break;
                try
                {
                    tasks[i] = Task.Run(() => DownLoad(s[i])
                    );
                    
                    urls[s[i]] = true;

                    lock (this)
                    {
                        PageDownloaded(this, s[i], $"success");
                    }
                }
                catch (Exception ex)
                {
                    PageDownloaded(this, s[i], $"\terror:{ex.ToString()}");
                }
            }

            Task.WaitAll(tasks);
            for (int i = 0; i < count; i++)
            {
                Parse(tasks[i].Result, s[i]);
            }


        }
        


        public void Parse(string htmlPage, string pageUrl)
        {
            MatchCollection matches = new Regex(strRef).Matches(htmlPage);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                linkUrl = FixUrl(linkUrl, pageUrl);//转绝对路径

                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string fileType = linkUrlMatch.Groups["file"].Value;
                if (fileType == "")
                    fileType = "index.html";

                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(fileType, FileFilter)
                    && !urls.ContainsKey(linkUrl))
                {
                    pending.Enqueue(linkUrl);
                    Parallelpending.Enqueue(linkUrl);
                    urls.Add(linkUrl, false);
                }
            }
        }
        public string FixUrl(string fixedurl,string baseurl)
        {
            if(baseurl.EndsWith("/"))
            {
                baseurl = baseurl.Substring(0, baseurl.Length - 2);
            }
            if(fixedurl.Contains("://"))
            {
                return fixedurl;
            }
            if(fixedurl.StartsWith("//"))
            {
                return "https:" + fixedurl;
            }
            if(fixedurl.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(baseurl, urlParseRegex);
                string site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + site.Substring(1) : site + fixedurl;
            }
            if(fixedurl.StartsWith("../"))
            {
                fixedurl = fixedurl.Substring(3);
                int idx = baseurl.LastIndexOf('/');
                return FixUrl(fixedurl, baseurl.Substring(0, idx));
            }

            int end = baseurl.LastIndexOf("/");
            return baseurl.Substring(0, end) + "/" + fixedurl;
        }
    }
}
