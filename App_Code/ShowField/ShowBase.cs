using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///ShowBase 的摘要说明
/// </summary>
public abstract class ShowBase : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }

    public ShowBase(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];       
        cell2.Controls.Add(getContrl(c,v));
	}

    public abstract Control getContrl(Column c, string v);
    
}
