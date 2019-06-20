<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pmdXrep.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdXrep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Pay Report</title>
    
</head>

<body style="background-color: #ffffcc">
    <form id="form1" runat="server">
    <div>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Export To MS-Excel</asp:LinkButton>
        <table style="width: 100%">
            <tr>
                <td style="width: 100%; text-align: right; height: 46px; background-color: #e8cd76;">
                    <table style="width: 56px; height: 16px">
                        <tr>
                            <td style="width: 310px; text-align: right">
                                <a href="javascript:window.print()">Print</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center; background-color: #e8cd76;">
                    <div style="text-align: center">
                        <table style="width: 100%; height: 100%">
                            <tr>
                                <td style="width: 6%; background-color: #e8cd76;">
                                </td>
                                <td style="font-size: 12px; width: 88%" valign="top">
                                    <table id="TABLE3" cellpadding="0" cellspacing="0" style="border-right: #000033 thin solid;
                                        border-top: #000033 thin solid; font-weight: normal; border-left: #000033 thin solid;
                                        width: 100%; color: #330000; border-bottom: #000033 thin solid; font-family: Arial;
                                        position: static">
                                        <tr>
                                            <td colspan="4" style="font-weight: bold; width: 100%; background-color: inactivecaptiontext; text-align: right;">
                                                <a href="#"></a>   <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-weight: bold; font-size: 14px; width: 100%; font-family: Arial; color: #660000;">
                                                Pay Roll System For Govt. Of Uttar Pradesh</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-weight: normal; font-size: 16px; width: 100%; font-family: Arial;
                                                height: 10px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-weight: normal; font-size: 15px; width: 100%; font-family: Arial; color: #660000;">
                                                Payroll For the Month of <asp:Label ID="MonthLabel" runat="server"></asp:Label>
                                                <asp:Label ID="YearLabel" runat="server"></asp:Label>
                                                for U.P. State Employees</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-weight: normal; font-size: 16px; width: 100%; font-family: Arial;
                                                height: 10px">
                                                <asp:Label ID="MSGLab" runat="server" Text="" style="color: #660000"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 10px; width: 100%; text-align: left" valign="top">
                                                <asp:Table ID="Table1"  runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                    Font-Size="Small" Width="100%" style="background-color: #e8cd76">
                                                </asp:Table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 6%; background-color: #e8cd76;">
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
