<%@ Page Title="::Change User Password::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="ChangeUpass.aspx.cs" Inherits="NewWebApp.Administrator.ChangeUpass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%; font-weight: bold; color: #661700;">
                <tr>
                    <td style="width: 100%; text-align: right;" valign="top" colspan="2">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; text-align: center" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="background-color: #661700; color: #ffffff;" colspan="3">
                                        Change Your Password For Security Purpose&nbsp;<asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
        <table style="font-weight: bold; width: 100%; color: #661700; font-family: Georgia; height: 100%; border-right: #333333 thin solid; border-top: #333333 thin solid; border-left: #333333 thin solid; border-bottom: #333333 thin solid; background-color: #fffbd6;">
                <tr>
                    <td  style="width: 100%; height: 21px; font-weight: normal; font-family: Arial;">
                        Old Password&nbsp;&nbsp;
                        <asp:TextBox ID="Otext" runat="server" TextMode="Password" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100%; font-weight: normal; font-family: Arial; height: 21px;">
                        New Password&nbsp;
                        <asp:TextBox ID="Ntext" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox></td>
                </tr>
            <tr>
                <td style="width: 100%; text-align: center;">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;
                    <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="Button1_Click" Text="Change Password" Width="144px" /></td>
            </tr>
            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #661700; color: #661700; height: 5%;" colspan="3">
                        <asp:Label ID="mess" runat="server" ForeColor="White" Visible="False" Font-Bold="True"></asp:Label>.<%--<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="Ntext" ErrorMessage="Special character are not allowed"
                            Font-Bold="True" ForeColor="#FFFFC0" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,20}$"></asp:RegularExpressionValidator>--%></td>
                                </tr>
                            </table>
                        </div>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; " valign="top">
                    </td>
                </tr>
            </table>
        </div>
        </div>

</asp:Content>
