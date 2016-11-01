using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
/// <summary>
///HideFK 的摘要说明
/// </summary>
public class HideFK:ShowBase
{
	public HideFK(Column c,string v):base(c,v)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public override System.Web.UI.Control getContrl(Column c, string v)
    {
        string sql = "select " + c.DataTextField + " from " + c.ForeignTable + " where " + c.DataValueField + "=" + v;

        Literal lit = new Literal();
        try
        {
            lit.Text = DBFactory.GetConn().exe1(sql);
        }
        catch (Exception ex)
        { }
        return lit;
    }
}
