using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_getcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        if (Request.Cookies["CheckCode"] != null && !string.IsNullOrEmpty(Request.Cookies["CheckCode"].Value))
        {
            Response.Write(Request.Cookies["CheckCode"].Value);
        }
        else
        {
            Response.Write("refresh");
        }
        Response.End();
    }
}
