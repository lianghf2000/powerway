using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminlontro_show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin"] == null || string.IsNullOrEmpty(Request.Cookies["admin"].Value))
        {
            Response.Write("<script>top.location.href='default.aspx';</script>");
            Response.End();
        }
        //string table = "testNews";
        //string id = "1";

        string table = Request.QueryString["t"];
        string id = Request.QueryString["id"];
        string p = Request.QueryString["p"];
        //string s = Request.QueryString["s"];
        string m = Request.QueryString["m"];
        Table t = new Table(table);
        if (string.IsNullOrEmpty(m))
        {
            m = table;
        }

        this.tableName.Value = table;
        this.thisID.Value = id;

        if (Request.QueryString["f"] != null && !string.IsNullOrEmpty(Request.QueryString["f"]))
        {
            this.Literal2.Text = "分类";
        }
        else
        {
            this.Literal2.Text = "信息";
        }

        this.Literal2.Text += "显示";

        //设置显示
        UIHelper.SetupPanel(table, this.main, this, id,true);
        

        if (!string.IsNullOrEmpty(p))
        {
            this.addlink.NavigateUrl = "edit.aspx?t=" + table + "&type=add&p=" + p + "&m=" + m;
        }
        else
        {
            this.addlink.Visible = false;
        }
        if (!string.IsNullOrEmpty(m) && (m != table))
        {
            this.menulink.NavigateUrl = "menu.aspx?mt=" + m + "&ct=" + table;
        }
        else
        {
            this.menulink.Visible = false;
        }

        if ((!string.IsNullOrEmpty(m)) && (new Table(m)).AddChildDepth != 0)
        {
            this.addmenulink.NavigateUrl = "edit.aspx?id=0&type=add&f=menu&t=" + m;
        }
        else
        {
            this.addmenulink.Visible = false;
        }

        if (t.IsSingle)
        {
            this.listlink.Visible = false;
            this.Literal3.Visible = false;
            this.searchKey.Visible = false;
            this.ImageButton1.Visible = false;
        }
        else
        {
            this.listlink.NavigateUrl = "list.aspx?t=" + table + "&m=" + m + "&p=" + p;
        }

        int pid = 0;
        try
        {
            pid = int.Parse(p);
        }
        catch (Exception ex)
        { }
        try
        {
            this.Literal1.Text = UIHelper.Location(m, pid);
        }
        catch (Exception ex)
        { }
        this.Literal1.Text += " → " + this.Literal2.Text;
    }

    public string GetValue(string columnType, string columnName)
    {
        if (columnType.ToLower() == "int" || columnType.ToLower() == "float")
        {
            return Request.Form[columnName + "_value"];
        }
        else if (columnType.ToLower() == "bit")
        {
            string bitV = Request.Form[columnName + "_value"];
            return (bitV == "on") ? "1" : "0";
        }
        else
        {
            return "'" + Request.Form[columnName + "_value"].Replace("'", "''") + "'";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string t = Request.QueryString["t"];
        string m = Request.QueryString["m"];
        string s = Request.QueryString["s"];
        string p = Request.QueryString["p"];
        string f = Request.QueryString["f"];
        if (!string.IsNullOrEmpty(f))
        {
            Response.Redirect("menu.aspx?mt=" + t + "&p=" + p);
        }
        else
        {
            Response.Redirect("list.aspx?t=" + t + "&p=" + p + "&s=" + this.searchKey.Text + "&m=" + m);
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string t = Request.QueryString["t"];
        string m = Request.QueryString["m"];
        string s = Request.QueryString["s"];
        string p = Request.QueryString["p"];
        string f = Request.QueryString["f"];
        if (!string.IsNullOrEmpty(f))
        {
            Response.Redirect("menu.aspx?mt=" + t + "&p=" + p);
        }
        else
        {
            Response.Redirect("list.aspx?t=" + t + "&p=" + p + "&s=" + this.searchKey.Text + "&m=" + m);
        }
    }
}
