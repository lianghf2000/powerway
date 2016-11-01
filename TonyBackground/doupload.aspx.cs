using System;
using System.IO;
using System.Web;
using System.Drawing;

public partial class upcutimg_doupload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Files.Count > 0)
        {
            HttpPostedFile file = Request.Files[0];            
            string msg = "";
            string error = "";
            string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    FileName += rnd.Next(9).ToString();
                }
                FileName += Path.GetExtension(file.FileName);
            if (file.ContentLength == 0)
                error = "文件长度为0";
            else
            {
                file.SaveAs(Server.MapPath("~/uploads/UserUp/") + FileName);
                //msg = "上传成功";
                
                msg = "UserUp/" + FileName;
            }
            int h = 0;
            int w = 0;
            try
            {
                Image img = Image.FromFile(Server.MapPath("~/uploads/UserUp/" + FileName));
                h = img.Height;
                w = img.Width;
                img.Dispose();
            }
            catch (Exception ex)
            { }
            string result = "{ error:'" + error + "', msg:'" + msg + "',height:'" + h.ToString() + "',width:'" + w.ToString() + "'}";
            Response.Write(result);
            Response.End();
        }
    }
}
