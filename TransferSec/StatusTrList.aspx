<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="StatusTrList.aspx.cs" Inherits="NewWebApp.TransferSec.StatusTrList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 325px; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 297px;" valign="top">
    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #661700;
            font-family: Arial; height: 1px; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #990000; border-bottom-width: thin; border-bottom-color: #990000; border-top-color: #990000; border-right-width: thin; border-right-color: #990000;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" style=" width: 100%; color: #ffff99;
                text-align: left; height: 18px; background-color: #661700;">
                <span style="font-size: 10pt;">&nbsp; Medical Section / P2 / Transfer
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>
                    <asp:Label
                        ID="Fnamet" runat="server" Visible="False"></asp:Label></span></td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 14px; width: 100%; color: maroon; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc; text-align: right;">
                                Transfer
                    Order No:</td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                    </td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                </td>
                            <td align="left" style="width: 25%; height: 25px; background-color: #fff8dc">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 20px; text-align: center;" colspan="4">
                                <asp:DropDownList ID="JORDERDD" runat="server" Width="80%" AutoPostBack="True" >
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                            </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    </td>
                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:Button ID="BSAVE" class="btn btn-success" runat="server" Text="Get status" OnClick="BSAVE_Click" Width="80px" /></td>
                        </tr>
                         <tr>
                            <td align="left" style="width: 25%">
                            </td>
                            <td align="left" style="width: 25%">
                </td>
                            <td align="left" style="width: 25%">
                </td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 16px; background-color: #ffffff;
                                text-align: left; font-size: 12px; color: #003366;">
                                <asp:Table class="table table-responsive-sm" ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Height="100%"
                                    Width="100%">
                                </asp:Table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 100%; height: 25px; background-color: #fff8dc;
                                text-align: center">
                    <asp:Label ID="mesg" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="background-color: #661700; text-align: center; color: #ffff99; width: 100%; height: 25px;">
                    </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        </table>
        </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
