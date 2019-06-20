<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parap1hdet.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap1hdet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Paramedical P1 Record</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <div style="text-align: center">
            <table style="width: 100%;">
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
                                    <td style="width: 15%">
                                    </td>
                                    <td style="width: 70%">
        <table id="TABLE3" style="border-right: #000033 thin solid; border-top: #000033 thin solid;
            font-weight: normal; border-left: #000033 thin solid; width: 704px;
            color: #330000; border-bottom: #000033 thin solid; font-family: Arial; position: static; height: 88px" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4" style="width: 100%; color: #000000; background-color: #cccccc; text-align: center">
                    <strong>Hospital Name:<asp:Label ID="Name" runat="server"></asp:Label></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="font-weight: bold; font-size: 12px; width: 100%; color: #000000;
                    background-color: #cccccc; text-align: center">
                    (Proforma1 According To Paramedical Section)</td>
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
                <td colspan="4"style="width: 100%;text-align: left">
                    <asp:Table ID="Table2" runat="server" Font-Bold="True" Font-Size="Small" CellPadding="0" CellSpacing="0" Width="100%">
                    </asp:Table>
                </td>
            </tr>
        </table>
                                    </td>
                                    <td style="width: 15%">
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
    </form>
</body>
</html>