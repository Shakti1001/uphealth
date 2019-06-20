<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="ADVLOANENTRY.aspx.cs" Inherits="NewWebApp.payrole.ADVLOANENTRY" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
    // <!CDATA[

    function TABLE1_onclick() {

    }

    // ]]>
</script>

    <div class="container" style="text-align: center">
        <table class="table table-responsive-sm table-active" border="0" cellpadding="0" cellspacing="0" style="width: 98%">
            <tr>
                <td style="width: 100%; height: 1px; text-align: right">
                    <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                        onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </td>
            </tr>
            <tr>
                <td style="font-weight: bold; font-size: 14px; width: 100%; color: #ffff99; height: 20px;
                    background-color: #661700">
                    Optional 
                </td>
            </tr>
            <tr>
                <td style="width: 100%" valign="top">
                    <table class="table table-responsive-sm" style="width: 100%; background-color: #fff8dc; font-weight: bold; font-size: 14px; color: maroon;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4" style="font-weight: bold; width: 100%; color: maroon; height: 25px;
                                background-color: burlywood" valign="top">
                                <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                    <tr>
                                        <td style="width: 50%">
                                            Seniority Number:<asp:Label ID="sen" runat="server" ForeColor="#C00000" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                                        <td style="width: 50%">
                    Name :<asp:Label ID="name" runat="server"
                        ForeColor="#C00000" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width: 100%; height: 20px; text-align: center">
                                <asp:RadioButton ID="OptEar" runat="server" Text="Optional Earning" AutoPostBack="True" OnCheckedChanged="OptEar_CheckedChanged" />
                                <asp:RadioButton ID="Optded" runat="server" Text="Optional Deduction" AutoPostBack="True" OnCheckedChanged="Optded_CheckedChanged" /></td>
                        </tr>
        <tr>
            <td colspan="4" style="width: 100%; text-align: center; height: 20px;">
                </td>
        </tr>
                        <tr>
                            <td colspan="4" style="width: 100%; text-align: center">
                             <asp:Panel ID="PanelER" runat="server" Width="100%" Visible="False">
                                 <div style="text-align: center">
                                     <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                         <tr>
                                             <td colspan="4" style="width: 100%; background-color: burlywood">
                                                 Earning</td>
                                         </tr>
                                         <tr>
                                             <td colspan="4" style="width: 100%; height: 25px;">
                                                 Select Allowns :<asp:DropDownList ID="ErD" runat="server" Width="144px">
                                                 </asp:DropDownList></td>
                                         </tr>
                                         <tr>
                                             <td colspan="2" style="width: 50%; height: 25px; text-align: center;">
                                                 Amount&nbsp;
                                             </td>
                                             <td colspan="2" style="width: 50%; height: 25px; text-align: center;">
                                                 <asp:TextBox ID="Eramt" runat="server"></asp:TextBox></td>
                                         </tr>
                                         <tr>
                                             <td colspan="2" style="width: 50%; height: 25px;">
                                             </td>
                                             <td colspan="2" style="width: 50%; height: 25px;">
                                                 &nbsp;<asp:Button ID="saveear" class="btn btn-success" runat="server" Text="Save Earning" OnClick="saveear_Click" /></td>
                                         </tr>
                                         <tr>
                                             <td colspan="4" style="width: 100%">
                                                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                     DataKeyNames="earoptid" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
                                                     Width="75%">
                                                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                     <Columns>
                                                         <asp:BoundField DataField="optearname" HeaderText="optearname" SortExpression="optearname" />
                                                         <asp:BoundField DataField="optearamt" HeaderText="optearamt" SortExpression="optearamt" />
                                                         <asp:CommandField ShowDeleteButton="True" />
                                                     </Columns>
                                                     <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                     <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                     <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                     <AlternatingRowStyle BackColor="White" />
                                                 </asp:GridView>
                                             
                                                 &nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
                                                     SelectCommand="SELECT pay_opt_earning.earoptid ,pay_optearmast.optearname, pay_opt_earning.optearamt FROM pay_opt_earning INNER JOIN pay_optearmast ON pay_opt_earning.optearid = pay_optearmast.optearid WHERE (pay_opt_earning.idno = @idno)" DeleteCommand="DELETE FROM pay_opt_earning WHERE (earoptid = @earoptid)">
                                                     <SelectParameters>
                                                         <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                                                     </SelectParameters>
                                                     <DeleteParameters>
                                                         <asp:ControlParameter ControlID="GridView2" Name="earoptid" PropertyName="SelectedValue" />
                                                     </DeleteParameters>
                                                 </asp:SqlDataSource>
                                             </td>
                                         </tr>
                                     </table>
                                 </div>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width: 100%; text-align: center">
                                <asp:Panel ID="Panelded" runat="server" Width="100%" Visible="False">
                                        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                            <tr>
                                                <td colspan="7" style="width: 100%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" style="width: 100%; background-color: burlywood; height: 17px;">
                                                    Deductions</td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" style="width: 100%;" rowspan="2">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<table
                                                        style="width: 766px">
                                                        <tr>
                                                            <td style="width: 73px">
                                                            </td>
                                                            <td style="width: 135px">
                                                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;</td>
                                                            <td style="width: 100px">
                                                            </td>
                                                            <td style="width: 284px">
                                                            </td>
                                                            <td style="width: 311px">
                                                            </td>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 24px">
                                                    &nbsp;Loan /Advance Type</td>
                                                            <td style="width: 100px; height: 24px">
                <asp:DropDownList ID="DLoan" runat="server" Width="135%">
                                   </asp:DropDownList></td>
                                                            <td style="width: 284px; height: 24px; text-align: left">
                                                                &nbsp; &nbsp; &nbsp;
                                                    &nbsp;Date Of Sanction &nbsp; &nbsp;</td>
                                                            <td style="width: 311px; height: 24px; text-align: left">
                                                                <asp:DropDownList ID="datedrp" runat="server" Width="28%">
                                                                </asp:DropDownList><asp:DropDownList ID="mondrp" runat="server" OnSelectedIndexChanged="DdlMonth_SelectedIndexChanged">
                                                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                                                    <asp:ListItem Value="05">May</asp:ListItem>
                                                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                                                    <asp:ListItem Value="09">Sep</asp:ListItem>
                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                </asp:DropDownList><asp:DropDownList ID="yeardrp" runat="server" Width="60px">
                                                                </asp:DropDownList></td>
                                                            <td style="width: 100px; height: 24px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                    Loan/Advance Amount</td>
                                                            <td style="width: 100px">
                <asp:TextBox ID="LamtT" runat="server" Width="127%" ></asp:TextBox></td>
                                                            <td style="width: 284px; text-align: justify">
                                                                &nbsp; &nbsp; &nbsp;
                                                    &nbsp;
                                                    No. Of Installments &nbsp; &nbsp; &nbsp; &nbsp;</td>
                                                            <td style="width: 311px; text-align: left">
                                                                <asp:TextBox ID="TInst" runat="server" Width="77%"></asp:TextBox></td>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                EMI Amount</td>
                                                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="insttext" runat="server" Width="130px"></asp:TextBox></td>
                                                            <td style="width: 284px; text-align: justify">
                                                                &nbsp; &nbsp; &nbsp;
                No Of &nbsp;Installments Paid&nbsp;</td>
                                                            <td style="width: 311px; text-align: left">
                                                    <asp:TextBox ID="InstpaidT" runat="server" Width="77%"></asp:TextBox></td>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                Amount Left from EMI</td>
                                                            <td style="width: 100px; text-align: left">
                                                    <asp:TextBox ID="adamt" runat="server" Width="129px"></asp:TextBox></td>
                                                            <td style="width: 284px; text-align: right">
                                                    &nbsp;Left amount Deducted with&nbsp;</td>
                                                            <td style="width: 311px; text-align: left">
                                                                &nbsp;<asp:DropDownList ID="dedwithDrp" runat="server">
                                                                    <asp:ListItem Value="F">First EMI</asp:ListItem>
                                                                    <asp:ListItem Value="L">Last EMI</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                <asp:DropDownList ID="DropDownList4" runat="server" Width="96%" Visible="False">
                    <asp:ListItem>In installment</asp:ListItem>
                </asp:DropDownList></td>
                                                            <td style="width: 100px">
                                                            </td>
                                                            <td colspan="2">
                                                    </td>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp;<table class="table table-responsive-sm"
                                                        style="width: 766px">
                                                        <tr>
                                                            <td style="width: 135px">
                                                                &nbsp;</td>
                                                            <td style="width: 100px">
                                                            </td>
                                                            <td style="width: 284px; text-align: right;">
                                                    <asp:Button ID="saveded" class="btn btn-success" runat="server"  Text="Save Deduction" OnClick="saveded_Click" /></td>
                                                            <td style="width: 311px; text-align: left;">
                                                            </td>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 27px">
                                                </td>
                                                <td style="width: 25%; height: 27px">
                                                </td>
                                                <td style="width: 25%; height: 27px;">
                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 24px;" colspan="7">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" style="width: 100%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="lid"
                    DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="75%" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        
                        <asp:BoundField DataField="litemname2" HeaderText="LoanItem" SortExpression="litemname2" />
                        <asp:BoundField DataField="TLrate" HeaderText="TotalRate" SortExpression="TLrate" />
                        <asp:BoundField DataField="linst" HeaderText="Installment" SortExpression="linst" />
                        <asp:BoundField DataField="ldatesactioned" HeaderText="SactionedDate" ReadOnly="True"
                            SortExpression="ldatesactioned" />
                        <asp:BoundField DataField="nlinstpaid" HeaderText="Installmentpaid" SortExpression="nlinstpaid" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:ButtonField CommandName="Select" Text="Edit" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>"
                    DeleteCommand="DELETE FROM pay_loan_entry WHERE (lid = @lid)" SelectCommand="SELECT pay_loan_entry.lid, pay_optloan.litemname2, pay_loan_entry.TLrate, pay_loan_entry.linst, pay_loan_entry.ldatesactioned AS ldatesactioned, pay_loan_entry.nlinstpaid FROM pay_optloan INNER JOIN pay_loan_entry ON pay_optloan.litemid = pay_loan_entry.litemid INNER JOIN Pay_sal_mast ON pay_loan_entry.idno = Pay_sal_mast.idno WHERE (pay_loan_entry.idno = @idno)">
                    <DeleteParameters>
                        <asp:ControlParameter ControlID="GridView1" Name="lid" PropertyName="SelectedValue" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter Name="idno" QueryStringField="idno" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                </asp:Panel>
                            </td>
                        </tr>
    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; color: #661700; background-color: #661700" valign="top">
                .<asp:Label ID="ME" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
