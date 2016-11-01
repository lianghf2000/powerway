using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
///CheckUser 的摘要说明
/// </summary>
public class CheckUser
{
    public CheckUser()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public void CheckUserView(string strTiaojian)
    {
        baseClassSql bcs = new baseClassSql();

        StringBuilder sb = new StringBuilder();

        try
        {
            if (HttpContext.Current.Session["groupIsLock"] != null && HttpContext.Current.Session["groupIsLock"].ToString() == "true")
            {
                sb.Append("alert('您所在的组被关闭，无法浏览！');");
                sb.Append("location='index.aspx';");
                bcs.MakeJs(sb.ToString());
                //Response.Redirect("index.aspx");
            }
            else if (HttpContext.Current.Session["userIsLock"] != null && HttpContext.Current.Session["userIsLock"].ToString() == "true")
            {
                sb.Append("alert('您被锁定，无法浏览！');");
                sb.Append("location='index.aspx';");
                bcs.MakeJs(sb.ToString());
                //Response.Redirect("index.aspx");
            }
            else if (HttpContext.Current.Session["groupView"] != null && !HttpContext.Current.Session["groupView"].ToString().Contains(strTiaojian))
            {
                sb.Append("alert('您的权限不够，无法浏览！');");
                sb.Append("location='index.aspx';");
                bcs.MakeJs(sb.ToString());
                //Response.Redirect("index.aspx");
            }
        }
        catch { sb.Append("location='index.aspx';"); bcs.MakeJs(sb.ToString()); }
    }

}
