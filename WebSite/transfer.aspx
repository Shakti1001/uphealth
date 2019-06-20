<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="NewWebApp.WebSite.transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="col-sm-12"><h4><center>Transfer/Posting Orders</center></h4></div>
<div class="col-sm-12">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="order">
        <ItemTemplate>
        
        <asp:HyperLink ID="HyperLink1" runat="server"
        text='<%#Eval("Description").ToString()+"&nbsp;&nbsp;&nbsp;&nbsp;"+Eval("PublishedDate").ToString()+"<br/><br/>" %>'
        NavigateUrl='<%#Eval("Link")+"\n" %>'></asp:HyperLink>
    
    </ItemTemplate>

    </asp:Repeater>

    <asp:SqlDataSource ID="order" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBCS %>" 
        SelectCommand="SELECT [Description], [Link], [PublishedDate] FROM [transfer] ORDER BY [id] DESC">
    </asp:SqlDataSource>
    </div>
</div>
</asp:Content>
