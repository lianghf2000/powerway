using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upcutimg_cut : System.Web.UI.Page
{
    public int needWidth;
    public int needHeight;
    public string columnName;
    protected void Page_Load(object sender, EventArgs e)
    {
        string imgurl = Request.QueryString["path"];
        imgurl = Server.UrlDecode(imgurl);
        columnName = Request.QueryString["name"];
        //Response.Write(imgurl);
        needWidth = int.Parse(Request.QueryString["w"]);
        needHeight = int.Parse(Request.QueryString["h"]);

        this.ImageDrag.ImageUrl = "../uploads/" + imgurl;
        this.ImageIcon.ImageUrl = "../uploads/" + imgurl;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int w = int.Parse(this.realWidth.Value);
        int h = int.Parse(this.realHeight.Value);
        int top = int.Parse(this.top.Value.Replace("px", "").Trim()) * -1;
        int left = int.Parse(this.left.Value.Replace("px", "").Trim()) * -1;

        //Response.Write("W:" + w.ToString());
        //Response.Write("H:" + h.ToString());
        //Response.Write("T:" + top.ToString());
        //Response.Write("L:" + left.ToString());
        string imgurl = Request.QueryString["path"];
        string savepath = Server.MapPath("~/uploads/CutSmall/");

        string file = CutPhotoHelp.SaveCutPic(Server.MapPath("../uploads/"+imgurl), savepath, 0, 0, needWidth, needHeight, left, top, w, h);
        //Response.Write("<br>"+file);
        this.script.Text = "<script>setImg('CutSmall/" + file + "')</script>";
        //Response.End();
    }
}
