﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="P1vsP2.aspx.cs" Inherits="NewWebApp.proforma.P1vsP2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="width: 100%; background-color: #ffffff;">
                <tr>
                    <td style="width: 100%; text-align: right">
                        <table class="table table-responsive-sm" style="width: 56px; height: 16px">
                            <tr>
                                <td style="width: 310px; text-align: right">
                                    <a class="btn btn-danger" href="javascript:window.print()"><span class="glyphicon glyphicon-print"></span>Print</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; height: 100%">
                                <tr>
                                    <td style="width: 10%">
                                    </td>
                                    <td style="width: 70%">
        <table id="TABLE3" style="border-right: #000033 thin solid; border-top: #000033 thin solid;
            font-weight: normal; border-left: #000033 thin solid; width: 100%;
            color: #330000; border-bottom: #000033 thin solid; font-family: Arial; position: static;" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4" style="width: 100%; color: #000000; background-color: #cccccc; text-align: center">
                    <strong>Hospital Name:<asp:Label ID="Name" runat="server"></asp:Label>
                        </strong></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    1.</td>
                <td style="width: 40%; text-align: left">
                    Division Name&nbsp;</td>
                <td colspan="2" style="width: 50%;text-align: left">
                    :<asp:Label ID="LDiv" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    2.</td>
                <td style="width: 40%; text-align: left">
                    District
                    Name</td>
                <td colspan="2" style="width: 50%;text-align: left">
                    :<asp:Label ID="LDist" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    3.</td>
                <td style="width: 40%; text-align: left">
                    Tehsil Name</td>
                <td colspan="2" style=" width: 50%;text-align: left">
                    :<asp:Label ID="LTN" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    4.</td>
                <td style="width: 40%; text-align: left">
                    Block Name</td>
                <td colspan="2" style=" width: 50%;text-align: left">
                    :<asp:Label ID="LBN" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    5.</td>
                <td style="width: 40%; text-align: left">
                    Hospital Type</td>
                <td colspan="2" style="width: 50%;text-align: left">
                    :<asp:Label ID="LHT" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 10%">
                    6.</td>
                <td style="width: 40%; text-align: left">
                    Available Beds
                </td>
                <td colspan="2" style="width: 50%;text-align: left">
                    :<asp:Label ID="LBed" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4"style="width: 100%;text-align: center">
                    <div style="text-align: center">
                        <table class="table table-responsive-sm" style="width: 100%; height: 100%">
                            <tr>
                                <td colspan="2" style="width: 100%; text-align: center;">
                    <asp:Table ID="Table2" runat="server" Font-Bold="True" Font-Size="Small" Width="100%" CellPadding="0" CellSpacing="0">
                    </asp:Table>
                                    </td>
                            </tr>
                        </table>
                    </div>
                    &nbsp;</td>
            </tr>
        </table>
                                    </td>
                                    <td style="width: 10%">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    
    </div>
</asp:Content>
