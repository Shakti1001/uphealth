<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorP2.aspx.cs" Inherits="NewWebApp.Guest.DoctorP2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%"><tr>
     <td style="width: 15%">
         </td>
      <td style="width: 70%">
      <table width="100%" style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid">
    <tr>
      <td width="70%" style="text-align: center; font-weight: bold; background-color: #cccccc;">
          Dept.Of Medical Health&amp; Family Welfare&nbsp;</td>
    </tr>
    
     <tr>
      <td style="text-align: center; font-weight: bold; background-color: #cccccc;">
          Government Of UttarPradesh</td>
    </tr>
     <tr>
      <td style="text-align: center; font-weight: bold; background-color: #cccccc;">
          Proforma-2(P2)</td>
    </tr>
     <tr>
      <td>
    </td>
    </tr>
     <tr>
      <td>
          <strong><span style="font-size: 11pt">Computer Id Number :
              <asp:Label ID="CMPID" runat="server"
              Font-Bold="True" Font-Size="Small"></asp:Label></span></strong></td>
    </tr>
     <tr><td>
     </td>
     </tr>
        <tr>
            <td>
                <fieldset style="height: 100%">
                    <legend style="font-weight: bold; font-size: smaller; color: navy">Personel Infromation</legend>
                    <table style="font-size: 11pt; width: 100%">
                        <tr>
                            <td style="width: 122px; text-align: left">
                            </td>
                            <td style="width: 361px; text-align: left">
                            </td>
                            <td style="width: 226px; text-align: left">
                            </td>
                            <td colspan="2" style="width: 59px">
                            </td>
                            <td colspan="1" style="width: 131px">
                            </td>
                            <td rowspan="1">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; color: black; text-align: left">
                                Name</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="Name" runat="server" Font-Names="Arial Narrow" Style="left: 1px; position: static;
                                    top: 0px" Width="100%"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 10pt; width: 226px; text-align: left">
                                Seniority No.</td>
                            <td colspan="3" style="text-align: left">
                                <asp:Label ID="Sen" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td rowspan="3">
                                <!--<asp:Image ID="Image1" runat="server" BorderColor="Navy" BorderStyle="Solid" BorderWidth="2px"
                                    Height="80px" ImageAlign="Top" Width="80px" />--><img src="../Doctors%20Image/noimg.jpg" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; text-align: left">
                                Father's/Husband's Name</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="FNAME" runat="server" Font-Names="Arial Narrow" Height="100%" Width="100%"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 10pt; width: 226px; text-align: left">
                                Cadre</td>
                            <td colspan="2" style="width: 59px; text-align: left">
                                <asp:Label ID="CADRE" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                               
                            <td colspan="1" style="width: 131px">
                            </td>
                        </tr>
                       
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; text-align: left">
                                Home District
                            </td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="HDIST" runat="server" Font-Names="Arial Narrow" Height="100%" Width="100%"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 10pt; width: 226px; text-align: left">
                                Cadre Seniority No.</td>
                            <td colspan="2" style="width: 59px; text-align: left">
                                <asp:Label ID="CSN" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td colspan="1" style="width: 131px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; text-align: left">
                                Date of birth</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="DOB" runat="server" Font-Names="Arial Narrow" Height="100%" Width="100%"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 10pt; width: 226px; text-align: left">
                                Category</td>
                            <td colspan="2" style="width: 59px; text-align: left">
                                <asp:Label ID="CATEGORY" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td colspan="1" style="width: 131px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; text-align: left">
                                Sex</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="SEX" runat="server" Font-Names="Arial Narrow" Height="100%" Width="100%"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 10pt; width: 226px; text-align: left">
                                Sub Category</td>
                            <td colspan="2" style="width: 59px; text-align: left">
                                <asp:Label ID="SCATEGORY" runat="server" Font-Names="Arial Narrow" Height="100%"
                                    Width="100%"></asp:Label></td>
                            <td colspan="1" style="width: 131px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; text-align: left">
                                Level</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="Llavel" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td style="font-weight: bold; font-size: 10pt; width: 226px; text-align: left">
                                Couple Gpf No</td>
                            <td colspan="2" style="width: 59px; text-align: left">
                                <asp:Label ID="CUID" runat="server" Font-Names="Arial Narrow" Height="100%" Width="100%"></asp:Label></td>
                            <td colspan="2" style="text-align: left">
                                (in case of Govt.service)</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 122px; color: black; text-align: left">
                                Qualification with Specialization</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="QD" runat="server" Font-Size="Small" Height="100%" Width="100%"></asp:Label></td>
                           <td style="font-weight: bold; font-size: 10pt; width: 122px; color: black; text-align: left">
                               Feeding Cadre</td>
                            <td style="width: 361px; text-align: left">
                                <asp:Label ID="Label3" runat="server" Font-Size="Small" Height="100%" Width="100%"></asp:Label></td>
                            <td colspan="1" style="width: 131px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" style="text-align: left">
                                <asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                    Font-Size="Small" Style="position: static" Width="100%">
                                </asp:Table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="height: 100%">
                    <legend style="font-weight: bold; font-size: smaller; color: navy">Address</legend>
                    <table style="font-size: 11pt; width: 100%">
                        <tr>
                            <td style="width: 138px; height: 2px; text-align: left">
                            </td>
                            <td colspan="4" style="height: 2px">
                            </td>
                            <td style="height: 2px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 138px; height: 36px; text-align: left">
                                Permanent Address</td>
                            <td colspan="4" style="height: 36px; text-align: left">
                                <asp:Label ID="PA" runat="server" Font-Size="Small" Width="100%"></asp:Label></td>
                            <td style="height: 36px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 138px; text-align: left">
                                Local Address</td>
                            <td colspan="4" style="text-align: left">
                                <asp:Label ID="LA" runat="server" Font-Size="Small" Width="100%"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="height: 100%">
                    <legend style="font-weight: bold; font-size: smaller; color: navy">Joining Details</legend>
                    <table style="font-size: 11pt; width: 100%">
                        <tr>
                            <td style="width: 171px; height: 19px; text-align: left">
                            </td>
                            <td colspan="4" style="height: 19px">
                            </td>
                            <td style="height: 19px">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 171px; text-align: left">
                                Date Of Appointment</td>
                            <td colspan="4" style="text-align: left">
                                <asp:Label ID="DOA" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 171px; text-align: left">
                                Date of Joining in service</td>
                            <td colspan="4" style="text-align: left">
                                <asp:Label ID="DOJ" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 171px; text-align: left">
                                Date of Confirmation</td>
                            <td colspan="4" style="text-align: left">
                                <asp:Label ID="DOC" runat="server" Font-Names="Arial Narrow" Width="100%"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset style="height: 100%">
                    <legend style="font-weight: bold; font-size: smaller; color: navy">Posting Details</legend>
                    <table style="width: 100%">
                        <tr>
                            <td colspan="1" style="width: 3px; text-align: center">
                            </td>
                            <td colspan="6" style="width: 585px; text-align: center">
                                <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Font-Size="Small"
                                    Style="font-size: 11pt; position: static" Width="100%">
                                </asp:Table>
                                &nbsp;</td>
                            <td colspan="1" style="text-align: center">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
                 
        <tr>
        <td>
        <fieldset style="height: 100%">
                    <legend style="font-weight: bold; font-size: smaller; color: navy">Training Details</legend>
                    <table style="width: 100%">
                        <tr>
                            <td colspan="1" style="width: 3px; text-align: center">
                            </td>
                            <td colspan="6" style="width: 585px; text-align: center">
                                <asp:Table ID="Table4" runat="server" CellPadding="0" CellSpacing="0" Font-Size="Small"
                                    Style="font-size: 11pt; position: static" Width="100%">
                                </asp:Table>
                                &nbsp;</td>
                            <td colspan="1" style="text-align: center">
                            </td>
                        </tr>
                    </table>
                </fieldset>
        
        </td>
        </tr>
        <tr>
            <td>
                <fieldset style="height: 100%">
                    <legend style="font-weight: bold; font-size: smaller; color: navy">Other Details</legend>
                    <table style="font-size: 11pt; width: 100%">
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 216px; text-align: left">
                                Dept. Enquiry/Proceedings(if any)</td>
                            <td colspan="4" style="text-align: left">
                                <asp:Label ID="Enq" runat="server" Font-Size="Small" Width="100%"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 10pt; width: 216px; text-align: left">
                                Remarks</td>
                            <td colspan="4" style="text-align: left">
                                <asp:Label ID="Remark" runat="server" Font-Size="Small" Width="100%"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 216px; text-align: left">
                            </td>
                            <td colspan="4">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label2" runat="server" Text="Other Posting Details" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Table ID="Table3" runat="server" CellPadding="0" CellSpacing="0" Font-Size="Small"
                    Style="position: static">
                </asp:Table>
            </td>
        </tr>
    </table>
    </td>
      <td width="15%" valign="top">
    
                        <a href="javascript:window.print()">Print</a>
          &nbsp;</td>
    </tr>
    </table>
        <br />
    
    </div>
    </form>
 
</body>
</html>
