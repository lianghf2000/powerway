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
                    ע��&nbsp;
                </h1>
            </div>
            <div class="forms-page-text">
                <div class="forms-page-description">
                    <br>
                    <div id="ctl00_PlaceHolderMain_pageDescriptiondDisplayModePanel">
                        ע���Ϊ��վ��Ա&nbsp;
                        <div>
                            <br>
                        </div>
                        <div>
                            <strong>�����ʻ�</strong></div>
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
                                                                                    ��ʾ�����ֶ� :</label>
                                                                                
                                                                                <table style="margin-top: 15px">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtFirstName">
                                                                                                    <span class="registration-required">*</span>��ʵ����:</label>
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
                                                                                                    <span class="registration-required">*</span>�����ʼ���ַ :</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server" type="text" maxlength="50" id="txtEmail" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="*�����¼ʱʹ��"></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr id="trPassword">
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtPassword">
                                                                                                    <span class="registration-required">*</span>����һ������:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input runat="server" type="password" maxlength="15" id="txtPassword">
                                                                                            </td>
                                                                                            <td width="280px">
                                                                                                �������������8-15���ַ�֮�䡣
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr id="trPasswordConfirm">
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtPassword2">
                                                                                                    <span class="registration-required">*</span>������������ :</label>
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
                                                                                                    <span class="registration-required">*</span>��ҵ:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <select size="10" runat="server" id="lstIndustries">
                                                                                                    <option value="����ҵ">����ҵ</option>
                                                                                                    <option value="�߾�����">�߾�����</option>
                                                                                                    <option value="�ɿ�">�ɿ�</option>
                                                                                                    <option value="���Ӻ͸߿Ƽ�">���Ӻ͸߿Ƽ�</option>
                                                                                                    <option value="��ӯ��">��ӯ��</option>
                                                                                                    <option value="��ҵ�豸">��ҵ�豸</option>
                                                                                                    <option value="������ȫ">������ȫ</option>
                                                                                                    <option value="��������">��������-����</option>
                                                                                                    <option value="������ҵ">������ҵ</option>
                                                                                                    <option value="������ѯ">������ѯ</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="����͹���">����͹���</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="���˼�����">���˼�����</option>
                                                                                                    <option value="������ʩ������">������ʩ������</option>
                                                                                                    <option value="��������">��������</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="��ҵ��Ʒ">��ҵ��Ʒ</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="ý�������">ý�������</option>
                                                                                                    <option value="��������">��������</option>
                                                                                                    <option value="��Դ">��Դ</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="������ѧ">������ѧ</option>
                                                                                                    <option value="˰��">˰��</option>
                                                                                                    <option value="ͨ��">ͨ��</option>
                                                                                                    <option value="����Ʒ�����ҵ">����Ʒ�����ҵ</option>
                                                                                                    <option value="ѧ��">ѧ��</option>
                                                                                                    <option value="ҽ������">ҽ������</option>
                                                                                                    <option value="����ҵ">����ҵ</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="�ʱ��г�">�ʱ��г�</option>
                                                                                                </select>
                                                                                            </td>
                                                                                            <td width="280px">
                                                                                                
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtOrg">
                                                                                                    <span class="registration-required">*</span>��˾/��֯/ѧУ:</label>
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
                                                                                                    <span class="registration-required">*</span>ְ�ܷ�Χ:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <select id="ddlFunctional" runat="server">
                                                                                                    <option selected="selected" value="">��ѡ��ְ�ܷ�Χ</option>
                                                                                                    <option value="������Ӫ">������Ӫ</option>
                                                                                                    <option value="�ɹ�">�ɹ�</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="���չ���">���չ���</option>
                                                                                                    <option value="��Ӧ��">��Ӧ��</option>
                                                                                                    <option value="��Ӫ���">��Ӫ���</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="������Դ">������Դ</option>
                                                                                                    <option value="�г�Ӫ��">�г�Ӫ��</option>
                                                                                                    <option value="����">����</option>
                                                                                                    <option value="��Ϣ����">��Ϣ����</option>
                                                                                                    <option value="ս��">ս��</option>
                                                                                                </select>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="txtJobTitle">
                                                                                                    <span class="registration-required">*</span>ְλ:</label>
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
                                                                                                    <span class="registration-required">*</span>����/����:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input type="text" id="txtCountryCity" runat="server" />                                                                                                 
                                                                                            </td>
                                                                                            <td>
                                                                                                ���磺�й�-�ӱ�-����
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="registration-leftcol">
                                                                                                <label for="ddlCountry">
                                                                                                    <span class="registration-required">*</span>��֤��:</label>
                                                                                            </td>
                                                                                            <td class="registration-middlecol">
                                                                                                <input type="text" id="txtCode" runat="server" maxlength="4" /><img src="/page/checkcode.aspx" onclick="javascript:this.src=this.src+'?t='+(new Date().getTime())" alt="��֤��" title="��֤��" />                                                                                                 
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
                                                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="registration-buttonlink" runat="server">ע��</asp:LinkButton>
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
                                                            
                                                            �㻹���������·�ʽֱ�ӵ�¼��<br>
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
