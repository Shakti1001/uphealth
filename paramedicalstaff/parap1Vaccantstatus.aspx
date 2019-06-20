<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parap1Vaccantstatus.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap1Vaccantstatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Para Vaccant Post Status</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="width: 100%; height: 24px; text-align: center;">
                    <a
    href="javascript:window.print()" style="color: #0000ff">Print</a>
                    </td>
                </tr>
        <tr>
            <td style="width: 100%; height: 24px; text-align: center">
                <div style="text-align: center">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 90%; height: 80%">
                        <tr>
                            <td style="width: 100%; height: 24px; font-size: 12px; text-align: left;" valign="top">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="sno" Width="100%" >
            <Columns> 
            <asp:TemplateField HeaderText="S.No">
<ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:TemplateField>                
                <asp:BoundField DataField="divname" HeaderText="Division" SortExpression="divname" />
                <asp:BoundField DataField="districtname" HeaderText="District" SortExpression="districtname" />
                <asp:BoundField DataField="tehsilname" HeaderText="Tehsil" SortExpression="tehsilname" />
                <asp:BoundField DataField="blockname" HeaderText="Block" SortExpression="blockname" />
                <asp:BoundField DataField="htype" HeaderText="Type" SortExpression="htype" />
                <asp:BoundField DataField="hname" HeaderText="Hospital Name" SortExpression="hname" >
                    <ItemStyle ForeColor="Navy" />
                </asp:BoundField>                
                
                <asp:TemplateField HeaderText="Hospital Paramedical P1 Record">
                <ItemStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Medium" ForeColor="Navy" Wrap="True" />
                
                  <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<% # Eval("sno")%>' Visible="false" Font-Bold="True" ForeColor="#804040" ></asp:Label>
                  <table>
                  <tr>
                  <td>
                      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Font-Size="X-Small">
            <Columns>
                <asp:BoundField DataField="designame" HeaderText="Post" SortExpression="designame" />
                <asp:BoundField DataField="posts" HeaderText="Sanctioned Post" SortExpression="posts" />
                <asp:BoundField DataField="withcadre" HeaderText="Filled Post With Cadre" SortExpression="withcadre" />
                <asp:BoundField DataField="withoutcadre" HeaderText="Filled Without Cadre" SortExpression="withoutcadre" />
                <asp:BoundField DataField="Extrapost" HeaderText="Extrapost" SortExpression="Extrapost" />
                <asp:BoundField DataField="vacantpost" HeaderText="Vacantpost" ReadOnly="True" SortExpression="vacantpost" />
            </Columns>
                          <HeaderStyle BackColor="Silver" ForeColor="Black" />
        </asp:GridView>
   
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
            SelectCommand="SELECT     PMDhospitaldesignation.designame, PMDhospitalrecord.posts, PMDhospitalrecord.withcadre, PMDhospitalrecord.withoutcadre, PMDhospitalrecord.Extrapost, PMDhospitalrecord.posts - PMDhospitalrecord.withcadre - PMDhospitalrecord.Extrapost AS vacantpost,PMDhospitaldesignation.desigid FROM         PMDhospitalrecord INNER JOIN   hospitalname ON PMDhospitalrecord.hnameid = hospitalname.sno INNER JOIN    PMDhospitaldesignation ON PMDhospitalrecord.desigid = PMDhospitaldesignation.desigid  WHERE (hospitalname.sno = @sno)">
                        <SelectParameters>
                            
                            <asp:ControlParameter ControlID="Label1" Name="sno" PropertyName="Text" DefaultValue="326" />
           <%-- <asp:SessionParameter Name="newpostid" SessionField="newpostid" />--%>
            </SelectParameters>
                      </asp:SqlDataSource>                 
                  </td></tr>
                  </table>
                  </ItemTemplate>
                    <HeaderStyle Font-Bold="True" ForeColor="Navy" HorizontalAlign="Left" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Print P1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='Print'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" Text='Print' NavigateUrl='<%#"parap1hdet.aspx?sno=" + Eval("sno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                       <HeaderStyle BackColor="Silver" />
        </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
            SelectCommand="SELECT divname, districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM hospitallist where divid like @divid and districtid like @districtid and hid like @hid and sno like @sno">
        <SelectParameters>
            <asp:SessionParameter Name="divid" SessionField="divid" />
            <asp:SessionParameter Name="districtid" SessionField="districtid" />
            <asp:SessionParameter Name="hid" SessionField="hid" />
            <asp:SessionParameter Name="sno" SessionField="sno" />
        </SelectParameters>
        </asp:SqlDataSource>

                    </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
                <tr>
                    
                </tr>
            </table>
    
    
    </div>

    </form>
</body>
</html>
