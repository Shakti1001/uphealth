<%@ Page Title="::Check Hospital List::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="onlyhreport.aspx.cs" Inherits="NewWebApp.proforma.onlyhreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
               
                </tr>
                <tr>
                    <td style="font-weight: bold; font-size: 16px; width: 100%; color: #ffff99; background-color: #74211f;
                        text-align: left" valign="top">
                        Hospital Reports Choice</td>
                </tr>
                <tr>
                    <td style="width: 100%;  text-align: center" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="font-weight: bold; font-size: 14px;
                                width: 100%; color: maroon; height: 100%">
                                <tr>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                                    </td>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                    Division</td>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:DropDownList ID="DDiv" class="form-control" runat="server" Width="200px" OnSelectedIndexChanged="DDiv_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
        </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%">
                                    </td>
                                    <td align="left" style="width: 25%">
                    District</td>
                                    <td align="left" style="width: 25%">
                    <asp:DropDownList ID="DDistrict" class="form-control" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="DDistrict_SelectedIndexChanged">
                    </asp:DropDownList></td>
                                    <td align="left" style="width: 25%">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                                        &nbsp;</td>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                    Hospital Type</td>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:DropDownList ID="DHtype" class="form-control" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DHtype_SelectedIndexChanged">
                </asp:DropDownList></td>
                                    <td align="left" style="width: 25%; background-color: #fff8dc">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100%; text-align: center;" colspan="4">
                                        <asp:Label ID="input" runat="server" Font-Size="Medium" ForeColor="#0000C0">For Full Report Just Click On Submit or Select Choice Then Click On Submit</asp:Label><br /><asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit Choice" OnClick="Button1_Click" /></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="width: 100%; background-color: #fff8dc; text-align: center">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="Label"
                                    Visible="False"></asp:Label> <asp:Label ID="strq" runat="server" Font-Size="Small" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="width: 100%; background-color: #fff8dc; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="width: 100%; color: #74211f; background-color: #74211f">
                                        .</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="width: 100%">
                                <asp:Table ID="Table1" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Navy" CellPadding="0" CellSpacing="0" Width="100%">
                                </asp:Table>
                                
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
