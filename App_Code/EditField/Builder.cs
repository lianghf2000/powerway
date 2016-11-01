using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///Builder 的摘要说明
/// </summary>
public class Builder
{
    public static Label GetLabel(Column c)
    {
        Label lbl = new Label();
        lbl.ID = c.ColumnName + "_lbl";
        lbl.CssClass = "CaptionCss";
        lbl.Text = c.EditShowName;
        return lbl;
    }

    public static Panel GetPanel(Column c)
    {
        Panel p = new Panel();
        p.ID = c.ColumnName + "_panel";
        p.Controls.Add(Builder.GetTable(c));
        return p;
    }
    public static System.Web.UI.WebControls.Table GetTable(Column c)
    {
        System.Web.UI.WebControls.Table tab = new System.Web.UI.WebControls.Table();
        tab.ID = c.ColumnName + "_tab";
        tab.CssClass = "TableCss";
        tab.Rows.Add(Builder.GetRow(c));
        return tab;
    }
    public static TableRow GetRow(Column c)
    {
        TableRow row = new TableRow();
        row.ID = c.ColumnName + "_row";
        row.CssClass = "TableRowCss";
        row.Cells.Add(Builder.GetCell1(c));
        row.Cells.Add(Builder.GetCell2(c));
        return row;
    }
    public static TableCell GetCell1(Column c)
    {
        TableCell cell = new TableCell();
        cell.ID = c.ColumnName + "_cell1";
        cell.CssClass = "leftCellCss";
        cell.Controls.Add(Builder.GetLabel(c));
        return cell;
    }
    public static TableCell GetCell2(Column c)
    {
        TableCell cell = new TableCell();
        cell.ID = c.ColumnName + "_cell2";
        cell.CssClass = "rightCellCss";
        return cell;
    }

    public static Literal GetScirpt(Column c,string script)
    {
        Literal lit = new Literal();
        lit.ID = c.ColumnName + "_script";
        lit.Text = "<script language=\"javascript\">" + script + "</script>";
        return lit;
    }

    public static Literal GetHTML(Column c, string html,int i)
    {
        Literal lit = new Literal();
        lit.ID = c.ColumnName + "_html_" + i.ToString();
        lit.Text = html;
        return lit;
    }
}
