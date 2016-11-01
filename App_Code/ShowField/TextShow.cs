using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///TextShow 的摘要说明
/// </summary>
public class TextShow :ShowBase{
	

    public TextShow(Column c, string v):base(c,v)
	{
        
	}

    public override System.Web.UI.Control getContrl(Column c, string v)
    {
        Literal txt = new Literal();
        txt.ID = this.ID + "_value";
        txt.Text = v;
        return txt;
    }
}
