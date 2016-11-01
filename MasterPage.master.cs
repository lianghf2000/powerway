using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Camnpr.Common;

public partial class MasterPage : System.Web.UI.MasterPage
{
    baseClassSql bc = new baseClassSql();
    public DataTable dt = new DataTable();
    public DataTable dtForeign = new DataTable();
    public DataTable dtMenu = new DataTable();
    public DataTable dtBottomNav = new DataTable();
    public DataTable dtConfig = new DataTable();

    public string[] strLetter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    //public string _language="";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{

        if (!IsPostBack)
        {
            getIP();
        }

        ////语言地区设置
        //if (Request.QueryString["lang"] != null && !string.IsNullOrEmpty(Request.QueryString["lang"].ToString()))
        //{
        //    _language = Request.QueryString["lang"].Trim() == "" ? "0" : Request.QueryString["lang"].Trim();
        //    DataCookie.SetCookie("_for_lang", 1, _language);
        //    currentCityImg.Src = _language == "0" ? "/images/China.jpg" : "/images/UnitedStates.jpg";
        //    _language = _language == "1" ? "en_" : "";
        //}

        //if (Request.QueryString["area"] != null && !string.IsNullOrEmpty(Request.QueryString["area"].ToString()))
        //{
        //    string areaid = Request.QueryString["area"].Trim() == "" ? "1" : Request.QueryString["area"].Trim();
        //    DataCookie.SetCookie("_for_area", 1, areaid);//1:地区id
        //    //currentCity.HRef = "/index.aspx?lang=0&area=" + areaid;
        //}

        //if (Request.QueryString["n"] != null && !string.IsNullOrEmpty(Request.QueryString["n"].ToString()))
        //{
        //    string areaname = Request.QueryString["n"].Trim() == "" ? "中国" : Request.QueryString["n"].Trim();
        //    DataCookie.SetCookie("_for_area_name", 1, areaname);
        //    //currentCity.InnerHtml = areaname;
        //    currentCityTxt.InnerText = areaname;
        //}
        //else
        //{
        //    try
        //    {
        //        string strname = DataCookie.GetCookie("_for_area_name");
        //        if (strname != "CookieNonexistence")
        //        {
        //            currentCityTxt.InnerText = strname;
        //            //currentCity.InnerHtml = strname;
        //        }
        //    }
        //    catch(Exception ex) { }
        //}
        //}

        ///*语言设置 start*/
        //_language = DataCookie.GetCookie("_for_lang");
        //if (_language != "CookieNonexistence")
        //{
        //    _language = _language == "1" ? "en_" : "";
        //}
        //else
        //{
        //    _language = "";
        //}
        ///*语言设置 end*/

        //导航
        rptNav.DataSource = bc.GetDataSet("select [id],[typename],[ispage] from [" + _language + "navtype] order by [orderid]");
        rptNav.DataBind();

        //菜单
        DataSet ds3 = bc.GetDataSet("select [id],[pid],[typename],[orderid],[ispage] from [" + _language + "menutype] order by [orderid]");
        if (ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
            dtMenu = ds3.Tables[0];

        //页面底部导航
        DataSet ds4 = bc.GetDataSet("select [id],[pid],[typename],[orderid],[ispage] from [" + _language + "newstype] order by [orderid]");
        if (ds4.Tables.Count > 0 && ds4.Tables[0].Rows.Count > 0)
            dtBottomNav = ds4.Tables[0];

        //页面配置项
        DataSet ds5 = bc.GetDataSet("select * from [" + _language + "config] where [id]=1");
        if (ds5.Tables.Count > 0 && ds5.Tables[0].Rows.Count > 0)
            dtConfig = ds5.Tables[0];


        //国家/城市
        DataSet ds = bc.GetDataSet("select [id],[typeid],[title],[letter],[bold],[changyong],[orderid] from [country] where typeid=1 or typeid in (select [id] from countryType where pid=1)");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            dt = ds.Tables[0];

        DataSet ds1 = bc.GetDataSet("select [id],[typeid],[title],[letter],[bold],[changyong],[orderid] from [country] where typeid<>1 and typeid not in (select [id] from countryType where pid=1)");
        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            dtForeign = ds1.Tables[0];


        currentCityTxt.InnerText = cityname;
        currentCityImg.Src = language == "" ? "/images/China.jpg" : "/images/UnitedStates.jpg";

        //}
    }

    private string language = "";
    public string _language
    {
        get
        {
            if (language == null)
            {
                language = DataCookie.GetCookie("_for_lang");
                if (language != "CookieNonexistence")
                {                    
                    language = language == "1" ? "en_" : "";
                }
                else
                {
                    language = "";
                }
            }
            return language;
        }
        set { language = value; }
    }
    private string cityname = "";
    public string _cityname
    {
        get {
            if (cityname == null)
            {
                cityname = DataCookie.GetCookie("_for_area_name");
                if (cityname == "CookieNonexistence")
                {
                    cityname = "中国";
                }
            }
            return cityname;
        }
        set { cityname = value; }
    }

    //public DataSet rptNavData
    //{
    //    get { return rptNavData; }
    //    set { rptNavData = value; }
    //}
    //public DataSet rptMenuData
    //{
    //    get { return rptMenuData; }
    //    set { rptMenuData = value; }
    //}
    //public DataSet rptBottomData
    //{
    //    get { return rptBottomData; }
    //    set { rptBottomData = value; }
    //}
    //public DataSet rptConfigData
    //{
    //    get { return rptConfigData; }
    //    set { rptConfigData = value; }
    //}

    private void getIP()
    {
        if (DataCookie.GetCookie("_for_area_name") == "CookieNonexistence")
        {
            string strIPs = Camnpr.ConfigHelper.GetConfigString("ipAddress");

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] bs = wc.DownloadData(strIPs);

            string ips = System.Text.Encoding.Default.GetString(bs); //var returnCitySN = {"cip": "27.186.30.179", "cid": "990000", "cname": "国内未能识别的地区"};

            ips = ips.Substring(ips.IndexOf("cname\": \"")).Replace("cname\": \"", "").Replace("\"}", "").Replace(";", "").Replace("市辖区", "");

            //if (ips == "国内未能识别的地区") { ips = "中国"; }

            //Response.Write(ips);
            //Response.End();

            DataSet dc = bc.GetDataSet("select top 1 [id],[title] from [country] where [title] like '%" + ips + "%'");
            if (dc.Tables.Count > 0 && dc.Tables[0].Rows.Count > 0)
            {
                DataCookie.SetCookie("_for_area_name", 1, dc.Tables[0].Rows[0][1].ToString());
                DataCookie.SetCookie("_for_area", 1, dc.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                DataCookie.SetCookie("_for_area_name", 1, "中国");
                DataCookie.SetCookie("_for_area", 1, "1");
            }
        }
    }
}
