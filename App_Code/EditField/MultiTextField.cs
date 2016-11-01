using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///MultiTextField 的摘要说明
/// </summary>
public class MultiTextField : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }
    public MultiTextField(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        TextBox txt = new TextBox();
        txt.ID = this.ID + "_value";
        txt.CssClass = "TextBox";
        txt.ValidationGroup = "modify";
        txt.Text = v;
        txt.TextMode = TextBoxMode.MultiLine;
        txt.Rows = 5;
        txt.Columns = 60;
        if (!string.IsNullOrEmpty(c.StringFormat))
        {
            txt.Text = string.Format(c.StringFormat, txt.Text);
        }
        cell2.Controls.Add(txt);

        if (c.Required)
        {
            cell2.Controls.Add(Validatas.GetRequired(c));
        }
        if (c.Range)
        {
            cell2.Controls.Add(Validatas.GetRange(c));
        }
	}
}
