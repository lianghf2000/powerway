using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminlontro_Edit : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            /*地区选择*/
            if (isRoleTable(table))
            {
                /*string[] areaids = { }, areaid = { };
                if (id != null)
                {
                    DataTable dt = DBFactory.GetConn().exeTable("select top 1 [area] from [" + table + "] where [id]=" + id);
                    areaids = dt.Rows[0][0].ToString().Split('|');
                }

                CheckBoxList1.DataSource = DBFactory.GetConn().exeTable("select [id],[typename] from [countryType] where [pid]=0 order by [orderid]");
                CheckBoxList1.DataTextField = "typename";
                CheckBoxList1.DataValueField = "id";
                CheckBoxList1.DataBind();

                try
                {
                    if (areaids.Length >= 1 && areaids[0] != null)
                    {
                        areaid = areaids[0].Split(',');
                        for (int i = 0; i < areaid.Length; i++)
                        {
                            if (areaid[i] != "" && areaid[i] != ",") CheckBoxList1.Items.FindByValue(areaid[i]).Selected = true;
                        }
                    }
                }
                catch { }

                CheckBoxList2.DataSource = DBFactory.GetConn().exeTable("select [id],[typename] from [countryType]  where [pid]<>0 order by [orderid]");
                CheckBoxList2.DataTextField = "typename";
                CheckBoxList2.DataValueField = "id";
                CheckBoxList2.DataBind();

                try
                {
                    if (areaids.Length >= 2 && areaids[1] != null)
                    {
                        areaid = areaids[1].Split(',');
                        for (int i = 0; i < areaid.Length; i++)
                        {
                            if (areaid[i] != "" && areaid[i] != ",") CheckBoxList2.Items.FindByValue(areaid[i]).Selected = true;
                        }
                    }
                }
                catch { }*/

                string[] areaids = { };
                if (id != null)
                {
                    DataTable dt = DBFactory.GetConn().exeTable("select top 1 [area] from [" + table + "] where [id]=" + id);
                    areaids = dt.Rows[0][0].ToString().Split(',');
                }

                CheckBoxList3.DataSource = DBFactory.GetConn().exeTable("select [id],[title] from [country] order by [orderid] desc");
                CheckBoxList3.DataTextField = "title";
                CheckBoxList3.DataValueField = "id";
                CheckBoxList3.DataBind();

                try
                {
                    for (int i = 0; i < areaids.Length; i++)
                    {
                        if (areaids[i] != "" && areaids[i] != ",") CheckBoxList3.Items.FindByValue(areaids[i]).Selected = true;
                    }
                }
                catch { }

                /*DropDownList1.DataSource = DBFactory.GetConn().exeTable("select [id],[typename] from [countryType] where [pid]=0 order by [orderid]");
                DropDownList1.DataTextField = "typename";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();

                try
                {
                    if (areaid.Length >= 1 && areaid[0] != null && areaid[1] != "")
                        DropDownList1.Items.FindByValue(areaid[0]).Selected = true;//1
                }
                catch { }

                DropDownList2.DataSource = DBFactory.GetConn().exeTable("select [id],[typename] from [countryType] where [pid]=" + DropDownList1.SelectedValue.ToString() + " order by [orderid]");
                DropDownList2.DataTextField = "typename";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();

                try
                {
                    if (areaid.Length >= 2 && areaid[1] != null && areaid[1] != "")
                        DropDownList2.Items.FindByValue(areaid[1]).Selected = true;//2
                }
                catch { }

                DropDownList3.DataSource = DBFactory.GetConn().exeTable("select [id],[title] from [country] where [typeid]=" + DropDownList2.SelectedValue.ToString() + " order by [orderid] desc");
                DropDownList3.DataTextField = "title";
                DropDownList3.DataValueField = "id";
                DropDownList3.DataBind();

                try
                {
                    if (areaid.Length >= 3 && areaid[2] != null && areaid[1] != "")
                        DropDownList3.Items.FindByValue(areaid[2]).Selected = true;//3
                }
                catch { }*/
            }
            /*地区选择*/
        }

        if (Request.QueryString["f"] != null && !string.IsNullOrEmpty(Request.QueryString["f"]))
        {
            this.Literal2.Text = "分类";
        }
        else
        {
            this.Literal2.Text = "信息";
        }

        if (Request.QueryString["type"] != null && Request.QueryString["type"] == "add")
        {
            this.Literal2.Text += "添加";
        }
        else
        {
            this.Literal2.Text += "修改";
        }
        

        UIHelper.SetupPanel(table, this.main, this, id,false);

        if (!string.IsNullOrEmpty(p))
        {
            this.addlink.NavigateUrl = "edit.aspx?t=" + table + "&type=add&p=" + p + "&m=" + m;
        }
        else
        {
            this.addlink.Visible = false;
        }
        if (!string.IsNullOrEmpty(m) && (m!=table))
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string table = Request.QueryString["t"];
        //string id = Request.QueryString["id"];
        //string p = Request.QueryString["p"];
        ////string s = Request.QueryString["s"];
        //string m = Request.QueryString["m"];
        //SortedList<int, Column> columns = new SortedList<int, Column>();
        //Table tab = new Table(table);
        //foreach (Column c in tab.Columns)
        //{
        //    if (c.IsEditShow)
        //    {
        //        int key = c.EditShowOrder;
        //        while (columns.ContainsKey(key))
        //        {
        //            key++;
        //        }
        //        columns.Add(key, c);
        //    }
        //}
        //string sql = string.Empty;
        //if ((!string.IsNullOrEmpty(Request.QueryString["type"])) && Request.QueryString["type"].ToLower() == "add")
        //{
        //    sql = "insert into " + table;
        //    sql += "(";
        //    string values = "(";
        //    string colAll = string.Empty;
        //    string valAll = string.Empty;
        //    foreach (Column c in columns.Values)
        //    {
        //        if (string.IsNullOrEmpty(colAll))
        //        {
        //            colAll += c.ColumnName;
        //            valAll += GetValue(c.ColumnType, c.ColumnName);
        //        }
        //        else
        //        {
        //            colAll += "," + c.ColumnName;
        //            valAll += "," + GetValue(c.ColumnType, c.ColumnName);
        //        }
        //    }
        //    sql += colAll;
        //    values += valAll;
        //    if (!string.IsNullOrEmpty(tab.OrderField))
        //    {
        //        sql += "," + tab.OrderField;
        //        string maxorder = DBFactory.GetConn().exe1("select max(" + tab.OrderField + ")+1 from " + tab.TableName);
        //        if (string.IsNullOrEmpty(maxorder))
        //        {
        //            maxorder = "1";
        //        }
        //        values += "," + maxorder;
        //    }
        //    sql += ")";
        //    values += ")";
        //    sql += "values " + values;
        //}
        //else
        //{
        //    sql = "update " + table + " set ";
        //    string all = string.Empty;
        //    foreach (Column c in columns.Values)
        //    {
        //        if (string.IsNullOrEmpty(all))
        //        {
        //            all += c.ColumnName;
        //        }
        //        else
        //        {
        //            all += "," + c.ColumnName;
        //        }
        //        all += "=";
        //        all += GetValue(c.ColumnType, c.ColumnName);
        //    }
        //    sql += all;
        //    sql += " where id=" + id;
        //}
        //Response.Write(sql);
        //DBFactory.GetConn().exe0(sql);
        //string f = Request.QueryString["f"];
        //if (!string.IsNullOrEmpty(f))
        //{
        //    Response.Redirect("menu.aspx?mt=" + table + "&p=" + p);
        //}
        //else
        //{
        //    Response.Redirect("list.aspx?t=" + table + "&p=" + p + "&m=" + m);
        //}
    }

    public string GetValue(Column c, string columnName)
    {
        string columnType = c.ColumnType;
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
            if (c.EditShowType == EditShowType.CheckList)
            {
                return "'," + Request.Form[columnName + "_value"].Replace ("'", "''") + ",'";
            }
            else
            {
                return "'" + Request.Form[columnName + "_value"].Replace ("'", "''") + "'";
            }
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
        string table = Request.QueryString["t"];
        string id = Request.QueryString["id"];
        string p = Request.QueryString["p"];
        //string s = Request.QueryString["s"];
        string m = Request.QueryString["m"];
        SortedList<int, Column> columns = new SortedList<int, Column>();
        Table tab = new Table(table);
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
        string sql = string.Empty;
        if ((!string.IsNullOrEmpty(Request.QueryString["type"])) && Request.QueryString["type"].ToLower() == "add")
        {
            sql = "insert into " + table;
            sql += "(";
            string values = "(";
            string colAll = string.Empty;
            string valAll = string.Empty;
            foreach (Column c in columns.Values)
            {
                if (string.IsNullOrEmpty(colAll))
                {
                    colAll += c.ColumnName;
                    valAll += GetValue(c, c.ColumnName);
                }
                else
                {
                    colAll += "," + c.ColumnName;
                    valAll += "," + GetValue(c, c.ColumnName);
                }
            }
            sql += colAll;
            values += valAll;
            if (!string.IsNullOrEmpty(tab.OrderField))
            {
                sql += "," + tab.OrderField;
                string maxorder = DBFactory.GetConn().exe1("select max(" + tab.OrderField + ")+1 from " + tab.TableName);
                if (string.IsNullOrEmpty(maxorder))
                {
                    maxorder = "1";
                }
                values += "," + maxorder;
            }

            if (isRoleTable(table))
            {
                sql += " ,[area],[areaname]";
            }

            sql += ")";

            if (isRoleTable(table))
            {
                /*values += ",'" + DropDownList1.SelectedValue + "," + DropDownList2.SelectedValue + "," + DropDownList3.SelectedValue + "'";
                values += ",'" + (DropDownList1.SelectedItem != null ? DropDownList1.SelectedItem.Text : "") + "," + (DropDownList2.SelectedItem != null ? DropDownList2.SelectedItem.Text : "") + "," + (DropDownList3.SelectedItem != null ? DropDownList3.SelectedItem.Text : "") + "'";*/

                values += ",'" + /*forCheckList1_val() + ",|," + forCheckList2_val() + ",|," +*/ forCheckList3_val() + "'";
                values += ",'" + /*forCheckList1_txt() + ",|," + forCheckList2_txt() + ",|," +*/ forCheckList3_txt() + "'";
            }
            
            values += ")";
            sql += "values " + values;
        }
        else
        {
            sql = "update " + table + " set ";
            string all = string.Empty;
            foreach (Column c in columns.Values)
            {
                if (string.IsNullOrEmpty(all))
                {
                    all += c.ColumnName;
                }
                else
                {
                    all += "," + c.ColumnName;
                }
                all += "=";
                all += GetValue(c, c.ColumnName);
            }
            sql += all;

            if (isRoleTable(table))
            {
                /*sql += " ,[area]='" + DropDownList1.SelectedValue + "," + DropDownList2.SelectedValue + "," + DropDownList3.SelectedValue + "'";
                sql += " ,[areaname]='" + (DropDownList1.SelectedItem != null ? DropDownList1.SelectedItem.Text : "") + "," + (DropDownList2.SelectedItem != null ? DropDownList2.SelectedItem.Text : "") + "," + (DropDownList3.SelectedItem != null ? DropDownList3.SelectedItem.Text : "") + "'";*/

                sql += " ,[area]='" + /*forCheckList1_val() + ",|," + forCheckList2_val() + ",|," +*/ forCheckList3_val() + "'";
                sql += " ,[areaname]='" + /*forCheckList1_txt() + ",|," + forCheckList2_txt() + ",|," +*/ forCheckList3_txt() + "'";
                
            }

            sql += " where id=" + id;
        }
        Response.Write(sql);
        DBFactory.GetConn().exe0(sql);
        string f = Request.QueryString["f"];
        if (tab.IsSingle)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else if (!string.IsNullOrEmpty(f))
        {
            Response.Redirect("menu.aspx?mt=" + table + "&p=" + p);
        }
        else
        {
            Response.Redirect("list.aspx?t=" + table + "&p=" + p + "&m=" + m);
        }
    }
    /*protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.DataSource = DBFactory.GetConn().exeTable("select [id],[typename] from [countryType] where [pid]=" + DropDownList1.SelectedValue.ToString() + " order by [orderid]");
        DropDownList2.DataTextField = "typename";
        DropDownList2.DataValueField = "id";
        DropDownList2.DataBind();
        DropDownList2_SelectedIndexChanged(sender, e);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList3.DataSource = DBFactory.GetConn().exeTable("select [id],[title] from [country] where [typeid]=" + DropDownList2.SelectedValue.ToString() + " order by [orderid] desc");
        DropDownList3.DataTextField = "title";
        DropDownList3.DataValueField = "id";
        DropDownList3.DataBind();
    }*/
    private bool isRoleTable(string table)
    {
        if ("menu,nav,news,en_menu,en_nav,en_news".IndexOf(table) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /*private string forCheckList1_val()
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList1.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Value + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        return strValue;
    }
    private string forCheckList1_txt()
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList1.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Text + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        return strValue;
    }
    private string forCheckList2_val()
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList2.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Value + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        return strValue;
    }
    private string forCheckList2_txt()
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList2.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Text + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        return strValue;
    }*/
    private string forCheckList3_val()
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList3.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Value + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        return strValue;
    }
    private string forCheckList3_txt()
    {
        string strValue = "";
        foreach (ListItem listItem in CheckBoxList3.Items)
        {
            if (listItem.Selected)
            {
                strValue += listItem.Text + ",";
            }
        }
        if (strValue.Length > 0) strValue = strValue.Substring(0, strValue.Length - 1);
        return strValue;
    }
}
