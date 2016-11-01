using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page_Results : System.Web.UI.Page
{
    baseClassSql bc = new baseClassSql();
    public string strKey = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strKey = Request.QueryString["k"] != null ? Request.QueryString["k"].ToString().Replace("'","") : "";

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

            if (strKey != "")
            {
                string strsql = "select [id],[title],[smallcontent],'" + forlanguage + "nav' as t from [" + forlanguage + "nav] where [Keywords] like '%" + strKey + "%' and [isis]=1 " +
                                "union select [id],[title],[smallcontent],'" + forlanguage + "menu' as t from [" + forlanguage + "menu] where [Keywords] like '%" + strKey + "%' and [isis]=1 " +
                                "union select [id],[title],[smallcontent],'" + forlanguage + "news' as t from [" + forlanguage + "news] where [Keywords] like '%" + strKey + "%' and [isis]=1 ";


                rptList.DataSource = bc.GetDataSet(strsql);
                rptList.DataBind();
            }
        }

    }
}