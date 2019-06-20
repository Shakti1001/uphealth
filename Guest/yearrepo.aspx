<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="yearrepo.aspx.cs" Inherits="NewWebApp.Guest.yearrepo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
    <asp:LinkButton ID="LinkButton1" class="btn btn-danger" OnClick="Back_Click" style="float:right;" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
               
                

<br />

<table class="table table-responsive-sm table-active" align="center" style="border-style: double; border-color: #000000">
                        <tr>
                            <td style="height: 42px; font-weight: bold; color: maroon; text-align: center;" 
                                colspan="3" >
                                <span style="font-weight: normal"><span style="font-size: large"><em><strong>&nbsp;::</strong></em><strong><em>Salary 
                                Ledger::</em></strong></span></span></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 127px">
                                                     <table class="table table-responsive-sm" style="text-align: left; border:1px solid black;">
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Maroon" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="font-weight: bold; text-align: center; height: 21px;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 121px; text-align: left; height: 28px;">
                                                <asp:Label ID="Lblcid" runat="server" Text="Computer Id" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label></td>
                                                        <td style="text-align: left; height: 28px;">
                                                <asp:TextBox class="form-control" ID="cmpid" runat="server" Width="121px" ValidationGroup="group1"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="cmpid">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 121px; text-align: left; height: 24px;">
                                                <asp:Label ID="Lblmon" runat="server" Text="Financial Year" style="font-weight: bold; color: navy" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left; height: 24px;">
                                                            <asp:DropDownList class="form-control"
                                                    ID="Drpyear" runat="server" Width="122px" style="left: -4px; position: static; top: 1px" OnSelectedIndexChanged="Drpyear_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;" colspan="2">
                                                            &nbsp;</td>
                                                    </tr>
                                                         <tr>
                                                             <td colspan="2" style="text-align: center">
                                                                 <asp:Button class="btn btn-success" ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="group1" /></td>
                                                         </tr>
                                                         <tr>
                                                             <td colspan="2" style="font-weight: normal">
                                                                 </td>
                                                         </tr>
                                                </table>
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 42px;">
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
    <div style="text-align: center">
    <%--SERVICE BOOK :::: Personal Management System--%>
       
    </div>
    </div>

</asp:Content>
