<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="TonyBackground_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="js/jquery.js" type="text/javascript"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        function expand(id)
        {
            $(".showss").not("#"+id).hide();
            $("#" + id).toggle();
        }

        $(document).ready(function()
        {
            $(".showss:first").show();
        });
    </script>
    <style type="text/css">

.cs2 {
	font-family: "宋体";
	font-size: 14px;
	line-height: 22px;
	font-weight: bold;
	color: #2C5792;
	text-decoration: none;
}
.cs3 {
	font-family: "宋体";
	font-size: 12px;
	line-height: 15px;
	font-weight: lighter;
	color: #2C5792;
	text-decoration: none;
}
.cs4 {
	font-family: "宋体";
	font-size: 12px;
	line-height: 20px;
	font-weight: lighter;
	color: #2C5792;
	text-decoration: none;
}
.cs5 {
	font-family: "宋体";
	font-size: 12px;
	line-height: 22px;
	font-weight: lighter;
	color: #666666;
	text-decoration: none;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="200" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td  height="15"></td>
                            </tr>
                            <tr>
                              <td height="24" align="left" class="cs2">&nbsp;网站信息管理</td>
                            </tr>
                            <tr>
                              <td  height="19" align="left" valign="middle" bgcolor="#E5F1FE" class="cs3">&nbsp;&nbsp;用户名： 
                                  <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                              <td  height="1" align="left"></td>
                            </tr>
                            <tr>
                              <td  height="19" align="left" valign="middle" bgcolor="#E5F1FE" class="cs3">&nbsp;&nbsp;操  作： <a href="passwd.aspx" target="main">改密码</a>&nbsp;
&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../" Target="_blank">去首页</asp:HyperLink>&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">退出</asp:LinkButton>
                                  </td>
                            </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="12"></td>
                      </tr>
                      <tr>
                        <td align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="2%" height="28" align="left" valign="middle" 
                                        background="images/di6.jpg"><img src="images/di4.jpg" width="3" 
                                          height="28" /></td>
                                  <td width="96%" align="left" valign="middle" background="images/di6.jpg"><span class="cs2">&nbsp;信息管理</span>&nbsp;&nbsp;<a title="右侧添加的分类，左侧不显示，请刷新" href="javascript:location.href=location.href;" style="font-size: 12px;text-decoration: none;">刷新分类</a></td>
                                  <td width="2%" align="right" valign="middle" background="images/di6.jpg">
                                      <img src="images/di5.jpg" width="3" height="28" /></td>
                                </tr>
                                <tr>
                                  <td colspan="3" align="center" valign="top" style="border:#A8D6EE 1px solid; height:auto;">
        
        <asp:DataList ID="DataList1" runat="server" 
            onitemdatabound="DataList1_ItemDataBound" Width="100%">
            <ItemTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border: #BCE1F4 1px solid">
                    <tr>
                        <td height="20" align="center" background="images/di3.jpg">
                            <table width="93%" height="16" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="10%" height="16" align="left">
                                    <%# Convert.ToBoolean(Eval("IsSpector").ToString())?"":"<img src=\"images/a2.jpg\" width=\"9\" height=\"9\" />" %>                                        
                                    </td>
                                    <td width="90%" align="left" valign="bottom" class='<%# Convert.ToBoolean(Eval("IsSpector").ToString())?"cs2":"cs3" %>' style='<%# Convert.ToBoolean(Eval("IsSpector").ToString())?"":"cursor:pointer" %>' onclick='<%# Convert.ToBoolean(Eval("IsSpector").ToString())?"return false;":"" %>javascript:expand(<%# Eval("id") %>)'>
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Name") %>'></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id='<%# Eval("id") %>' class="showss">
                <tr>
                <td style=" width:15px;"></td>
                <td align="left">
                <asp:HiddenField ID="hide" runat="server" Value='<%# Eval("id") %>' />
                <asp:TreeView ID="tree" runat="server" ExpandDepth="0" ShowLines="True" CssClass="cs4">
                </asp:TreeView>
                </td></tr></table>
            </ItemTemplate>
            <ItemStyle Width="100%" />
        </asp:DataList>
                                    </td>
                                </tr>
                              </table></td>
                            </tr>
                          
                        </table></td>
                      </tr>
                      <tr>
                        <td  height="10"></td>
                      </tr>
                  </table>&nbsp;<asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" Visible="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="name" 
                DataNavigateUrlFormatString="list.aspx?t={0}" DataTextField="name" 
                HeaderText="表名" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
