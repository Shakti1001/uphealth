<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="MonthlyMpr.aspx.cs" Inherits="NewWebApp.payrole.MonthlyMpr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
 <table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td align="right" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2" 
                style="text-decoration: underline; font-size: large">
                <strong>Monthly MPR (Multiple Choice)</strong></td>
        </tr>
        <tr>
            <td align="right" style="width: 578px">
                <strong>District Name::</strong></td>
            <td align="left">
                <asp:DropDownList ID="district" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="district_SelectedIndexChanged" Width="130px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 26px; width: 578px;">
                <strong>DDO ID::</strong></td>
            <td align="left" style="height: 26px">
                <asp:DropDownList ID="ddlddo" runat="server" Width="130px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 578px">
                <strong>Duty Type::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddldutytype" runat="server" Width="130px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 578px">
                <strong>Month::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlmonth" runat="server" Width="130px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 578px">
                <strong>Year::</strong></td>
            <td align="left">
                <asp:DropDownList ID="ddlyear" runat="server" Height="16px" Width="130px">
                    <asp:ListItem>Select</asp:ListItem>
                   <%-- <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>--%>
                    <asp:ListItem>2016</asp:ListItem>
                     <asp:ListItem>2017</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 578px">
                &nbsp;</td>
            <td align="left">
                <strong>
                <asp:Label ID="lblmess" runat="server" style="color: #FF3300"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td style="width: 578px">
                &nbsp;</td>
            <td align="left">
                <asp:Button class="btn btn-success" ID="Button1" runat="server" Font-Bold="True" Height="29px" 
                    onclick="Button1_Click" Text="Submit" Width="146px" />
            </td>
        </tr>
        <tr>
            <td style="width: 578px">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 578px">
                &nbsp;</td>
            <td align="left">
                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                    
                    
                    
                    
                    
                    
                    
                    SelectCommand="SELECT dutytype.dutyname, monthlympr.name, monthlympr.spqual, monthlympr.newpostname, monthlympr.hname, monthlympr.districtname, monthlympr.cases, monthlympr.month, monthlympr.year, monthlympr.districtid, monthlympr.username FROM dutytype INNER JOIN monthlympr ON dutytype.dutyid = monthlympr.dutyid">
                </asp:SqlDataSource>--%>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView2" runat="server" >
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Width="100%" PageSize="40"> 
                    <Columns>
                     <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="username" HeaderText="DDO Name" />
                    <asp:BoundField DataField="name" HeaderText="Doctor Name"/>
                                        <asp:BoundField DataField="spqual" HeaderText="Qualification"/>
                                        <asp:BoundField DataField="newpostname" HeaderText="Post"/>

                                         <asp:BoundField DataField="hname" HeaderText="Hospital Name"/>
                                          <asp:BoundField DataField="districtname" HeaderText="District Name"/>


                           <asp:BoundField DataField="year" HeaderText="Year" />
                           <asp:BoundField DataField="month" HeaderText="Month" />
                     <asp:BoundField DataField="dutyname" HeaderText="Duty" />
                      <asp:BoundField DataField="cases" HeaderText="Cases" />
                       
                 
                    
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
