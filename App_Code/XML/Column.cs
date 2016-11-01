using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

/// <summary>
///Column 的摘要说明
/// </summary>
public class Column
{	
    public Column()
    { }
    public Column(XmlNode node)
    {        
        this.columnName = node.Attributes["name"].Value;
        this.columntype = node.Attributes["type"].Value;
        //this.islistshow = bool.Parse(node.ChildNodes[0].InnerText);
        this.islistshow = bool.Parse(node.Attributes["ListShow"].Value);
        //this.iseditshow = bool.Parse(node.ChildNodes[1].InnerText);
        this.iseditshow = bool.Parse(node.Attributes["EditShow"].Value);
        //this.listshoworder = int.Parse(node.ChildNodes[2].InnerText);
        this.listshoworder = int.Parse(node.Attributes["ListShowOrder"].Value);
        //this.editshoworder =int.Parse(node.ChildNodes[3].InnerText);
        this.editshoworder = int.Parse(node.Attributes["EditShowOrder"].Value);
        //this.listshowname = node.ChildNodes[4].InnerText;
        this.listshowname = node.Attributes["ListShowName"].Value;
        //this.editshowname = node.ChildNodes[5].InnerText;
        this.editshowname = node.Attributes["EditShowName"].Value;
        //this.listshowtype = (ListShowType)Enum.Parse(typeof(ListShowType), node.ChildNodes[6].InnerText);
        this.listshowtype=(ListShowType)Enum.Parse(typeof(ListShowType),node.Attributes["ListShowType"].Value.ToString());
        this.editshowtype = (EditShowType)Enum.Parse(typeof(EditShowType), node.Attributes["EditShowType"].Value);
        //this.editshowtype = (EditShowType)Enum.Parse(typeof(EditShowType), node.ChildNodes[7].InnerText);
        int w = 0;
        int.TryParse(node.Attributes["ImgWidth"].Value, out w);
        this.imgwidth = w;
        int h = 0;
        int.TryParse(node.Attributes["ImgHeight"].Value, out h);
        this.imgheight = h;
        //this.allowext = node.ChildNodes[10].InnerText;
        this.allowext = node.Attributes["AllowExt"].Value;
        //this.required = bool.Parse(node.ChildNodes[11].InnerText);
        this.required = bool.Parse(node.Attributes["Required"].Value);
        //this.range = bool.Parse(node.ChildNodes[12].InnerText);
        this.range = bool.Parse(node.Attributes["Range"].Value);
        //this.rangeType = (ValidationDataType)Enum.Parse(typeof(ValidationDataType), node.ChildNodes[13].InnerText);
        this.rangeType=(ValidationDataType)Enum.Parse(typeof(ValidationDataType),node.Attributes["RangeType"].Value);
        //this.min = node.ChildNodes[14].InnerText;
        this.min = node.Attributes["RangeMin"].Value;
        //this.max = node.ChildNodes[15].InnerText;
        this.max = node.Attributes["RangeMax"].Value;
        //this.sqltext = node.ChildNodes[16].InnerText;
        this.sqltext = node.Attributes["SQL"].Value;
        //this.datatextfield = node.ChildNodes[17].InnerText;
        this.datatextfield=node.Attributes["DataTextField"].Value;
        //this.datavaluefield = node.ChildNodes[18].InnerText;
        this.datavaluefield=node.Attributes["DataValueField"].Value;
        //this.linkurl = node.ChildNodes[19].InnerText;
        this.linkurl = node.Attributes["LinkUrl"].Value;
        //this.truetext = node.ChildNodes[20].InnerText;
        this.truetext = node.Attributes["TrueText"].Value;
        //this.falsetext = node.ChildNodes[21].InnerText;
        this.falsetext = node.Attributes["FalseText"].Value;
        //this.linktext = node.ChildNodes[22].InnerText;
        this.linktext = node.Attributes["LinkText"].Value;
        //this.stringformat = node.ChildNodes[23].InnerText;
        this.stringformat = node.Attributes["StringFormat"].Value;
        //this.urlfield = node.ChildNodes[24].InnerText;
        this.urlfield = node.Attributes["UrlField"].Value;
        //this.confirmtxt = node.ChildNodes[25].InnerText;
        this.confirmtxt = node.Attributes["ConfirmText"].Value;
        this.foreigntable = node.Attributes["ForeignTable"].Value;
        this.listtemplate = node.Attributes["ListTemplate"].Value;
        this.edittemplate = node.Attributes["EditTemplate"].Value;
        try
        {
            this.hiddenfrom = node.Attributes["HiddenFrom"].Value;
        }
        catch (Exception ex)
        { }
    }

    private Table table;
    public Table Table
    {
        get { return this.table; }
        set { this.table = value; }
    }

    private string columnName;
    public string ColumnName
    {
        get { return this.columnName; }        
    }
    private string columntype;
    public string ColumnType
    {
        get { return this.columntype; }
    }

    private bool islistshow;
    public bool IsListShow
    {
        get { return this.islistshow; }
        set { this.islistshow = value; }
    }
    private bool iseditshow;
    public bool IsEditShow
    {
        get { return this.iseditshow; }
        set { this.iseditshow = value; }
    }
    private int listshoworder;
    public int ListShowOrder
    {
        get { return this.listshoworder; }
        set { this.listshoworder = value; }
    }
    private int editshoworder;
    public int EditShowOrder
    {
        get { return this.editshoworder; }
        set { this.editshoworder = value; }
    }
    private string listshowname;
    public string ListShowName
    {
        get { return this.listshowname; }
        set { this.listshowname = value; }
    }
    private string editshowname;
    public string EditShowName
    {
        get { return this.editshowname; }
        set { this.editshowname = value; }
    }
    private ListShowType listshowtype;
    public ListShowType ListShowType
    {
        get { return this.listshowtype; }
        set { this.listshowtype = value; }
    }
    private EditShowType editshowtype;
    public EditShowType EditShowType
    {
        get { return this.editshowtype; }
        set { this.editshowtype = value; }
    }
    private int imgwidth;
    public int ImgWidth
    {
        get { return this.imgwidth; }
        set { this.imgwidth = value; }
    }
    private int imgheight;
    public int ImgHeight
    {
        get { return this.imgheight; }
        set { this.imgheight = value; }
    }
    private string allowext;
    public string AllowExt
    {
        get { return this.allowext; }
        set { this.allowext = value; }
    }
    private bool required;
    public bool Required
    {
        get { return this.required; }
        set { this.required = value; }
    }
    private bool range;
    public bool Range
    {
        get { return this.range; }
        set { this.range = value; }
    }
    private ValidationDataType rangeType;
    public ValidationDataType RangeType
    {
        get { return this.rangeType; }
        set { this.rangeType = value; }
    }
    private string min;
    public string RangeMin
    {
        get { return this.min; }
        set { this.min = value; }
    }
    private string max;
    public string RangeMax
    {
        get { return this.max; }
        set { this.max = value; }
    }
    private string sqltext;
    public string SqlText
    {
        get { return this.sqltext; }
        set { this.sqltext = value; }
    }
    private string datatextfield;
    public string DataTextField
    {
        get { return this.datatextfield; }
        set { this.datatextfield = value; }
    }
    private string datavaluefield;
    public string DataValueField
    {
        get { return this.datavaluefield; }
        set { this.datavaluefield = value; }
    }
    private string linkurl;
    public string LinkUrl
    {
        get { return this.linkurl; }
        set { this.linkurl = value; }
    }
    private string truetext;
    public string TrueText
    {
        get { return this.truetext; }
        set { this.truetext = value; }
    }
    private string falsetext;
    public string FalseText
    {
        get { return this.falsetext; }
        set { this.falsetext = value; }
    }
    private string linktext;
    public string LinkText
    {
        get { return this.linktext; }
        set { this.linktext = value; }
    }
    private string stringformat;
    public string StringFormat
    {
        get { return this.stringformat; }
        set { this.stringformat = value; }
    }
    private string urlfield;
    public string UrlField
    {
        get { return this.urlfield; }
        set { this.urlfield = value; }
    }
    private string confirmtxt;
    public string ConfirmText
    {
        get { return this.confirmtxt; }
        set { this.confirmtxt = value; }
    }
    private string foreigntable;
    public string ForeignTable
    {
        get
        {
            return this.foreigntable;
        }
        set
        {
            this.foreigntable = value;
        }
    }
    private string listtemplate;
    public string ListTemplate
    {
        get { return this.listtemplate; }
        set { this.listtemplate = value; }
    }
    private string edittemplate;
    public string EditTempLate
    {
        get { return this.edittemplate; }
        set { this.edittemplate = value; }
    }

    private string hiddenfrom;
    public string HiddenFrom
    {
        get { return this.hiddenfrom; }
        set { this.hiddenfrom = value; }
    }
}
