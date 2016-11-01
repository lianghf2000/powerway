<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Results.aspx.cs" Inherits="page_Results" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="article-fullview">
        <div class="page-title">
		    <h1 class="fcolor-a fsize-b">
			    您的搜索”<%=strKey %>”结果：
		    </h1>
	    </div>
    </div>

    <div id="searchResultListSection">
        
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="keywordSearchResult">
                    <h3>
                        <a style="color: #AA1133;" href="/page/singlepage.aspx?t=<%#Eval("t") %>&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>"
                            title="<%#Eval("title") %>"><%#Eval("title")%></a></h3>            
            
                    <div style="clear: both;"><%#Eval("smallcontent")%></div>
                    <br>
                    <div class="gray-box">
                        <a class="whitearrow-link" href="/page/singlepage.aspx?t=<%#Eval("t") %>&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>" title="阅读更多">阅读更多</a></div>
                    <br>
                    <br>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</asp:Content>
