<%@ WebHandler Language="C#" Class="imgShowCut" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
public class imgShowCut : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string path = context.Request.QueryString["p"];
        string topstr = context.Request.QueryString["t"];
        string leftstr = context.Request.QueryString["l"];
        string widthstr = context.Request.QueryString["w"];
        string heightstr = context.Request.QueryString["h"];
        string s = context.Request.QueryString["s"];
        bool small = false;
        string b = context.Request.QueryString["b"];
        bool big = false;
        if (!string.IsNullOrEmpty(s))
        {
            small = true;
        }
        if (!string.IsNullOrEmpty(b))
        {
            big = true;
        }
        
        int top = 0;
        int left = 0;
        context.Response.ContentType = "image/jpeg";

        if (!File.Exists(context.Server.MapPath(path)))
        {
            Bitmap no = new Bitmap (1, 1, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics gno = Graphics.FromImage(no);
            gno.Clear(Color.Transparent);
            gno.DrawRectangle(new Pen(Color.White), 0, 0, 1, 1);
            MemoryStream msno = new MemoryStream();
            no.Save(msno, System.Drawing.Imaging.ImageFormat.Png);

            no.Dispose();
            gno.Dispose();
            no.Dispose();
            msno.WriteTo(context.Response.OutputStream);
            return;
        }
        Image imgPhoto = Image.FromFile(context.Server.MapPath(path));
        int width = imgPhoto.Width;
        int height = imgPhoto.Height;        
        
        if (!string.IsNullOrEmpty(widthstr))
        {
            int.TryParse(widthstr, out width);
        }
        if (!string.IsNullOrEmpty(heightstr))
        {
            int.TryParse(heightstr, out height);
        }

        if (!string.IsNullOrEmpty(topstr))
        {
            if (topstr.ToLower() == "mid" || topstr.ToLower() == "middle" || topstr.ToLower() == "center")
            {
                top = (imgPhoto.Height - height) / 2;
            }
            else
            {
                int.TryParse(topstr, out top);
            }
        }
        if (!string.IsNullOrEmpty(leftstr))
        {
            if (leftstr.ToLower() == "mid" || leftstr.ToLower() == "middle" || leftstr.ToLower() == "center")
            {
                left = (imgPhoto.Width - width) / 2;
            }
            else
            {
                int.TryParse(leftstr, out left);
            }
        }        
        
        Bitmap bmPhoto = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        Graphics gbmPhoto = Graphics.FromImage(bmPhoto);
        gbmPhoto.Clear(Color.Transparent);

        if (small && (imgPhoto.Width>width || imgPhoto.Height>height))
        {
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = imgPhoto.Width;
            int oh = imgPhoto.Height;

            if ((double)imgPhoto.Width / (double)imgPhoto.Height > (double)towidth / (double)toheight)
            {
                oh = imgPhoto.Height;
                ow = imgPhoto.Height * towidth / toheight;
                y = 0;
                x = (imgPhoto.Width - ow) / 2;
            }
            else
            {
                ow = imgPhoto.Width;
                oh = imgPhoto.Width * height / towidth;
                x = 0;
                y = (imgPhoto.Height - oh) / 2;
            }
            
            gbmPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
        }
        else if (big && (imgPhoto.Width < width || imgPhoto.Height < height))
        {
            MemoryStream mms = new MemoryStream();
            imgPhoto.Save(mms, System.Drawing.Imaging.ImageFormat.Png);
            mms.WriteTo(context.Response.OutputStream);
            mms.Dispose();
            imgPhoto.Dispose();
            return;
        }
        else
        {
            int w = width;
            int h = height;
            if (imgPhoto.Width < width) { w = imgPhoto.Width; }
            if (imgPhoto.Height < height) { h = imgPhoto.Height; }
            
            gbmPhoto.FillRectangle(Brushes.White,0,0,width,height);
            
            gbmPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, w, h), left, top, w, h, GraphicsUnit.Pixel);            
        }
        
        MemoryStream ms2 = new MemoryStream();
        bmPhoto.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);

        imgPhoto.Dispose();
        gbmPhoto.Dispose();
        bmPhoto.Dispose();

        ms2.WriteTo(context.Response.OutputStream);
        ms2.Dispose();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}