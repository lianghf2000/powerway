using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///DateTimeField 的摘要说明
/// </summary>
public class DateTimeField : WebControl
{

    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }

    public DateTimeField(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        TextBox txt = new TextBox();
        txt.ID = this.ID + "_value";
        txt.CssClass = "DateTime";
        txt.ValidationGroup = "modify";
        if (!string.IsNullOrEmpty(v))
        {
            txt.Text = v;
        }
        else
        {
            txt.Text = DateTime.Now.ToString();
        }
        txt.ReadOnly = true;
        
        string scripttxt = "$(document).ready(function() {Date.format = 'yyyy-mm-dd';$(function(){$('#" + c.ColumnName + "_value" + "').datePicker({ startDate: '1996-01-01' });});});";
        //string scripttxt = "$(document).ready(function() {$(\"#" + c.ColumnName + "_values\").datepicker();}";
        Literal lit = Builder.GetScirpt(c,scripttxt);

        if (!string.IsNullOrEmpty(c.StringFormat))
        {
            txt.Text = string.Format(c.StringFormat, DateTime.Parse(txt.Text));
        }
        else
        {
            txt.Text = DateTime.Parse(txt.Text).ToString();
        }
        cell2.Controls.Add(txt);
        //cell2.Controls.Add(btn);
        //cell2.Controls.Add(html);
        cell2.Controls.Add(lit);

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
