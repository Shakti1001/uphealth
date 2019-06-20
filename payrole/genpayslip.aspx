<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="genpayslip.aspx.cs" Inherits="NewWebApp.payrole.genpayslip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
    <%--SERVICE BOOK :::: Personal Management System--%>
       <table class="table table-responsive-sm table-active" style="width: 100%; background-color: #e8cd76; color: white;">
            <tr>
                <td style="width: 100%; text-align: center; height: 11px; background-color: #e8cd76; position: relative; font-weight: bold; color: maroon;">
                    <br />
                    <br />
                    <br />
                    <br />
                                                     <table class="table table-responsive-sm" style="text-align: left">
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="font-weight: bold; text-align: center">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmpid"
                                                    ErrorMessage="Enter Computer Id" ForeColor="Maroon" ValidationGroup="group1"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left;">
                                                <asp:Label ID="Lblcid" runat="server" Text="Computer Id" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label></td>
                                                        <td colspan="2" style="text-align: left">
                                                <asp:TextBox ID="cmpid" runat="server" Width="161px" ValidationGroup="group1"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left;">
                                                <asp:Label ID="Lblmon" runat="server" Text="Month/Year" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td style="width: 77px; text-align: left">
                                                            <asp:DropDownList ID="Drpmon" runat="server" Width="78px" style="left: 0px; top: 0px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList></td>
                                                        <td style="width: 100px; text-align: left">
                                                            <asp:DropDownList
                                                    ID="Drpyear" runat="server" Width="78px" style="left: -4px; position: static; top: 1px">
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
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 77px">
                                                </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 77px; text-align: left">
                                                </td>
                                                        <td style="width: 100px; text-align: left">
                                                </td>
                                                    </tr>
                                                         <tr>
                                                             <td colspan="3" style="font-weight: normal">
                                                                 <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" OnClick="LinkButton1_Click">Search ComputerID</asp:LinkButton></td>
                                                         </tr>
                                                </table>
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
