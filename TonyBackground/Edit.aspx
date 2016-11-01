<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="adminlontro_Edit" ValidateRequest="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script src="JS/jquery.js" type="text/javascript"></script>

    <link href="css/datePicker.css" rel="stylesheet" type="text/css" />

    <script src="JS/DataPicker/date.js" type="text/javascript"></script>

    <script src="JS/DataPicker/jquery.datePicker.min-2.1.1.js" type="text/javascript"></script>

    <script src="JS/jquery.blockUI.js" type="text/javascript"></script>    

    <script src="JS/ajaxfileupload.js" type="text/javascript"></script>

    <script src="JS/UpCutImg.js" type="text/javascript"></script>

    <script src="JS/jquery.lightbox-0.5.js" type="text/javascript"></script>

    <link href="css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    
    <style>
    a.dp-choose-date {
	float: left;
	width: 16px;
	height: 16px;
	padding: 0;
	margin: 5px 3px 0;
	display: block;
	text-indent: -2000px;
	overflow: hidden;
	background: url(images/calendar.png) no-repeat; 
    }
    a.dp-choose-date.dp-disabled {
	    background-position: 0 -20px;
	    cursor: default;
    }
    /* makes the input field shorter once the date picker code
     * has run (to allow space for the calendar icon
     */
    input.dp-applied {
	    width: 140px;
	    float: left;
    }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="tableName" runat="server" />
    <asp:HiddenField ID="thisID" runat="server" />
    <div id="uploaddiv" style="display:none;">
        <iframe id="frame" src="" width="100%" height="100%" frameborder="0" marginheight="0" marginwidth="0">            
        </iframe>
    </div>
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left">
                &nbsp;<span class="cs6">当前位置 
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </span>&nbsp;</td>
        </tr>
        <tr>
            <td height="1" bgcolor="#8BA6B5">
            </td>
        </tr>
        <tr>
            <td height="12">
            </td>
        </tr>
    </table>
        <table width="99%" height="14" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="51%" align="left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="left" class="cs7"><asp:Literal ID="Literal3" runat="server" Text="关键字："></asp:Literal>
                            <asp:TextBox ID="searchKey" runat="server" 
                                Width="222px"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/a4.jpg" 
                                onclick="ImageButton1_Click" />
                          </td>
                      </tr>
                    </table></td>
                    <td width="49%" align="right"><table width="84%" height="17" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td align="right">
                            <asp:HyperLink ID="addmenulink"
                                runat="server" ImageUrl="images/a9.jpg">HyperLink</asp:HyperLink></td>
                        <td align="right">
                            <asp:HyperLink ID="menulink" runat="server" ImageUrl="images/a10.jpg">HyperLink</asp:HyperLink>
                          </td>
                        <td align="right">        
                        <asp:HyperLink ID="addlink" runat="server" ImageUrl="images/a11.jpg">add</asp:HyperLink>    
                        </td>
                        <td align="right">
                            <asp:HyperLink ID="listlink" runat="server" ImageUrl="images/a12.jpg">HyperLink</asp:HyperLink>
                          </td>
                      </tr>
                    </table></td>
                  </tr>
                </table>
                <table width="98%"><tr><td class="title">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal></td></tr></table>

<%if (Request.QueryString["t"].ToLower() == "menu" || Request.QueryString["t"].ToLower() == "nav" || Request.QueryString["t"].ToLower() == "news")
  { %>
        <span class="CaptionCss" id="title_lbl" style="margin:0 45px;">地区选择（可以多选）</span>
        <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>--%>
        <br /><%--<span style="font-size:13px;color:#888">第一级：</span><asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="10">
        </asp:CheckBoxList>
        <span style="font-size:13px;color:#888">第二级：</span><asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="10">
        </asp:CheckBoxList>
        <span style="font-size:13px;color:#888">第三级：</span>--%><asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatDirection="Horizontal" RepeatColumns="15">
        </asp:CheckBoxList>
 <%} %>
        <asp:Panel ID="main" runat="server">
        </asp:Panel>
 
    

    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" 
        ValidationGroup="modify" Visible="False" />
    <asp:ImageButton ID="ImageButton2" runat="server" OnClientClick="javascript:_refresh();" ImageUrl="images/ok.jpg" 
        onclick="ImageButton2_Click" />
    </form>
    <input id="unblock" type="button" value="button" style="display:none;" />
    <script language="javascript">

        function _refresh() {
            if ($("#ispage_lbl").length || $("#typename_lbl").length) window.parent.frames['leftFrame'].location.href = window.parent.frames['leftFrame'].location.href+"?t="+new Date().getTime();
        }

        $(document).ready(function()
        {
            $("#unblock").click(function() { $.unblockUI(); });
            //initUpload("img");

            $("#searchKey").keydown(function()
            {
                if (event.keyCode == 13)
                {
                    $("#ImageButton1").focus();
                    $("#ImageButton1").click();
                }
            });
        });
    </script>
</body>
</html>
