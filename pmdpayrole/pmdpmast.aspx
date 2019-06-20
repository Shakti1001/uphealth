<%@ Page Title="::Edit Salary Detail::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="pmdpmast.aspx.cs" Inherits="NewWebApp.pmdpayrole.pmdpmast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<div class="container" style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 0px; background-color: #661700; text-align: left; font-weight: bold; font-size: 14px; color: #ffff99;"
                        valign="top">
                        Pay Details Of&nbsp; A Employer
                        <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label><asp:Label ID="Uidt"
                            runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:Label ID="Label4" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top">
                        <div style="text-align: center">
                            <table class="table table-responsive-sm" style="width: 100%; background-color: #fff8dc; font-weight: bold; font-size: 14px; color: maroon; text-align: left;">
                                <tr>
                                    <td colspan="6" style="font-weight: bold;
                                        color: maroon; width: 100%; background-color: burlywood; text-align: center;">
                                        &nbsp; &nbsp;
                                        Basic&nbsp; Salary Detail &nbsp; &nbsp; 
                                        <asp:Label ID="ddoid" runat="server" Visible="False"></asp:Label>
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
                                        <asp:TextBox ID="DT1" runat="server"  Width="94%"></asp:TextBox></td>
                                        <td style="width: 16%">
                                        Employee Type</td>
                                        <td style="width: 16%">
                                        <asp:DropDownList ID="DEmpt" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        Provident Fund (PF) Type</td>
                                    <td style="width: 16%">
                                        <asp:DropDownList ID="pftype" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                    <td style="width: 16%">
                                        Pay Scale</td>
                                    <td style="width: 16%">
                                        <asp:DropDownList ID="DPays" runat="server" Width="99%">
                                        </asp:DropDownList></td>
                                        <td style="width: 16%">
                                        Head Of Salary</td>
                                        <td style="width: 16%">
                                            <asp:DropDownList ID="Dpayh" runat="server" Width="99%">
                                            </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%">
                                        GPF/NewPen.PlanNo</td>
                                    <td style="width: 16%">
                                        <asp:TextBox ID="GPFT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%">
                                        Bank Name</td>
                                    <td style="width: 16%">
                                        <asp:DropDownList ID="DBank" runat="server" Width="99%" OnSelectedIndexChanged="DBank_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td style="width: 16%">
                                        Bank Acc. No.
                                    </td>
                                        <td style="width: 16%">
                                        <asp:TextBox ID="BANKAT" runat="server"  Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        &nbsp;PAN No.&nbsp;&nbsp;</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="PAN" runat="server" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Stop Salary (in days)</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:DropDownList ID="DIncs" runat="server" Width="99%" >
                                        </asp:DropDownList></td>
                                    <td style="width: 16%; height: 21px">
                                        Remark</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="RMARKT" runat="server"  Width="94%"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="font-weight: bold; width: 100%; color: maroon; background-color: burlywood;
                                        text-align: center">
                                        EARNINGS</td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Basic/Band Pay</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="BPAYT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Grade Pay</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="GradePay" runat="server" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        H.R.A.</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="EHRAT" runat="server"  Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        CCA</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="CCAT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Personal Pay</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="PENST" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Transport Allowance</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="GVTPT" runat="server"  Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Special Pay</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="SPAYT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Pension Pay</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="pensionText" runat="server" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Rural Allowance</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="ruralall" runat="server" Width="94%" Enabled="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        </td>
                                    <td style="width: 16%; height: 21px">
                                        </td>
                                    <td style="width: 16%; height: 21px">
                                        </td>
                                    <td style="width: 16%; height: 21px">
                                        </td>
                                    <td style="width: 16%; height: 21px">
                                        </td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="AttText" runat="server" Width="94%" Visible="False"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="font-weight: bold; width: 100%; color: maroon; background-color: burlywood;
                                        text-align: center">
                                    NORMAL-DEDUCTION</td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        GPF/PRAN Contribution</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="GPFCT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        GPF Contribution (Class-iv)</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="GPFCF" runat="server"  Width="94%" 
                                            ontextchanged="GPFCF_TextChanged"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Income Tax</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="INCOMET" runat="server"  Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        G.I.S. Insurance</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="GIFT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        G.I.S. Saving</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="GSFT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Electric Bill Charge</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="elecbill" runat="server" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        Govt. Veh. Deduction</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="GVRT" runat="server"  Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        OtherSalaryDeduction</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="SDT" runat="server" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Recurring Deposit</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="RD" runat="server" Width="94%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        House Rent Recovery</td>
                                    <td style="width: 16%; height: 21px">
                                        <asp:TextBox ID="HRR" runat="server" Width="94%"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        LIC Deduction</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="lic" runat="server"  Width="94%" ontextchanged="GPFCF_TextChanged"></asp:TextBox></td>
                                    <td style="width: 16%; height: 21px">
                                        Society Deduction</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="socded" runat="server"  Width="94%" 
                                            ontextchanged="GPFCF_TextChanged"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        RD Deduction</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="rdded" runat="server"  Width="94%" 
                                            ontextchanged="GPFCF_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                        PRAN Recovery</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="pranr" runat="server"  Width="94%" 
                                            ontextchanged="GPFCF_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="width: 16%; height: 21px">
                                        Month &amp; Year (Pran Rec)</td>
                                    <td style="width: 16%; height: 21px">
                                    <asp:TextBox ID="monthr" runat="server"  Width="94%" 
                                            ontextchanged="GPFCF_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 16%; height: 21px">
                                        </td>
                                    <td style="width: 16%; height: 21px">
                                    </td>
                                    <td colspan="4" style="height: 21px; text-align: center">
                                        For Optional Earning/Loan Entry &nbsp; &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="Other" runat="server" ForeColor="Maroon" OnClick="Other_Click">Click Here</asp:LinkButton>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="width: 100%; background-color: burlywood; text-align: center">
                                        <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click1" Font-Bold="True" ForeColor="Red" Width="74px" />&nbsp;
                                        <asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="Red" OnClick="Button1_Click"
                                            Text="Enable Page" Width="109px" />&nbsp;<asp:Button ID="Update" runat="server" OnClick="Update_Click1"
                                                Text="Update" Width="111px" Font-Bold="True" ForeColor="Red" />
                                        <asp:Label ID="Label1" runat="server" ForeColor="Black"></asp:Label>
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
