using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminlontro_OrderGo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id=0;
        string tab=Request.QueryString["t"];
        string direction = Request.QueryString["d"];
        Table t = new Table(tab);
        //try
        {
            id = int.Parse(Request.QueryString["id"]);
            string sql = "select " + t.OrderField + " from " + t.TableName + " where " + t.PKFiled + "=" + id.ToString();
            
            string thisorder = DBFactory.GetConn().exe1(sql);

            string nextsql=string.Empty;
            DataRow row=null;
            string[] groupStr = t.SetOrderSqlString.Split(',');
            string groupsql = string.Empty;
            foreach (string str in groupStr)
            {
                if (!string.IsNullOrEmpty(str.Trim()))
                {
                    groupsql += " and " + str + "=(select " + str + " from " + t.TableName + " where " + t.PKFiled + "=" + id + ")";
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["desc"]))
            {
                if (direction.ToLower() == "down")
                {
                    nextsql = "select top 1 " + t.PKFiled + "," + t.OrderField + " from " + t.TableName + " where " + t.OrderField + " >" + thisorder + groupsql + " order by " + t.OrderField;
                    row = DBFactory.GetConn().exeRow(nextsql);
                }
                else
                {
                    nextsql = "select top 1 " + t.PKFiled + "," + t.OrderField + " from " + t.TableName + " where " + t.OrderField + " <" + thisorder + groupsql + " order by " + t.OrderField + " desc";
                    row = DBFactory.GetConn().exeRow(nextsql);
                }
            }
            else
            {
                if (direction.ToLower() == "up")
                {
                    nextsql = "select top 1 " + t.PKFiled + "," + t.OrderField + " from " + t.TableName + " where " + t.OrderField + " >" + thisorder + groupsql + " order by " + t.OrderField;
                    row = DBFactory.GetConn().exeRow(nextsql);
                }
                else
                {
                    nextsql = "select top 1 " + t.PKFiled + "," + t.OrderField + " from " + t.TableName + " where " + t.OrderField + " <" + thisorder + groupsql + " order by " + t.OrderField + " desc";
                    row = DBFactory.GetConn().exeRow(nextsql);
                }
            }
            Response.Write(nextsql);
            
            if (row != null)
            {                
                string nextid = row[t.PKFiled].ToString();
                string nextorder = row[t.OrderField].ToString();

                string gosql = "update " + t.TableName + " set " + t.OrderField + "=" + thisorder + " where " + t.PKFiled + "=" + nextid + ";update " + t.TableName + " set " + t.OrderField + "=" + nextorder + " where " + t.PKFiled + "=" + id;
                Response.Write(gosql);
                DBFactory.GetConn().exe0(gosql);
            }
        }
        //catch (Exception ex)
        {
            //throw new Exception(ex.Message);
        }        
        
        Response.Redirect(Request.UrlReferrer.ToString());
    }
}
