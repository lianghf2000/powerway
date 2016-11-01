using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.Collections;

/// <summary>
///UIHelper 的摘要说明
/// </summary>
public class UIHelper
{
	public UIHelper()
	{
		
	}

    private static void SetupMenuSource(string tablename, DataTable sourceTable,int pid,string pcolumn,int depth)
    {
        SortedList<int, Column> columns = new SortedList<int, Column>();
        Table tab = new Table(tablename);
        foreach (Column c in tab.Columns)
        {
            if (c.IsListShow)
            {
                int key = c.ListShowOrder;
                while (columns.ContainsKey(key))
                {
                    key++;
                }
                columns.Add(key, c);
            }
        }

        string sql = "select " + tab.PKFiled;
        foreach (Column c in columns.Values)
        {
            if (sql == "select")
            {
                sql += " " + c.ColumnName;
                if (c.ListShowType == ListShowType.Foreign)
                {
                    string fsql = "(select " + c.DataTextField + " from testnewstype where " + c.DataValueField + "=" + tablename + "." + c.ColumnName + ") as " + c.ColumnName + "_Foreign";
                    sql += "," + fsql;
                }

            }
            else
            {
                sql += "," + c.ColumnName;
                if (c.ListShowType == ListShowType.Foreign)
                {
                    string fsql = "(select " + c.DataTextField + " from " + c.ForeignTable + " where " + c.DataValueField + "=" + tablename + "." + c.ColumnName + ") as " + c.ColumnName + "_Foreign";
                    sql += "," + fsql;
                }
            }            
        }
        sql += " from " + tab.TableName + " where "+pcolumn+"="+pid.ToString();
        if ((!string.IsNullOrEmpty(tab.SelectOrder)) && tab.SelectOrder.Trim().ToLower().StartsWith("order by"))
        {
            sql += " " + tab.SelectOrder;
        }
        else
        {
            sql += " order by " + tab.SelectOrder;
        }        

        DataTable thistab = DBFactory.GetConn().exeTable(sql);
        
        foreach (DataColumn col in thistab.Columns)
        {
            if (!sourceTable.Columns.Contains(col.ColumnName))
            {
                sourceTable.Columns.Add(col.ColumnName);
            }
        }

        foreach (DataRow row in thistab.Rows)
        {            
            List<object> p = new List<object>();
            string temp = depth.ToString();
            if (row == thistab.Rows[0])
            {
                if (depth == 0)
                {
                    temp = "┌";
                }
                else
                {
                    temp = "├";
                }

                if (row == thistab.Rows[thistab.Rows.Count - 1])
                {
                    temp = "└";
                }
            }
            else if (row == thistab.Rows[thistab.Rows.Count - 1])
            {
                temp = "└";
            }
            else
            {
                temp = "├";
            }
            if (depth != 0)
            {
                for (int i = 1; i < depth; i++)
                {
                    temp = "│" + temp;
                }
                temp = "│" + temp;
            }
            temp += "+"+depth.ToString();
            p.Add(temp);
            foreach (DataColumn c in thistab.Columns)
            {
                string str = row[c.ColumnName].ToString();                
                p.Add(str);
            }
            sourceTable.Rows.Add(p.ToArray());            
            SetupMenuSource(tablename, sourceTable, int.Parse(row[tab.PKFiled].ToString()), pcolumn, depth+1);
        }
    }

    public static void SetupMenuGrid(string tablename, GridView grid)
    {
        SortedList<int, Column> columns = new SortedList<int, Column>();
        Table tab = new Table(tablename);
        foreach (Column c in tab.Columns)
        {
            if (c.IsListShow)
            {
                int key = c.ListShowOrder;
                while (columns.ContainsKey(key))
                {
                    key++;
                }
                columns.Add(key, c);
            }
        }
        BoundField field1 = new BoundField();
        field1.DataField = "depth";
        field1.ItemStyle.Width = new Unit(30);
        grid.Columns.Add(field1);
        
        foreach (Column c in columns.Values)
        {            
            DataControlField field = ListFieldFactory.GetListField(c.ListShowType.ToString(), tablename, c.ColumnName);
            if (c.ColumnName == columns.Values[0].ColumnName)
            {
                field.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                field.ItemStyle.CssClass = string.Empty;
            }
            grid.Columns.Add(field);
        }

        //添加排序
        if (!string.IsNullOrEmpty(tab.OrderField))
        {
            HyperLinkField orderup = new HyperLinkField();
            orderup.Text = "<img src='images/up.jpg' border=0 />";
            orderup.DataNavigateUrlFields = tab.PKFiled.Split(',');
            orderup.DataNavigateUrlFormatString = "OrderGO.aspx?id={0}&d=up&t=" + tablename+"&desc=1";
            orderup.ItemStyle.Width = new Unit(20);
            grid.Columns.Add(orderup);

            HyperLinkField orderdown = new HyperLinkField();
            orderdown.Text = "<img src='images/down.jpg' border=0 />";
            orderdown.DataNavigateUrlFields = tab.PKFiled.Split(',');
            orderdown.DataNavigateUrlFormatString = "OrderGO.aspx?id={0}&d=down&t=" + tablename + "&desc=1";
            orderdown.ItemStyle.Width = new Unit(20);
            grid.Columns.Add(orderdown);
        }
        //添加添加
        if (tab.AddChildDepth != 0 && tab.AddChildDepth!=1)
        {
            HyperLinkField addField = new HyperLinkField();
            addField.Text = "添加子栏目";
            addField.DataNavigateUrlFields = tab.PKFiled.Split(',');
            addField.HeaderText = "<a href='edit.aspx?id=0&type=add&f=menu&t=" + tablename + "&p=&m='>添加栏目</a>";
            addField.DataNavigateUrlFormatString = "edit.aspx?id={0}&type=add&f=menu&t=" + tablename + "&p=" + HttpContext.Current.Request.QueryString["p"] + "&m=" + HttpContext.Current.Request.QueryString["m"];
            addField.ItemStyle.Width = new Unit(70);
            grid.Columns.Add(addField);
        }
        //添加编辑
        HyperLinkField editField = new HyperLinkField();
        editField.Text = "编辑";
        editField.DataNavigateUrlFields = tab.PKFiled.Split(',');
        editField.HeaderText = "编辑";
        editField.DataNavigateUrlFormatString = "edit.aspx?id={0}&f=menu&t=" + tablename + "&p=" + HttpContext.Current.Request.QueryString["p"] + "&m=" + HttpContext.Current.Request.QueryString["m"];
        editField.ItemStyle.Width = new Unit(40);
        grid.Columns.Add(editField);
        //添加删除
        ConfirmLinkField delField = new ConfirmLinkField();
        delField.Text = "删除";
        delField.DataNavigateUrlFields = tab.PKFiled.Split(',');
        delField.DataNavigateUrlFormatString = "del.aspx?id={0}&t=" + tablename;
        delField.HeaderText = "删除";
        delField.ItemStyle.Width = new Unit(40);
        grid.Columns.Add(delField);


        DataTable sourceTable = new DataTable();
        sourceTable.Columns.Add("depth");
        SetupMenuSource(tablename, sourceTable, 0, tab.FKField,0);

        grid.AutoGenerateColumns = false;

        grid.DataSource = sourceTable;
        grid.DataBind();
    }

    public static void SetupGrid(string tablename, GridView grid, string searchStr, string treeStr, int pagesize, int nowpage, out int RecCount)
    {
        SortedList<int, Column> columns = new SortedList<int, Column>();
        Table tab = new Table(tablename);
        foreach (Column c in tab.Columns)
        {
            if (c.IsListShow)
            {
                int key = c.ListShowOrder;
                while (columns.ContainsKey(key))
                {
                    key++;
                }
                columns.Add(key, c);
            }
        }
        string sql = "select " + tab.PKFiled;
        foreach (Column c in columns.Values)
        {
            if (sql == "select")
            {
                sql += " " + c.ColumnName;
                if (c.ListShowType == ListShowType.Foreign)
                {
                    string fsql = "(select " + c.DataTextField + " from testnewstype where " + c.DataValueField + "=" + tablename + "." + c.ColumnName + ") as " + c.ColumnName + "_Foreign";
                    sql += "," + fsql;
                }

            }
            else
            {
                sql += "," + c.ColumnName;
                if (c.ListShowType == ListShowType.Foreign)
                {
                    string fsql = "(select " + c.DataTextField + " from " + c.ForeignTable + " where " + c.DataValueField + "=" + tablename + "." + c.ColumnName + ") as " + c.ColumnName + "_Foreign";
                    sql += "," + fsql;
                }
            }
            DataControlField field = ListFieldFactory.GetListField(c.ListShowType.ToString(), tablename, c.ColumnName);
            grid.Columns.Add(field);
        }
        sql += " from " + tab.TableName + " where 1=1";

        if ((!string.IsNullOrEmpty(searchStr)) && (!string.IsNullOrEmpty(tab.SearchColumn)))
        {
            sql += " and (";
            string searchSql = string.Empty;
            string[] arr = searchStr.Split (",".ToCharArray (), StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in arr)
            {
                if (!string.IsNullOrEmpty (searchSql))
                {
                    searchSql += " or ";
                }
                searchSql += tab.SearchColumn + " like '%" + searchStr.Replace ("'", "''") + "%'";
            }

            sql += searchSql;
            sql += ")";
        }
        if ((!string.IsNullOrEmpty(treeStr)) && (!string.IsNullOrEmpty(tab.TreeColumn)))
        {
            sql += " and " + tab.TreeColumn + "='" + treeStr.Replace("'", "''") + "'";
        }

        //Response.Write(sql);
        //Response.End();
        if (!string.IsNullOrEmpty(tab.SelectOrder))
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

        grid.AutoGenerateColumns = false;

        //添加排序
        if (!string.IsNullOrEmpty(tab.OrderField))
        {
            HyperLinkField orderup = new HyperLinkField();
            orderup.Text = "<img src='images/up.jpg' border=0 />";
            orderup.DataNavigateUrlFields = tab.PKFiled.Split(',');
            orderup.DataNavigateUrlFormatString = "OrderGO.aspx?id={0}&d=up&t=" + tablename;
            orderup.ItemStyle.Width = new Unit(20);
            grid.Columns.Add(orderup);

            HyperLinkField orderdown = new HyperLinkField();
            orderdown.Text = "<img src='images/down.jpg' border=0 />";
            orderdown.DataNavigateUrlFields = tab.PKFiled.Split(',');
            orderdown.DataNavigateUrlFormatString = "OrderGO.aspx?id={0}&d=down&t=" + tablename;
            orderdown.ItemStyle.Width = new Unit(20);
            grid.Columns.Add(orderdown);
        }
        //添加查看
        if (tab.AllowShow)
        {
            HyperLinkField showField = new HyperLinkField();
            showField.Text = "查看";
            showField.DataNavigateUrlFields = tab.PKFiled.Split(',');
            showField.HeaderText = "查看";
            showField.DataNavigateUrlFormatString = "show.aspx?id={0}&t=" + tablename + "&p=" + HttpContext.Current.Request.QueryString["p"] + "&m=" + HttpContext.Current.Request.QueryString["m"];
            showField.ItemStyle.Width = new Unit(40);
            grid.Columns.Add(showField);
        }
        //添加编辑
        if (tab.AllowEdit)
        {
            HyperLinkField editField = new HyperLinkField();
            editField.Text = "编辑";
            editField.DataNavigateUrlFields = tab.PKFiled.Split(',');
            editField.HeaderText = "编辑";
            editField.DataNavigateUrlFormatString = "edit.aspx?id={0}&t=" + tablename + "&p=" + HttpContext.Current.Request.QueryString["p"] + "&m=" + HttpContext.Current.Request.QueryString["m"];
            editField.ItemStyle.Width = new Unit(40);
            grid.Columns.Add(editField);
        }
        if (tab.AllowDel)
        {
            //添加删除
            ConfirmLinkField delField = new ConfirmLinkField();
            delField.Text = "删除";
            delField.DataNavigateUrlFields = tab.PKFiled.Split(',');
            delField.DataNavigateUrlFormatString = "del.aspx?id={0}&t=" + tablename;
            delField.HeaderText = "删除";
            delField.ItemStyle.Width = new Unit(40);
            grid.Columns.Add(delField);
        }
        //绑定

        DataTable tabsource = DBFactory.GetConn().exeTable(sql);
        RecCount = tabsource.Rows.Count;
        if (pagesize > 0)
        {
            grid.DataSource = PagerHelper.GetPagedData(pagesize, nowpage, tabsource.DefaultView);
            grid.DataBind();
        }
        else
        {
            grid.DataSource = tabsource;
            grid.DataBind();
        }

    }

    public static void SetupPanel(string tablename,Panel panel,Page page,string id,bool show)
    {
        if (string.IsNullOrEmpty(id))
        {
            id = "0";
        }

        SortedList<int, Column> columns = new SortedList<int, Column>();
        Table tab = new Table(tablename);
        foreach (Column c in tab.Columns)
        {
            if (c.IsEditShow)
            {
                int key = c.EditShowOrder;
                while (columns.ContainsKey(key))
                {
                    key++;
                }
                columns.Add(key, c);
            }
        }

        string sql = "select * from " + tablename + " where id=" + id;
        DataRow row = DBFactory.GetConn().exeRow(sql);

        foreach (Column c in columns.Values)
        {
            string value = string.Empty;
            try
            {
                value = row[c.ColumnName].ToString();
            }
            catch (Exception ex)
            { }
            if (page.IsPostBack)
            {
                value = page.Request.Form[c.ColumnName + "_value"];
            }
            if ((!string.IsNullOrEmpty(page.Request.QueryString["type"])) && page.Request.QueryString["type"].ToLower() == "add")
            {
                value = string.Empty;
                if (c.EditShowType == EditShowType.Hidden)
                {
                    value = page.Request[c.HiddenFrom];
                }
            }
            Panel p = null;
            if (show)
            {
                p = ShowFieldFactory.GetEditColumn(c.EditShowType.ToString(), c, value);
            }
            else
            {
                p = EditFieldFactory.GetEditColumn(c.EditShowType.ToString(), c, value);
            }
            panel.Controls.Add(p);
        }
    }

    public static string Location(string menuTable,int thisid)
    {
        string r = string.Empty;

        Table tab = new Table(menuTable);
                
        string sql = "select * from " + menuTable + " where "+tab.PKFiled+"=" + thisid;
        DataRow row=DBFactory.GetConn().exeRow(sql);

        string pid = row[tab.FKField].ToString();
        if (pid != "0")
        {
            r += Location(menuTable, int.Parse(pid));
        }

        r += "→" + row[tab.ShowField].ToString();

        return r;
    }
}
