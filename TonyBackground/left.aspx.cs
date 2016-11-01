using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class TonyBackground_left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin"] == null || string.IsNullOrEmpty(Request.Cookies["admin"].Value))
        {
			Response.Write("<script>top.location.href='login.aspx';</script>");
            Response.End();
        }
        this.Literal2.Text = Request.Cookies["admin"].Value;

        

        //string sql = "select Name from sysobjects where xtype='u' and status>=0 order by name";
        //this.GridView1.DataSource = DBFactory.GetConn().exeTable(sql);
        //this.GridView1.DataBind();

        string filepath = Server.MapPath("~/config/menu.xml");
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(filepath);
        XmlNodeList list = xdoc.GetElementsByTagName("Menu");

        List<Menu> lists = new List<Menu>();
        foreach (XmlNode node in list)
        {
            if (node.Attributes["Parent"].Value == "root")
            {
                Menu m = new Menu(node);
                lists.Add(m);
            }
        }
        this.DataList1.DataSource = lists;
        this.DataList1.DataBind();

       
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HiddenField hide = e.Item.FindControl("hide") as HiddenField;
        TreeView tree = e.Item.FindControl("tree") as TreeView;

        if (hide != null && tree!=null)
        {
            string id = hide.Value;

            string filepath = Server.MapPath("~/config/menu.xml");
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filepath);

            XmlNode node = xdoc.DocumentElement.SelectSingleNode("descendant::Menu[@id='" + id + "']");

            Menu mm = new Menu(node);
            if (mm.ShowChild)
            {
                //从数据库读取，添加树结点
                mm.AppendAllChildFromDB(tree);
            }

            //从xml读取
            mm.AppendAllChildFromXml(tree,hide.Value);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Cookies.Clear();
        Response.Cookies["admin"].Value = string.Empty;
		Response.Write("<script>top.location.href='login.aspx'</script>");
        Response.End();
    }
}
