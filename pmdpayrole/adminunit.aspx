<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="adminunit.aspx.cs" Inherits="NewWebApp.pmdpayrole.adminunit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" style="background-color: #B6941F; color: #800000;">
                <strong>Prepare Administrative Unit wise Hospital List...</strong></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td style="border-right: thick groove #B6941F; text-align: right;">
                <strong>
                    <asp:LinkButton class="btn btn-danger" ID="LinkButton2" runat="server" 
                    onclick="LinkButton2_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                </strong></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td style="border-right: thick groove #B6941F; text-align: right;">
                <strong>
                <em>
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View Admin Unit wise Hospital List</asp:LinkButton>
                &nbsp;&nbsp;&nbsp; </em>
                </strong></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="font-size: large">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td style="border-left: thick groove #B6941F; text-align: right;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="font-size: large">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td style="border-left: thick groove #B6941F; text-align: right;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="font-size: large">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td style="border-left: thick groove #B6941F; text-align: right;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="font-size: large">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td style="border-left: thick groove #B6941F; text-align: right;">
                <strong>&nbsp;<asp:Label ID="Label3" runat="server" style="margin-left: 0px" 
                    Text=" Select Bill Processing Unit"></asp:Label>
                ::</strong></td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    style="height: 22px">
                </asp:DropDownList>
            </td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="font-size: large">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td style="border-left: thick groove #B6941F; text-align: right;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                <strong>
                <asp:Label ID="Label1" runat="server" style="font-size: large; color: #800000;" 
                    Text="Tick Hospitals under Selected Unit....." Visible="False"></asp:Label>
                </strong></td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Visible="False">
  
</asp:CheckBoxList></td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                <strong>
                <asp:Label ID="Label2" runat="server" style="color: #CC0000; font-size: large"></asp:Label>
                </strong></td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" 
                    Width="96px" Visible="False" />
            </td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" colspan="2" 
                
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" colspan="2" 
                
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td align="left" colspan="2" 
                
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                
                style="border-left: thick groove #B6941F; border-right: thick groove #B6941F; text-align: right;">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-right-style: groove; border-right-width: thick; border-right-color: #B6941F; border-left-style: groove; border-left-width: thick; border-left-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F; border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F; border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F; border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F; border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-left-style: groove; border-left-width: thick; border-left-color: #B6941F; border-right-style: groove; border-right-width: thick; border-right-color: #B6941F;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" 
                style="border-left: thick groove #B6941F; border-right: thick groove #B6941F; text-align: right;">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59px">
                &nbsp;</td>
            <td colspan="2" style="background-color: #B6941F">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
