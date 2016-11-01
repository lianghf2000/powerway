using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///EditFieldFactory 的摘要说明
/// </summary>
public class EditFieldFactory
{
    public static Panel GetEditColumn(string ShowType,Column c,string v)
    {
        if (ShowType == EditShowType.Text.ToString())
        {
            TextField field = new TextField(c,v);
            
            return field.Panel;            
        }
        else if (ShowType == EditShowType.DateTime.ToString())
        {
            DateTimeField field = new DateTimeField(c,v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.Check.ToString())
        {
            CheckField field = new CheckField(c,v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.DropDownList.ToString())
        {
            DropDownField field = new DropDownField(c, v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.CheckList.ToString())
        {
            CheckListField field = new CheckListField(c, v);
            return field.Panel;
        }
        else if (ShowType== EditShowType.RadioList.ToString())
        {
            RadioListField field = new RadioListField(c, v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.picUpload.ToString())
        {
            UploadImgField field = new UploadImgField(c, v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.MultiText.ToString())
        {
            MultiTextField field = new MultiTextField(c, v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.Editor.ToString())
        {
            EditorField field = new EditorField(c, v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.docUpload.ToString())
        {
            UploadFileField field = new UploadFileField(c,v);
            return field.Panel;
        }
        else if (ShowType == EditShowType.Hidden.ToString())
        {
            Panel p = new Panel();
            HiddenField field = new HiddenField();
            field.ID = c.ColumnName + "_value";
            field.Value = v;
            p.Controls.Add(field);
            return p;
        }
        else if (ShowType == EditShowType.Template.ToString())
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                Control ctrl = page.LoadControl(c.EditTempLate);

                TemplateFields field = new TemplateFields(c, v, ctrl);
                return field.Panel;
            }
            else
            {
                return null;
            }
        }
        else
        {
            TextField field = new TextField(c, v);

            return field.Panel;
        }
    }
}
