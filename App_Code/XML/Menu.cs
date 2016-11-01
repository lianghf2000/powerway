using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
///Menu 的摘要说明
/// </summary>
public class Menu
{
    baseClassSql bc = new baseClassSql();
	public Menu()
	{
		
	}

    public Menu(XmlNode node)
    {
        this.Name = node.Attributes["Name"].Value;
        this.Parent = node.Attributes["Parent"].Value;
        this.Table = node.Attributes["Table"].Value;
        this.Url = node.Attributes["Url"].Value;
        this.ShowChild = bool.Parse(node.Attributes["ShowChild"].Value);
        this.ID = node.Attributes["id"].Value;
        this.IDColumn = node.Attributes["IDColumn"].Value;
        this.ParentIDColumn = node.Attributes["ParentIDColumn"].Value;
        this.ShowColumn = node.Attributes["ShowColumn"].Value;
        this.contenttable = node.Attributes["ContentTable"].Value;
        try
        {
            this.isspector = bool.Parse(node.Attributes["IsSpector"].Value);
        }
        catch (Exception ex)
        { }
    }

    private bool isspector=false;
    public bool IsSpector
    {
        get { return this.isspector; }
        set { this.isspector = value; }
    }

    private string id;
    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    private string contenttable;
    public string ContentTable
    {
        get { return this.contenttable; }
        set { this.contenttable = value; }
    }

    private string name;
    public string Name
    { 
        get { return this.name; }
        set { this.name = value; }
    }

    private string table;
    public string Table
    {
        get { return this.table; }
        set { this.table = value; }
    }
    private string parent;
    public string Parent
    {
        get { return this.parent; }
        set { this.parent = value; }
    }
    private string url;
    public string Url
    {
        get { return this.url; }
        set { this.url = value; }
    }
    private bool showchild;
    public bool ShowChild
    {
        get { return this.showchild; }
        set { this.showchild = value; }
    }

    private string idcolumn;
    public string IDColumn
    {
        get { return this.idcolumn; }
        set { this.idcolumn = value; }
    }
    private string showcolumn;
    public string ShowColumn
    {
        get { return this.showcolumn; }
        set { this.showcolumn = value; }
    }

    private string parentidcolumn;
    public string ParentIDColumn
    {
        get { return this.parentidcolumn; }
        set { this.parentidcolumn = value; }
    }
        
    public List<Menu> Child
    {
        get 
        {
            string filepath =HttpContext.Current.Server.MapPath("~/config/menu.xml");
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filepath);

            XmlNodeList list = xdoc.GetElementsByTagName("Menu");

            List<Menu> child = new List<Menu>();
            foreach (XmlNode node in list)
            {
                if (node.Attributes["Parent"].Value == this.id)
                {
                    Menu m = new Menu(node);                    

                    child.Add(m);
                }
            }
            return child;
        }
    }

    public void AppendAllChildFromDB(TreeView tree)
    {
        if (this.ShowChild)
        {
            AppendRootChildFromDB(tree);    
        }
    }

    private void AppendRootChildFromDB(TreeView tree)
    {
        string sql = "select * from " + this.Table + " where " + this.ParentIDColumn + "=0";
        Table tab = new Table(this.Table);
        if ((!string.IsNullOrEmpty(tab.SelectOrder.Trim())))
        {
            if (tab.SelectOrder.Trim().ToLower().StartsWith("order by"))
            {
                sql += " " + tab.SelectOrder;
            }
            else
            {
                sql += " order by " + tab.SelectOrder;
            }
        }

        //DataTable tab1 = DBFactory.GetConn().exeTable(sql);

        DataSet dt = bc.GetDataSet(sql);

        foreach (DataRow row in dt.Tables[0].Rows)
        {
            TreeNode node = new TreeNode();
            node.Text = row[this.ShowColumn].ToString();
            node.Value = row[this.idcolumn].ToString();
            if (this.Table.ToLower() == "menutype" || this.Table.ToLower() == "navtype" || this.Table.ToLower() == "newstype")
            {
                if (row["ispage"] != null && row["ispage"].ToString().ToLower() == "true")
                {
                    node.NavigateUrl = "edit.aspx?id=" + row[this.IDColumn] + "&t=" + this.Table + "&p=" + row["pid"].ToString() + "&m=" + this.ContentTable;
                }
                else
                {
                    node.NavigateUrl = "list.aspx?t=" + this.ContentTable + "&p=" + row[this.IDColumn].ToString() + "&m=" + this.Table;
                }
            }
            else
            {
                node.NavigateUrl = "list.aspx?t=" + this.ContentTable + "&p=" + row[this.IDColumn].ToString() + "&m=" + this.Table;
            }
            //node.NavigateUrl = "list.aspx?t=" + this.ContentTable + "&p=" + row[this.IDColumn].ToString()+"&m="+this.Table;
            node.Target = "main";            
            tree.Nodes.Add(node);
            AppendChildFromDB(node, row[this.IDColumn].ToString());
        }
    }

    private void AppendChildFromDB(TreeNode thisnode, string pid)
    {
        string sql = "select * from " + this.Table + " where " + this.ParentIDColumn + "="+pid;
        Table tab = new Table(this.Table);
        if ((!string.IsNullOrEmpty(tab.SelectOrder.Trim())))
        {
            if (tab.SelectOrder.Trim().ToLower().StartsWith("order by"))
            {
                sql += " " + tab.SelectOrder;
            }
            else
            {
                sql += " order by " + tab.SelectOrder;
            }
        }
        //DataTable tab1 = DBFactory.GetConn().exeTable(sql);

        DataSet dt = bc.GetDataSet(sql);

        foreach (DataRow row in dt.Tables[0].Rows)
        {
            TreeNode node = new TreeNode();
            node.Text = row[this.ShowColumn].ToString();
            node.Value = row[this.idcolumn].ToString();

            if (this.Table.ToLower() == "menutype" || this.Table.ToLower() == "navtype" || this.Table.ToLower() == "newstype")
            {
                if (row["ispage"] != null && row["ispage"].ToString().ToLower() == "true")
                {
                    node.NavigateUrl = "edit.aspx?id=" + row[this.IDColumn] + "&t=" + this.Table + "&p=" + row["pid"].ToString() + "&m=" + this.ContentTable;
                }
                else
                {
                    node.NavigateUrl = "list.aspx?t=" + this.ContentTable + "&p=" + row[this.IDColumn].ToString() + "&m=" + this.Table;
                }
            }
            else
            {
                node.NavigateUrl = "list.aspx?t=" + this.ContentTable + "&p=" + row[this.IDColumn].ToString() + "&m=" + this.Table;
            }
            node.Target = "main";

            thisnode.ChildNodes.Add(node);
            AppendChildFromDB(node, row[this.IDColumn].ToString());
        }
        if (thisnode.ChildNodes.Count > 0)
        {
            thisnode.NavigateUrl = null;
            thisnode.SelectAction = TreeNodeSelectAction.Expand;
        }
        else
        {
            thisnode.SelectAction = TreeNodeSelectAction.Select;
        }
    }

    public void AppendAllChildFromXml(TreeView tree,string pid)
    {
        AppenRootChildFromXml(tree,pid);
    }
    private void AppenRootChildFromXml(TreeView tree,string pid)
    {
        string filepath = HttpContext.Current.Server.MapPath("~/config/menu.xml");
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(filepath);

        XmlNodeList list = xdoc.DocumentElement.SelectSingleNode("descendant::Menu[@id='" + pid + "']").ChildNodes;
        foreach (XmlNode n in list)
        {
            if (n.Attributes["Parent"].Value == pid)
            {
                TreeNode no = new TreeNode();
                no.Text = n.Attributes["Name"].Value;
                no.Value = n.Attributes["id"].Value;
                no.NavigateUrl = n.Attributes["Url"].Value;
                no.Target = "main";
                tree.Nodes.Add(no);
                AppendChildFromXml(no, n.Attributes["id"].Value);
            }
        }
    }
    private void AppendChildFromXml(TreeNode node, string pid)
    {
        string filepath = HttpContext.Current.Server.MapPath("~/config/menu.xml");
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(filepath);

        XmlNodeList list = xdoc.DocumentElement.SelectSingleNode("descendant::Menu[@id='" + pid + "']").ChildNodes;
        foreach (XmlNode n in list)
        {
            if (n.Attributes["Parent"].Value == pid)
            {
                TreeNode no = new TreeNode();
                no.Text = n.Attributes["Name"].Value;
                no.Value = n.Attributes["id"].Value;
                no.NavigateUrl = n.Attributes["Url"].Value;
                no.Target = "main";
                node.ChildNodes.Add(no);
                AppendChildFromXml(no, n.Attributes["id"].Value);
            }
        }
        if (node.ChildNodes.Count > 0)
        {
            node.NavigateUrl = null;
            node.SelectAction = TreeNodeSelectAction.Expand;
        }
        else
        {
            node.SelectAction = TreeNodeSelectAction.Select;
        }
    }
}
