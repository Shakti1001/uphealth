<%@ Page Title="::Edit/Delete User::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="NewWebApp.Administrator.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm" style="  width: 100%">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-danger" 
                            onclick="LinkButton5_Click"><span class="glyphicon glyphicon-arrow-left"></span>Back</asp:LinkButton>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 0px; text-align: center" valign="top">
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
                                                background-color: #661700; text-align: left" width="55%">
                                                &nbsp;
                    Welcome User::
                                                <asp:Label ID="Label5" runat="server"></asp:Label></td>
                                            <td bgcolor="#fe8631" class="normalEng" style="font-weight: bold; color: #ffff99;
                                                background-color: #661700" width="28%">
                                            </td>
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
                        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Maroon" OnClick="LinkButton1_Click" Font-Bold="True">Delete User</asp:LinkButton></td>
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
                        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Maroon" OnClick="LinkButton2_Click" Font-Bold="True">Change Password</asp:LinkButton></td>
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
                        <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Maroon" OnClick="LinkButton3_Click" Font-Bold="True">Change Permission </asp:LinkButton></td>
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
                                <td bgcolor="#fe8631" height="30" style="font-weight: bold; color: #ffffff; background-color: #661700">
                                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#fe8631">
                                <td bgcolor="#fe8631" height="30" style="font-weight: bold; font-size: 18px; height: 20px;
                                    background-color: #fff8dc; text-align: center" valign="top">
                                        <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="Maroon"
                                            OnClick="LinkButton4_Click">User List</asp:LinkButton></td>
                            </tr>
                            <tr bgcolor="#fe8631">
                                <td bgcolor="#fe8631" height="30" style="font-weight: bold; height: 20px; background-color: #661700;
                                    text-align: right" valign="top">
                                </td>
                            </tr>
                            <tr bgcolor="#fe8631">
                                <td bgcolor="#fe8631" style="font-weight: bold; background-color: #e8cd76; font-size: 12px; text-align: left; height: 30px;" valign="top">
                                        <asp:Table ID="Table1" runat="server" Font-Bold="True" Font-Size="Small" CellPadding="0" CellSpacing="0" Width="100%">
                                        </asp:Table>
                                </td>
                            </tr>
                            <tr bgcolor="#fe8631">
                                <td bgcolor="#fe8631" height="30" style="font-weight: bold; width: 100%; background-color: #e8cd76">
                        <asp:Panel ID="Panel4" runat="server" Width="100%" Visible="False">
                            <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #3366cc;
                font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;">
                                <tr>
                                    <td colspan="2" style="width: 100%; background-color: #661700; text-align: center; color: #ffffff; font-weight: bold;">
                                        User Id ::<asp:TextBox ID="UID" runat="server" OnTextChanged="UID_TextChanged" Enabled="False"></asp:TextBox>
                                        </td>
                                </tr>
                            </table>
                        </asp:Panel>
                                    <asp:Panel ID="Panel3" runat="server" Width="100%" Visible="False">
                                        <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #3366cc;
                font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;">
                                <tr>
                                    <td colspan="2" style="width: 100%; text-align: center">
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete User" />
                        </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; text-align: center; background-color: #661700;">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
                            <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: maroon;
                font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;">
                <tr>
                    <td style="width: 50%; text-align: left; background-color: #fff8dc;">
                        Old Password</td>
                    <td style="width: 50%; text-align: left; background-color: #fff8dc;">
                        <asp:TextBox ID="Oldp" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left;">
                        New Password</td>
                    <td style="width: 50%; text-align: left;">
                        <asp:TextBox ID="Newp" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: left; background-color: #fff8dc;">
                        Repeat New Password</td>
                    <td style="width: 50%; text-align: left; background-color: #fff8dc;">
                        <asp:TextBox ID="Conp" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; text-align: center">
                        <asp:Button ID="Changep" runat="server" Text="Change Password" OnClick="Changep_Click" Width="136px" />
                        <asp:Button ID="Button1" runat="server" Text="Retrieve Password" Width="120px" OnClick="Button1_Click" UseSubmitBehavior="False" />
                        <asp:Label ID="Label4" runat="server" ForeColor="Maroon"></asp:Label></td>
                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; text-align: center; background-color: #661700; color: #661700;">
                        <asp:Label ID="Label3" runat="server" ForeColor="#FFFFC0"></asp:Label>
                                        .</td>
                                </tr>
                            </table>
                        </asp:Panel>
                               <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
                                <table class="table table-responsive-sm" style="width: 100%; font-weight: bold; color: #3366cc; font-family: Arial; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;">
                                    <tr>
                                        <td colspan="2" style="width: 100%; text-align: center; background-color: #fff8dc;">
                                            <asp:CheckBox ID="R" runat="server" ForeColor="Brown" Text="READ" />&nbsp;
                                            <asp:CheckBox ID="A" runat="server" ForeColor="Brown" Text="ADD" />
                                            <asp:CheckBox ID="E" runat="server" ForeColor="Brown" Text="EDIT" />&nbsp;
                                            <asp:CheckBox ID="D" runat="server" ForeColor="Brown" Text="DELETE" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px;width: 100%; text-align: center;" colspan="2">
                                            <asp:Button ID="Changeper" runat="server" Text="Change Permission" Width="136px" OnClick="Changeper_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 21px;width: 100%; text-align: center; background-color: #661700;">
                                            <asp:Label ID="Label2" runat="server" ForeColor="#FFFFC0"></asp:Label></td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
