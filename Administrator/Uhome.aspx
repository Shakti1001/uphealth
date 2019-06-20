<%@ Page Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Uhome.aspx.cs" Inherits="NewWebApp.Administrator.Uhome" Title="::User Service Book::" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 90%; text-decoration:none; margin-left:5%; margin-right:5%;">
                 <tr>
                    <td colspan="2" style="width: 100%; height: 0px; text-align: center" valign="top">
                        <table align="center" class="table table-responsive-sm" style="text-decoration:none;" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="hindiW">
                                    <table class="table table-responsive-sm" style="text-decoration:none;" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td bgcolor="#fe8631" height="34" style="font-weight: bold; color: #ffff99; background-color: #74211f"
                                                width="5%">
                                                <div align="center" class="englishb">
                                                </div>
                                            </td>
                                            <td bgcolor="#fe8631" class="normalEng" height="34" style="font-weight: bold; color: #ffff99;
                                                background-color: #74211f; text-align: left" width="55%">
                                                UP Govt. Medical Service Book Options
                                            </td>
                                            <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffffff;
                                                background-color: #74211f; text-align: right;" colspan="2">
                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>User :: <asp:Label ID="Fnamet" runat="server" ForeColor="#FFFF80"></asp:Label>
                                                &nbsp;</td>
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
                        <asp:LinkButton ID="medicalsection" runat="server" Font-Bold="True" Font-Size="Medium"
                            OnClick="medicalsection_Click" Width="152px" ForeColor="#74211F">Medical Section</asp:LinkButton></td>
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
                        <asp:LinkButton ID="Paramedical" runat="server" Font-Bold="True" OnClick="Paramedical_Click" Font-Size="Medium" Width="176px" ForeColor="#74211F">Paramedical Section</asp:LinkButton></td>
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
                        <asp:LinkButton ID="ucp" runat="server" ForeColor="#74211F" OnClick="ucp_Click" Font-Size="Medium" Font-Bold="True">Change Password</asp:LinkButton></td>
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
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; " valign="top">
        
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        </div>

</asp:Content>
