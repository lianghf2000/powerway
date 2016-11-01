using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System;
using System.Collections;
using System.Web.UI;

    public class HtmlHelper
    {
        public static string GetHTML(string url)
        {
            WebRequest request = WebRequest.Create(url);//为指定的 URI 方案初始化新的 System.Net.WebRequest 实例 

            request.UseDefaultCredentials = false;//获取或设置一个 System.Boolean 值，该值控制 System.Net.CredentialCache.DefaultCredentials 
            WebResponse response = request.GetResponse();//返回对 Internet 请求的响应。 
            Stream resStream = response.GetResponseStream();//返回从 Internet 资源返回数据流 
            StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);//实例华一个流的读写器 
            string Text = sr.ReadToEnd();//这就是百度首页的HTML哦 ,字符串形式的流的其余部分（从当前位置到末尾）。如果当前位置位于流的末尾，则返回空字符串 ("") 
            resStream.Close();//关闭当前流并释放与之关联的所有资源 
            sr.Close(); //关闭 System.IO.StreamReader 对象和基础流，并释放与读取器关联的所有系统资源
            return Text;
        }

        public static string GetHTML(string url,Encoding encoding)
        {
            WebRequest request = WebRequest.Create(url);//为指定的 URI 方案初始化新的 System.Net.WebRequest 实例 

            request.UseDefaultCredentials = false;//获取或设置一个 System.Boolean 值，该值控制 System.Net.CredentialCache.DefaultCredentials 
            WebResponse response = request.GetResponse();//返回对 Internet 请求的响应。 
            Stream resStream = response.GetResponseStream();//返回从 Internet 资源返回数据流 
            StreamReader sr = new StreamReader(resStream, encoding);//实例华一个流的读写器 
            string Text = sr.ReadToEnd();//这就是百度首页的HTML哦 ,字符串形式的流的其余部分（从当前位置到末尾）。如果当前位置位于流的末尾，则返回空字符串 ("") 
            resStream.Close();//关闭当前流并释放与之关联的所有资源 
            sr.Close(); //关闭 System.IO.StreamReader 对象和基础流，并释放与读取器关联的所有系统资源
            return Text;
        }

        public static void CreateHTMLPageSatatic(string path, string html)
        {
            System.IO.StreamWriter sw;

            sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default);
            sw.Write(html.ToString());
            sw.Close();            
        }

        public static string GetHtmlUrl(string aspxUrl)
        {
            string aspxurl = aspxUrl;

            aspxurl = aspxurl.Replace("https://", "").Replace("http://", "");
            aspxurl = aspxurl.Replace(HttpContext.Current.Request.Url.Host.ToString(), "").Replace(":" + HttpContext.Current.Request.Url.Port, "");
            string[] path = aspxurl.Split(new string[] { ".aspx" }, StringSplitOptions.None);

            string filename = path[0];
            if (path.Length > 1)
            {
                string fileElse = path[1].Replace("?", "");
                string[] qstr = fileElse.Split("&".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                
                //SortedList list = new SortedList();
                //foreach (string str in qstr)
                //{
                //    list.Add(str, str);
                //}
                foreach (string str in qstr)
                {
                    filename += "_" + str.Replace("=", "_");
                }
            }
            filename += ".htm";

            return filename;
        }

        public static string GetAspxUrl(string htmlUrl)
        {
            string basename = htmlUrl.Replace(".htm", "");
            string[] namePart = basename.Split('_');
            string name = namePart[0] + ".aspx";

            if (namePart.Length > 1)
            {
                name += "?";
                string qstr = string.Empty;
                for (int i = 1; i < namePart.Length; i+=2)
                {
                    if (!string.IsNullOrEmpty(qstr))
                    {
                        qstr += "&";                        
                    }

                    qstr += namePart[i] + "=" + namePart[i + 1];
                    
                }
                name += qstr;
            }

            return name;
        }

        public static string CreateHTMLPage(string html,string aspxUrl)
        {
            string aspxpage = aspxUrl.Split('/')[aspxUrl.Split('/').Length - 1];
            string htmlFileName = HtmlHelper.GetHtmlUrl(aspxUrl);
            System.IO.StreamWriter sw;
            string path = HttpContext.Current.Server.MapPath(htmlFileName);
            if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(htmlFileName)))
            {
                sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default);
                string writeHTML = html.ToString();

                writeHTML = writeHTML.Replace("href=\"" + aspxpage + "\"", "href=\"" + htmlFileName + "\"");
                writeHTML = writeHTML.Replace("href='" + aspxpage + "'", "href='" + htmlFileName + "'");
                writeHTML = writeHTML.Replace("href=" + aspxpage + "", "href=" + htmlFileName + "");

                sw.Write(writeHTML.ToString());
                sw.Close();
            }            

            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                string fromurl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToString().Split('/')[HttpContext.Current.Request.UrlReferrer.AbsoluteUri.ToString().Split('/').Length - 1];
                if (fromurl.EndsWith(".htm"))
                {
                    string aspx = HtmlHelper.GetAspxUrl(fromurl);
                    if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(fromurl)))
                    {
                        System.IO.StreamReader r = new System.IO.StreamReader(HttpContext.Current.Server.MapPath(fromurl), System.Text.Encoding.Default);
                        string fromhtml = r.ReadToEnd();
                        
                        fromhtml = fromhtml.Replace("href=\"" + aspxpage + "\"", "href=\"" + htmlFileName + "\"");
                        fromhtml = fromhtml.Replace("href='" + aspxpage + "'", "href='" + htmlFileName + "'");
                        fromhtml = fromhtml.Replace("href=" + aspxpage + "", "href=" + htmlFileName + "");
                        
                        r.Close();
                        System.IO.StreamWriter w = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath(fromurl), false, System.Text.Encoding.Default);
                        w.Write(fromhtml);
                        w.Close();
                    }
                }
            }

            return htmlFileName;
        }

        public static void SaveHtmlBuildLog(string aspxurl, string htmlurl, bool reBuild)
        {
            string sql = "select count(*) from htmlBuild where aspxurl='" + aspxurl.Replace("'", "''") + "' and htmlurl='" + htmlurl.Replace("'", "''") + "'";
            int cnt = Convert.ToInt32(DBFactory.GetConn().exe1(sql));
            if (cnt > 0)
            {
                sql = "update htmlbuild set buildtime=getdate(),rebuild=" + (reBuild ? "1" : "0") + " where aspxurl='" + aspxurl.Replace("'", "''") + "'";
            }
            else
            {
                sql = "insert into htmlbuild (aspxurl,htmlurl,rebuild) values ('"+aspxurl.Replace("'","''")+"','"+htmlurl.Replace("'","''")+"',"+(reBuild?"0":"1")+")";
            }
            DBFactory.GetConn().exe0(sql);
        }

        public static void RefreshHTML(string aspxurl)
        {
            string htmlurl = HtmlHelper.GetHtmlUrl(aspxurl);
            string aboutName = htmlurl.Split('/')[htmlurl.Split('/').Length - 1];
            aboutName = aboutName.Split('.')[0];            
            if (File.Exists(HttpContext.Current.Server.MapPath(htmlurl)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(htmlurl));

                FileInfo finfo = new FileInfo(HttpContext.Current.Server.MapPath(htmlurl));
                DirectoryInfo dir = finfo.Directory;
                foreach (FileInfo f in dir.GetFiles("*.htm"))
                {
                    if (f.Name.StartsWith(aboutName))
                    {
                        f.Delete();
                    }
                }
            }
            string gotourl = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + HttpContext.Current.Request.ApplicationPath + "/" + aspxurl;
            gotourl = gotourl.Replace("~/", "");
            HtmlHelper.GetHTML(gotourl);
        }
    }

