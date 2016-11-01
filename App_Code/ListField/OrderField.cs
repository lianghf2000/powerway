using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///OrderField 的摘要说明
/// </summary>
public class OrderField:BoundField
{
	public OrderField()
	{
		
	}

    public string UpText
    {
        get
        {
            object o = ViewState["UpText"];
            if (o != null)
                return (string)o;
            return "上";
        }
        set
        {
            if (!String.Equals(value, ViewState["UpText"]))
            {
                ViewState["UpText"] = value;
            }
        }
    }
    public string DownText
    {
        get
        {
            object o = ViewState["DownText"];
            if (o != null)
                return (string)o;
            return "下";
        }
        set
        {
            if (!String.Equals(value, ViewState["DownText"]))
            {
                ViewState["DownText"] = value;
            }
        }
    }

    protected override string FormatDataValue(object dataValue, bool encode)
    {
        //return base.FormatDataValue(dataValue, encode);

        string html = "<a href='goup.aspx?id='>上</a> <a href='godown.aspx?id='>下</a>";

        return html;
    }
}
