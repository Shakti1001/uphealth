﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="payrolehome.aspx.cs" Inherits="NewWebApp.payrole.payrolehome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
    <table class="table table-responsive-sm table-active" style="width: 100%; height: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 0px; text-align: right" valign="top">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 0px; text-align: center" valign="top">
                <table class="table table-responsive-sm" align="center" border="0" cellpadding="0" cellspacing="0" width="88%">
                    <tr>
                        <td class="hindiW">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #661700"
                                        width="5%">
                                        <div align="center" class="englishb">
                                        </div>
                                    </td>
                                    <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700; text-align: left;" width="55%">
                                        Medical Section  Pay Roll Option
                                        <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                    <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                        background-color: #661700" width="28%">
                                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                    <td bgcolor="#fe8631" style="font-weight: bold; color: #ffff99; background-color: #661700"
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
                                        <asp:LinkButton ID="Addddo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="Addddo_Click" Width="104px">DDO Master</asp:LinkButton>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                    <td height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" bgcolor="#376fbc" height="30" style="font-weight: bold; background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc; text-align: left">
                                        <asp:LinkButton ID="DDO" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#74211F"
                                            OnClick="DDO_Click" Width="280px">Selection Of DDO To Different Hospitals</asp:LinkButton>&nbsp;</td>
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
                                        <asp:LinkButton ID="SalDet" runat="server" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#74211F" OnClick="SalDet_Click" Width="152px">Salary Procedures </asp:LinkButton>&nbsp;</td>
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
                                    <td bgcolor="#376fbc" colspan="3" height="30" style="background-color: #fff8dc;">
                                        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue" Text="Please Select DDO for Salary Process" Visible="False"></asp:Label>&nbsp;<asp:DropDownList ID="DDONAME" runat="server" Width="248px" OnSelectedIndexChanged="DDONAME_SelectedIndexChanged" AutoPostBack="True" BackColor="Cornsilk" Font-Bold="True" ForeColor="Maroon" Visible="False">
                                        </asp:DropDownList>&nbsp;</td>
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
                        <td bgcolor="#fe8631" height="30" style="background-color: #661700">
                            <asp:Label ID="mess" runat="server" Font-Bold="True" ForeColor="White"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%" valign="top">
            </td>
        </tr>
    </table>
        </div>
</asp:Content>
