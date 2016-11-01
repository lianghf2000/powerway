using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = "注册 - " + Camnpr.ConfigHelper.GetConfigString("Title");
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
        string _txtCode = txtCode.Value.Replace("'", "");
        if (Request.Cookies["pageCode"] == null || string.IsNullOrEmpty(Request.Cookies["pageCode"].Value) || Request.Cookies["pageCode"].Value.ToString() != _txtCode)
        {
            Literal1.Text = "验证码错误";
            return;
        }

        string _txtPassword = txtPassword.Value.Replace("'", "");
        string _txtPassword2 = txtPassword2.Value.Replace("'", "");
        if (_txtPassword == "" || _txtPassword != _txtPassword2)
        {
            Literal1.Text = "两次密码不一致";
            return;
        }

        string _txtFirstName = txtFirstName.Value.Replace("'", "");
        string _txtEmail = txtEmail.Value.Replace("'", "");
        
        string _lstIndustries = lstIndustries.Value.Replace("'", "");
        string _txtOrg = txtOrg.Value.Replace("'", "");
        string _ddlFunctional = ddlFunctional.Value.Replace("'", "");
        string _txtJobTitle = txtJobTitle.Value.Replace("'", "");
        string _txtCountryCity = txtCountryCity.Value.Replace("'", "");


        baseClassSql bc = new baseClassSql();
        bool affect = bc.ExecuteSql("insert into [userVip] ([u_email],[u_pass],[u_xingming],[u_hangye],[u_companyname],[u_department],[u_position],[u_address]) values (" +
                                                "'" + _txtEmail + "'," +
                                                "'" + _txtPassword2 + "'," +
                                                "'" + _txtFirstName + "'," +
                                                "'" + _lstIndustries + "'," +
                                                "'" + _txtOrg + "'," +
                                                "'" + _ddlFunctional + "'," +
                                                "'" + _txtJobTitle + "'," +
                                                "'" + _txtCountryCity + "'" +
                                                ")");
        if (affect)
        {
            Page.RegisterStartupScript("success", "<script>alert('注册成功');location.href='/page/login.aspx';</script>");
        }
        else
        {
            Page.RegisterStartupScript("success", "<script>alert('注册失败');</script>");
        }
        Literal1.Text = "";
    }
}