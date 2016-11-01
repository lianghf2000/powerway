using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///BoolLinkField 的摘要说明
/// </summary>
public class BoolLinkField : HyperLinkField
{
	public BoolLinkField()
	{
		
	}

    public string TrueText
    {
        get
        {
            object o = ViewState["TrueText"];
            if (o != null)
                return (string)o;
            return "是";
        }
        set
        {
            if (!String.Equals(value, ViewState["TrueText"]))
            {
                ViewState["TrueText"] = value;
            }
        }
    }
    public string FalseText
    {
        get
        {
            object o = ViewState["FalseText"];
            if (o != null)
                return (string)o;
            return "否";
        }
        set
        {
            if (!String.Equals(value, ViewState["FalseText"]))
            {
                ViewState["FalseText"] = value;
            }
        }
    }

    protected override string FormatDataTextValue(object dataTextValue)
    {
        bool state = false;
        bool.TryParse(dataTextValue.ToString(), out state);
        return state ? this.TrueText : this.FalseText;
        //return base.FormatDataTextValue(dataTextValue);
    }
}
