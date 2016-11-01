<%@ Page Language="c#" CodeFile="login.aspx.cs" AutoEventWireup="true" Inherits="TonyBackgroud_login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>『 管理登陆 』</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">
        BODY
        {
            margin: 0px;
        }
        .form1
        {
            border-right: #4696ee 1px solid;
            border-top: #4696ee 1px solid;
            font-size: 12px;
            border-left: #4696ee 1px solid;
            color: #000066;
            border-bottom: #4696ee 1px solid;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
        .font1
        {
            font-size: 12px;
            color: #0066cc;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
        .font2
        {
            font-size: 12px;
            color: #000000;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
        .style2
        {
            font-size: 12px;
            color: #ff0000;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
        .style3
        {
            color: #3333cc;
        }
        .style4
        {
            color: #ff0000;
        }
    </style>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script language="javascript">
        function getcode(obj) {
            var rnd = Math.random();
            $.get(
                "getcode.aspx",
                {
                    id: rnd
                },
                function (data) {
                    if (data != "refresh") {
                        obj.value = data;
                    }
                    else {
                        alert('已超时，请重新登陆');
                        location.href = 'default.aspx';
                    }
                }
            );
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<TR>
							<TD><SPAN class="font5"></SPAN>
								<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR>
											<TD>
												<TABLE cellSpacing="0" cellPadding="0" width="616" align="center" border="0">
													<TBODY>
														<TR>
															<TD><IMG height="84" src="images/denglu_r1_c1.jpg" width="281"><IMG height="84" src="images/denglu_r1_c4.jpg" width="335"></TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="616" border="0">
																	<TBODY>
																		<TR>
																			<TD width="281"><IMG height="68" src="images/denglu_r2_c1.jpg" width="281"></TD>
																			<TD width="185"><IMG height="68" src="images/denglu_r2_c4.jpg" width="185"></TD>
																			<TD width="126">
																				<TABLE cellSpacing="0" cellPadding="0" width="126" border="0">
																					<TBODY>
																						<TR>
																							<TD><A href="/"><IMG height="41" src="images/denglu_r2_c7.jpg" width="126" border="0"></A></TD>
																						</TR>
																						<TR>
																							<TD><IMG height="27" src="images/denglu_r3_c7.jpg" width="126"></TD>
																						</TR>
																					</TBODY></TABLE>
																			</TD>
																			<TD><IMG height="68" src="images/denglu_r2_c10.jpg" width="24"></TD>
																		</TR>
																	</TBODY></TABLE>
															</TD>
														</TR>
														<TR>
															<TD><IMG height="50" src="images/denglu_r4_c1.jpg" width="164"><IMG height="50" src="images/denglu_r4_c2.jpg" width="332"><IMG height="50" src="images/denglu_r4_c9.jpg" width="120"></TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="616" border="0">
																	<TBODY>
																		<TR>
																			<TD width="164"><IMG height="135" src="images/denglu_r5_c1.jpg" width="164"></TD>
																			<TD width="332">
																				<TABLE height="135" cellSpacing="0" cellPadding="0" width="332" background="images/denglu_r5_c2.jpg"
																					border="0">
																					<TBODY>
																						<TR>
																							<TD>
																								<TABLE height="96" cellSpacing="0" cellPadding="0" width="266" align="center" border="0">
																									<TBODY>																										
																										<TR>
																											<TD width="48" height="24"><FONT class="font1" color="#000066"><STRONG>用户名</STRONG></FONT></TD>
																											<TD width="218"><asp:TextBox ID="admin_name" runat="server" CssClass="form1" Width="168px" MaxLength="32"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="admin_name" Display="Dynamic" ForeColor="#99CCFF"></asp:RequiredFieldValidator><asp:Label ID="Label1" runat="server" ForeColor="#99CCFF" Text="用户名或密码不正确" Visible="False"></asp:Label></TD>
																										</TR>
																										<TR>
																											<TD height="24"><FONT class="font1" color="#000066"><STRONG>密 码</STRONG></FONT></TD>
																											<TD> <asp:TextBox ID="admin_pass" TextMode="Password" CssClass="form1" Width="168px" MaxLength="32" runat="server"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                                                        ControlToValidate="admin_pass" Display="Dynamic" ForeColor="#99CCFF"></asp:RequiredFieldValidator></TD>
																										</TR>
																										<TR>
																											<TD height="24"><FONT class="font1" color="#000066"><STRONG>验证码</STRONG></FONT></TD>
																											<TD vAlign="top" colSpan="" rowSpan=""><asp:TextBox ID="chkcode" CssClass="form1" Width="88px" MaxLength="32" ondblclick="javascript:getcode(this);" Text="双击即可" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="chkcode" Display="Dynamic" ForeColor="#99CCFF"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="验证码不正确" ControlToValidate="chkcode" Display="Dynamic" ForeColor="#99CCFF" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator><img src="checkcode.aspx" alt="点击更换验证码" onclick="this.src = 'checkcode.aspx?' + Math.random();" /><SPAN class="font1"><SPAN class="font2"></SPAN>
																												</SPAN></TD>
																										</TR>
																									</TBODY></TABLE>
																							</TD>
																						</TR>
																					</TBODY></TABLE>
																			</TD>
																			<TD width="120"><IMG height="135" src="images/denglu_r5_c9.jpg" width="120"></TD>
																		</TR>
																	</TBODY></TABLE>
															</TD>
														</TR>
														<TR>
															<TD><IMG height="13" src="images/denglu_r6_c1.jpg" width="616"></TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="616" border="0">
																	<TBODY>
																		<TR>
																			<TD><IMG height="27" src="images/denglu_r7_c1.jpg" width="337"></TD>
																			<TD><asp:imagebutton OnClick="login_submit_Click" id="ImageButton1" runat="server" ImageUrl="images/denglu_r7_c5.jpg"></asp:imagebutton></TD>
																			<TD><asp:imagebutton id="ImageButton2" runat="server" ImageUrl="images/denglu_r7_c6.jpg"></asp:imagebutton></TD>
																			<TD><IMG height="27" src="images/denglu_r7_c8.jpg" width="131"></TD>
																		</TR>
																	</TBODY></TABLE>
															</TD>
														</TR>
														<TR>
															<TD><IMG height="66" src="images/denglu_r8_c1.jpg" width="281"><IMG height="66" src="images/denglu_r8_c4.jpg" width="335"></TD>
														</TR>
													</TBODY></TABLE>
												<TABLE height="22" cellSpacing="0" cellPadding="0" width="615" align="center" border="0">
													<TBODY>
														<TR>
															<TD align="center" width="335">&nbsp;</TD>
															<TD align="center" width="280">&nbsp;</TD>
														</TR>
													</TBODY></TABLE>
											</TD>
										</TR>
									</TBODY></TABLE>
			
			</TD></TR></TBODY>
			</TABLE>
    </form>
</body>
</html>
