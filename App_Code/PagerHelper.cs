using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

/// <summary>
///PagerHelper 的摘要说明
/// </summary>
public class PagerHelper
{
	public PagerHelper()
	{
		
	}

    public string GetPagerString(int reccount,int pagesize,int nowpage)
    {
        if (pagesize<1){pagesize=10;}
        if (nowpage < 1) { nowpage = 1; }
        int recordcount = reccount;
        int maxpage = recordcount / pagesize;
        if (recordcount % pagesize > 0) { maxpage++; }
        if (nowpage > maxpage) { nowpage = maxpage; }
        this.maxpage = maxpage;

        string firststr = "<a href='" + string.Format(urlformate, "1", qstring, pagename,thispagename) + "'>" + this.first + "</a>";
        string prewstr = "<a href='" + string.Format(urlformate, Convert.ToString(nowpage - 1), qstring, pagename,thispagename) + "'>" + this.prew + "</a>";
        string nextstr = "<a href='" + string.Format(urlformate, Convert.ToString(nowpage + 1), qstring, pagename,thispagename) + "'>" + this.next + "</a>";
        string laststr = "<a href='" + string.Format(urlformate, maxpage.ToString(), qstring, pagename,thispagename) + "'>" + this.last + "</a>";
        string dd = "<select onchange=\"location.href='" + string.Format(urlformate, "'+this.value+'", qstring, pagename, thispagename) + "'\">";
        for (int i = 1; i <= maxpage; i++)
        {
            dd += "<option value='"+i+"' "+((i==nowpage)?"selected":"")+">"+i+"</option>";
        }
        dd += "</select>";

        string numstr = string.Empty;

        int front = this.shownumcnt / 2;
        int back = front;
        if (this.shownumcnt % 2 > 0) { back++; }

        int start = nowpage - front;
        int end = nowpage + back;
        if (start < 1)
        {
            end += Math.Abs(1-start);
            start = 1;
            if (end > maxpage)
            {
                end = maxpage;
            }
        }
        else if (end > maxpage)
        {
            start -= Math.Abs(end - maxpage);
            end = maxpage;
            if (start < 1)
            {
                start = 1;
            }
        }


        for (int i = start; i <= end; i++)
        {
            if (!string.IsNullOrEmpty(numstr))
            {
                numstr += spector;
            }
            string temp = string.Empty;
            if (i == nowpage)
            {
                temp = this.nownum;
            }
            else
            {
                temp = this.num;
            }

            numstr += temp.Replace("{0}", "<a href='" + string.Format(urlformate, i.ToString(), qstring, pagename,thispagename) + "'>"+i.ToString()+"</a>");
        }

        string r = this.template.Replace("{first}", firststr);
        r = r.Replace("{prew}", prewstr);
        r = r.Replace("{next}", nextstr);
        r = r.Replace("{last}", laststr);
        r = r.Replace("{num}", numstr);
        r = r.Replace("{pagecount}", maxpage.ToString());
        r = r.Replace("{now}", nowpage.ToString());
        r = r.Replace("{recordcount}", recordcount.ToString());
        r = r.Replace("{size}", pagesize.ToString());
        r = r.Replace("{dropdown}", dd);

        return r;
    }

    public IEnumerable GetPagedData(IList source, int pagesize, int nowpage)
    {
        if (pagesize < 1) { pagesize = 10; }
        if (nowpage < 1) { nowpage = 1; }
        int recordcount = source.Count;
        int maxpage = recordcount / pagesize;
        if (recordcount % pagesize > 0) { maxpage++; }
        if (nowpage > maxpage) { nowpage = maxpage; }

        int start = (nowpage - 1) * pagesize;
        int end = start + pagesize;
        if (end > recordcount) { end = recordcount; }

        int backremoved = 0;

        for (int i = recordcount-1; i >= end; i--)
        {
            source.RemoveAt(i);
            backremoved++;
        }

        //throw new Exception(source.Count.ToString() + "|" + start.ToString());

        for (int i = 0; i < start; i++)
        {
            source.RemoveAt(0);
        }
        

        return source;
    }

    public static string GetPagerString(int recCount, int psize, int nowpage,string template)
    {
        PagerHelper p = new PagerHelper();
        if (!string.IsNullOrEmpty(template))
        {
            p.Template = template;
        }
        return p.GetPagerString(recCount, psize, nowpage);
    }

    public static IEnumerable GetPagedData(int pagesize, int nowpage, IList source)
    {
        return new PagerHelper().GetPagedData(source, pagesize, nowpage);
    }

    
    private string template="{first} {prew} {num} {next} {last} 第{now}/{pagecount}页 共{recordcount}条 每页{size}条 {dropdown}";
    /// <summary>
    /// {first} 第一页
    /// {last} 最后页
    /// {prew} 上一页
    /// {next} 下一页
    /// {num} 数字
    /// {pagecount}页数
    /// {now}当前页数
    /// {recordcount}记录数
    /// {size}每页条数
    /// </summary>
    public string Template
    {
        //get { return this.template; }
        set { this.template = value.ToLower(); }
    }
    public string dropdown="{dropdown}";
    public string DropDown
    {
        set { this.dropdown = value.ToLower(); }
    }

    private string thispagename;
    public string ThisPageName
    {
        get { return this.thispagename; }
        set { this.thispagename = value.ToLower(); }
    }

    private string urlformate="{3}?{2}={0}{1}";
    public string UrlFormate
    {
        get { return this.urlformate; }
        set { this.urlformate = value.ToLower(); }
    }

    private string first="<<";    
    public string FirstTemplate
    {
        set { this.first = value; }
    }

    private string last=">>";
    public string LastTemplate
    {
        set { this.last = value; }
    }

    private string qstring=string.Empty;
    /// <summary>
    /// 需要传递的查询字符串
    /// </summary>
    public string QueryString
    {
        set { this.qstring = value; }
    }

    private string prew="<";
    public string PrewTemplate
    {
        set { this.prew = value; }
    }

    private string next=">";
    public string NextTemplate
    {
        set { this.next = value; }
    }

    private string spector=" ";
    public string NumSpector
    {
        set { this.spector = value; }
    }

    private string num="{0}";
    /// <summary>
    /// {0}
    /// </summary>
    public string NumTemplate
    {
        set { this.num = value; }
    }
    private string nownum="<span style='color:red'>[{0}]</span>";
    /// <summary>
    /// <span color='red'>[{0}]</span>
    /// </summary>
    public string NowNumTemplate
    {
        set { this.nownum = value; }
    }

    private int shownumcnt=10;
    public int ShowNumCnt
    {
        set { this.shownumcnt = value; }
    }
    private string pagename = "page";
    public string PageQueryStringName
    {
        get 
        {
            return this.pagename;
        }
        set { this.pagename = value; }
    }

    private int maxpage;
    public int PageCount
    {
        get { return this.maxpage; }
    }
}
