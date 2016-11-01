using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///EditorField 的摘要说明
/// </summary>
public class EditorField : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }
    public EditorField(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];

        FredCK.FCKeditorV2.FCKeditor editor = new FredCK.FCKeditorV2.FCKeditor();
        editor.ID = c.ColumnName + "_value";
        editor.Value = v;
        editor.Height = 460;

        
        cell2.Controls.Add(editor);//把编辑器对象添加到页面上。

        if (c.Required)
        {
            cell2.Controls.Add(Validatas.GetRequired(c));
        }        
	}
}
