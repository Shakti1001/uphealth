<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yearlyrepo.aspx.cs" Inherits="NewWebApp.payrole.yearlyrepo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#e8cd76">
    <form id="form1" runat="server">
    <div>
        <table border="1" style="width: 964px; height: 217px; border-right: #000000 thin groove; border-top: #000000 thin groove; left: 50px; border-left: #000000 thin groove; border-bottom: #000000 thin groove; position: static; top: 0px; text-align: center;">
            <tr>
                <td colspan="3" style="font-weight: normal; font-size: 16pt; color: #990000; font-family: 'Arial Black';
                    text-align: center; ">
                    <asp:Label ID="lblerr" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-weight: normal; font-size: 19px; color: #000066; font-family: 'Arial Black';">
                    &nbsp;Yearly&nbsp; Earning and Deduction (YE&amp;D) Report<br />
                    &nbsp;(Year&nbsp;<asp:Label ID="lblyear" runat="server"></asp:Label>)</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 7px; text-align: center;">
                   <asp:Table ID="Table4" runat="server" BorderColor="#000000" BorderWidth="0px" CellPadding="0"
                                    CellSpacing="0" Font-Bold="True" Font-Size="small" HorizontalAlign="Center" Style="font-weight: bold;
                                    font-family: Verdana; background-color: #e8cd76; border-top-width: thin; border-left-width: thin; border-left-color: black; border-bottom-width: thin; border-bottom-color: black; border-top-color: black; border-right-width: thin; border-right-color: black;" Width="80%"
                                    >
                                </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight: bold; font-size: 16px; color: navy; font-family: Arial;
                    background-color: #ccccff; text-align: center">
                    Earnings</td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    
                 <asp:Table ID="Table2" runat="server" BorderColor="#000000" BorderWidth="0px" CellPadding="0"
                                    CellSpacing="0" Font-Bold="True" Font-Size="small" HorizontalAlign="Left" Style="font-weight: bold;
                                    font-family: Verdana; background-color: white; border-top-width: thin; border-left-width: thin; border-left-color: black; border-bottom-width: thin; border-bottom-color: black; border-top-color: black; border-right-width: thin; border-right-color: black;"
                                   Width="100%"  >
                                </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight: bold; font-size: 16px; color: navy; font-family: Arial;
                    background-color: #ccccff; text-align: center; height: 23px;">
                    Deductions</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 27px; text-align: center">
                <asp:Table ID="Table3" runat="server" BorderColor="#000000" BorderWidth="0px" CellPadding="0"
                                    CellSpacing="0" Font-Bold="True" Font-Size="small" HorizontalAlign="Left" Style="font-weight: bold;
                                    font-family: Verdana; background-color: white; border-top-width: thin; border-left-width: thin; border-left-color: black; border-bottom-width: thin; border-bottom-color: black; border-top-color: black; border-right-width: thin; border-right-color: black;"
                                   Width="100%"  >
                                </asp:Table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight: bold; font-size: 16px; color: #000066; font-family: Arial;
                    height: 16px; background-color: #ccccff; text-align: left">
                    Net Salary :<asp:Label ID="Lblnet" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblNetSalWord" runat="server" Font-Size="Smaller" ForeColor="Maroon"></asp:Label></td>
            </tr>
        </table>
        <div style="text-align: center">
            &nbsp;</div>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>