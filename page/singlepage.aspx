<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="singlepage.aspx.cs" Inherits="page_singlepage" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="article-fullview">
        <div class="page-title">
		    <h1 class="fcolor-a fsize-b">
			    <%=title %>
		    </h1>
	    </div>
        <div class="page-details">
            <ul class="my-list">
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <%#Eval("neirong")%>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
    </div>
</asp:Content>

