using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class testsql : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=TonyDB;User ID=sa;password=asdf1234;");
        conn.Open();
        SqlCommand comm = new SqlCommand("select top 1 * from spt_values", conn);
        int affect = comm.ExecuteNonQuery();
        comm.Dispose();
        conn.Close();
        Response.Write(affect);

        if (!IsPostBack)
        {
            CheckBoxList1.DataSource = DBFactory.GetConn().exeTable("select [id],[typename] from [countryType] where [pid]=0 order by [orderid]");
            CheckBoxList1.DataTextField = "typename";
            CheckBoxList1.DataValueField = "id";
            CheckBoxList1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList1.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Value + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        Response.Write(strValue);
    }
}