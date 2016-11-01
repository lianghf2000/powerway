<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
    <meta name="keywords" content="<%=Camnpr.ConfigHelper.GetConfigString("KeyWord")%>" />
    <meta name="description" content="<%=Camnpr.ConfigHelper.GetConfigString("Description")%>" />
    <meta name="ROBOTS" content="FOLLOW,INDEX" />
    <script src="/js/changimages.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="imgADPlayer" style="width:980px;height:280px;margin-top:76px;"></div>
      <script type="text/javascript">

          <%for(int i=0;i<imgdt.Rows.Count;i++){ %>
            PImgPlayer.addItem('<%=imgdt.Rows[i]["Name"].ToString() %>', '<%=imgdt.Rows[i]["Come"].ToString() %>', '<%="/uploads/"+imgdt.Rows[i]["PhotoPath"].ToString() %>'); 
          <%} %>

          PImgPlayer.init("imgADPlayer", 980, 280);   
   </script>
   <div class="article-fullview"     style="margin-top:3px;">
        <div class="page-details"       style="width:910px; margin:0 auto;">

 
            <ul class="my-list" style="width:300px;float:left">
            <h2>热门职位</h2>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <li><span><a title="立即阅读" href="/page/singlepage.aspx?t=nav&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>"></a>&nbsp;<img src="/images/red-arrow.gif" style="position: relative; top: 2px;"></span><a href="/page/singlepage.aspx?t=nav&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>"><%#Eval("title") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>



            <ul class="my-list" style="width:300px;float:left;margin-left:5px;">
            <h2>主要业务</h2>
                <asp:Repeater ID="rptList2" runat="server">
                    <ItemTemplate>
                        <li><span><a title="立即阅读" href="/page/singlepage.aspx?t=menu&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>"></a>&nbsp;<img src="/images/red-arrow.gif" style="position: relative; top: 2px;"></span><a href="/page/singlepage.aspx?t=menu&m=<%#Eval("title").ToString().Replace("&","") %>&id=<%#Eval("id") %>"><%#Eval("title") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

            <ul class="my-list" style="width:300px;float:left;margin-left:5px;">
             <div class="contactus">
              <h2>联系我们</h2>
              <h3>客服电话：400 029 0869 <br>电话：0086-29-81877800 <br>邮箱：<a href="mailto:tonyleung@powerways.net">tonyleung@powerways.net</a></h3>
              <a href="http://www.powerways.net" target="_blank"><img  src='images/qrcode_for_gh_e762a52306c4_258.jpg'></a>	</div>
            </ul>
          </div>
    </div>
</asp:Content>
