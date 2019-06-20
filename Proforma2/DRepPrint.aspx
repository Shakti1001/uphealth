<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DRepPrint.aspx.cs" Inherits="NewWebApp.Proforma2.DRepPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title> Dynamic Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%">
            <tr>
                <td style="width: 100%; text-align: right">
                    <table style="width: 56px; height: 16px">
                        <tr>
                            <td style="width: 310px; text-align: right">
                                <a href="javascript:window.print()">Print</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center">
                    <div style="text-align: center">
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="width: 5%">
                                </td>
                                <td style="width: 90%; font-size: 12px;" valign="top">
                                    <table id="TABLE3" style="border-right: #000033 thin solid; border-top: #000033 thin solid;
                                        font-weight: normal; border-left: #000033 thin solid; width: 100%; color: #330000;
                                        border-bottom: #000033 thin solid; font-family: Arial; position: static;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 100%; background-color: #cccccc; font-weight: bold; font-size: 14px;" colspan="4">
                                                <span style="text-decoration: underline">
                                                List Of Record Based On Your Dynamic Selection</span>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-weight: bold; font-size: 14px; width: 100%; background-color: #cccccc">
                                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" ForeColor="#0000C0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="width: 100%; text-align: left; font-size: 11px;" valign="top">
                                                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                    Font-Size="X-Small" Width="100%">
                                                </asp:Table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 5%">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

