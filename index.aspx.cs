using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Camnpr.Common;
using System.Data;

public partial class index : System.Web.UI.Page
{
    baseClassSql bc = new baseClassSql();
    string areaid = "1", forlanguage = "", areaname="";
    public DataTable imgdt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = Camnpr.ConfigHelper.GetConfigString("Title");

        //语言地区设置
        if (Request.QueryString["lang"] != null && !string.IsNullOrEmpty(Request.QueryString["lang"].ToString()))
        {
            forlanguage = Request.QueryString["lang"].Trim() == "" ? "0" : Request.QueryString["lang"].Trim();
            DataCookie.SetCookie("_for_lang", 1, forlanguage);
        }

        if (Request.QueryString["area"] != null && !string.IsNullOrEmpty(Request.QueryString["area"].ToString()))
        {
            areaid = Request.QueryString["area"].Trim() == "" ? "1" : Request.QueryString["area"].Trim();
            DataCookie.SetCookie("_for_area", 1, areaid);//1:地区id
        }
        else
        {
            areaid = Camnpr.Common.DataCookie.GetCookie("_for_area");
            areaid = areaid == "CookieNonexistence" ? "1" : areaid;
        }

        if (Request.QueryString["n"] != null && !string.IsNullOrEmpty(Request.QueryString["n"].ToString()))
        {
            areaname = Request.QueryString["n"].Trim() == "" ? "中国" : Request.QueryString["n"].Trim();
            DataCookie.SetCookie("_for_area_name", 1, areaname);
        }
        else
        {
            areaname = Camnpr.Common.DataCookie.GetCookie("_for_area_name");
            areaname = areaname == "CookieNonexistence" ? "中国" : areaname;
        }

        /*语言设置 start*/
        if (Request.QueryString["lang"] == null)
        {
            forlanguage = Camnpr.Common.DataCookie.GetCookie("_for_lang");
            if (forlanguage != "CookieNonexistence")
            {
                forlanguage = forlanguage == "1" ? "en_" : "";
            }
            else
            {
                forlanguage = "";
            }
        }
        else
        {
            if (forlanguage != "")
            {
                forlanguage = forlanguage == "1" ? "en_" : "";
            }
        }
        /*语言设置 end*/

        Master._language = forlanguage;
        Master._cityname = areaname;

        //Master.rptNavData = bc.GetDataSet("select [id],[typename],[ispage] from [" + forlanguage + "navtype] order by [orderid]");
        //Master.rptMenuData = bc.GetDataSet("select [id],[pid],[typename],[orderid],[ispage] from [" + forlanguage + "menutype] order by [orderid]");
        //Master.rptBottomData = bc.GetDataSet("select [id],[pid],[typename],[orderid],[ispage] from [" + forlanguage + "newstype] order by [orderid]");
        //Master.rptConfigData = bc.GetDataSet("select * from [" + forlanguage + "config] where [id]=1");

        //Response.Write(areaid + "/" + forlanguage);
        //Response.End();


        rptList.DataSource = bc.GetDataSet("select [id],[title] from [" + forlanguage + "nav] where [isis]=1 and [shouye]=1 and charindex( '," + areaid + ",',','+area+',')>0 order by [orderid] desc, [inputdate] desc");
        rptList.DataBind();
        
        rptList2.DataSource = bc.GetDataSet("select [id],[title] from [" + forlanguage + "menu] where [isis]=1 and [shouye]=1 order by [orderid] desc, [inputdate] desc");
        rptList2.DataBind();


        DataSet ds5 = bc.GetDataSet("select [Name],[Come],[PhotoPath] from [T_tupian] order by [NewTime] desc, [id] desc");
        if (ds5.Tables.Count > 0 && ds5.Tables[0].Rows.Count > 0)
            imgdt = ds5.Tables[0];

    }
}