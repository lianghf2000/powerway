using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///CheckField 的摘要说明
/// </summary>
public class CheckField : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }
	public CheckField(Column c,string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        CheckBox check = new CheckBox();
        check.ID = c.ColumnName + "_value";
        bool value = false;
        bool.TryParse(v, out value);
        check.Checked = value;
        check.CssClass = "CheckBox";

        cell2.Controls.Add(check);
	}
}
