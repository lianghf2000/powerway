using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = "登录 - " + Camnpr.ConfigHelper.GetConfigString("Title");
        }
        
        /*语言设置 start*/
        string _language = Camnpr.Common.DataCookie.GetCookie("_for_lang"), forlanguage = "";
        if (_language != "CookieNonexistence")
        {
            forlanguage = _language == "1" ? "en_" : "";
        }
        /*语言设置 end*/

        Master._language = forlanguage;
        string cn = Camnpr.Common.DataCookie.GetCookie("_for_area_name");
        Master._cityname = cn == "CookieNonexistence" ? "中国" : cn;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        baseClassSql bc = new baseClassSql();
        string semail = txtEmail.Value.Replace("'", "");

        string affect = bc.getOneMsg("select [id] from [userVip] where [u_email]='" + semail + "' and [u_pass]='" + txtPass.Value.Replace("'", "") + "'");
        if (affect != "")
        {
            Session.Add("uid", affect);
            Session.Add("umail", semail);

            Page.RegisterStartupScript("success", "<script>alert('登录成功');location.href='/index.aspx';</script>");
        }
        else
        {
            Page.RegisterStartupScript("success", "<script>alert('登录失败');</script>");
        }
    }
}