using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///TextField 的摘要说明
/// </summary>
public class TextField:WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }

	public TextField(Column c,string v)
	{
        this.ID = c.ColumnName;        
        
        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        TextBox txt = new TextBox();
        txt.ID = this.ID + "_value";
        txt.CssClass = "TextBox";
        txt.ValidationGroup = "modify";
        txt.Text = v;
        if (c.ImgWidth != 0)
        {
            txt.Width = new Unit(c.ImgWidth);
        }
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
