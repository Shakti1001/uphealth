<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="currentlist.aspx.cs" Inherits="NewWebApp.Guest.currentlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .imgr{
   float: left;
   padding: 0 5px 5px 0;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
    <div style="width:100%; margin-left:5%; margin-right:5%;">
        <div>
        <div style="float:left; width:70%; height:150px; text-align:center;">
        <p>
       <img src="../Images/headlogo.png" alt="UPGovernment" class="imgr" />
       <h4 style="text-align:left; float:left;"><b>Department Of Medical Health & Family Welfare <br /><b>चिकित्सा स्वास्थ्य एवं परिवार कल्याण विभाग (उत्तर प्रदेश)</b></b></h4>
      
           </p>    
        
        </div>
        <div style="float:right;width:30%; height:150px;">
        <img src="../Images/swachh-bharat-abhiyan-logo-vector-file-768x334.jpg" width="200px" height="150px" alt="UPGovernment" class="imgr" />
        </div>

        <br />
         
            <div >
                <div >
                    <table style="width:90%; height:5%;">
                        <tr>
                        <td style="width: 310px; text-align: left">
                        <a href="doctor'sposting.aspx">Back</a></td>
                            <td style="width: 310px; text-align: right">
                        <a href="javascript:window.print()">Print</a></td>
                        </tr>
                    </table>
                </div>
            </div>
            <table style="font-weight: normal; left: -6px; width: 90%; font-family: Arial; position: relative;
                top: 0px; height: 88px; border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; border-bottom: #000033 thin solid; color: #330000;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style=" width: 896px; color: #000000; background-color: #cccccc; text-align: center; font-weight: bold; font-size: 14px; height: 24px;">
                        <strong></strong>Current
                        Posting List &nbsp;&nbsp;<asp:Label ID="Uidt" runat="server"
                            Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold; font-size: 14px; width: 896px; color: #000000;
                        background-color: #cccccc; text-align: center">
                        <asp:Label ID="strq" runat="server" Font-Bold="True" ForeColor="#C00000">Sorry,No Record Found</asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; width: 100%; color: #000000; text-align: right; height: 3px;">
                        </td>
                </tr> 
                <tr>
                    <td colspan="4" style="font-size: 13px; width: 100%; color: #000000; text-align: left; height: 3px;">
                        <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" 
                            Width="100%" Font-Bold="True" style="text-align: center">
                        </asp:Table>
                        </td>
                </tr> 
                <tr>
                    <td style="width: 36px; height: 20px;">
                    </td>
                    <td style="width: 320px; text-align: left; height: 20px;">
                        <asp:Label ID="distsublbl" runat="server" Visible="False"></asp:Label></td>
                    <td style="width: 420px; height: 20px;">
                    </td>
                    <td style="width: 100px; height: 20px;">
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
        &nbsp;

    </form>
</body>
</html>
