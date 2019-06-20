<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payslip.aspx.cs" Inherits="NewWebApp.payrole.payslip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PaySlip</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table table-responsive-sm" style="width:99% ">
            <tr>
                <td colspan="1" style="text-align: right; width: 20%;" rowspan="14">
                    </td>
                <td colspan="4" style="text-align: center; height: 21px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label" Visible="False"></asp:Label></td>
                <td colspan="1" style="text-align: right; width: 20%;" rowspan="14">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center; font-weight: bold; color: black; height: 84px;" rowspan="3">
                
                    <span id="sp" runat="server" style="height:52px; text-align:center">
                        <asp:Image ID="Image6" runat="server" ImageAlign="Left" ImageUrl="~/images/logo.jpg" Height="69px" Width="59px" />Department of Health & Family Welfare 
                        <br />
                        Government of Uttar pardesh<br />
                            (Payslip)</span></td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="4" style="height: 6px">
                    <asp:Image ID="Image4" runat="server" Height="4px" ImageUrl="~/images/myline1.jpg" Width="588px" /></td>
            </tr>
            <tr>
                <td colspan="4">
                 <asp:Table ID="Table2" runat="server" BorderColor="#000000" BorderWidth="0px" CellPadding="0"
                                    CellSpacing="0" Font-Bold="True" Font-Size="small" HorizontalAlign="Left" Style="font-weight: bold;
                                    font-family: Verdana; background-color: white; border-top-width: thin; border-left-width: thin; border-left-color: black; border-bottom-width: thin; border-bottom-color: black; border-top-color: black; border-right-width: thin; border-right-color: black;"
                                    Width="100%">
                                </asp:Table>
                    </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 6px">
                    <asp:Image ID="Image1" runat="server" Height="4px" ImageUrl="~/images/myline1.jpg" Width="588px" /></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: black; border-top-style: none; border-right-style: none; border-left-style: none; text-align: justify; border-bottom-style: none; height: 13px;" colspan="2">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    Earnings</td>
                <td style="border-top-width: thin; font-weight: bold; border-left-width: thin; border-bottom-width: thin; color: black; text-align: justify; border-right-width: thin; height: 13px;" colspan="2">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    Deductions</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image2" runat="server" Height="4px" ImageUrl="~/images/myline1.jpg" Width="588px" /></td>
            </tr>
            <tr>
                <td colspan="4">
                               <asp:Table ID="Table1" runat="server" BorderColor="#000000" BorderWidth="0px" CellPadding="0"
                                    CellSpacing="0" Font-Bold="True" Font-Size="small" HorizontalAlign="Left" Style="font-weight: bold;
                                    font-family: Verdana; background-color: white; border-top-width: thin; border-left-width: thin; border-left-color: black; border-bottom-width: thin; border-bottom-color: black; border-top-color: black; border-right-width: thin; border-right-color: black;"
                                    Width="100%">
                                </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image3" runat="server" Height="4px" ImageUrl="~/images/myline1.jpg" Width="588px" /></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: black;" colspan="4">
                    Total Earnings : &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="totearning" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Total Deductions : &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="totded" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: black;" colspan="4">
                    Net Salary :
                    <asp:Label ID="netsalary" runat="server" Font-Bold="True"></asp:Label>
                    <asp:Label ID="netsalword" runat="server" Font-Size="Small" style="font-size: 10pt"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="font-weight: bold; color: black">
                 <asp:Image ID="Image5" runat="server" Height="4px" ImageUrl="~/images/myline1.jpg" Width="588px" /></td>
            </tr>
        </table>

        </div>
    </form>
</body>
</html>
