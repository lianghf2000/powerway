using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page_listed : System.Web.UI.Page
{
    baseClassSql bc = new baseClassSql();
    public string table="",title="";
    protected void Page_Load(object sender, EventArgs e)
    {
        table = Request.QueryString["t"] != null ? Request.QueryString["t"].ToString().Replace("'","") : "news";
        string pid = Request.QueryString["pid"] != null ? Request.QueryString["pid"].ToString().Replace("'", "") : "0";
        title = Request.QueryString["m"] != null ? Request.QueryString["m"].ToString().Replace("'", "") : "";

        this.Page.Title = title + "-" + Camnpr.ConfigHelper.GetConfigString("Title");

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

        rptList.DataSource = bc.GetDataSet("select [id],[title] from [" + forlanguage + table + "] where [typeid]=" + pid + " and [isis]=1 and charindex( '," + Camnpr.Common.DataCookie.GetCookie("_for_area") + ",',','+area+',')>0 order by [orderid] desc, [inputdate] desc");
        rptList.DataBind();
    }

    //protected void AspNetPager_log_PageChanged(object sender, EventArgs e)
    //{
    //    DBind();
    //}

    //private void DBind()
    //{
    //    int totalrecordscount = 0;

    //    DataTable dt = bll_W8callLog.GetList(AspNetPager_log.CurrentPageIndex, AspNetPager_log.PageSize, "select * from W8callLog where UserId='" + UserNo + "' order by w8_datetime desc", out totalrecordscount).Tables[1];
    //    if (dt.Rows.Count > 0)
    //    {
    //        this.Repeater1.DataSource = dt.DefaultView;
    //        ASPNetPagerHelper.ASPNetPager.AspNetPagerSetting(AspNetPager_log, totalrecordscount);
    //        Repeater1.DataBind();
    //    }
    //}
    //public DataSet GetList(Int32 iPageCurr, Int32 iPageSize, string sql, out Int32 totalRecords)
    //    {


    //        SqlParameter[] parameters = {
    //                new SqlParameter("@RecordCount", SqlDbType.Int),
    //                new SqlParameter("@PageCurrent", SqlDbType.Int),
    //                new SqlParameter("@Pagesize", SqlDbType.Int),
    //                new SqlParameter("@sql", SqlDbType.VarChar,1000),
					
    //                };
    //        parameters[0].Direction = ParameterDirection.Output;
    //        parameters[1].Value = iPageCurr;
    //        parameters[2].Value = iPageSize;
    //        parameters[3].Value = sql;

    //        DataSet ds = DbHelperSQL.RunProcedure("sp_PageView", parameters, "ds");
    //        totalRecords = Convert.ToInt32(parameters[0].Value.ToString());
    //        //返回DataTable的结果
    //        return ds;

    //    }


//执行存数过程：
///// <summary>
//        /// 执行存储过程
//        /// </summary>
//        /// <param name="storedProcName">存储过程名</param>
//        /// <param name="parameters">存储过程参数</param>
//        /// <param name="tableName">DataSet结果中的表名</param>
//        /// <returns>DataSet</returns>
//        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                DataSet dataSet = new DataSet();
//                connection.Open();
//                SqlDataAdapter sqlDA = new SqlDataAdapter();
//                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
//                sqlDA.Fill(dataSet, tableName);
//                connection.Close();
//                return dataSet;
//            }
//        }

///// <summary>
//        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
//        /// </summary>
//        /// <param name="connection">数据库连接</param>
//        /// <param name="storedProcName">存储过程名</param>
//        /// <param name="parameters">存储过程参数</param>
//        /// <returns>SqlCommand</returns>
//        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
//        {
//            SqlCommand command = new SqlCommand(storedProcName, connection);
//            command.CommandType = CommandType.StoredProcedure;
//            foreach (SqlParameter parameter in parameters)
//            {
//                if (parameter != null)
//                {
//                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
//                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
//                        (parameter.Value == null))
//                    {
//                        parameter.Value = DBNull.Value;
//                    }
//                    command.Parameters.Add(parameter);
//                }
//            }

//            return command;
//        }

}