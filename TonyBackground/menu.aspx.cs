using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_menu : System.Web.UI.Page
{
    public string PkFiled;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin"] == null || string.IsNullOrEmpty(Request.Cookies["admin"].Value))
        {
            Response.Write("<script>top.location.href='default.aspx';</script>");
            Response.End();
        }

        if (!Page.IsPostBack)
        {            
            string mt = Request.QueryString["mt"];
            string ct = Request.QueryString["ct"];
            Table t = new Table(mt);
            PkFiled = t.PKFiled;

            UIHelper.SetupMenuGrid(mt, this.GridView1);

            if (t.AddChildDepth != 0)
            {
                this.addmenulink.NavigateUrl = "edit.aspx?id=0&type=add&f=menu&t=" + mt;
            }
            else
            {
                this.addmenulink.Visible = false;
            }
            this.menulink.NavigateUrl = "menu.aspx?mt=" + mt + "&ct="+ct;
            this.listlink.NavigateUrl = "list.aspx?t=" + ct + "&p=&m=" + mt;

            this.Literal1.Text += "→分类管理";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(Request.Form["SelectThis"]);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            LogicHelper.DeleteMore(Request.QueryString["t"], Request.Form["SelectThis"]);
            Response.Redirect(Request.Url.ToString());
        }
        catch (NullReferenceException ex)
        {
            this.script.Text = "<script>alert ('您没有选择')</script>";
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            LogicHelper.SetBoolMore(Request.QueryString["t"], Request.Form["SelectThis"], "ischeck", 1);
            Response.Redirect(Request.Url.ToString());
        }
        catch (NullReferenceException ex)
        {
            this.script.Text = "<script>alert ('您没有选择')</script>";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string str = e.Row.Cells[1].Text.Split('+')[0];
            str = str.Replace("┌", "<img src='images/1.gif' border='0' />");
            str = str.Replace("│", "<img src='images/2.gif' border='0' />");
            str = str.Replace("├", "<img src='images/3.gif' border='0' />");
            str = str.Replace("└", "<img src='images/4.gif' border='0' />");
            str = str.Replace("_", "&nbsp;&nbsp;");
            e.Row.Cells[2].Text = str + e.Row.Cells[2].Text;

            string mt = Request.QueryString["mt"];
            string ct = Request.QueryString["ct"];
            Table t = new Table(mt);
            if (t.AddChildDepth != 1 && t.AddChildDepth!=0)
            {
                int depth = 0;
                try
                {
                    depth = int.Parse(e.Row.Cells[1].Text.Split('+')[1]);

                    if (t.AddChildDepth != -1)
                    {
                        if (depth >= t.AddChildDepth-1)
                        {
                            //添加屏蔽
                            e.Row.Cells[e.Row.Cells.Count - 3].Enabled = false;
                            e.Row.Cells[e.Row.Cells.Count - 3].Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        this.GridView1.Columns[1].Visible = false;
    }
}
