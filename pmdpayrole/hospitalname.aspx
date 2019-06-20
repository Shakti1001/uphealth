<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="hospitalname.aspx.cs" Inherits="NewWebApp.pmdpayrole.hospitalname" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm" style="width: 100%" >
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td width="60%">
                &nbsp;</td>
            <td width="20%">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    style="font-weight: bold" Text="Back" Width="55px" />
            </td>
                
                 
            
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td style="color: #800000; font-size: large; text-align: left;" width="60%">
                <strong>List of Hospitals Along with Admininstrative/Bill Processing Unit</strong></td>
            <td width="20%">
                &nbsp;</td>
                

        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>

            <td align="center" style="text-align: left" width="60%">&nbsp;<asp:GridView 
                    ID="GridView1" runat="server" >
                  <%--  <SortedAscendingCellStyle BackColor="#FAFAE7" />--%>
                    <Columns>
                              <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                
                    
                    
                    </Columns>
                </asp:GridView>
            </td>
            <td width="20%">
                &nbsp;</td>
           
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td width="60%">
                &nbsp;</td>
            <td width="20%">
                &nbsp;</td>
           
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
                  <td width="60%">
                &nbsp;</td>
                <td width="20%">
                &nbsp;</td>
            
            
        </tr>
    </table>
</div>
</asp:Content>
