<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listed.aspx.cs" Inherits="page_listed" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <li><span><a title="立即阅读" href="/page/singlepage.aspx?t=<%=table %>&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>">立即阅读</a>&nbsp;<img src="/images/red-arrow.gif" style="position: relative; top: 2px;"></span><a href="/page/singlepage.aspx?t=<%=table %>&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>"><%#Eval("title") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

            <%--<webdiyer:AspNetPager ID="AspNetPager_log" CssClass="manu" runat="server" PageSize="20"
                    SubmitButtonStyle="" InputBoxStyle=""
                    SubmitButtonText="" NumericButtonTextFormatString="{0}"
                    TextBeforeInputBox="转到第" TextAfterInputBox="页" NumericButtonCount="5"
                    AlwaysShow="True" ShowInputBox="Always" ShowFirstLast="false" 
                OnPageChanged="AspNetPager_log_PageChanged" FirstPageText="首页" 
                LastPageText="尾页" NextPageText="下一页  >" PrevPageText="<  上一页" CustomInfoHTML="" 
                PageIndexBoxStyle="" 
                CurrentPageButtonClass="current" TextAfterPageIndexBox="" 
                TextBeforePageIndexBox="" HorizontalAlign="Center">
           </webdiyer:AspNetPager>--%>

          </div>
    </div>

</asp:Content>
