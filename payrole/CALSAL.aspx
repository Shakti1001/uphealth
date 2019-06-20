<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CALSAL.aspx.cs" Inherits="NewWebApp.payrole.CALSAL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Calculated Salary</title>
</head>
<body style="background-color: #ffffcc">
    <form id="form1" runat="server">
    <div style="text-align: center; background-color: #ffffcc;">
        <asp:Label ID="mesg" runat="server" Font-Bold="True" Font-Size="Larger" ></asp:Label>
        <asp:Label ID="Label1" runat="server" Visible="False" ></asp:Label>
        <br />
        <asp:Label ID="mesg2" runat="server" Font-Bold="True" Font-Size="Larger" ></asp:Label>
        <br />
        <asp:Label ID="mesg3" runat="server" Font-Bold="True" Font-Size="Larger" ></asp:Label>
        <br />
        <asp:Label ID="mesg1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#0000C0"
            Text="mesg"></asp:Label>
        <asp:Button ID="Button1" runat="server" ForeColor="Red" OnClick="Button1_Click" Text="Delete" /><br />
        <br /><asp:Label ID="Uidt"
                            runat="server" Visible="False"></asp:Label>
        <asp:Label ID="ME" runat="server" Text="Label" Visible="False"></asp:Label><br />
        <asp:LinkButton ID="GRLink" runat="server" OnClick="GRLink_Click"></asp:LinkButton><br />
        <br />
        <asp:Label ID="basicpay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="Gradepay" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="npaall" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="dearnesspay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="da" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="dapay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="hra" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="cca" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="perpay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="tpay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="sppay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="pensionpay" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="gpf" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="gisi" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="giss" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="incometax" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="gvr" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="hrr" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="payded" runat="server" Visible="False"></asp:Label>
        
        <asp:Label ID="ddocode" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="sectionid" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="headid" runat="server" Visible="False" ></asp:Label>
        <asp:Label ID="scaleid" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="idno" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="gpfno" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="attendance" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="salded" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="remark" runat="server" Visible="False"></asp:Label>&nbsp;
        <asp:Label ID="litemid" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="plino" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="elecbill" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="Licrd" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="PAN" runat="server" Visible="False"></asp:Label></div>
    </form>
</body>
</html>
