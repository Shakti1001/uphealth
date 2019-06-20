<%@ Page Title="::Paramedical P2 Entered Report::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="MonitoringReport.aspx.cs" Inherits="NewWebApp.paramedicalstaff.MonitoringReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" style="width: 100%">
 <tr><td colspan="6"><asp:LinkButton class="btn btn-danger" style="float:right;" ID="LinkButton1" OnClick="Back_Click" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td></tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:GridView ID="GridView1" runat="server">
               
               
               
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:GridView ID="GridView2" runat="server">
               <%-- <Columns>
                <asp:BoundField DataField="" HeaderText="" />
                </Columns>--%>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
