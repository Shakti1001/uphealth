<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="genpaySlip.aspx.cs" Inherits="NewWebApp.Guest.genpaySlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%;">
            <tr>
                <td style="width: 100%; text-align: center; height: 11px; background-color: transparent; position: relative; font-weight: bold; color: maroon;">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" style="float:right;" class="btn btn-danger" OnClick="Back_Click" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                    <br />
                    <br />
                                                     <table class="table table-responsive-sm" style="border-style: groove;  border-color: #000000; text-align: left" 
                        align="center">
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                                                            ::PaySlip::</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="font-weight: bold; text-align: center">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left;">
                                                <asp:Label ID="Lblcid" runat="server" Text="Computer Id" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label></td>
                                                        <td colspan="2" style="text-align: left">
                                                <asp:TextBox class="form-control" ID="cmpid" runat="server" Width="155px" ValidationGroup="group1" 
                                                                AutoCompleteType="Disabled"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="cmpid">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left;">
                                                <asp:Label ID="Lblmon" runat="server" Text="Month/Year" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td style="width: 77px; text-align: left">
                                                            <asp:DropDownList class="form-control" ID="Drpmon" runat="server" Width="100px" style="left: 0px; top: 0px">
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
                                                            <asp:DropDownList class="form-control"
                                                    ID="Drpyear" runat="server" Width="100px" style="left: -4px; position: static; top: 1px">
                                                </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;" colspan="3">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                                                <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="group1" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 77px">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"></asp:Label>
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
                                                             <td colspan="3" style="text-align: center">
                                                                 &nbsp;</td>
                                                         </tr>
                                                </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center; background-color: transparent; height: 201px;">
                    <div style="text-align: center">
                        &nbsp;</div>
                </td>
            </tr>
        </table>
    <div style="text-align: center">
    <%--SERVICE BOOK :::: Personal Management System--%>
       
    </div>
    </div>
</asp:Content>
