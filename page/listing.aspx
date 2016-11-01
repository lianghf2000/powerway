<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="listing.aspx.cs" Inherits="page_listing" %>
    <%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-topic-page">
        <div class="main-title-container">
            <asp:Repeater ID="rptParentContent" runat="server">
                <ItemTemplate>
                    <%#Eval("typecontent") %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="main-content-container">
            <div class="sub-content-container">
                <div class="section-topic-tab-zone section-topic-tab-zone-exist">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <div width="100%" class="ms-WPBody">
                                                        <div>
                                                            <div class="noindex">
                                                                <span class="tab-container">
                                                                    <%System.Data.DataRow[] dr = mydt.Rows.Count > 0 ? mydt.Select() : new System.Data.DataRow[0];
                                                                      for (int x = 0; x < dr.Length; x++)
                                                                      {
                                                                          if (cid == "0")
                                                                          {
                                                                               %>
                                                                                <%if (id != "0" && dr[x]["id"].ToString() == id)
                                                                                  {
                                                                                      ispage = dr[x]["ispage"].ToString().ToLower();%>
                                                                                <span><span class="selected">
                                                                                    <%=dr[x]["typename"]%></span> </span>
                                                                                <%}
                                                                                  else if (id == "0" && cid == "0")
                                                                                  {
                                                                                      ispage = dr[x]["ispage"].ToString().ToLower();
                                                                                      id = dr[x]["id"].ToString();%>
                                                                                  <span><span class="selected">
                                                                                    <%=dr[x]["typename"]%></span> </span>

                                                                                      <%}
                                                                                  else
                                                                                  { %>
                                                                                <span><a title="<%=dr[x]["typename"] %>" href="<%=dr[x]["ispage"].ToString().ToLower()=="true"?"/page/listing.aspx?t=menutype&pid="+pid+"&id=":"/page/listing.aspx?pid="+pid+"&cid=" %><%=dr[x]["id"] %>"
                                                                                    style="text-decoration: none;">
                                                                                    <%=dr[x]["typename"]%></a> </span>
                                                                                <%}
                                                                          }
                                                                          else
                                                                          { %>

                                                                                <%if (cid == dr[x]["id"].ToString())
                                                                                {
                                                                                    //ispage = dr[x]["ispage"].ToString().ToLower();
                                                                                 %>
                                                                                    <span><span class="selected">
                                                                                        <%=dr[x]["typename"]%></span> </span>
                                                                                    <%}
                                                                                  else
                                                                                  { %>
                                                                                <span><a title="<%=dr[x]["typename"] %>" href="<%=dr[x]["ispage"].ToString().ToLower()=="true"?"/page/listing.aspx?t=menutype&pid="+pid+"&id=":"/page/listing.aspx?pid="+pid+"&cid=" %><%=dr[x]["id"] %>"
                                                                                    style="text-decoration: none;">
                                                                                    <%=dr[x]["typename"]%></a> </span>
                                                                                <%}%>

                                                                      <%} %>


                                                                    <%} %>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="content-zone">
                    <% //Response.Write(id + "/" + ispage);
                        if (id != "0" && ispage == "true")
                        {
                            System.Data.DataRow[] daiye = mydt.Rows.Count > 0 ? mydt.Select("[id]=" + id) : new System.Data.DataRow[0];
                            %>
                            <%=daiye.Length > 0 ? daiye[0]["typecontent"].ToString() : ""%>
                    <%}
                        else
                        {

                            if (cid != "0")
                            {
                                System.Data.DataSet myds = bc.GetDataSet("select [id],[title] from [" + forlanguage + table.Replace("type", "") + "] where [typeid]=" + cid + " and [isis]=1 and charindex( '," + Camnpr.Common.DataCookie.GetCookie("_for_area") + ",',','+area+',')>0 order by [orderid] desc, [inputdate] desc");
                                if (myds.Tables.Count > 0 && myds.Tables[0].Rows.Count > 0)
                                {%>
                    <ul class="my-list">
                        <% foreach (System.Data.DataRow dd in myds.Tables[0].Rows)
                           {%>
                        <li><span><a target="_blank" title="立即阅读" href='<%="/page/singlepage.aspx?m=" + dd["title"].ToString().Replace("&", "") + "&t=" + table.Replace("type", "") + "&id="+dd["id"].ToString() %>'>立即阅读</a>&nbsp;<img src="/images/red-arrow.gif" style="position: relative; top: 2px;"></span><a target="_blank" href='<%="/page/singlepage.aspx?m=" + dd["title"].ToString().Replace("&", "") + "&t=" + table.Replace("type", "") + "&id="+dd["id"].ToString() %>'><%=dd["title"] %></a></li>
                        <%}%>
                    </ul>
                    <%
                        }
                            }

                        }%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
