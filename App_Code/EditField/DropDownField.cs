using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
///DropDownList 的摘要说明
/// </summary>
public class DropDownField : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }

    public DropDownField(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        string html = "<select id='" + c.ColumnName + "_value" + "' name='" + c.ColumnName + "_value" + "'>";
        DataTable tab = DBFactory.GetConn().exeTable(c.SqlText);
        if (!c.Required)
        {
            html += "<option value=''>请选择</option>";
        }
        foreach (DataRow row in tab.Rows)
        {
            html += "<option value='"+row[c.DataValueField].ToString()+"' "+((row[c.DataValueField].ToString()==v)?"selected":"")+">"+row[c.DataTextField].ToString()+"</option>";
        }
        html += "</select>";
        Literal lit = Builder.GetHTML(c, html, 0);
        cell2.Controls.Add(lit);
	}
}
