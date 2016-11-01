using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///TemplateField 的摘要说明
/// </summary>
public class TemplateFields : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }
    public TemplateFields(Column c, string v,Control ctrl)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        HiddenField hide = new HiddenField();
        hide.Value = v;
        hide.ID = c.ColumnName + "_hide";
        ctrl.ID = c.ColumnName + "_template";
        cell2.Controls.Add(hide);
        cell2.Controls.Add(ctrl);        

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
