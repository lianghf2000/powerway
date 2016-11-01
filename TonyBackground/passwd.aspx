<%@ Page Language="C#" AutoEventWireup="true" CodeFile="passwd.aspx.cs" Inherits="adminlontro_passwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../JS/jquery.js" type="text/javascript"></script>

    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 102px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" colspan="2">
                &nbsp;<span class="cs6">当前位置 → 修改密码
                </span>&nbsp;</td>
        </tr>
        <tr>
            <td height="1" bgcolor="#8BA6B5" colspan="2">
            </td>
        </tr>
        <tr>
            <td height="12" class="style1">
                用户</td>
            <td height="12">
            &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="#3399FF" Text="更新成功" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="12" class="style1">
                原始密码</td>
            <td height="12">
            &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="旧密码不正确" 
                    onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td height="12" class="style1">
                新密码</td>
            <td height="12">
            &nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox3" ControlToValidate="TextBox2" Display="Dynamic" 
                    ErrorMessage="两次密码输入不一致"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td height="12" class="style1">
                确认密码</td>
            <td height="12">
            &nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="12" align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确认" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
