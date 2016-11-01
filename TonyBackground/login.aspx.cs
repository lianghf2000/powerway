using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TonyBackgroud_login : System.Web.UI.Page
{
    baseClassSql bc = new baseClassSql();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Visible = false;
    }
    protected void login_submit_Click(object sender, ImageClickEventArgs e)
    {
        if (this.CustomValidator1.IsValid)
        {
            string sql = "select count(*) from admins where uname='" + this.admin_name.Text.Replace("'", "''") + "' and passwd='" + this.admin_pass.Text.Replace("'", "''") + "'";
            //int cnt = int.Parse(DBFactory.GetConn().exe1(sql));

            DataSet dt = bc.GetDataSet(sql);
            int cnt =  dt.Tables[0].Rows.Count;


            if (cnt > 0)
            {
                Response.Cookies.Add(new HttpCookie("admin", this.admin_name.Text));
                Response.Redirect("main.htm");
            }
            else
            {
                this.Label1.Visible = true;
                this.admin_name.Focus();
            }
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Request.Cookies["CheckCode"] != null && !string.IsNullOrEmpty(Request.Cookies["CheckCode"].Value))
        {
            if (args.Value == Request.Cookies["CheckCode"].Value)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            this.CustomValidator1.ErrorMessage = "您的浏览器可能禁用了Cookie,请开启后再使用本系统";
            args.IsValid = false;
        }
    }
}
