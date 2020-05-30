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
        private Hashtable urls = new Hashtable();
        private int count = 0;
        public event Action<string> PageLoad;
        public string StartUrl { set; get; }
        public void Crawl()
        {
            string listinfo;
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null)
                {
                    listinfo = "Finished";
                    PageLoad(listinfo);
                    break;
                }
                else
                {
                    listinfo = "Crawling  " + current;
                    string html = DownLoad(current); // 下载
                    urls[current] = true;
                    count++;
                    Parse(html);//解析,并加入新的链接
                }
                PageLoad(listinfo);
            }
        }

        public void Start()
        {
            urls.Clear();
            urls.Add(StartUrl, false);
            Crawl();
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public string GetLimitation()
        {
            string s = "";
            bool needAppend = false;
            for (int i = 0; i < StartUrl.Length; i++)
            {
                s += StartUrl[i];
                if (Regex.IsMatch(s, @"(http://|https://)"))
                {
                    s = "";
                    continue;
                }
                else if (Regex.IsMatch(s, @".*/")&&!Regex.IsMatch(s, @"http"))
                    break;
                else if (i == StartUrl.Length - 1)
                {
                    needAppend = true;
                    break;
                }
            }
            //if (!Regex.IsMatch(s, @"^http"))
                //s = "https:" + s;
            if (needAppend)
                return s + "/";
            else
                return s;
        }

        public void Parse(string html)
        {

            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            string partten = @".*html";
            
            string limitUrl = GetLimitation();
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>','*');
                if (Regex.IsMatch(strRef, @"(^http)") && !Regex.IsMatch(strRef, limitUrl))
                    continue;
                else if (Regex.IsMatch(strRef, limitUrl))
                {
                    if (Regex.IsMatch(strRef, @"^../"))//以../开头的url
                        continue;
                    else if (Regex.IsMatch(strRef, @"^//"))//以//开头的url加上https:
                        strRef = "https:" + strRef;
                }
                else 
                {
                    if (Regex.IsMatch(strRef, @"^/"))
                        strRef = limitUrl + strRef.Trim('/');
                    else
                        strRef = limitUrl + strRef;
                }

                if (!Regex.IsMatch(strRef, partten)) continue;//爬取html文件
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
