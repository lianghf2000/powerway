using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///ListFieldFactory 的摘要说明
/// </summary>
public class ListFieldFactory
{
    public static DataControlField GetListField(string ShowType,string Table,string Column)
    {
        Table t = new Table(Table);
        Column c = t.GetColumns(Column);
        if (ShowType == ListShowType.Link.ToString())
        {
            HyperLinkField field = new HyperLinkField();
            field.Text = c.LinkText;
            field.DataNavigateUrlFields = c.UrlField.Split(',');
            field.DataNavigateUrlFormatString = c.LinkUrl;
            field.HeaderText = c.ListShowName;
            return field;
        }
        else if (ShowType == ListShowType.BoundLink.ToString())
        {
            HyperLinkField field = new HyperLinkField();
            field.DataTextField = c.ColumnName;
            field.DataNavigateUrlFields = c.UrlField.Split(',');
            field.DataNavigateUrlFormatString = c.LinkUrl;
            field.HeaderText = c.ListShowName;
            field.DataTextFormatString = c.StringFormat;
            return field;
        }
        else if (ShowType == ListShowType.Foreign.ToString())
        {
            HyperLinkField field = new HyperLinkField();
            field.DataTextField = c.ColumnName + "_Foreign";
            field.DataNavigateUrlFields = c.UrlField.Split(',');
            if (!string.IsNullOrEmpty(c.LinkUrl))
            {
                field.DataNavigateUrlFormatString = c.LinkUrl;
            }
            else
            {
                field.DataNavigateUrlFormatString = "list.aspx?t=" + c.Table.TableName + "&p={0}&m="+c.ForeignTable;
            }
            field.HeaderText = c.ListShowName;
            field.DataTextFormatString = c.StringFormat;
            return field;
        }
        else if (ShowType == ListShowType.Pic.ToString())
        {
            ImageField field = new ImageField();
            field.HeaderText = c.ListShowName;
            field.DataImageUrlField = c.ColumnName;
            field.DataImageUrlFormatString = c.StringFormat;
            int height = c.ImgHeight;
            height = (height > 50) ? 50 : height;
            field.ControlStyle.Height = new Unit(height);
            return field;
        }
        else if (ShowType == ListShowType.ConfirmLink.ToString())
        {
            ConfirmLinkField field = new ConfirmLinkField();
            field.HeaderText = c.ListShowName;
            if (string.IsNullOrEmpty(c.LinkText))
            {
                field.DataTextField = c.ColumnName;
                field.DataTextFormatString = c.StringFormat;
            }
            else
            {
                field.Text = c.LinkText;
            }
            field.DataNavigateUrlFields = c.UrlField.Split(',');
            field.DataNavigateUrlFormatString = c.LinkUrl;
            field.ConfirmText = c.ConfirmText;

            return field;
        }
        else if (ShowType == ListShowType.BoolLink.ToString())
        {
            BoolLinkField field = new BoolLinkField();
            field.DataTextField = c.ColumnName;
            field.HeaderText = c.ListShowName;
            field.TrueText = c.TrueText;
            field.FalseText = c.FalseText;
            field.DataNavigateUrlFields = c.UrlField.Split(',');
            field.DataNavigateUrlFormatString = c.LinkUrl;

            return field;
        }
        else if (ShowType == ListShowType.Template.ToString())
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                TemplateField field = new TemplateField();
                field.HeaderText = c.ListShowName;
                field.ItemTemplate = page.LoadTemplate(c.ListTemplate);

                return field;
            }
            else
            {
                BoundField field = new BoundField();
                field.DataField = c.ColumnName;
                field.HeaderText = c.ListShowName;
                field.DataFormatString = c.StringFormat;
                return field;
            }
        }
        else if (ShowType == ListShowType.Hidden.ToString())
        {
            BoundField field = new BoundField();
            field.DataField = c.ColumnName;
            field.HeaderText = c.ListShowName;
            field.DataFormatString = c.StringFormat;
            field.Visible = false;
            return field;
        }
        else //(ShowType == ListShowType.Text.ToString())
        {
            BoundField field = new BoundField();
            field.DataField = c.ColumnName;
            field.HeaderText = c.ListShowName;
            field.DataFormatString = c.StringFormat;
            return field;
        }
    }
}
