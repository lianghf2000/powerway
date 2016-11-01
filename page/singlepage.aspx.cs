using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page_singlepage : System.Web.UI.Page
{
    baseClassSql bc = new baseClassSql();
    public string table = "", title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        table = Request.QueryString["t"] != null ? Request.QueryString["t"].ToString().Replace("'", "") : "news";
        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString().Replace("'", "") : "0";
        title = Request.QueryString["m"] != null ? Request.QueryString["m"].ToString().Replace("'", "") : "";

        this.Page.Title = title + "-" + Camnpr.ConfigHelper.GetConfigString("Title");
        string strFields="";

        if (table.IndexOf("type") > 0)
        {
            strFields = "[typecontent]";
        }
        else
        {
            strFields = "[content]";
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

        rptList.DataSource = bc.GetDataSet("select " + strFields + " as neirong from [" + forlanguage+table + "] where [id]=" + id);
        rptList.DataBind();
    }
}