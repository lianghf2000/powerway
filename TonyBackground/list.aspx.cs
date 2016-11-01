using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Collections;

public partial class adminlontro_list : System.Web.UI.Page
{
    public string PkFiled;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.searchKey.Focus();
        if (Request.Cookies["admin"] == null || string.IsNullOrEmpty(Request.Cookies["admin"].Value))
        {
            Response.Write("<script>top.location.href='default.aspx';</script>");
            Response.End();
        }
        //this.script.Text = string.Empty;
        if (!Page.IsPostBack)
        {
            this.ImageButton3.Attributes.Add("onclick", "return confirm('确定删除?')");
            //string table = "Content";
            string table = Request.QueryString["t"];
            Table t = new Table(table);
            PkFiled = t.PKFiled;
            string searchStr = string.Empty;
            string menu = Request.QueryString["m"];
            if (!string.IsNullOrEmpty(Request.QueryString["s"]))
            {
                searchStr = Request.QueryString["s"];
                this.searchKey.Text = searchStr;
            }
            string treeStr = "";
            if (!string.IsNullOrEmpty(Request.QueryString["p"]))
            {
                treeStr = Request.QueryString["p"];
            }

            int pagesize = 10;
            int nowpage = 0;
            try
            {
                nowpage = int.Parse(Request.QueryString["page"]);
            }
            catch (Exception ex)
            { }

            int RecCount;
            UIHelper.SetupGrid(table, this.GridView1, searchStr, treeStr, pagesize, nowpage, out RecCount);
            PagerHelper pager = new PagerHelper();
            pager.FirstTemplate = "第一页";
            pager.PrewTemplate = "上一页";
            pager.NextTemplate = "下一页";
            pager.LastTemplate = "最后页";
            pager.QueryString = "&t="+table+"&s="+searchStr+"&p="+treeStr+"&m="+menu;
            this.pager.Text = pager.GetPagerString(RecCount, pagesize, nowpage);

            if (!string.IsNullOrEmpty(t.TreeColumn))
            {
                if (!string.IsNullOrEmpty(treeStr))
                {
                    this.addlink.NavigateUrl = "edit.aspx?t=" + table + "&type=add&p=" + treeStr + "&m=" + menu;
                }
                else
                {
                    this.addlink.Visible = false;
                }
            }
            else
            {
                this.addlink.NavigateUrl = "edit.aspx?t=" + table + "&type=add&p=" + treeStr + "&m=" + menu;
            }
            if (!string.IsNullOrEmpty(menu) && (menu!=table))
            {
                this.menulink.NavigateUrl = "menu.aspx?mt=" + menu + "&ct=" + table;
            }
            else
            {
                this.menulink.Visible = false;
            }
            
            if ((!string.IsNullOrEmpty(menu)) && (new Table(menu)).AddChildDepth != 0)
            {
                this.addmenulink.NavigateUrl = "edit.aspx?id=0&type=add&f=menu&t=" + menu;
            }
            else
            {
                this.addmenulink.Visible = false;
            }
            this.listlink.NavigateUrl = "list.aspx?t="+table+"&m="+menu+"&p="+Request.QueryString["p"];


            int pid=0;
            try
            {
                pid=int.Parse(treeStr);
            }
            catch(Exception ex)
            {}
            try
            {
                this.Literal1.Text = UIHelper.Location(menu, pid);
            }
            catch (Exception ex)
            {
                this.Literal1.Text += "→全部信息";
            }
            //string thisNodeName = this.Literal1.Text.Split('→')[this.Literal1.Text.Split('→').Length - 1];
            //this.addlink.Text += thisNodeName;
            //this.listlink.Text = thisNodeName + this.listlink.Text;
            if (!t.AllowAddContent)
            {
                this.addlink.Visible = false;
            }            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(Request.Form["SelectThis"]);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string t = Request.QueryString["t"];
        string m = Request.QueryString["m"];
        string s = Request.QueryString["s"];
        string p = Request.QueryString["p"];
        Response.Redirect("list.aspx?t=" + t + "&p=" + p + "&s=" + this.searchKey.Text + "&m=" + m);
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
}
