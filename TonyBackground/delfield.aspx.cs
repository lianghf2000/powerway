using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_delfield : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string tab = Request.QueryString["t"];
        string c = Request.QueryString["c"];
        string id = Request.QueryString["id"];
        string sql = "update " + tab + " set " + c + "='' where id=" + id;
        DBFactory.GetConn().exe0(sql);
        Response.Clear();
        Response.Write("ok");
        Response.End();
    }
}
