<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="postwisevacancy.aspx.cs" Inherits="NewWebApp.proforma.postwisevacancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    
    <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="font-size: 20px; width: 100%; height: 24px; text-align: center">
                Post wise vacancy Details In Hospitals</td>
        </tr>
                <tr>
                    <td style="width: 100%; height: 24px; text-align: center;">
                    <a class="btn btn-danger" href="javascript:window.print()" style="color: #0000ff"><span class="glyphicon glyphicon-print"></span>Print</a>
                        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
        <tr>
            <td style="width: 100%; height: 24px; text-align: center">
                <div style="text-align: center">
                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 90%; height: 80%">
                        <tr>
                            <td style="width: 100%; height: 24px; font-size: 12px; text-align: left;" valign="top">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="sno" Width="100%" >
            <Columns> 
            <asp:TemplateField HeaderText="S.No">
<ItemTemplate ><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Left" />
<HeaderStyle HorizontalAlign="Left" />
</asp:TemplateField>                
                <asp:BoundField DataField="newpostname" HeaderText="Post" SortExpression="newpostname" >
                </asp:BoundField>
                <asp:BoundField DataField="posts" HeaderText="Sanctioned Post" SortExpression="posts" >
                    <ItemStyle Font-Bold="True" ForeColor="#C00000" />
                </asp:BoundField>                                  
                <asp:BoundField DataField="withcadre" HeaderText="Filled Post With Cadre" SortExpression="withcadre" />
                <asp:BoundField DataField="withoutcadre" HeaderText="Filled Without Cadre" SortExpression="withoutcadre" />
                <asp:BoundField DataField="Extrapost" HeaderText="Extrapost" SortExpression="Extrapost" />
                <asp:BoundField DataField="vacantpost" HeaderText="Vacantpost" ReadOnly="True" SortExpression="vacantpost" >
                    <ItemStyle ForeColor="#0000C0" Font-Bold="True" />
                </asp:BoundField>                
                
                <asp:TemplateField HeaderText="Hospital Details">
                <ItemStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Medium" ForeColor="Navy" Wrap="True" />
                
                  <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<% # Eval("sno")%>' Visible="false" Font-Bold="True" ForeColor="#804040" ></asp:Label>
                  <table>
                  <tr>
                  <td>
                      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Font-Size="X-Small">
            <Columns>
            <asp:BoundField DataField="hname" HeaderText="Hospital Name" SortExpression="hname" >
                    <ItemStyle ForeColor="DarkRed" />
                </asp:BoundField>
            <asp:BoundField DataField="divname" HeaderText="Division" SortExpression="divname" />
                <asp:BoundField DataField="districtname" HeaderText="District" SortExpression="districtname" />
                <asp:BoundField DataField="tehsilname" HeaderText="Tehsil" SortExpression="tehsilname" />
                <asp:BoundField DataField="blockname" HeaderText="Block" SortExpression="blockname" />
                <asp:BoundField DataField="htype" HeaderText="H Type" SortExpression="htype" />
                
            </Columns>
                          <HeaderStyle BackColor="Silver" ForeColor="Black" />
        </asp:GridView>   
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
            SelectCommand="select Distinct(sno),divname, districtname, tehsilname, blockname, htype,hname FROM hospitallist WHERE (sno = @sno) order by divname, districtname, tehsilname, blockname, htype">
                        <SelectParameters>                            
                            <asp:ControlParameter ControlID="Label1" Name="sno" PropertyName="Text" DefaultValue="326" />
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
                        <asp:HyperLink ID="HyperLink1" Text='Print' NavigateUrl='<%#"Hdetails.aspx?sno=" + Eval("sno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                       <HeaderStyle BackColor="Silver" />
        </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
            >        
        </asp:SqlDataSource>

                    </td>
                        </tr>
                        <tr><td><%=QS %></td></tr>
                    </table>
                </div>
            </td>
        </tr>
                <tr>
                    
                </tr>
            </table>
    
    
    </div>

</asp:Content>
