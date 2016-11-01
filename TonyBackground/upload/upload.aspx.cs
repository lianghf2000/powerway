using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
public partial class TonyBackground_upload_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("~/uploads/")+this.FileUpload1.FileName);

            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/uploads/") + this.FileUpload1.FileName);
            Response.Write(img.Height);
            Response.Write(img.Width);


            this.Literal1.Text = "<script>var ic = new ImgCropper('bgDiv', 'dragDiv', '../../uploads/" + FileUpload1.FileName + "', " + img.Width.ToString() + ", " + img.Height.ToString() + ", {dragTop: 0, dragLeft: 0, dragWidth:400,dragHeight:300,Scale:true, Right: 'rRight', Left: 'rLeft', Up: 'rUp', Down: 'rDown',RightDown: 'rRightDown', LeftDown: 'rLeftDown', RightUp: 'rRightUp', LeftUp: 'rLeftUp',View: 'viewDiv', viewWidth: 400, viewHeight: 300});</script>";
            img.Dispose();
        }
    }
}
