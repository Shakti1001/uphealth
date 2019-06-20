<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="TotHospital.aspx.cs" Inherits="NewWebApp.proforma.TotHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <table class="table table-responsive-sm table-active" style="width: 100%">
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
                                <td style="width: 80%; font-size: 12px;" valign="top">
                                    <table class="table table-responsive-sm" id="TABLE3" style="border-right: #000033 thin solid; border-top: #000033 thin solid;
                                        font-weight: normal; border-left: #000033 thin solid; width: 100%; color: #330000;
                                        border-bottom: #000033 thin solid; font-family: Arial; position: static;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 100%; background-color: #cccccc; font-weight: bold; font-size: 14px;" colspan="4">
                                                Hopitals Name District Wise In Uttar Pradesh
                                                <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="width: 100%; text-align: left; font-size: 11px;" valign="top">
                                                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                    Font-Size="Small" Width="100%">
                                                </asp:Table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 10%">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
    
    </div>
</asp:Content>
