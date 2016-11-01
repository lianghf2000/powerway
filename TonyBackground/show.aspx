<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="adminlontro_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
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
        <asp:Panel ID="main" runat="server">
        </asp:Panel>
    

    </div>
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/ok.jpg" 
        onclick="ImageButton2_Click" />
    </form>
</body>
</html>
