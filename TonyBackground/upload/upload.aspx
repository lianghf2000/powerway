<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="TonyBackground_upload_upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="upandcut.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <style type="text/css">
#rRightDown,#rLeftDown,#rLeftUp,#rRightUp,#rRight,#rLeft,#rUp,#rDown{position:absolute;background:#F00;width:5px; height:5px; z-index:500; font-size:0;}
#dragDiv{border:1px solid #000000;}
</style>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50%"><div id="bgDiv" style="width:400px; height:500px;">
        <div id="dragDiv">
          <div id="rRightDown" style="right:0; bottom:0;"> </div>
          <div id="rLeftDown" style="left:0; bottom:0;"> </div>
          <div id="rRightUp" style="right:0; top:0;"> </div>
          <div id="rLeftUp" style="left:0; top:0;"> </div>
          <div id="rRight" style="right:0; top:50%;"> </div>
          <div id="rLeft" style="left:0; top:50%;"> </div>
          <div id="rUp" style="top:0; left:50%;"> </div>
          <div id="rDown" style="bottom:0;left:50%;"></div>
        </div>
      </div></td>
    <td><div id="viewDiv" style="width:200px; height:200px;"> </div></td>
  </tr>
</table>
<script>
//    var ic = new ImgCropper("bgDiv", "dragDiv", "1.jpg", 300, 400, {
//        dragTop: 0, dragLeft: 0,
//        Right: "rRight", Left: "rLeft", Up: "rUp", Down: "rDown",
//        RightDown: "rRightDown", LeftDown: "rLeftDown", RightUp: "rRightUp", LeftUp: "rLeftUp"
//    });
    
</script>
<script>

    //设置图片大小
    function Size(w, h)
    {
        ic.Width = w;
        ic.Height = h;
        ic.Init();
    }
    //换图片
    function Pic(url)
    {
        ic.Url = url;
        ic.Init();
    }
    //设置透明度
    function Opacity(i)
    {
        ic.Opacity = i;
        ic.Init();
    }
    //是否使用比例
    function Scale(b)
    {
        ic.Scale = b;
        ic.Init();
    }
    //Scale(true);
    function Create()
    {
        var p = ic.Url,
	    x = ic.Drag.offsetLeft,
	    y = ic.Drag.offsetTop,
	    w = ic.Drag.offsetWidth,
	    h = ic.Drag.offsetHeight,
	    pw = ic.Width,
	    ph = ic.Height;

        $("imgCreat").src = "ImgCropper.ashx?p=" + p + "&x=" + x + "&y=" + y + "&w=" + w + "&h=" + h + "&pw=" + pw + "&ph=" + ph + "&" + Math.random;
        $("imgCreat").style.display = "";
    }
</script>
<br />

<div>
  <input name="" type="button" value="生成图片" onclick="Create()" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
  <br />
  <img id="imgCreat" style="display:none;" />
</div>

    </form>
</body>
</html>
