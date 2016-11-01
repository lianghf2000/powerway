using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.IO;

/// <summary>
///baseClass 的摘要说明
/// </summary>
public class baseClassSql
{
	public baseClassSql()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //private static string connStr="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+HttpContext .Current .Server .MapPath ("App_Data/data.mdb");
    private static string connStr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString.ToString();

    private SqlConnection oleconn = null;
    private SqlCommand olecomm = null;
    private SqlDataAdapter oleda = null;
    /// <summary>
    /// ///////
    /// </summary>
    /// <returns></returns>
    
    public SqlDataReader Get(string AccSQL)
    {
        SqlConnection MyCon = new SqlConnection(connStr);
        SqlCommand MyCm = new SqlCommand(AccSQL, MyCon);
        try
        {
            MyCon.Open();
            return MyCm.ExecuteReader(CommandBehavior.CloseConnection);

        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            throw new Exception(ex.Message);
        }

    }
    public SqlDataReader get_one( )
    {
        //string sql = "select * from " + table + " where id =" + id;
        string sql = "select top 1 * from [w_jieshao] where [id]=5 or [title]='企业招聘' order by [inputdate] desc";

        baseClassSql GET = new baseClassSql();
        return GET.Get(sql);
    }


    ///////////////

    protected SqlConnection getConn()
    {
        return new SqlConnection(connStr);
    }
    protected  void closeAll()
    {
        //try
        //{
        //    olecomm.Dispose();            
        //}
        //catch {  }
        try
        {
            oleda.Dispose();
        }
        catch {  }
        try
        {
            oleconn.Close();
        }
        catch { }
    }
    public DataView GetDataView(string strSql)
    {
        oleconn = getConn();
        oleda = new SqlDataAdapter(strSql, oleconn);
        DataSet ds = new DataSet();
        oleda.Fill(ds);

        closeAll();

        return ds.Tables[0].DefaultView;
    }

    public ArrayList GetDateArrayList(string strSql)
    {
        oleconn = getConn();
        oleda = new SqlDataAdapter(strSql, oleconn);
        DataSet ds = new DataSet();
        oleda.Fill(ds);

        closeAll();

        ArrayList al = new ArrayList(ds.Tables[0].Rows.Count);

        foreach (DataRow dr in ds.Tables[0].Rows)
            al.Add(dr[0].ToString());

        return al;
    }

    public SqlDataReader GetDataReader(string strSql)
    {
        oleconn = getConn();
        olecomm = new SqlCommand(strSql, oleconn);
        SqlDataReader oledr=null;
        try{
            oledr =(SqlDataReader)olecomm.ExecuteReader();

        }catch{}

       // closeAll();

        return oledr;
    }

    public DataSet GetDataSet(string strSql)
    {
        oleconn = getConn();
        oleda = new SqlDataAdapter(strSql, oleconn);
        DataSet ds = new DataSet();
        try
        {
            oleda.Fill(ds);
        }
        catch { }
        closeAll();

        return ds;
    }
    public void ExecuteSqlNotRe(string strSql)
    {
        try
        {
            oleconn = getConn();
            olecomm = new SqlCommand(strSql, oleconn);
            oleconn.Open();
            olecomm.ExecuteNonQuery();
        }
        catch {  }
        finally
        {
            olecomm.Dispose();
            oleconn.Close();
        }
    }
    public bool ExecuteSql(string strSql)
    {
        try
        {
            oleconn = getConn();
            olecomm = new SqlCommand(strSql, oleconn);
            oleconn.Open();
            olecomm.ExecuteNonQuery();
            return true;
        }
        catch { return false; }
        finally
        {
            olecomm.Dispose();
            oleconn.Close();
        }
    }

    public int getAllCount(string tablename)
    {
        int count = 0;
        try
        {
            count = Convert.ToInt16(getOneMsg("select count(*) from [" + tablename + "]"));
        }
        catch { }
        return count;
    }

    public bool isExistRecord(string strSql)
    {
        try
        {
            oleconn = getConn();
            olecomm = new SqlCommand(strSql, oleconn);
            oleconn.Open();
            SqlDataReader oledr = olecomm.ExecuteReader();
            if (oledr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch { return false; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="msg"></param>
    public void MessageBox(string msg)
    {
        HttpContext.Current.Response.Write("<script language=javascript>alert('"+msg+"');</script>");       
    }
    public void MakeJs(string strJs)
    {
        HttpContext.Current.Response.Write("<script language=javascript>"+strJs.Trim()+"</script>");
    }
    public string getOneMsg(string strSql)
    {
        try
        {
            oleconn = getConn();
            olecomm = new SqlCommand(strSql, oleconn);
            oleconn.Open();
            SqlDataReader oleddr = olecomm.ExecuteReader();
            string tempvalue = string.Empty;
            while (oleddr.Read())
            {
                tempvalue=oleddr.GetValue(0).ToString();
                break;
            }
            return tempvalue;
        }
        catch { return ""; }
        finally
        {
            olecomm.Dispose();
            oleconn.Close();
        }
    }


    /// <summary>
    /// 返回一个自定义DataTable;
    /// </summary>
    /// <param name="al">列的数组</param>
    /// <param name="tablename">建的表名</param>
    /// <param name="tablevalue">一行自定义值</param>
    /// <returns></returns>
    public DataTable createEmptyTable(ArrayList al, string tablename,string[] tablevalue)
    {
        DataTable dt=null;
        DataColumn dc;
        //DataRow dr;

        try
        {

            dt = new DataTable(tablename);

            for (int i = 0; i < al.Count; i++)
            {
                dc = new DataColumn(al[i].ToString());
                dc.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(dc);
            }

            dt.Rows.Add(tablevalue);
        }
        catch { }

        return dt;

    }
    private void InsertDT(DataTable dt, string name, string cls)
    {
        string[] row = { name, cls };
        dt.Rows.Add(row);
    }

    /// <summary>
    /// 功能：执行客户端一小块脚本语言。输出：无。
    /// </summary>
    /// <param name="page">脚本注册到在页</param>
    /// <param name="sb">注册的脚本内容，例：alert('dd');</param>
    /// <param name="strRegDirection">注册到页面上的位置，up是注册到：在Page对象的&lt;form runat='server'&gt;元素的开始标记后立即发出该脚本，默认为down</param>
    public void RegisterJs(System.Web.UI.Page page,StringBuilder sb,string strRegDirection)
    {
        string strKey="";
        StringBuilder sbScript=new StringBuilder();
        int i;

        //脚本块内容
        sbScript.Append("<script style='text/javascript'>\n");
        sbScript.Append(sb.ToString());
        sbScript.Append("</script>");

        //注册脚本块KEY
        strKey=System.DateTime.Now.ToString();
        //循环，直至找到某个没被注册过的Key
        for(i=0;i<100;i++)
        {
            if(!page.IsClientScriptBlockRegistered(strKey+i.ToString()))
                break;
        }
        
        if(strRegDirection=="up")
        {
            page.RegisterClientScriptBlock(strKey + i.ToString(), sbScript.ToString());
        }else//默认注册到页面下面
        {
            page.RegisterStartupScript(strKey + i.ToString(), sbScript.ToString());
        }
    }

      /// <summary>
     /// 创建缩略图
     /// </summary>
     /// <param name="src">来源页面
     /// 可以是相对地址或者绝对地址
     /// </param>
     /// <param name="width">缩略图宽度</param>
     /// <param name="height">缩略图高度</param>
     /// <returns>字节数组</returns>
    public static byte[] MakeThumbnail(string src, double width, double height)
    {
        System.Drawing.Image image;

        // 相对路径从本机直接读取
       if (src.ToLower().IndexOf("http://") == -1)
        {
            src = HttpContext.Current.Server.MapPath(src);
            image = System.Drawing.Image.FromFile(src, true);
        }
        else // 绝对路径从 Http 读取
        {
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(src);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
            Stream receiveStream = resp.GetResponseStream();
            image = System.Drawing.Image.FromStream(receiveStream);
            resp.Close();
            receiveStream.Close();
        }
        double newWidth, newHeight;
        if (image.Width > image.Height)
        {
            newWidth = width;
            newHeight = image.Height*(newWidth/image.Width);
        }
        else
        {
            newHeight = height;
            newWidth = (newHeight/image.Height)*image.Width;
        }
       if (newWidth > width)
        {
            newWidth = width;
        }
        if (newHeight > height)
        {
            newHeight = height;
        }
        //取得图片大小
        Size size = new Size((int) newWidth, (int) newHeight);
        //新建一个bmp图片
        System.Drawing.Image bitmap = new Bitmap(size.Width, size.Height);
        //新建一个画板
        Graphics g = Graphics.FromImage(bitmap);
        //设置高质量插值法
        g.InterpolationMode = InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = SmoothingMode.HighQuality;
        //清空一下画布
        g.Clear(Color.White);
        //在指定位置画图
        g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    new Rectangle(0, 0, image.Width, image.Height),
                    GraphicsUnit.Pixel);
        /**////文字水印
        //System.Drawing.Graphics G=System.Drawing.Graphics.FromImage(bitmap);
        //System.Drawing.Font f=new Font("宋体",10);
        //System.Drawing.Brush b=new SolidBrush(Color.Black);
        //G.DrawString("myohmine",f,b,10,10);
        //G.Dispose();
        /**////图片水印
        //System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("pic/1.gif"));
        //Graphics a = Graphics.FromImage(bitmap);
        //a.DrawImage(copyImage, new Rectangle(bitmap.Width-copyImage.Width,bitmap.Height-copyImage.Height,copyImage.Width, copyImage.Height),0,0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
       //copyImage.Dispose();
        //a.Dispose();
       //copyImage.Dispose();
        //保存高清晰度的缩略图
        MemoryStream stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Jpeg);
        byte[] buffer = stream.GetBuffer();
        g.Dispose();
        image.Dispose();
        bitmap.Dispose();
        return buffer;
    }
}
