using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_passwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin"] == null || string.IsNullOrEmpty(Request.Cookies["admin"].Value))
        {
            Response.Write("<script>top.location.href='default.aspx'</script>");
            Response.End();
        }
        string realname = DBFactory.GetConn().exe1("select realname from admins where uname='" + Request.Cookies["admin"].Value + "'");
        this.Label1.Text = realname;

        this.Label2.Visible = false;
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string sql = "select passwd from admins where uname='" + Request.Cookies["admin"].Value + "'";
        string pass = DBFactory.GetConn().exe1(sql);
        if (args.Value == pass)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.CustomValidator1.IsValid)
        {
            string sql = "update admins set passwd='" + this.TextBox2.Text + "' where uname='" + Request.Cookies["admin"].Value + "'";
            DBFactory.GetConn().exe0(sql);
            this.Label2.Visible = true;
        }
    }
}
