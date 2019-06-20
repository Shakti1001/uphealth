<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="OPTIONALEARN.aspx.cs" Inherits="NewWebApp.pmdpayrole.OPTIONALEARN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td style="color: #800000; text-decoration: underline; text-align: left;">
                </td>
        </tr>
        <tr>
            <td style="color: #800000; text-decoration: underline;">
                <strong>Add/Edit Optional Earning (Id Number-<asp:Label ID="idno" 
                    runat="server" style="color: #000000"></asp:Label>
&nbsp; Name-<asp:Label ID="name" runat="server" style="color: #000000"></asp:Label>
                )</strong></td>
        </tr>
        <tr>
            <td>
            <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                         <tr>
                                             <td style="width: 50%; height: 25px; text-align: right;">
                                                 &nbsp;</td>
                                             <td style="width: 50%; height: 25px; text-align: left;">
                                                 &nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td style="width: 50%; height: 25px; text-align: right;">
                                                 <strong>Select Allowns:: </strong>
                                             </td>
                                             <td style="width: 50%; height: 25px; text-align: left;">
                                                 <asp:DropDownList ID="ErD" runat="server" Width="144px">
                                                 </asp:DropDownList></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 50%; height: 25px; text-align: right;">
                                                 <strong>Amount&nbsp;
                                                 ::</strong></td>
                                             <td style="width: 50%; height: 25px; text-align: left;">
                                                 <asp:TextBox ID="Eramt" runat="server"></asp:TextBox></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 50%; height: 25px;">
                                             </td>
                                             <td style="width: 50%; height: 25px;">
                                                 &nbsp;<strong><asp:Button ID="saveear" runat="server" Text="Save Earning" 
                                                     OnClick="saveear_Click" style="font-weight: bold" /></strong></td>
                                         </tr>
                                         <tr>
                                             <td style="height: 25px; text-decoration: underline; text-align: left; color: #990000;" 
                                                 colspan="2">
                                                 <strong>
                                                 <asp:Label ID="Label2" runat="server" 
                                                     Text="List of Already Entered Optional Earning...........!" Visible="False"></asp:Label>
                                                 </strong>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td colspan="2" align="center" style="width: 100%" >
                                                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                     DataKeyNames="earoptid" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
                                                     Width="75%">
                                                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                     <Columns>
                                                         <asp:BoundField DataField="optearname" HeaderText="Earning Name" SortExpression="optearname" />
                                                         <asp:BoundField DataField="optearamt" HeaderText="Amount" SortExpression="optearamt" />
                                                         <asp:CommandField ShowDeleteButton="True" />
                                                     </Columns>
                                                     <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                     <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                     <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                     <AlternatingRowStyle BackColor="White" />
                                                 </asp:GridView>
                                             
                                                 &nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td colspan="2" style="width: 100%">
                                                 <strong>
                                                 <asp:Label ID="Label1" runat="server" style="color: #993300"></asp:Label>
                                                 </strong>
                                                 <asp:Label ID="ME" runat="server" Visible="False"></asp:Label>
                                                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpcon%>"
                                                     
                                                     SelectCommand="SELECT     pmd_pay_opt_earning.earoptid, pay_optearmast.optearname, pmd_pay_opt_earning.optearamt FROM         pmd_pay_opt_earning INNER JOIN                     pay_optearmast ON pmd_pay_opt_earning.optearid = pay_optearmast.optearid WHERE (pmd_pay_opt_earning.idno = @idno)" 
                                                     DeleteCommand="DELETE FROM pmd_pay_opt_earning WHERE (earoptid = @earoptid)">
                                                     <SelectParameters>
                                                         <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                                                     </SelectParameters>
                                                     <DeleteParameters>
                                                         <asp:ControlParameter ControlID="GridView2" Name="earoptid" PropertyName="SelectedValue" />
                                                     </DeleteParameters>
                                                 </asp:SqlDataSource>
                                             </td>
                                         </tr>
                                     </table></td>
        </tr>
    </table>
    </div>
</asp:Content>
