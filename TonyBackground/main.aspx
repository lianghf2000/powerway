<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="TonyBackground_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	<title>网站后台管理中心</title>
	<link href="css/basiccn.css" rel="stylesheet" type="text/css">
	<style type="text/css">
	<!--
	body {
		background-color: #FFFFFF;
	}
	.b{color:#000066;cursor:hand}
	.menu {
	font-family:Arial;
	cursor:Default;
	font-size:12px;
	border-collapse: collapse;
	}
	.ht{
	font-weight:bold
	}
	-->
	</style>

</head>
<body>
	<br>
	<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
		<tr><td>	<table width="100%" border="0" cellpadding="0" cellspacing="0" align="center">
<tr><td width="1065" height="20" align="left" valign="middle">&nbsp;</td>
</tr>
<tr>
  <td height="15" ></td>
</tr>
		</table></td></tr>
		<tr>
			<td style="border: 1pt #cedbe6 solid">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/t01.jpg">
              <tr >
                <td height="26" ><div align="center" class="localboldfont">
                      <div align="left">
                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                          <tr>
                            <td height="20" ><div align="left" class="greayboldfont"><strong> <font color="#000000">系统信息 </font></strong></div></td>
                          </tr>
                        </table>
                      </div>
                    </div></td>
              </tr>
            </table>
			  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="2%" height="25" style="border-bottom: 1pt #EDF1F0 solid">&nbsp;
							
						</td>
						<td width="18%" valign="middle" style="border-bottom: 1pt #EDF1F0 solid">
							操作系统：</td>
						<td width="80%" valign="top" style="border-bottom: 1pt #EDF1F0 solid">
							<asp:Label ID="os" runat="server"></asp:Label>
						</td>
					</tr>
					<tr bgcolor="#EDF1F0">
					  <td height="25" valign="top" >&nbsp;					  </td>
						<td height="25" valign="middle" >
							IIS/APACHE/TOMCAT：</td>
						<td valign="top" >
							<asp:Label ID="soft" runat="server"></asp:Label>
					  </td>
					</tr>
					<tr>
						<td height="25" valign="top" style="border-bottom: 1pt #EDF1F0 solid">&nbsp;
					  </td>
						<td height="25" valign="middle" style="border-bottom: 1pt #EDF1F0 solid">
							数据库类型及版本：</td>
						<td valign="top" style="border-bottom: 1pt #EDF1F0 solid">
							<asp:Label ID="database" runat="server" Text="Sql Server"></asp:Label>
						</td>
					</tr>
					<tr bgcolor="#EDF1F0">
					  <td height="25" valign="top" style="border-bottom: 1pt #EDF1F0 solid">&nbsp;					  </td>
						<td height="25" valign="middle" bgcolor="#EDF1F0" style="border-bottom: 1pt #EDF1F0 solid">
							当前网站尺寸：</td>
						<td valign="top" style="border-bottom: 1pt #EDF1F0 solid">
							<asp:Label ID="site_size" runat="server"></asp:Label>
					  </td>
					</tr>
					<tr>
						<td height="25" valign="top">&nbsp;
					  </td>
						<td height="25" valign="middle" >
							当前数据库尺寸：</td>
						<td valign="top" >
							<asp:Label ID="db_size" runat="server"></asp:Label>
						</td>
					</tr>
					<tr bgcolor="#EDF1F0">
					  <td height="25" valign="top" >&nbsp;					  </td>
						<td height="25" valign="middle" >
							当前附件尺寸：</td>
						<td valign="middle">
							<asp:Label ID="file_size" runat="server"></asp:Label>
					  </td>
				</tr>
					<tr>
						<td width="2%" height="25" >&nbsp;
							
						</td>
						<td width="18%" valign="middle">
							框架版本：</td>
						<td width="80%" valign="middle" >
							<asp:Label ID="version" runat="server"></asp:Label>
					  </td>
					</tr>
					<tr bgcolor="#EDF1F0">
					  <td height="25" valign="top" >&nbsp;					  </td>
						<td height="25" valign="middle" >
							处理器数量：</td>
						<td valign="middle" >
							<asp:Label ID="pro_count" runat="server"></asp:Label>
					  </td>
				</tr>
			  </table>
		  </td>
		</tr>
	</table>
	<br>
	<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
		<tr>
			<td style="border: 1pt #cedbe6 solid">
				<table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/t01.jpg">
					<tr>
						<td height="26" ><div align="center" class="localboldfont">
								<div align="left">
									<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
										<tr>
											<td height="20">
												<div align="left">
													<font color="#000000">技术支持</font></div>
											</td>
										</tr>
									</table>
								</div>
							</div>
					  </td>
					</tr>
			  </table>
				<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="15" height="25" style="border-bottom: 1pt #EDF1F0 solid">
							<div align="left">
							</div>
						</td>
						<td width="120" valign="middle" style="border-bottom: 1pt #EDF1F0 solid">
							技术支持：</td>
						<td valign="middle" style="border-bottom: 1pt #EDF1F0 solid">
							郑州网建</td>
					</tr>
					<tr bgcolor="#EDF1F0">
					  <td height="25" valign="top" style="border-bottom: 1pt #EDF1F0 solid">&nbsp;					  </td>
						<td height="25" valign="middle" style="border-bottom: 1pt #EDF1F0 solid">
							公司网站：</td>
						<td valign="middle" style="border-bottom: 1pt #EDF1F0 solid">
							<a href="http://www.camnpr.cn" target="_blank">www.camnpr.cn</a></td>
					</tr>					
			  </table>
			</td>
		</tr>
	</table>
	<table width="100%" height="20" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td></td>
      </tr>
    </table>
	<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
		<tr>
			<td height="30" style="border-top: 1pt #646262 solid">
				<div align="center">
					<font color="#B4120F">技术支持 &copy; </font><a href="http://www.camnpr.cn" target="_blank">
<font color="#B4120F">郑州网建</font></a></div>
			</td>
		</tr>
	</table>
</body>
</html>
