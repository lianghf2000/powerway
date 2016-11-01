using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_setbool : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string t = Request.QueryString["t"];
        string c = Request.QueryString["c"];
        string id = Request.QueryString["id"];
        int intid = 0;
        if (!int.TryParse(id, out intid))
        {
            id = "'" + id + "'";
        }
        Table tt = new Table(t);

        string savedatesql = "select count(*) from information_schema.columns where table_name = N'" + tt.TableName + "' and column_name='" + c + "_date'";
        string cnt = DBFactory.GetConn().exe1(savedatesql);
        string setdate = string.Empty;
        if (Convert.ToInt32(cnt) > 0)
        {
            bool nowvalue = bool.Parse(DBFactory.GetConn().exe1("select " + c + " from " + tt.TableName + " where " + tt.PKFiled + "=" + id));

            setdate = "," + c + "_date=" + ((nowvalue) ? "null" : "'"+DateTime.Now.ToString()+"'");
        }

        string sql = "update " + tt.TableName + " set " + c + "=(" + c + "+1)%2 "+setdate+" where " + tt.PKFiled + "=" + id;
        DBFactory.GetConn().exe0(sql);
        Response.Redirect(Request.UrlReferrer.ToString());
    }
}
