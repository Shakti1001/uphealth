<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="payearnings.aspx.cs" Inherits="NewWebApp.payrole.payearnings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="24px" Width="64px" ImageUrl="~/images/images1.jpg" OnClick="ImageButton1_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 0px; background-color: #661700; text-align: left; font-weight: bold; font-size: 14px; color: #ffff99;"
                        valign="top">
                        Pay Details Of&nbsp; A Employer</td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; background-color: #fff8dc; font-weight: bold; font-size: 14px; color: maroon; text-align: left;">
                                <tr>
                                    <td colspan="6" style="font-weight: bold;
                                        color: maroon; width: 100%; background-color: burlywood; text-align: center;">
                                        Basic
                                        Personal &nbsp;Detail of Salary &nbsp; &nbsp; 
                                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        Name</td>
                                    <td style="width: 16%">
                                        <asp:Label ID="Lname" runat="server" Width="98%" ForeColor="#0000C0"></asp:Label></td>
                                    <td style="width: 16%">
                                        Post</td>
                                    <td style="width: 16%">
                                        <asp:Label ID="LPost" runat="server" Width="98%" ForeColor="#0000C0"></asp:Label></td>
                                        <td style="width: 16%">
                                            Palce Of Posting</td>
                                        <td style="width: 16%">
                                            <asp:Label ID="LPalce" runat="server" Width="98%" ForeColor="#0000C0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        District</td>
                                    <td style="width: 16%">
                                        <asp:Label ID="LDist" runat="server" Width="98%" ForeColor="#0000C0"></asp:Label></td>
                                    <td style="width: 16%">
                                        DDO Office</td>
                                    <td style="width: 16%">
                                        <asp:TextBox ID="T11" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                        <td style="width: 16%">
                                        Section/Unit</td>
                                        <td style="width: 16%">
                                        <asp:DropDownList ID="DUnit" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        Employee Type</td>
                                    <td style="width: 16%">
                                        <asp:DropDownList ID="DEmpt" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                    <td style="width: 16%">
                                        Pay Scale</td>
                                    <td style="width: 16%">
                                        <asp:DropDownList ID="DPays" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                        <td style="width: 16%">
                                        Head</td>
                                        <td style="width: 16%">
                                            <asp:DropDownList ID="Dpayh" runat="server" Width="99%">
                                            </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        GPF &nbsp;No</td>
                                    <td style="width: 16%">
                                        <asp:TextBox ID="T1" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%">
                                        GPF Nominee</td>
                                    <td style="width: 16%">
                                        <asp:TextBox ID="T2" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%">
                                        GPF Contribution</td>
                                        <td style="width: 16%">
                                            <asp:DropDownList ID="DGpfc" runat="server" Width="99%">
                                                <asp:ListItem Value="1">Continue</asp:ListItem>
                                                <asp:ListItem Value="2">Stop</asp:ListItem>
                                            </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Increment Status</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DIncs" runat="server" Width="99%">
                                            <asp:ListItem Value="1">Continue</asp:ListItem>
                                            <asp:ListItem Value="2">Stop</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width: 16%; height: 21px">
                                        Date Of Increment</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T3" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Increment due on
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T4" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Pli. No.</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T5" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Mode Of Payment</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DPaymode" runat="server" Width="99%">
                                            <asp:ListItem Value="1">Cheque</asp:ListItem>
                                            <asp:ListItem Value="2">Cash</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width: 16%; height: 21px">
                                        Bank Name</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DBank" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Bank Acc. No.
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T6" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Attendance</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T7" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Suspend %</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DSuspend" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Suspenion Period in Days</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T8" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Temporarily Stop The Pay
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DropDownList9" runat="server" Width="99%">
                                            <asp:ListItem Value="2">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width: 16%; height: 21px">
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="Doff" runat="server" Width="99%" Visible="False">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="font-weight: bold; width: 100%; color: maroon; background-color: burlywood;
                                        text-align: center">
                                        EARNINGS</td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Basic Pay</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T9" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        N.P.A.</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DNPA" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                    <td style="width: 16%; height: 21px">
                                        Dearness &nbsp;Pay</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="T10" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        D.A.Code<br />
                                    </td>
                                    <td style="width: 16%; height: 21px"><asp:DropDownList ID="DDAcode" runat="server" Width="99%">
                                    </asp:DropDownList></td>
                                    <td style="width: 16%; height: 21px">
                                        H.R.A.</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T12" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        CCA</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T13" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Personal Pay</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T14" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        TP.A.</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T15" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Special Pay</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T16" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="font-weight: bold; width: 100%; color: maroon; background-color: burlywood;
                                        text-align: center">
                                    NORMAL-DEDUCTION</td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        GPF Contribution</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T17" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        H.R.A.</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T18" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        G.I.S. I.F.</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T19" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        G.I.S. S.F.</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T20" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Income Tax</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T21" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Govt. Veh. Rent
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T22" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Salary Deduction</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="T23" runat="server" MaxLength="6" Width="94%"></asp:TextBox></td>
                                    <td colspan="4" style="height: 21px; text-align: center">
                                        For More Advance/Loan Entry Click here
                                        <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Maroon" PostBackUrl="~/payrole/ADVLOANENTRY.aspx">Other Entry</asp:LinkButton>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="width: 100%; background-color: burlywood; text-align: center">
                                        <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click1" /><asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
                                    <asp:Label ID="ME" runat="server"></asp:Label>
                                    <asp:Label ID="MD" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                    
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
