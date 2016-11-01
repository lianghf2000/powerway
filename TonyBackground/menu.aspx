<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="adminlontro_menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../JS/jquery.js" type="text/javascript"></script>

    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                        <td align="left" class="cs7">关键字：<asp:TextBox ID="searchKey" runat="server" 
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
                        <asp:HyperLink ID="addlink" runat="server" ImageUrl="images/a11.jpg" 
                                Visible="False">add</asp:HyperLink>    
                        </td>
                        <td align="right">
                            <asp:HyperLink ID="listlink" runat="server" ImageUrl="images/a12.jpg">HyperLink</asp:HyperLink>
                          </td>
                      </tr>
                    </table></td>
                  </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BorderStyle="None" BorderWidth="0px" CellPadding="0" CellSpacing="1" 
            CssClass="Grid" ondatabound="GridView1_DataBound" 
            onrowdatabound="GridView1_RowDataBound">
            <RowStyle CssClass="MenuGridRow" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <input type="checkbox" value="<%# Eval(PkFiled) %>" name="SelectThis" />                        
                    </ItemTemplate>
                    <HeaderTemplate>
                        <input type="checkbox" title="全选" id="selectall" />
                    </HeaderTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridHeader" />
        </asp:GridView>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" valign="top">
                <table width="18%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="center">
        &nbsp;</td>
                        <td align="left">
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="images/a6.jpg" 
                                onclick="ImageButton3_Click" />
&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="操作所选" 
            Visible="False" />
    
        <asp:Literal ID="script" runat="server"></asp:Literal>
    
    </div>
    <script language="javascript">
        $(document).ready(function()
        {
            $("#selectall").click(function()
            {
                $("input[type='checkbox']").attr("checked",$(this).attr("checked"));
            });

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
    </div>
    </form>
</body>
</html>
