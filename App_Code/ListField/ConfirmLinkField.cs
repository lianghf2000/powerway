using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
/// <summary>
///ConfirmLinkField 的摘要说明
/// </summary>
public class ConfirmLinkField:HyperLinkField
{
	public ConfirmLinkField()
	{
		
	}

    public string ConfirmText
    {
        get
        {
            object o = ViewState["ConfirmText"];
            if (o != null)
                return (string)o;
            return "确认?";
        }
        set
        {
            if (!String.Equals(value, ViewState["ConfirmText"]))
            {
                ViewState["ConfirmText"] = value;                
            }
        }
    }

    public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
    {
        base.InitializeCell(cell, cellType, rowState, rowIndex);
        if (cellType == DataControlCellType.DataCell)
        {
            HyperLink link = cell.Controls[0] as HyperLink;
            if (link != null)
            {
                link.Attributes.Add("onclick", "javascript:return confirm('"+this.ConfirmText+"');");
            }
        }
    }
}
