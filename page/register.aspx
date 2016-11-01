<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="register.aspx.cs" Inherits="page_register" %>
    <%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-contents">
        <div class="form-template">
            <div class="forms-page-title">
                <h1 class="form-template-bold">
                    注册&nbsp;
                </h1>
            </div>
            <div class="forms-page-text">
                <div class="forms-page-description">
                    <br>
                    <div id="ctl00_PlaceHolderMain_pageDescriptiondDisplayModePanel">
                        注册成为本站会员&nbsp;
                        <div>
                            <br>
                        </div>
                        <div>
                            <strong>创建帐户</strong></div>
                    </div>
                </div>
                <div class="forms-page-basicadhoc">
                    <br>                    
                </div>
            </div>
            <div class="form-main">
                <div class="forms-page-content" style="">
                    <div id="divLeft" class="left-zone" style="display: none;">
                    </div>
                    <div class="middle-zone add-margin">
                        <div class="middle-content" style="color:Red;margin:10px 0px;clear:both;">
                             <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                        <div class="webpart-zone">
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
                                                                    <div id="eac-registration-form">                                                                        
                                                                        <div id="DotcomRegistrationForm" class="registration">
                                                                            <div class="registration-form">
                                                                                <div class="registration-required">
                                                                                    *</div>
                                                                                <label>
                                                                                    表示必填字段 :</label>
                                                                                
                                                                                <table style="margin-top: 15px">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtFirstName">
                                                                                                    <span class="registration-required">*</span>真实姓名:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server"
                                                                                                    type="text" maxlength="50" id="txtFirstName">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>                                                                                       
                                                                                        <tr id="trEmailAddress">
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtEmail">
                                                                                                    <span class="registration-required">*</span>电子邮件地址 :</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server" type="text" maxlength="50" id="txtEmail" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="*必填，登录时使用"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr id="trPassword">
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtPassword">
                                                                                                    <span class="registration-required">*</span>创建一个密码:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server" type="password" maxlength="15" id="txtPassword">
                                                                                            </td>
                                                                                            <td width="280px">
                                                                                                您的密码必须是8-15个字符之间。
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr id="trPasswordConfirm">
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtPassword2">
                                                                                                    <span class="registration-required">*</span>重新输入密码 :</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server" type="password" maxlength="15" id="txtPassword2">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>                                                                                        
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="lstIndustries">
                                                                                                    <span class="registration-required">*</span>行业:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <select size="10" runat="server" id="lstIndustries">
                                                                                                    <option value="保险业">保险业</option>
                                                                                                    <option value="边境管理">边境管理</option>
                                                                                                    <option value="采矿">采矿</option>
                                                                                                    <option value="电子和高科技">电子和高科技</option>
                                                                                                    <option value="非盈利">非盈利</option>
                                                                                                    <option value="工业设备">工业设备</option>
                                                                                                    <option value="公共安全">公共安全</option>
                                                                                                    <option value="公共服务">公共服务-其他</option>
                                                                                                    <option value="公用事业">公用事业</option>
                                                                                                    <option value="管理咨询">管理咨询</option>
                                                                                                    <option value="国防">国防</option>
                                                                                                    <option value="海关">海关</option>
                                                                                                    <option value="航空">航空</option>
                                                                                                    <option value="航天和国防">航天和国防</option>
                                                                                                    <option value="化工">化工</option>
                                                                                                    <option value="货运及物流">货运及物流</option>
                                                                                                    <option value="基础设施和运输">基础设施和运输</option>
                                                                                                    <option value="建筑材料">建筑材料</option>
                                                                                                    <option value="金属">金属</option>
                                                                                                    <option value="林业产品">林业产品</option>
                                                                                                    <option value="零售">零售</option>
                                                                                                    <option value="旅游">旅游</option>
                                                                                                    <option value="媒体和娱乐">媒体和娱乐</option>
                                                                                                    <option value="民政服务">民政服务</option>
                                                                                                    <option value="能源">能源</option>
                                                                                                    <option value="其他">其他</option>
                                                                                                    <option value="汽车">汽车</option>
                                                                                                    <option value="生命科学">生命科学</option>
                                                                                                    <option value="税收">税收</option>
                                                                                                    <option value="通信">通信</option>
                                                                                                    <option value="消费品与服务业">消费品与服务业</option>
                                                                                                    <option value="学生">学生</option>
                                                                                                    <option value="医疗卫生">医疗卫生</option>
                                                                                                    <option value="银行业">银行业</option>
                                                                                                    <option value="邮政">邮政</option>
                                                                                                    <option value="资本市场">资本市场</option>
                                                                                                </select>
                                                                                            </td>
                                                                                            <td width="280px">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtOrg">
                                                                                                    <span class="registration-required">*</span>公司/组织/学校:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server" type="text" maxlength="50" id="txtOrg">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="ddlFunctional">
                                                                                                    <span class="registration-required">*</span>职能范围:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <select id="ddlFunctional" runat="server">
                                                                                                    <option selected="selected" value="">请选择职能范围</option>
                                                                                                    <option value="财务运营">财务运营</option>
                                                                                                    <option value="采购">采购</option>
                                                                                                    <option value="操作">操作</option>
                                                                                                    <option value="风险管理">风险管理</option>
                                                                                                    <option value="供应链">供应链</option>
                                                                                                    <option value="经营外包">经营外包</option>
                                                                                                    <option value="其他">其他</option>
                                                                                                    <option value="人力资源">人力资源</option>
                                                                                                    <option value="市场营销">市场营销</option>
                                                                                                    <option value="销售">销售</option>
                                                                                                    <option value="信息技术">信息技术</option>
                                                                                                    <option value="战略">战略</option>
                                                                                                </select>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtJobTitle">
                                                                                                    <span class="registration-required">*</span>职位:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input type="text" runat="server" maxlength="100" id="txtJobTitle">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="ddlCountry">
                                                                                                    <span class="registration-required">*</span>国家/地区:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input type="text" id="txtCountryCity" runat="server" />                                                                                                 
                                                                                            </td>
                                                                                            <td>
                                                                                                例如：中国-河北-保定
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="ddlCountry">
                                                                                                    <span class="registration-required">*</span>验证码:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input type="text" id="txtCode" runat="server" maxlength="4" /><img src="/page/checkcode.aspx" onclick="javascript:this.src=this.src+'?t='+(new Date().getTime())" alt="验证码" title="验证码" />                                                                                                 
                                                                                            </td>
                                                                                            <td>                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </div>                                                                            
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">                                                            
                                                            <div class="registration-button">
                                                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="registration-buttonlink" runat="server">注册</asp:LinkButton>
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
                    </div>
                    <div id="divRight" class="right-zone">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tbody>
                                <tr>
                                    <td id="MSOZoneCell_WebPartWPQ2" valign="top">
                                        <table toplevel="" border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td valign="top">
                                                        <div width="100%" class="ms-WPBody" style="display:none;">
                                                            
                                                            你还可以用以下方式直接登录：<br>
                                                            <a class="l_sinaweibo" href="/connect/auth/weibo"></a>
                                                            <a class="l_qq" href="/connect/auth/qzone"></a>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
