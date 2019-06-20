<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rddedsch.aspx.cs" Inherits="NewWebApp.pmdpayrole.rddedsch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body style="background-color: #ffffcc">
     <form id="form1" runat="server">
    <div>
        <table id="table9" align="center" border="1" bordercolor="#000000" cellpadding="0"
            cellspacing="0" width="100%" >
            <tr>
                <td align="center" height="57" valign="top" width="100%" style="background-color: #660000">
                    <table id="table10" align="center" bgcolor="#00ccff" border="0" cellpadding="0" cellspacing="0"
                        width="100%" style="background-color: #669999; height: 160px;">
                       
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" style="height: 0px">
                                <div align="center" class="normal style3">
                                    <p class="style4" style="font-weight: bold; font-size: 16pt; color: khaki; background-color: #660000">
                                        Office Of&nbsp; :<asp:Label ID="Label1" runat="server" style="font-size: 15pt"></asp:Label></p>
                                    <p class="style4" style="font-weight: bold; font-size: 14pt; color: navy; background-color: #ffffcc">
                                        Schedule Of RD-Deduction made from salary for the month 
                                        <asp:Label ID="MonthLabel" runat="server"></asp:Label><asp:Label ID="YearLabel" runat="server"></asp:Label>of
                                        
                                        payable on 1st of next month<br />
                                        
                                        </p>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" style="background-color: #ffffcc; height: 77px;">
                                </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" style="text-align: left; background-color: #ffffcc; height: 14px;">
                                <asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" Width="100%" style="left: -1px; position: relative; top: -137px; background-color: #660000; text-align: center">
                                </asp:Table><asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Width="90%" style="left: 41px; position: relative; top: -57px; background-color: #e8cd76; text-align: center">
                                </asp:Table>
                                <asp:Table ID="Table3" runat="server" CellPadding="0" CellSpacing="0" Width="100%" style="left: 0px; position: relative; top: -113px; background-color: #e8cd76; text-align: center">
                                </asp:Table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" height="38" style="background-color: #660000">
                                <asp:Label ID="MSGLab" runat="server" Text="" style="font-size: 11pt; color: white"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
