using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        string t = Request.QueryString["t"];
        Table tab = new Table(t);
        string sql = "delete from " + t + " where " + tab.PKFiled + "='" + id + "'";
        DBFactory.GetConn().exe0(sql);
        Response.Redirect(Request.UrlReferrer.ToString());
    }
}
