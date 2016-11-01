<%@ WebHandler Language="C#" Class="RemoveUnUseImg" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
public class RemoveUnUseImg : IHttpHandler {

    public List<string> FileList = new List<string>();
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";

        GetFileNameInDir("~/uploads");
        foreach (string str in FileList)
        {
            context.Response.Write(str);            
            if (!Used(str.Replace("~/uploads/","")))
            {
                Del(context.Server.MapPath(str));
                context.Response.Write("--Del");
            }
            context.Response.Write("<br />");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    private void GetFileNameInDir(string dir)
    {
        DirectoryInfo dinfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(dir));

        foreach (FileInfo finfo in dinfo.GetFiles())
        {
            FileList.Add(dir + "/" + finfo.Name);
        }
        foreach (DirectoryInfo d in dinfo.GetDirectories())
        {
            GetFileNameInDir(dir + "/" + d.Name);
        }
    }

    private bool Used(string fileName)
    {
        bool r = false;
        string sql = "select Name from sysobjects where xtype='u' and status>=0 order by name";
        DataTable tab = DBFactory.GetConn().exeTable(sql);
        foreach (DataRow row in tab.Rows)
        {
            string sql1 = "select column_name,data_type from information_schema.columns where table_name = N'" + row["name"].ToString() + "' ";
            DataTable columns = DBFactory.GetConn().exeTable(sql1);

            string goSql = "select count(*) from " + row["name"].ToString() + " where 1=1 ";
            string where = string.Empty;
            foreach (DataRow row1 in columns.Rows)
            {
                if (!string.IsNullOrEmpty(where))
                {
                    where += " or ";
                }
                where += row1["column_name"].ToString() + " like '%" + fileName + "%'";
            }

            goSql = goSql + " and (" + where + ")";
            
            int cnt = int.Parse(DBFactory.GetConn().exe1(goSql));

            if (cnt > 0)
            {
                r = true;
                return true;
            }
        }
        return r;
    }

    private void Del(string filename)
    {
        File.Delete(filename);
    }

}