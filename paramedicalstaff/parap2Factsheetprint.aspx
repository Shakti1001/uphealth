<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parap2Factsheetprint.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap2Factsheetprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Paramedical Employee Factsheet</title>
</head>
<body leftmargin="0px" topmargin="0px" style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <div style="text-align: right">
                <div style="text-align: right">
                    <table style="width: 56px; height: 16px;">
                        <tr>
                            <td style="width: 310px; text-align: right">
                        <a href="javascript:window.print()">Print</a></td>
                        </tr>
                    </table>
                </div>
            </div>
            <table style="font-weight: normal; left: -14px; width: 700px; font-family: Arial; position: relative;
                top: 0px; height: 88px; border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; border-bottom: #000033 thin solid; color: #330000;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style=" width: 896px; color: #000000; background-color: #cccccc; text-align: center; font-weight: bold; font-size: 14px;">
                        <strong></strong>Proforma-2 to be filled by individual&nbsp; and verified by CMO/CMS</td>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold; font-size: 14px; width: 896px; color: #000000;
                        background-color: #cccccc; text-align: center">
                        (Applicable For Paramedical Staff Recruited On Regular Basis)</td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 896px; color: #000000; text-align: right">
                        <strong>Computer Id Number:</strong><asp:Label ID="CMPID" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                 <tr>
                    <td style="width: 36px">
                        1.</td>
                    <td style="width: 320px; text-align: left">
                        GPF Number<strong> </strong>
                    </td>
                    <td colspan="2" style="text-align: left">
                        :<asp:Label ID="Sen" runat="server" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        2.</td>
                    <td style="width: 320px; text-align: left">
                        Name</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="Name" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        3.</td>
                    <td style="width: 320px; text-align: left">
                        Father's/Husband's Name</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="FNAME" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        4.</td>
                    <td style="width: 320px; text-align: left">
                        Sex</td>
                    <td style="text-align: left" colspan="2">
                        :<asp:Label ID="SEX" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        5.</td>
                    <td style="width: 320px; text-align: left">
                        Cadre</td>
                    <td style="text-align: left" colspan="2">
                        :<asp:Label ID="CADRE" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        6.</td>
                    <td style="width: 320px; text-align: left">
                        Feeding
                        Cadre</td>
                    <td style="text-align: left" colspan="2">
                        :<asp:Label ID="FCADREID" runat="server" Width="90%" 
                            Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        7.</td>
                    <td style="width: 320px; text-align: left">
                        Seniority Number</td>
                    <td style="text-align: left" colspan="2">
                        :<asp:Label ID="CSN" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        8.</td>
                    <td style="width: 320px; text-align: left">
                        Cast</td>
                    <td style="text-align: left" colspan="2">
                        :<asp:Label ID="CATEGORY" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        9.</td>
                    <td style="width: 320px; text-align: left">
                        Disability</td>
                    <td style="text-align: left" colspan="2">
                        :<asp:Label ID="DISABILITY" runat="server" 
                            Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        10.</td>
                    <td style="width: 320px; text-align: left">
                        Home District 
                    </td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="HDIST" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        11.</td>
                    <td style="width: 320px; text-align: left">
                        Date of birth</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="DOB" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        12.</td>
                    <td style="width: 320px; text-align: left">
                        Date Of Appointment</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="DOA" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        13.</td>
                    <td style="width: 320px; text-align: left">
                        Date of Joining in service</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="DOJ" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        14.</td>
                    <td style="width: 320px; text-align: left">
                        Data of Confirmation/Regularization
                    </td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="DOC" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        15.</td>
                    <td style="width: 320px; text-align: left">
                        Couple Gpf No(in case of posting)</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="CUID" runat="server" Width="90%" Font-Names="Arial Narrow"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        16.</td>
                    <td style="width: 320px; text-align: left">
                        Qualification with Specialization</td>
                    <td style="text-align: left;" colspan="2">
                        :<asp:Label ID="QD" runat="server" Font-Size="Small" Width="90%"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="4" style="text-align: center; width: 896px"> 
                        <asp:Table ID="Table2" runat="server" Font-Size="Small" Font-Bold="True" CellPadding="0" CellSpacing="0" Width="100%">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        17</td>
                    <td style="width: 320px; text-align: left">
                        Posting Details</td>
                    <td style="width: 420px">
                    </td>
                    <td style="width: 100px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px; color: #ffffff">
                        /</td>
                    <td style="width: 36px; color: #ffffff">
                        /</td>
                    <td style="width: 36px; color: #ffffff">
                        /</td>
                    <td style="width: 36px; color: #ffffff">
                        /</td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;width: 896px; height: 27px;">
                        <asp:Table ID="Table1" runat="server" Font-Size="Small" CellPadding="0" CellSpacing="0" Width="95%">
                        </asp:Table>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px; height: 20px;">
                        17.</td>
                    <td style="width: 320px; text-align: left; height: 20px;">
                        Address for correspondence</td>
                    <td style="text-align: left; height: 20px;" colspan="2">
                        <asp:Label ID="LA" runat="server" Font-Size="Small" Width="90%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        18.</td>
                    <td style="width: 320px; text-align: left">
                        Permanent Address</td>
                    <td style="text-align: left;" colspan="2">
                        <asp:Label ID="PA" runat="server" Font-Size="Small" Width="90%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        19.</td>
                    <td style="width: 320px; text-align: left">
                        Dept. Enquiry/Proceedings(if any)</td>
                    <td style="text-align: left;" colspan="2">
                        <asp:Label ID="Enq" runat="server" Font-Size="Small" Width="90%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td style="width: 36px">
                        20.</td>
                    <td style="width: 320px; text-align: left">
                        Remarks</td>
                    <td colspan="2" style="text-align: left">
                        <asp:Label ID="Remark" runat="server" Width="90%" Font-Size="Small"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left; height: 24px;">
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label><div align="right">
                            <span class="normal">Signature/Name/Post/Stamp Of Concern</span></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 50%; text-align: left; height: 24px;">
                        Verified By</td>
                    <td colspan="2" style="width: 50%; height: 24px; text-align: left;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="width: 100%; text-align: left; height: 24px;">
                        Signature/Name/Post/Stamp Of CMO/CMS/Head Of Office</td>
                </tr>
                <tr>
                    <td style="width: 36px; height: 20px;">
                    </td>
                    <td style="width: 320px; text-align: left; height: 20px;">
                        </td>
                    <td style="width: 420px; height: 20px;">
                    </td>
                    <td style="width: 100px; height: 20px;">
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
                        <asp:Label ID="Label2" runat="server" Text="Other Posting Details" Visible="False"></asp:Label>&nbsp;<asp:Table ID="Table3" runat="server" Font-Size="Small" CellPadding="0" CellSpacing="0">
                        </asp:Table>
    </form>
</body>
</html>
