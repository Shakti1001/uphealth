<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="yearreport.aspx.cs" Inherits="NewWebApp.payrole.yearreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
    <%--SERVICE BOOK :::: Personal Management System--%>
       <table class="table table-responsive-sm table-active" style="width: 100%; background-color: #e8cd76; color: white;">
            <tr>
                <td style="text-align: center; background-color: #e8cd76; position: static; font-weight: bold; color: maroon;">
                    <br />
                    <br />
                    <br />
                    <table class="table table-responsive-sm">
                        <tr>
                            <td style="height: 42px; font-weight: bold; color: maroon; text-align: center;" colspan="3">
                                &nbsp;Yearly&nbsp; Earning and Deduction (YE&amp;D) Report<br />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                            </td>
                            <td style="width: 127px">
                                                     <table class="table table-responsive-sm" style="text-align: left; border-left-color: #663300; border-bottom-color: #663300;  border-top-style: groove; border-top-color: #663300; border-right-style: groove; border-left-style: groove; height: 42px; border-right-color: #663300; border-bottom-style: groove;">
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="font-weight: bold; text-align: center; height: 21px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmpid"
                                                    ErrorMessage="Enter Computer Id" ForeColor="Maroon" ValidationGroup="group1"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left; height: 28px;">
                                                <asp:Label ID="Lblcid" runat="server" Text="Computer Id" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label></td>
                                                        <td colspan="2" style="text-align: left; height: 28px;">
                                                <asp:TextBox ID="cmpid" runat="server" Width="121px" ValidationGroup="group1"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left; height: 24px;">
                                                <asp:Label ID="Lblmon" runat="server" Text="Financial Year" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left; height: 24px;" colspan="2">
                                                            <asp:DropDownList
                                                    ID="Drpyear" runat="server" Width="122px" style="left: -4px; position: static; top: 1px" OnSelectedIndexChanged="Drpyear_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;" colspan="3">
                                                        &nbsp;</td>
                                                    </tr>
                                                         <tr>
                                                             <td colspan="3" style="text-align: center">
                                                                 <asp:Button class="btn btn-success" ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="group1" /></td>
                                                         </tr>
                                                         <tr>
                                                             <td colspan="3" style="font-weight: normal">
                                                                 </td>
                                                         </tr>
                                                </table>
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                            </td>
                            <td style="width: 127px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center; background-color: #e8cd76; height: 201px;">
                    <div style="text-align: center">
                        &nbsp;</div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
