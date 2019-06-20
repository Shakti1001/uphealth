<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="pmdPayRoption.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdPayRoption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 98%">
        <tr>
            <td style="width: 100%; height: 1px; text-align: right">
                <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                    onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 14px; width: 100%; color: #ffff99; height: 20px;
                background-color: #661700; text-align: center;">
                Report Option&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
                <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="font-weight: bold; font-size: 14px;
                    width: 100%; color: maroon; background-color: #fff8dc">
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="width: 100%; height: 20px; text-align: center">
                                        </td>
                    </tr>
                    <tr style="font-size: 10pt; color: #800000">
                        <td colspan="4" style="width: 100%; height: 25px; text-align: left">
                            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; background-color: burlywood; text-align: center; font-weight: bold; color: maroon; font-size: 13pt;">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;DDO Name &nbsp;
                                        <asp:TextBox ID="DDOText" runat="server" Width="30%" ForeColor="#C00000" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="DDOIDLab" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%; height: 25px; text-align: center">
                                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;
                                            text-align: left">
                                            <tr>
                                                <td style="width: 25%">
                                                    &nbsp;</td>
                                                <td style="font-weight: bold; width: 25%; color: maroon; text-align: center; font-size: 13pt;">
                                                    &nbsp;Unit Name</td>
                                                <td style="width: 25%">
                                                    <asp:DropDownList ID="hname" runat="server" Width="51%" 
                                                        onselectedindexchanged="hname_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 25%">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">
                                                </td>
                                                <td style="font-weight: bold; width: 25%; color: maroon; text-align: center; font-size: 13pt;">
                                                    &nbsp;Year</td>
                                                <td style="width: 25%">
                                                    &nbsp;<asp:DropDownList 
                                                        ID="year" runat="server" Width="51%" AutoPostBack="True" 
                                                        onselectedindexchanged="year_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                                <td style="width: 25%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">
                                                </td>
                                                <td style="width: 25%; font-weight: bold; color: maroon; text-align: center; font-size: 13pt;">
                                                    &nbsp; &nbsp;Month</td>
                                                <td style="width: 25%">
                                                    &nbsp;<asp:DropDownList ID="Month" runat="server" Width="50%" AutoPostBack="True">
                                            <asp:ListItem>In installment</asp:ListItem>
                                        </asp:DropDownList></td>
                                                <td style="width: 25%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">
                                                </td>
                                                <td style="font-weight: bold; width: 25%; color: maroon; text-align: center; font-size: 13pt;">
                                                    &nbsp;Salary &nbsp;Head</td>
                                                <td style="width: 25%">
                                                    &nbsp;<asp:DropDownList ID="Head" runat="server" Width="90%" AutoPostBack="True">
                                            
                                        </asp:DropDownList></td>
                                                <td style="width: 25%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 15px;">
                                                </td>
                                                <td style="width: 25%; height: 15px; font-weight: bold; color: maroon; text-align: center; font-size: 13pt;">
                                                    &nbsp; &nbsp;PF Type</td>
                                                <td style="width: 25%; height: 15px;">
                                                    &nbsp;<asp:DropDownList 
                                                        ID="gpfseries" runat="server" Width="90%" 
                                                        onselectedindexchanged="gpfseries_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
                                                <td style="width: 25%; height: 15px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 28px;">
                                                </td>
                                                <td style="width: 25%; font-weight: bold; color: maroon; height: 28px; text-align: center; font-size: 13pt;">
                                                    </td>
                                                <td style="width: 25%; height: 28px;">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 28px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                                <td style="width: 25%; height: 25px">
                                                    &nbsp;</td>
                                                <td style="width: 25%; height: 25px">
                                                    <asp:DropDownList ID="Drep" runat="server" Width="50%" AutoPostBack="True" Visible="False">                                            
                                        </asp:DropDownList></td>
                                                <td style="width: 25%; height: 25px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%; background-color: burlywood">
                                                </td>
                                                <td style="width: 25%; background-color: burlywood">
                                                </td>
                                                <td style="width: 25%; background-color: burlywood">
                                        <asp:Button ID="save" runat="server" OnClick="save_Click" Text="Submit" Font-Bold="True" 
                                                        ForeColor="#C00000" style="height: 26px" /></td>
                                                <td style="width: 25%; background-color: burlywood">
                                        </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 25px">
                            <asp:Label ID="MSGLabel" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList ID="DDO" runat="server" Width="90%" Visible="False">
                                                                  </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; color: #661700; background-color: #661700" valign="top">
                .<asp:Label ID="ME" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
</div>
</asp:Content>
