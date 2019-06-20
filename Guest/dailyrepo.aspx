<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="dailyrepo.aspx.cs" Inherits="NewWebApp.Guest.dailyrepo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table width="100%"><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td></td><td>
        &nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table>
    
    <table width="100%"><tr><td>
    <asp:GridView ID="GridView1" runat="server" Width="100%" 
            AutoGenerateColumns="false">
    <Columns>
    <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
    <asp:BoundField HeaderText="Computer Id" DataField="compid"/>
    <asp:BoundField HeaderText="Duty Date" DataField="date" DataFormatString="{0:D}" />
    <asp:BoundField HeaderText="Duty Name" DataField="dutyname"/>
    <asp:BoundField HeaderText="Cases Done" DataField="cases"/>
    
    </Columns>
    </asp:GridView>
    </td></tr></table>

</asp:Content>
