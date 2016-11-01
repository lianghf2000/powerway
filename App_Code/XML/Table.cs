using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Data;
using System.Text;
using System.IO;

/// <summary>
///Table 的摘要说明
/// </summary>
public class Table
{
	public Table(string tableName)
	{
        this.tableName = tableName;
        if (!File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "config\\table\\" + tableName + ".xml"))
        {
            BuildXML();
        }
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(HttpContext.Current.Request.PhysicalApplicationPath + "config\\table\\" + tableName + ".xml");

        try
        {
            this.searchColumn = xdoc.DocumentElement.Attributes["SearchColumn"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.treeColumn = xdoc.DocumentElement.Attributes["TreeColumn"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.PKFiled = xdoc.DocumentElement.Attributes["PKColumn"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.FKField = xdoc.DocumentElement.Attributes["FKColumn"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.ShowField = xdoc.DocumentElement.Attributes["ShowColumn"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.selectorder = xdoc.DocumentElement.Attributes["SelectOrder"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.orderfield = xdoc.DocumentElement.Attributes["OrderColumn"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.setorderstring = xdoc.DocumentElement.Attributes["SetOrderSqlString"].Value;
        }
        catch (Exception ex)
        { }
        try
        {
            this.allowaddcontent = bool.Parse(xdoc.DocumentElement.Attributes["AllowAddContent"].Value);
        }
        catch (Exception ex)
        { }
        try
        {
            this.addchilddepth = int.Parse(xdoc.DocumentElement.Attributes["AddChildDepth"].Value);
        }
        catch (Exception ex)
        { }

        try
        {
            this.issingle = bool.Parse(xdoc.DocumentElement.Attributes["IsSingle"].Value);
        }
        catch (Exception ex)
        { }

        try
        {
            this.allowEdit = bool.Parse(xdoc.DocumentElement.Attributes["AllowEdit"].Value);
        }
        catch (Exception ex)
        { }
        try
        {
            this.allowDel = bool.Parse(xdoc.DocumentElement.Attributes["AllowDel"].Value);
        }
        catch (Exception ex)
        { }
        try
        {
            this.allowShow = bool.Parse(xdoc.DocumentElement.Attributes["AllowShow"].Value);
        }
        catch (Exception ex)
        { }

        XmlNodeList nodes = xdoc.GetElementsByTagName("Column");
        foreach (XmlNode n in nodes)
        {
            Column c = new Column(n);
            c.Table = this;
            this.columns.Add(c);
        }
	}

    bool allowEdit=true;
    public bool AllowEdit
    {
        get { return this.allowEdit; }
        set { this.allowEdit = value; }
    }
    bool allowDel = true;
    public bool AllowDel
    {
        get { return this.allowDel; }
        set { this.allowDel = value; }
    }
    bool allowShow = false;
    public bool AllowShow
    {
        get { return this.allowShow; }
        set { this.allowShow = value; }
    }

    int addchilddepth;
    public int AddChildDepth
    {
        get { return this.addchilddepth; }
        set { this.addchilddepth = value; }
    }
    bool issingle;
    public bool IsSingle
    {
        get { return this.issingle; }
        set { this.issingle = value; }
    }
    bool allowaddcontent;
    public bool AllowAddContent
    {
        get { return this.allowaddcontent; }
        set { this.allowaddcontent = value; }
    }

    string setorderstring;
    public string SetOrderSqlString
    {
        get { return this.setorderstring; }
        set { this.setorderstring = value; }
    }
    string orderfield;
    public string OrderField
    {
        get { return this.orderfield; }
        set { this.orderfield = value; }
    }
    string selectorder;
    public string SelectOrder
    {
        get { return this.selectorder; }
        set { this.selectorder = value; }
    }
    public Table()
    { }

    string searchColumn;
    public string SearchColumn
    {
        get { return this.searchColumn; }
        set { this.searchColumn = value; }
    }
    string treeColumn;
    public string TreeColumn
    {
        get { return this.treeColumn; }
        set { this.treeColumn = value; }
    }
    string tableName;
    public string TableName
    {
        get { return tableName; }
        set { this.tableName = value; }
    }

    string pkfiled;
    public string PKFiled
    {
        get { return this.pkfiled; }
        set { this.pkfiled = value; }
    }
    string fkfield;
    public string FKField
    {
        get { return this.fkfield; }
        set { this.fkfield = value; }
    }
    string showfield;
    public string ShowField
    {
        get { return this.showfield; }
        set { this.showfield = value; }
    }

    List<Column> columns=new List<Column>();
    public List<Column> Columns
    {
        get { return columns; }
    }

    public Column GetColumns(string columnname)
    {
        foreach (Column c in this.columns)
        {
            if (c.ColumnName == columnname)
            {
                return c;
            }
        }
        return null;
    }

    public void SaveXML()
    {
        string path = HttpContext.Current.Request.PhysicalApplicationPath + "config\\table\\" + this.tableName + ".xml";

        XmlWriter w = new XmlTextWriter(path, Encoding.Unicode);
        //写文档开始
        w.WriteStartDocument();
        //写根                
        w.WriteStartElement("Table");

        //内容表
        w.WriteStartAttribute("SearchColumn");
        w.WriteString(this.searchColumn);
        w.WriteEndAttribute();
        w.WriteStartAttribute("TreeColumn");
        w.WriteString(this.treeColumn);
        w.WriteEndAttribute();

        //目录表
        w.WriteStartAttribute("PKColumn");
        w.WriteString(this.pkfiled);
        w.WriteEndAttribute();
        w.WriteStartAttribute("FKColumn");
        w.WriteString(this.fkfield);
        w.WriteEndAttribute();
        w.WriteStartAttribute("ShowColumn");
        w.WriteString(this.showfield);
        w.WriteEndAttribute();

        //排序
        w.WriteStartAttribute("SelectOrder");
        w.WriteString(this.selectorder);
        w.WriteEndAttribute();
        w.WriteStartAttribute("OrderColumn");
        w.WriteString(this.orderfield);
        w.WriteEndAttribute();
        w.WriteStartAttribute("SetOrderSqlString");
        w.WriteString(this.setorderstring);
        w.WriteEndAttribute();

        //添加子目录及内容
        w.WriteStartAttribute("AllowAddContent");
        w.WriteString(this.allowaddcontent.ToString());
        w.WriteEndAttribute();
        w.WriteStartAttribute("AddChildDepth");
        w.WriteString(this.addchilddepth.ToString());
        w.WriteEndAttribute();

        //单页
        w.WriteStartAttribute("IsSingle");
        w.WriteString(this.issingle.ToString());
        w.WriteEndAttribute();

        //显示，编辑，删除
        w.WriteStartAttribute("AllowEdit");
        w.WriteString(this.allowEdit.ToString());
        w.WriteEndAttribute();
        w.WriteStartAttribute("AllowDel");
        w.WriteString(this.allowDel.ToString());
        w.WriteEndAttribute();
        w.WriteStartAttribute("AllowShow");
        w.WriteString(this.allowShow.ToString());
        w.WriteEndAttribute();

        foreach (Column c in this.Columns)
        {
            w.WriteStartElement("Column");
            //列名
            w.WriteStartAttribute("name");
            w.WriteString(c.ColumnName);
            w.WriteEndAttribute();
            //字段类型
            w.WriteStartAttribute("type");
            w.WriteString(c.ColumnType);
            w.WriteEndAttribute();
            //---
            w.WriteStartAttribute("ListShow");
            w.WriteString(c.IsListShow.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditShow");
            w.WriteString(c.IsEditShow.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("ListShowOrder");
            w.WriteString(c.ListShowOrder.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditShowOrder");
            w.WriteString(c.EditShowOrder.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("ListShowName");
            w.WriteString(c.ListShowName);
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditShowName");
            w.WriteString(c.EditShowName);
            w.WriteEndAttribute();

            w.WriteStartAttribute("ListShowType");
            w.WriteString(c.ListShowType.ToString());
            w.WriteEndAttribute();

            w.WriteStartAttribute("EditShowType");
            w.WriteString(c.EditShowType.ToString());
            w.WriteEndAttribute();

            w.WriteStartAttribute("ImgWidth");
            w.WriteString(c.ImgWidth.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("ImgHeight");
            w.WriteString(c.ImgHeight.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("AllowExt");
            w.WriteString(c.AllowExt);
            w.WriteEndAttribute();
            w.WriteStartAttribute("Required");
            w.WriteString(c.Required.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("Range");
            w.WriteString(c.Range.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("RangeType");
            w.WriteString(c.RangeType.ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("RangeMin");
            w.WriteString(c.RangeMin);
            w.WriteEndAttribute();
            w.WriteStartAttribute("RangeMax");
            w.WriteString(c.RangeMax);
            w.WriteEndAttribute();
            w.WriteStartAttribute("SQL");
            w.WriteString(c.SqlText);
            w.WriteEndAttribute();
            w.WriteStartAttribute("DataTextField");
            w.WriteString(c.DataTextField);
            w.WriteEndAttribute();
            w.WriteStartAttribute("DataValueField");
            w.WriteString(c.DataValueField);
            w.WriteEndAttribute();
            w.WriteStartAttribute("LinkUrl");
            w.WriteString(c.LinkUrl);
            w.WriteEndAttribute();
            w.WriteStartAttribute("TrueText");
            w.WriteString(c.TrueText);
            w.WriteEndAttribute();
            w.WriteStartAttribute("FalseText");
            w.WriteString(c.FalseText);
            w.WriteEndAttribute();
            w.WriteStartAttribute("LinkText");
            w.WriteString(c.LinkText);
            w.WriteEndAttribute();
            w.WriteStartAttribute("StringFormat");
            w.WriteString(c.StringFormat);
            w.WriteEndAttribute();
            w.WriteStartAttribute("UrlField");
            w.WriteString(c.UrlField);
            w.WriteEndAttribute();
            w.WriteStartAttribute("ConfirmText");
            w.WriteString(c.ConfirmText);
            w.WriteEndAttribute();
            w.WriteStartAttribute("ForeignTable");
            w.WriteString(c.ForeignTable);
            w.WriteEndAttribute();
            w.WriteStartAttribute("ListTemplate");
            w.WriteString(c.ListTemplate);
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditTemplate");
            w.WriteString(c.EditTempLate);
            w.WriteEndAttribute();
            w.WriteStartAttribute("HiddenFrom");
            w.WriteString(c.HiddenFrom);
            w.WriteEndAttribute();
            //---
            w.WriteEndElement();
        }
        w.WriteEndElement();
        w.WriteEndDocument();
        w.Close();
    }

    public void BuildXML()
    {
        string sql = "select column_name,data_type from information_schema.columns where table_name = N'" + this.tableName + "' ";
        string path = HttpContext.Current.Request.PhysicalApplicationPath + "config\\table\\" + this.tableName + ".xml";
        
        XmlWriter w = new XmlTextWriter(path, Encoding.Unicode);
        //写文档开始
        w.WriteStartDocument();
        //写根
        w.WriteStartElement("Table");

        //内容表
        w.WriteStartAttribute("SearchColumn");
        w.WriteString(this.searchColumn);
        w.WriteEndAttribute();
        w.WriteStartAttribute("TreeColumn");
        w.WriteString(this.treeColumn);
        w.WriteEndAttribute();

        //目录表
        w.WriteStartAttribute("PKColumn");
        w.WriteString(this.pkfiled);
        w.WriteEndAttribute();
        w.WriteStartAttribute("FKColumn");
        w.WriteString(this.fkfield);
        w.WriteEndAttribute();
        w.WriteStartAttribute("ShowColumn");
        w.WriteString(this.showfield);
        w.WriteEndAttribute();

        //排序
        w.WriteStartAttribute("SelectOrder");
        w.WriteString(this.selectorder);
        w.WriteEndAttribute();
        w.WriteStartAttribute("OrderColumn");
        w.WriteString(this.orderfield);
        w.WriteEndAttribute();
        w.WriteStartAttribute("SetOrderSqlString");
        w.WriteString(this.setorderstring);
        w.WriteEndAttribute();

        //添加子目录及内容
        w.WriteStartAttribute("AllowAddContent");
        w.WriteString(this.allowaddcontent.ToString());
        w.WriteEndAttribute();
        w.WriteStartAttribute("AddChildDepth");
        w.WriteString(this.addchilddepth.ToString());
        w.WriteEndAttribute();

        //单页
        w.WriteStartAttribute("IsSingle");
        w.WriteString(this.issingle.ToString());
        w.WriteEndAttribute();

        //显示，编辑，删除
        w.WriteStartAttribute("AllowEdit");
        w.WriteString(this.allowEdit.ToString());
        w.WriteEndAttribute();
        w.WriteStartAttribute("AllowDel");
        w.WriteString(this.allowDel.ToString());
        w.WriteEndAttribute();
        w.WriteStartAttribute("AllowShow");
        w.WriteString(this.allowShow.ToString());
        w.WriteEndAttribute();

        DataTable tab = DBFactory.GetConn().exeTable(sql);
        foreach (DataRow row in tab.Rows)
        {
            //写一个列
            w.WriteStartElement("Column");
            //列名
            w.WriteStartAttribute("name");
            w.WriteString(row["column_name"].ToString());
            w.WriteEndAttribute();
            //字段类型
            w.WriteStartAttribute("type");
            w.WriteString(row["data_type"].ToString());
            w.WriteEndAttribute();
            //---
            w.WriteStartAttribute("ListShow");
            w.WriteString("False");
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditShow");
            w.WriteString("False");
            w.WriteEndAttribute();
            w.WriteStartAttribute("ListShowOrder");
            w.WriteString("1");
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditShowOrder");
            w.WriteString("1");
            w.WriteEndAttribute();
            w.WriteStartAttribute("ListShowName");
            w.WriteString(row["column_name"].ToString());
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditShowName");
            w.WriteString(row["column_name"].ToString());
            w.WriteEndAttribute();

            w.WriteStartAttribute("ListShowType");
            w.WriteString(ListShowType.Text.ToString());
            w.WriteEndAttribute();

            w.WriteStartAttribute("EditShowType");
            w.WriteString(EditShowType.Text.ToString());
            w.WriteEndAttribute();

            w.WriteStartAttribute("ImgWidth");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("ImgHeight");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("AllowExt");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("Required");
            w.WriteString("False");
            w.WriteEndAttribute();
            w.WriteStartAttribute("Range");
            w.WriteString("False");
            w.WriteEndAttribute();
            w.WriteStartAttribute("RangeType");
            w.WriteString("String");
            w.WriteEndAttribute();
            w.WriteStartAttribute("RangeMin");
            w.WriteString("0");
            w.WriteEndAttribute();
            w.WriteStartAttribute("RangeMax");
            w.WriteString("9999999");
            w.WriteEndAttribute();
            w.WriteStartAttribute("SQL");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("DataTextField");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("DataValueField");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("LinkUrl");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("TrueText");
            w.WriteString("是");
            w.WriteEndAttribute();
            w.WriteStartAttribute("FalseText");
            w.WriteString("否");
            w.WriteEndAttribute();
            w.WriteStartAttribute("LinkText");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("StringFormat");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("UrlField");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("ConfirmText");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("ForeignTable");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("ListTemplate");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("EditTemplate");
            w.WriteString("");
            w.WriteEndAttribute();
            w.WriteStartAttribute("HiddenFrom");
            w.WriteString("");
            w.WriteEndAttribute();
            //---
            w.WriteEndElement();
        }
        w.WriteEndElement();
        w.WriteEndDocument();
        w.Close();
    }

    public void UpdateXML()
    {
        string path = HttpContext.Current.Request.PhysicalApplicationPath + "config\\table\\" + tableName + ".xml";
        if (!File.Exists(path))
        {
            BuildXML();
        }
        else
        {
            string sql = "select column_name,data_type from information_schema.columns where table_name = N'" + this.tableName + "' ";
            DataTable tab = DBFactory.GetConn().exeTable(sql);
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);

            //内容表
            if (xdoc.DocumentElement.Attributes["SearchColumn"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("SearchColumn");
                att.Value = this.searchColumn;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["SearchColumn"].Value = this.searchColumn;
            }
            if (xdoc.DocumentElement.Attributes["TreeColumn"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("TreeColumn");
                att.Value = this.treeColumn;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["TreeColumn"].Value = this.treeColumn;
            }
            //目录表            
            if (xdoc.DocumentElement.Attributes["PKColumn"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("PKColumn");
                att.Value = this.pkfiled;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["PKColumn"].Value = this.pkfiled;
            }
            if (xdoc.DocumentElement.Attributes["FKColumn"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("FKColumn");
                att.Value = this.fkfield;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["FKColumn"].Value = this.fkfield;
            }
            if (xdoc.DocumentElement.Attributes["ShowColumn"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("ShowColumn");
                att.Value = this.showfield;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["ShowColumn"].Value = this.showfield;
            }

            //排序
            if (xdoc.DocumentElement.Attributes["SelectOrder"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("SelectOrder");
                att.Value = this.selectorder;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["SelectOrder"].Value = this.selectorder;
            }
            if (xdoc.DocumentElement.Attributes["OrderColumn"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("OrderColumn");
                att.Value = this.orderfield;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["OrderColumn"].Value = this.orderfield;
            }
            if (xdoc.DocumentElement.Attributes["SetOrderSqlString"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("SetOrderSqlString");
                att.Value = this.setorderstring;
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["SetOrderSqlString"].Value = this.setorderstring;
            }

            //添加子目录及内容
            if (xdoc.DocumentElement.Attributes["AllowAddContent"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("AllowAddContent");
                att.Value = this.allowaddcontent.ToString();
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["AllowAddContent"].Value = this.allowaddcontent.ToString();
            }
            if (xdoc.DocumentElement.Attributes["AddChildDepth"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("AddChildDepth");
                att.Value = this.addchilddepth.ToString();
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["AddChildDepth"].Value = this.addchilddepth.ToString();
            }

            //单页
            if (xdoc.DocumentElement.Attributes["IsSingle"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("IsSingle");
                att.Value = this.issingle.ToString();
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["IsSingle"].Value = this.issingle.ToString();
            }

            //显示，编辑，删除
            if (xdoc.DocumentElement.Attributes["AllowEdit"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("AllowEdit");
                att.Value = this.allowEdit.ToString();
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["AllowEdit"].Value = this.allowEdit.ToString();
            }
            if (xdoc.DocumentElement.Attributes["AllowDel"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("AllowDel");
                att.Value = this.allowDel.ToString();
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["AllowDel"].Value = this.allowDel.ToString();
            }
            if (xdoc.DocumentElement.Attributes["AllowShow"] == null)
            {
                XmlAttribute att = xdoc.CreateAttribute("AllowShow");
                att.Value = this.allowShow.ToString();
                xdoc.DocumentElement.Attributes.Append(att);
            }
            else
            {
                xdoc.DocumentElement.Attributes["AllowShow"].Value = this.allowShow.ToString();
            }            
            
            XmlNodeList nodes = xdoc.GetElementsByTagName("Column");
            foreach (DataRow row in tab.Rows)
            {
                string columnName = row["column_name"].ToString();
                bool has = false;
                foreach (XmlNode n in nodes)
                {
                    if (n.Attributes["name"].Value == columnName)
                    {
                        has = true;
                        break;
                    }
                }
                if (!has)
                {
                    XmlNode newNode = xdoc.CreateElement("Column");
                    //添加名称
                    XmlAttribute att = xdoc.CreateAttribute("name");                    
                    att.Value=row["column_name"].ToString();
                    newNode.Attributes.Append(att);
                    //添加类型
                    att = xdoc.CreateAttribute("type");
                    att.Value = row["data_type"].ToString();
                    newNode.Attributes.Append(att);
                    //
                    att = xdoc.CreateAttribute("ListShow");
                    att.Value = "False";
                    newNode.Attributes.Append(att);
                    //
                    att = xdoc.CreateAttribute("EditShow");
                    att.Value = "False";
                    newNode.Attributes.Append(att);
                    //
                    att = xdoc.CreateAttribute("ListShowOrder");
                    att.Value = "1";
                    newNode.Attributes.Append(att);
                    //
                    att = xdoc.CreateAttribute("EditShowOrder");
                    att.Value = "1";
                    newNode.Attributes.Append(att);
                    //
                    att = xdoc.CreateAttribute("ListShowName");
                    att.Value = row["column_name"].ToString();
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("EditShowName");
                    att.Value = row["column_name"].ToString();
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("ListShowType");
                    att.Value = "Text";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("EditShowType");
                    att.Value = "Text";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("ImgWidth");
                    att.Value = "0";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("ImgHeight");
                    att.Value = "0";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("AllowExt");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("Required");
                    att.Value = "False";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("Range");
                    att.Value = "False";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("RangeType");
                    att.Value = "String";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("RangeMin");
                    att.Value = "0";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("RangeMax");
                    att.Value = "0";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("SQL");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("DataTextField");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("DataValueField");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("LinkUrl");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("TrueText");
                    att.Value = "是";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("FalseText");
                    att.Value = "否";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("LinkText");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("StringFormat");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("UrlField");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("ConfirmText");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("ForeignTable");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("ListTemplate");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("EditTemplate");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                    //
                    att = xdoc.CreateAttribute("HiddenFrom");
                    att.Value = "";
                    newNode.Attributes.Append(att);
                    xdoc.DocumentElement.AppendChild(newNode);
                }
            }
            xdoc.Save(path);
        }
    }
}
