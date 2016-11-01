using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///FkShow 的摘要说明
/// </summary>
public class FkShow:ShowBase
{
	public FkShow(Column c,string v):base(c,v)
	{
		
	}

    public override Control getContrl(Column c, string v)
    {
        string[] arr = v.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        DataTable tab = DBFactory.GetConn().exeTable(c.SqlText);
        string rv = string.Empty;
        foreach (DataRow row in tab.Rows)
        {
            foreach (string str in arr)
            {
                if (row[c.DataValueField].ToString() == str)
                {
                    if (!string.IsNullOrEmpty("rv"))
                    {
                        rv += ",";
                    }
                    rv += row[c.DataTextField].ToString();
                }
            }
        }
        Literal lit = new Literal();
        lit.Text = rv;
        return lit;
        
    }
}
