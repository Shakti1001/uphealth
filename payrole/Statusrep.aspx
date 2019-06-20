<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statusrep.aspx.cs" Inherits="NewWebApp.payrole.Statusrep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Status Report</title>
</head>
<body style="background-color: #ffffcc">
    <form id="form1" runat="server">
    <div>
        <table id="TABLE1" style="width: 100%; background-color: #e8cd76; border-color:Black;" >
            <tr style="width: 100%">
                <td colspan="3" style="text-align: center; height: 40px;">
                    <asp:Label ID="Label1" runat="server" Text="Status Report Of Pay Record " style="align:center" Font-Bold="True" ForeColor="#C00000" Font-Size="X-Large"></asp:Label></td>
            </tr>
            <tr style="width: 100%">
                <td style="width: 15%;">
                </td>
                <td style="width: 50%;">
                    <!--<asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                        BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="157px"
                        Width="904px">
                        <FooterStyle BackColor="Tan" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>-->
                     <asp:Gridview ID="Status_Report" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Status_Report_SelectedIndexChanged" OnRowDataBound="Status_Report_RowDataBound" Width="982px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="None" style="Background-color:#e8cd76;" >
    <Columns>
    <asp:TemplateField HeaderText="Sr.No.">
                    <ItemTemplate>
                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                    </ItemTemplate>
                    
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
  
    <asp:TemplateField HeaderText="DistrictId" >
    <ItemTemplate>
    <%#DataBinder.Eval(Container.DataItem,"DisId")%>
       </ItemTemplate>
       <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
    </asp:TemplateField>
     
     
     <asp:TemplateField HeaderText="DistrictName">
    <ItemTemplate>
    <%#DataBinder.Eval(Container.DataItem,"districtname")%>
       </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
    </asp:TemplateField>
    
    
    
    <asp:TemplateField HeaderText="DDOCode ">
    <ItemTemplate>
    <%#DataBinder.Eval(Container.DataItem,"userid")%>
       </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
     
   <asp:TemplateField HeaderText="UserName">
    <ItemTemplate>
    <%#DataBinder.Eval(Container.DataItem,"username")%>
       </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
         <asp:TemplateField HeaderText="Basic Record">
    <ItemTemplate>
    <%#DataBinder.Eval(Container.DataItem,"BasicRecord")%>
       </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
        
    </Columns>
                         <FooterStyle BackColor="Tan" />
                         <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                         <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                         <HeaderStyle BackColor="Maroon" Font-Bold="True" ForeColor="#FFFFC0" />
                         <AlternatingRowStyle BackColor="PaleGoldenrod" />
</asp:GridView>  
                    <table style="width: 980px; background-color: maroon;">
                        <tr>
                            <td style="width: 100px; color: maroon">
                                </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 98px">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#FFFFC0" Text="Total Records"></asp:Label></td>
                            <td style="width: 100px">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblsum" runat="server" Font-Bold="True" ForeColor="#FFFFC0"></asp:Label></td>
                        </tr>
                    </table>
              
                  
                </td>
                <td style="width: 40%">
                </td>
            </tr>
            <tr style="width: 100%">
                <td colspan="3">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
