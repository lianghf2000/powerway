using System;
using System.IO;

public partial class TonyBackground_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //common.ChkLogin();
        os.Text = Environment.OSVersion.ToString();
        soft.Text = Request.ServerVariables["server_software"];

        try
        {
            site_size.Text = ConvertByte(FolderSize(Server.MapPath("../")));
        }
        catch (Exception ex)
        { }
        try
        {
            db_size.Text = ConvertByte(FolderSize(Server.MapPath("../data")));
        }
        catch (Exception ex)
        { }
        try
        {
            file_size.Text = ConvertByte(FolderSize(Server.MapPath("../uploads")));
        }
        catch(Exception ex)
        {}

        version.Text = Environment.Version.ToString();
        pro_count.Text = Environment.ProcessorCount.ToString();
    }

    public long FolderSize(string sPath)
    {
        if (!Directory.Exists(sPath))
            return 0;
        long dLen = 0;

        DirectoryInfo di = new DirectoryInfo(sPath);
        //取得文件的大小
        foreach (FileInfo fi in di.GetFiles())
        {
            dLen += fi.Length;
        }
        //取得文件夹，递归文件夹大小
        foreach (DirectoryInfo dis in di.GetDirectories())
        {
            dLen += FolderSize(dis.FullName);
        }
        return dLen;
    }
    //将BYTE字节数转换成文字显示
    public string ConvertByte(long nBytes)
    {
        string[] sUnits = { "B", "KB", "MB", "GB", "TB" };
        double dBytes = (double)nBytes;
        int i = 0;
        while (dBytes > 1024)
        {
            dBytes /= 1024;
            i++;
        }
        return dBytes.ToString("###.###") + sUnits[i];
    }
}
