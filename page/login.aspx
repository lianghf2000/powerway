<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="page_login" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .login-content{margin:0 auto;width:900px;}
        .login-content ul{ list-style:none}
        .login-content li{line-height:30px;margin-bottom:10px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="clear:both;margin-top:100px"></div>
    <div class="login-content">
        <ul class="login-content">
            <li>电子邮件地址：<input type="text" runat="server" id="txtEmail" /><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" 
                    ControlToValidate="txtEmail"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式错误" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtEmail"></asp:RegularExpressionValidator></li>
            <li>　　　　密码：<input type="password" runat="server" id="txtPass" /><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" 
                    ControlToValidate="txtPass"></asp:RequiredFieldValidator></li>
            <li></li>
        </ul>
        <div class="registration-button">
            <asp:LinkButton ID="LinkButton1" class="registration-buttonlink" runat="server" 
                onclick="LinkButton1_Click">登录</asp:LinkButton>
        </div>
    </div>
</asp:Content>

