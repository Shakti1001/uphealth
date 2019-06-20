<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="NewWebApp.Proforma2.transfer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="javascript:window.print()">Print</a>
       <asp:GridView ID="GridView1" runat="server" DataSourceID="sqldatasource1" 
            AutoGenerateColumns="False">
        <Columns>
        <asp:TemplateField HeaderText="S.No.">
            <ItemTemplate><%#Container.DataItemIndex+1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Computer Id" HeaderText="Computer Id" 
                SortExpression="Computer Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
            <asp:BoundField DataField="Current District" HeaderText="Current District" 
                SortExpression="Current District" />
            <asp:BoundField DataField="Hospital Name" HeaderText="Hospital Name" 
                SortExpression="Hospital Name" />
            <asp:BoundField DataField="Post" HeaderText="Post" SortExpression="Post" />
            <asp:BoundField DataField="Year Completed" HeaderText="Year Completed" 
                SortExpression="Year Completed" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
            
            SelectCommand="SELECT DISTINCT ListUnder_TransferPolicy2013.idno AS [Computer Id], currentsearchCriteria.name AS Name, currentsearchCriteria.lavel AS Level, currentsearchCriteria.districtname AS [Current District], currentsearchCriteria.hname AS [Hospital Name], currentsearchCriteria.newpostname AS Post, left(ListUnder_TransferPolicy2013.ExactYear,5) AS [Year Completed] FROM currentsearchCriteria INNER JOIN ListUnder_TransferPolicy2013 ON currentsearchCriteria.idno = ListUnder_TransferPolicy2013.idno ORDER BY Level DESC, [Year Completed] DESC"></asp:SqlDataSource>
      
    </div>
    </form>
</body>
</html>

