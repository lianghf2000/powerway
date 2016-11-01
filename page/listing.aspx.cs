using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class page_listing : System.Web.UI.Page
{
    public baseClassSql bc = new baseClassSql();
    public DataTable mydt = new DataTable();
    public string table, pid, cid = "0", id="", ispage = "false", forlanguage="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = Camnpr.ConfigHelper.GetConfigString("Title");

            table = Request.QueryString["t"] != null ? Request.QueryString["t"].ToString().Replace("'", "") : "menutype";
            pid = Request.QueryString["pid"] != null ? Request.QueryString["pid"].ToString().Replace("'", "") : "0";
            cid = Request.QueryString["cid"] != null ? Request.QueryString["cid"].ToString().Replace("'", "") : "0";
            id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString().Replace("'", "") : "0";

            rptParentContent.DataSource = bc.GetDataSet("select [typecontent] from [" + table + "] where [id]=" + pid);
            rptParentContent.DataBind();

            /*语言设置 start*/
            string _language = Camnpr.Common.DataCookie.GetCookie("_for_lang");
            if (_language != "CookieNonexistence")
            {
                forlanguage = _language == "1" ? "en_" : "";
            }
            /*语言设置 end*/
            Master._language = forlanguage;
            string cn = Camnpr.Common.DataCookie.GetCookie("_for_area_name");
            Master._cityname = cn == "CookieNonexistence" ? "中国" : cn;

            DataSet ds = bc.GetDataSet("select [id],[pid],[typecontent],[typename],[orderid],[ispage] from [" + forlanguage+table + "] where [pid]=" + pid + " order by [orderid]");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                mydt = ds.Tables[0];
        }        
    }
}