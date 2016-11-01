using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
///ImgShow 的摘要说明
/// </summary>
public class ImgShow:ShowBase
{
    public ImgShow(Column c, string v):base(c,v)        
    { }

    public override Control getContrl(Column c, string v)
    {
        Image img = new Image();
        int w = 100;
        int h = 100;
        if (c.ImgWidth > 100 && c.ImgWidth < 300)
        {
            w = c.ImgWidth;
        }
        if (c.ImgHeight > 100 && c.ImgHeight < 300)
        {
            h = c.ImgHeight;
        }
        img.Width = w;
        img.Height = h;
        img.ImageUrl = "../uploads/" + v;

        return img;
    }
}
