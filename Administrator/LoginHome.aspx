<%@ Page Title="::Medical Login Home::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="LoginHome.aspx.cs" Inherits="NewWebApp.Administrator.LoginHome" %>
<%@ Register Src="~/ltop.ascx" TagName="ltop" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align: center" class="container">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 100%">
                <tr>
                    <td style="width: 100%; text-align: right;" valign="top" colspan="2">
                        <asp:LinkButton ID="LinkButton3" class="btn btn-danger" runat="server" onclick="LinkButton3_Click1"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; text-align: center" valign="top">
                        <table class="table table-responsive-sm table-light" style="width: 100%; height: 100%;">
                            <tr>
                                <td colspan="2" style="height: 0px; text-align: center" valign="top">
                                    <table align="center" class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="88%">
                                        <tr>
                                            <td class="hindiW">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="5%">
                                                            <div align="center" class="englishb">
                                                            </div>
                                                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f; text-align: left" width="55%">
                                                            &nbsp;
                        Welcome To Medical Section</td>
                                                        <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f" width="28%">
                                                            <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                                        <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="12%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" style="font-weight: bold; background-color: #fff8dc; height: 30px;">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" style="background-color: #fff8dc; text-align: left; height: 30px;">
                        <asp:LinkButton ID="Hsec" runat="server" Font-Bold="True" Font-Size="Medium"
                            OnClick="Hsec_Click" Width="152px" ForeColor="#74211F">Hospital Section</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="Msec" runat="server" Font-Bold="True" OnClick="Msec_Click" Font-Size="Medium" Width="128px" ForeColor="#74211F">Personnel Section</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="Newpay" runat="server" Font-Bold="True" OnClick="Newpay_Click" Font-Size="Medium" Width="120px" 
                                                                ForeColor="#74211F">Payroll Section</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                   <!-- <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                        <asp:LinkButton ID="mpr" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                                Width="120px" ForeColor="#74211F">Doctor's MPR</asp:LinkButton></td>
                                                    </tr>-->
                                                    
                                                    
                                                   <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                  
                                                    
                                                  
                                                    
                                                    
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc; color: #fff8dc;">
                                                            </td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                    <asp:LinkButton ID="Psec" runat="server" Font-Bold="True" ForeColor="Wheat"
                        OnClick="Psec_Click" Width="112px" Visible="False">Old Pay Section</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: right">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">folderpay</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Cornsilk"
                                                                OnClick="Link_Click" Width="64px">New Pay</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#fe8631">
                                            <td bgcolor="#fe8631" height="30" style="background-color: #74211f">
                        <asp:Label ID="mess" runat="server" ForeColor="White"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="width: 100%;" valign="top">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
