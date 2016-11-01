using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
///CheckListField 的摘要说明
/// </summary>
public class CheckListField : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }

    public CheckListField(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];

        string html = string.Empty;

        DataTable tab = DBFactory.GetConn().exeTable(c.SqlText);
        int i = 0;
        string[] vs = v.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (DataRow row in tab.Rows)
        {
            string check = string.Empty;
            foreach (string s in vs)
            {
                if (s == row[c.DataValueField].ToString())
                {
                    check = "checked";
                    break;
                }
            }
            html += "<input id='" + c.ColumnName + "_value" + i.ToString() + "' name='" + c.ColumnName + "_value" + "' type=\"checkbox\" "+check+" value='"+row[c.DataValueField].ToString()+"' />"+row[c.DataTextField]+"&nbsp;";

            i++;
        }

        Literal lit = Builder.GetHTML(c,html,0);
        cell2.Controls.Add(lit);
	}
}
