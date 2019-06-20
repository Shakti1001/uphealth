<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Cpostdetail.aspx.cs" Inherits="NewWebApp.proforma.Cpostdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
    
    <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 60%;">
        <tr>
            <td style="font-size: 20px; width: 100%; height: 24px; text-align: center">
                Hospitals wise Post Details</td>
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
                            <td style="width: 80%; height: 24px; font-size: 12px; text-align: left;" valign="top">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="sno" Width="80%" >
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
                
                <asp:TemplateField HeaderText="Hospital P1 Record">
                <ItemStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Medium" ForeColor="Navy" Wrap="True" />
                
                  <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<% # Eval("sno")%>' Visible="false" Font-Bold="True" ForeColor="#804040" ></asp:Label>
                  <table>
                  <tr>
                  <td>
                      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Font-Size="X-Small">
            <Columns>
                <asp:BoundField DataField="newpostname" HeaderText="Post" SortExpression="newpostname" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"  />
                <asp:BoundField DataField="posts" HeaderText="Sanctioned Post" SortExpression="posts" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"  />
                <asp:BoundField DataField="withcadre" HeaderText="Filled Post With Cadre" SortExpression="withcadre" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"  />
                <asp:BoundField DataField="withoutcadre" HeaderText="Filled Without Cadre" SortExpression="withoutcadre" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                <asp:BoundField DataField="Extrapost" HeaderText="Extrapost" SortExpression="Extrapost" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"  />
                <asp:BoundField DataField="vacantpost" HeaderText="Vacantpost" ReadOnly="True" SortExpression="vacantpost" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
               
            </Columns>
                          <HeaderStyle BackColor="Silver" ForeColor="Black" />
        </asp:GridView>
   
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
            SelectCommand="SELECT post.newpostname, hospitalrecord.posts, hospitalrecord.withcadre, hospitalrecord.withoutcadre, hospitalrecord.Extrapost, hospitalrecord.posts - hospitalrecord.withcadre - hospitalrecord.Extrapost AS vacantpost, post.newpostid FROM hospitalrecord INNER JOIN post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno WHERE (hospitalname.sno = @sno)and (post.newpostname = @post)">
                        <SelectParameters>                            
                            <asp:ControlParameter ControlID="Label1" Name="sno" PropertyName="Text" DefaultValue="326" />
                            <asp:ControlParameter ControlID="TextBox3" Name="post" PropertyName="Text" />           
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
