<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cut.aspx.cs" Inherits="upcutimg_cut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Expires" CONTENT="0"> 
<meta http-equiv="Cache-Control" CONTENT="no-cache"> 
<meta http-equiv="Pragma" CONTENT="no-cache"> 
    <title></title>
    <style>
        #Canvas
        {
            position: relative;
            width: 400px;
            height: 400px;
            border: 1px solid #000000;
            overflow: hidden;
            cursor: pointer;
        }
        #IconContainer
        {
            position: relative;
            left: 0px;
            width: 100%;
            height: 100%;
        }
        #IconContainer img
        {
            filter: alpha(opacity=60);
            opacity: 0.6;
            background-color: #ccc;
        }
        #ImageDragContainer
        {
            border: 1px solid #ff0000;
            width: 0;
            height: 0;
            cursor: pointer;
            position: relative;
            overflow: hidden;
            z-index: 1;
        }
        #bar
        {
            width: 211px;
            height: 18px;
            background-image: url("image/track.gif");
            background-repeat: no-repeat;
            position: relative;
        }
        .child
        {
            width: 11px;
            height: 16px;
            top: 2px;
            position: absolute;
            left: 100px;
        }
    </style>

    <script src="JS/jquery.js" type="text/javascript"></script>

    <script src="JS/jquery-ui-personalized-1.6rc2.js" type="text/javascript"></script>

    <script src="JS/jquery.blockUI.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript">
        function setImg(v)
        {
            var obj = $(window.parent.document);
            obj.find("#unblock").click();
            obj.find("#<%= columnName %>_img").attr("src", "../uploads/"+v);
            obj.find("#<%= columnName %>_value").val(v);
        }
    </script>
    <asp:Literal ID="script" runat="server"></asp:Literal>
    <div id="Canvas">
        <div id="ImageDragContainer">
            <asp:Image ID="ImageDrag" runat="server" ImageUrl="" CssClass="imagePhoto"
                ToolTip="" />
        </div>
        <div id="IconContainer">
            <asp:Image ID="ImageIcon" runat="server" ImageUrl="" CssClass="imagePhoto"
                ToolTip="" />
        </div>
    </div>
    <div class="uploaddiv">
        <table>
            <tr>
                <td id="Min">
                    <%--<img alt="缩小" src="image/_c.gif" onmouseover="this.src='image/_c.gif';" onmouseout="this.src='image/_h.gif';"
                        id="moresmall" class="smallbig" />--%>
                </td>
                <td>
                    <div id="bar">
                        <%--<div class="child">
                        </div>--%>
                        <img src="image/grip.gif" class="child" />
                    </div>
                </td>
                <td id="Max">
                    <%--<img alt="放大" src="image/c.gif" onmouseover="this.src='image/c.gif';" onmouseout="this.src='image/h.gif';"
                        id="morebig" class="smallbig" />--%>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="realWidth" runat="server" />    
    <asp:HiddenField ID="realHeight" runat="server" />
    <asp:HiddenField ID="top" runat="server" />
    <asp:HiddenField ID="left" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="剪切" onclick="Button1_Click" />
    <input id="c" type="button" value="取消" />
    <script language="javascript">
        function getRealWidth()
        {
            $("#realWidth").val($("#ImageDrag").width());
        }
        function getRealHeight()
        {
            $("#realHeight").val($("#ImageDrag").height());
        }
        function getTop()
        {
            $("#top").val($("#ImageDrag").css("top"));
        }
        function getLeft()
        {
            $("#left").val($("#ImageDrag").css("left"));
        }
        $(document).ready(function()
        {
            $("#c").click(function() 
            {
                var obj=$(window.parent.document);
                obj.find("#unblock").click();
            });
            
            var inW = <%= needWidth %>;
            var inH = <%= needHeight %>;
            //设置内框宽高
            $("#ImageDragContainer").width(inW);
            $("#ImageDragContainer").height(inH);
            
            //内框超过默认外框            
            if ($("#ImageDragContainer").width()>$("#Canvas").width())
            {
                $("#Canvas").width($("#ImageDragContainer").width()+100);
            }
            if ($("#ImageDragContainer").height()>$("#Canvas").height())
            {
                $("#Canvas").height($("#ImageDragContainer").height()+100);
            }
            
            var outW = $("#Canvas").width();
            var outH = $("#Canvas").height();
            
            
            var inLeft = (outW - inW) / 2;
            var inTop = (outH - inH) / 2;
            $("#IconContainer").css("top", -inH);            
            
            //设置内框在中间
            $("#ImageDragContainer").css("top", inTop);
            $("#ImageDragContainer").css("left", inLeft);
                        
            var inImgTop;
            var inImgLeft;
            var outImgTop;
            var outImgLeft;
            
            var inImgHeight=parseInt($("#ImageDrag").height());
            var inImgWidth=parseInt($("#ImageDrag").width());
            
            if (inImgHeight>inH)
            {
                //如果图片高于所需
                inImgTop=parseInt((inH-inImgHeight)/2);
            }
            else
            {
                //如果图片高小于等于所需
                inImgTop=0;                
            }
            if (inImgWidth>inW)
            {
                //如果图片宽于所需
                inImgLeft=parseInt((inW-inImgWidth)/2);
            }
            else
            {
                //如果图片宽小于等于所需
                inImgLeft=0;
            }
            //设置内图显示中间            
            $("#ImageDrag").css("left",inImgLeft);
            $("#ImageDrag").css("top",inImgTop);
            //设置外图与内图重合
            $("#ImageIcon").css("left",inImgLeft+inLeft);
            $("#ImageIcon").css("top",inImgTop+inTop);

            $("#NowLeft").val($("#ImageDrag").css("left"));
            $("#NowTop").val($("#ImageDrag").css("top"));

            $("#outLeft").val($("#ImageIcon").css("left"));
            $("#outTop").val($("#ImageIcon").css("top"));
                        
            getRealWidth();
            getRealHeight();
            getLeft();
            getTop();
            
            //小图拖动
            $("#ImageDrag").draggable({
                cursor: 'move',
                drag: function(e, ui)
                {
                    var self = $(this).data("draggable");

                    if (self.position.top > 0)
                    {
                        self.position.top = 0;
                    }
                    if (self.position.left > 0)
                    {
                        self.position.left = 0;
                    }
                    if (self.position.top < parseInt($(this).height()) * -1 + $("#ImageDragContainer").height())
                    {
                        self.position.top = parseInt($(this).height()) * -1 + $("#ImageDragContainer").height();
                    }
                    if (self.position.left < parseInt($(this).width()) * -1 + $("#ImageDragContainer").width())
                    {
                        self.position.left = parseInt($(this).width()) * -1 + $("#ImageDragContainer").width();
                    }

                    

                    var gotoTop = self.position.top + inTop;
                    var gotoLeft = self.position.left + inLeft;
                   

                    $("#ImageIcon").css("top", gotoTop + "px");
                    $("#ImageIcon").css("left", gotoLeft + "px");
                    
                    getRealWidth();
                    getRealHeight();
                    getLeft();
                    getTop();
                }
            });

            //大图拖动
            $("#ImageIcon").draggable({
                cursor: 'move',
                drag: function(e, ui)
                {
                    var self = $(this).data("draggable");
                    if (self.position.top > inTop)
                    {
                        self.position.top = inTop;
                    }
                    if (self.position.left > inLeft)
                    {
                        self.position.left = inLeft;
                    }                    

                    var allowTop = parseInt($(this).height()) * -1 + inTop + $("#ImageDragContainer").height();
                    if (self.position.top < allowTop)
                    {
                        self.position.top = allowTop;
                    }
                    var allowLeft = parseInt($(this).width()) * -1 + inLeft + $("#ImageDragContainer").width();
                    if (self.position.left < allowLeft)
                    {
                        self.position.left = allowLeft;
                    }

                    var gotoTop = self.position.top - inTop;
                    var gotoLeft = self.position.left - inLeft;
                    $("#ImageDrag").css("top", gotoTop);
                    $("#ImageDrag").css("left", gotoLeft);
                    
                    getRealWidth();
                    getRealHeight();
                    getLeft();
                    getTop();
                }
            });

            //放大缩小条拖动
            var oldH = $("#ImageIcon").height();
            var oldW = $("#ImageIcon").width();
            $(".child").draggable({
                cursor: "move", containment: $("#bar"),
                drag: function(e, ui)
                {
                    var left = parseInt($(this).css("left"));
                    
                    $(this).css("top", "10");
                    var bili = oldW / oldH;
                    var maxH = oldH * 2;
                    var maxW = oldW * 2;

                    var needW = parseInt($("#ImageDragContainer").width());
                    var needH = parseInt($("#ImageDragContainer").height());

                    var minH = needH;
                    var minW = needW;

                    var perH = (maxH - minH) / 200;
                    var perW = (maxW - minW) / 200;
                    var addW = (left - 100) * perW;
                    var addH = (left - 100) * perH;
                    //var addH = addW * bili;
                    var newH = parseInt(oldH + addH);
                    var newW = parseInt(oldW + addW);

                    if (newH < needH)
                    {
                        newH = needH;
                    }
                    if (newW < needW)
                    {
                        newW = needW;
                    }
                    if (needH > needW)
                    {
                        $("#ImageDrag").height(newH);
                        $("#ImageIcon").height(newH);
                    }
                    else
                    {
                        $("#ImageDrag").width(newW);
                        $("#ImageIcon").width(newW);
                    }

                    var nowW = $("#ImageDrag").width();
                    var nowH = $("#ImageDrag").height();
                    var top = parseInt((nowH - needH) / 2);
                    var left = parseInt((nowW - needW) / 2);
                    $("#ImageDrag").css("top", -top);
                    $("#ImageDrag").css("left", -left);

                    var gotoTop = parseInt($("#ImageDrag").css("top")) + inTop;
                    var gotoLeft = parseInt($("#ImageDrag").css("left")) + inLeft;
                    
                    $("#ImageIcon").css("top", gotoTop);
                    $("#ImageIcon").css("left", gotoLeft);
                    
                    getRealWidth();
                    getRealHeight();
                    getLeft();
                    getTop();
                }
            });

        }); 
    </script>
    
    </form>
</body>
</html>
