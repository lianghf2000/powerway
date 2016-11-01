using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///ShowFieldFactory 的摘要说明
/// </summary>
public class ShowFieldFactory
{
    public static Panel GetEditColumn(string ShowType, Column c, string v)
    {
        if (ShowType == EditShowType.picUpload.ToString())
        {
            ImgShow show = new ImgShow(c, v);
            return show.Panel;
        }
        else if (ShowType==EditShowType.CheckList.ToString() || ShowType== EditShowType.DropDownList.ToString() || ShowType==EditShowType.RadioList.ToString())
        {
            FkShow show = new FkShow(c, v);
            return show.Panel;
        }
        else if (ShowType == EditShowType.Hidden.ToString())
        {
            HideFK show = new HideFK(c, v);
            return show.Panel;
        }
        else
        {
            TextShow show = new TextShow(c, v);
            return show.Panel;
        }
    }
}
