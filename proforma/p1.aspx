﻿<%@ Page Title="::P1 Home::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="p1.aspx.cs" Inherits="NewWebApp.proforma.p1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align: center" class="container">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton>  </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" valign="top">
                        <table class="table table-responsive-sm" style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="2" style="height: 0px; text-align: center" valign="top">
                                    <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                                        <tr>
                                            <td class="hindiW">
                                                <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                            width="5%">
                                                            <div align="center" class="englishb">
                                                            </div>
                                                        </td>
                                                        <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                            background-color: #74211f; text-align: left" width="55%">
                                                            Medical Section / Hospital (P1) Section &nbsp;</td>
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
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                <asp:LinkButton ID="AddH" runat="server" Font-Bold="True" OnClick="AddH_Click" Font-Size="Medium" ForeColor="#74211F">Add Hospital </asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                                            &nbsp;</td>
                                                        <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                <asp:LinkButton ID="EDITHR" runat="server" Font-Bold="True" OnClick="EDITHR_Click" Font-Size="Medium" ForeColor="#74211F">Add/Edit Hospital (P1)  Records</asp:LinkButton></td>
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
                <asp:LinkButton ID="HREP" runat="server" Font-Bold="True" Font-Size="Medium" OnClick="HREP_Click"
                    Width="152px" ForeColor="#74211F">Hospital (P1) Reports</asp:LinkButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td colspan="2" style="height: 10px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#fe8631">
                                            <td bgcolor="#fe8631" height="30" style="background-color: #74211f">
                <asp:Label ID="mess" runat="server" ForeColor="#FFFF99" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
