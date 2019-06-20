<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="dash.aspx.cs" Inherits="NewWebApp.Proforma2.dash" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%-- <script type="text/javascript" language="javascript" src="../js/dashboard.js"></script>--%>
    
      <div class="container">
        
            <div >
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                 <asp:Panel ID="Panel6" runat="server"  Width="99%">
                <div >
                <div class="col-sm-12 text-right">
                    <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                        onclick="LinkButton1_Click1"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton></div><br />
                <table class="table table-responsive-sm table-active" align="center" >
                    <tr>
                        <td style="width: 40%" align="center">
                            <table class="table table-responsive-sm" align="center" border="0" cellpadding="1" cellspacing="1" 
                                style="color: #FFFFFF" width="75%" bgcolor="#007CA6">
                                <tr>
                                    <td align="center">
                                        Division:
                                        <br />
                                        <asp:DropDownList ID="ddl_div" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddl_div_SelectedIndexChanged" Width="110px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        District:<br /><asp:DropDownList ID="ddl_dist" runat="server" 
                                            AutoPostBack="True" onselectedindexchanged="ddl_dist_SelectedIndexChanged" 
                                            Width="110px">
                                        </asp:DropDownList>
                                    </td>
                                    <%--<td valign="middle">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                            AssociatedUpdatePanelID="UpdatePanel1">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image2" runat="server" CssClass="style4" Height="33px" 
                                                    ImageUrl="~/images/page-loader.gif" Width="37px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>--%>
                                    <td align="center">
                                        Facility:
                                        <br />
                                        <asp:DropDownList ID="ddl_Facility" runat="server" AutoPostBack="false" 
                                            onselectedindexchanged="ddl_Facility_SelectedIndexChanged1" Width="110px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lbl_type" runat="server" CssClass="style4" Text=""></asp:Label>
                                        <b>
                                        <asp:Label ID="lbl_FRU_Type" runat="server" CssClass="style5" Text=""></asp:Label>
                                        <asp:Label ID="lbl_msg" runat="server" CssClass="style5" style="color: #FF0000" 
                                            Text=""></asp:Label>
                                        </b>
                                    </td>
                                    <td align="center">
                                        Month:<br />
                                        <asp:DropDownList ID="ddl_month" runat="server" CssClass="style6" AutoPostBack="false" Width="75px">
                                            <asp:ListItem Value="1">January</asp:ListItem>
                                            <asp:ListItem Value="2">February</asp:ListItem>
                                            <asp:ListItem Value="3">March</asp:ListItem>
                                            <asp:ListItem Value="4">April</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">June</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">August</asp:ListItem>
                                            <asp:ListItem Value="9">September</asp:ListItem>
                                            <asp:ListItem Value="10">October</asp:ListItem>
                                            <asp:ListItem Value="11">November</asp:ListItem>
                                            <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        Year:<br />
                                        <asp:DropDownList ID="ddl_year" runat="server" AutoPostBack="false"   >
                                            <asp:ListItem Value="2013-2014" >2013-2014</asp:ListItem>
                                            <asp:ListItem Value="2014-2015">2014-2015</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center" valign="middle">
                                        <asp:Button class="btn btn-success" ID="Button1" runat="server" BorderColor="Red" 
                                            onclick="Button1_Click" Text="Submit" />
                                        <br />
                                        <asp:Label ID="lbl_month" runat="server" CssClass="style4" 
                                            style="color: #FFFF99; font-weight: 700;" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                   
                    <tr>
                        <td style="width: 42%">
                            <asp:Panel ID="mainpnl" runat="server" BackColor="White">
                                <table class="table table-responsive-sm" class="style2" width="100%">
                                    <tr>
                                        <td width="20%" valign="top">
                                            <asp:Panel ID="Panel1" runat="server" BackColor="#82C0FF" width="99%">
                                <table class="table table-responsive-sm" align="center" cellpadding="0" cellspacing="1" width="99%" 
                                                    style="border: 1px solid #000000; color: #000066;" border="1">
                                        <tr>
                                            <td align="center" colspan="2" 
                                                style="font-family: 'Times New Roman', Times, serif; font-size: 14px;
                                                 border: thin solid #000000">
                                                <strong style="text-align: center">Doctors</strong><asp:Label ID="lbl_counter" runat="server" 
                                                    style="color: #CC3300; font-weight: 700" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  width="50%"
                                                style="font-family: 'Times New Roman', Times, serif; font-size: 14px; 
                                             border: thin solid #000000; text-align: left;" class="style13">
                                                Sanctioned</td>
                                            <td align="center"  style="border: thin solid #000000;" 
                                                width="50%">
                                                <asp:Label ID="lbl_total_Sanc" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: thin solid #000000; text-align: left;" class="style13">
                                                Posted<asp:LinkButton ID="lnk_view" runat="server" onclick="lnk_view_Click1" 
                                                    style="text-decoration: none; font-weight: 700;" ToolTip="Link to NIC PIS" 
                                                    Visible="False"> View </asp:LinkButton>
                                            </td>
                                            <td align="center" style="border: thin solid #000000">
                                                &nbsp;<asp:LinkButton ID="lbl_posted" runat="server" onclick="lbl_posted_Click"></asp:LinkButton>
                                                <asp:Image ID="img_alert_dr" runat="server" Height="16px" 
                                                    ImageUrl="~/Images/alert.gif" Width="16px" />
                                            </td>
                                        </tr>
                                    </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel1_RoundedCornersExtender" runat="server" 
                                                BorderColor="#0079FF" Enabled="True" Radius="15" TargetControlID="Panel1" 
                                                Corners="Top">
                                            </cc1:RoundedCornersExtender>
                                            <asp:Panel ID="Panel7" runat="server" BackColor="#82C0FF" Width="100%">
                                                <table class="table table-responsive-sm" cellspacing="1" style="width: 100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <span class="style17"><strong style="text-align: center">Performance</strong></span>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left; font-size: 11pt;">
                                                            OPD New</td>
                                                        <td style="border: thin solid #000000">
                                                            
                                                            <asp:Label ID="lbl_OPD" runat="server" CssClass="style12" 
                                                                style="font-size: 11pt"></asp:Label>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left; font-size: 11pt;">
                                                            OPD Old</td>
                                                        <td style="border: thin solid #000000">
                                                            
                                                            <asp:Label ID="lbl_OPD_old" runat="server" CssClass="style12" 
                                                                style="font-size: 11pt"></asp:Label>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left; font-size: 11pt;">
                                                            IPD</td>
                                                        <td style="border: thin solid #000000; margin-left: 40px;">
                                                            
                                                            <asp:Label ID="lbl_IPD" runat="server" CssClass="style12" 
                                                                style="font-size: 11pt"></asp:Label>
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br style="font-size: 2pt" />
                                            </asp:Panel>
                                                                                                                                
                                            <cc1:RoundedCornersExtender ID="Panel7_RoundedCornersExtender" runat="server" 
                                                Corners="Bottom" Enabled="True" Radius="15" TargetControlID="Panel7">
                                            </cc1:RoundedCornersExtender>
                                                                                                                                
                                           <div style="height: 5px; width:100%">
                                            </div>
                                            
                                            <asp:Panel ID="Panel8" runat="server" BackColor="#82C0FF" Width="100%" >
                                                <table class="table table-responsive-sm" border="1" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td colspan="2" 
                                                            style="border: thin solid #000000; text-align: center; color: #000000;">
                                                            <strong style="text-align: center">Surgeon</strong></td>
                                                    </tr>
                                                    <tr class="style15">
                                                        <td style="border: thin solid #000000; text-align: left;" width="65%" 
                                                            class="style25">
                                                            Sanctioned</td>
                                                        <td style="border: thin solid #000000" width="40%" class="style25">
                                                            <asp:Label ID="lbl_sur_sanc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="65%">
                                                            <span class="style24">Posted </span>
                                                            <asp:LinkButton ID="surgeon" runat="server" onclick="surgeon_Click1" 
                                                                style="text-decoration: none" ToolTip="click to View all" 
                                                                CssClass="style23" Visible="False"> View </asp:LinkButton>
                                                        </td>
                                                        <td style="border: thin solid #000000" width="40%" class="style24">
                                                            <asp:LinkButton ID="lbl_sur_posted" runat="server" 
                                                                onclick="lbl_sur_posted_Click"></asp:LinkButton>
                                                            <asp:Image ID="img_alert_Surg" runat="server" Height="16px" 
                                                                ImageUrl="~/Images/alert.gif" Width="16px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" 
                                                            style="border: thin solid #000000; text-align: center;
                                                             color: #000000;" width="60%">
                                                            <strong style="text-align: center">Anaesthetist</strong></td>
                                                    </tr>
                                                    <tr class="style15">
                                                        <td style="border: thin solid #000000; text-align: left;" width="65%" 
                                                            class="style25">
                                                            Sanctioned</td>
                                                        <td style="border: thin solid #000000" width="40%" class="style25">
                                                            <asp:Label ID="lbl_anae_sanc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="65%" 
                                                            class="style25">
                                                            <span class="style24">Posted </span>
                                                            <asp:LinkButton ID="anaes" runat="server" CssClass="style23" 
                                                                onclick="anaes_Click" style="text-decoration: none" 
                                                                ToolTip="click to View all" Visible="False"> View </asp:LinkButton>
                                                        </td>
                                                        <td class="style24" style="border: thin solid #000000" width="40%">
                                                            <asp:LinkButton ID="lbl_anas_posted" runat="server" 
                                                                onclick="lbl_anas_posted_Click"></asp:LinkButton>
                                                            <asp:Image ID="img_alert_anae" runat="server" Height="16px" 
                                                                ImageUrl="~/Images/alert.gif" Width="16px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel8_RoundedCornersExtender" runat="server" 
                                               Corners="Top" Enabled="True" Radius="15" TargetControlID="Panel8">
                                            </cc1:RoundedCornersExtender>
                                            <asp:Panel ID="Panel9" runat="server" BackColor="#6AC0FF" Width="100%">
                                                <table class="table table-responsive-sm" class="style19" width="100%">
                                                    
                                                    <tr class="style18">
                                                        <td style="border: thin solid #000000" class="style31" colspan="2">
                                                            <span class="style30"><strong style="text-align: center">Performance</strong></span><span 
                                                                class="style25"> </span></td>
                                                    </tr>
                                                    <tr class="style18">
                                                        <td class="style31" style="border: thin solid #000000; text-align: left;">
                                                            <span class="style25">Major Surgery</span></td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_major" runat="server" CssClass="style28" Text=""></asp:Label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td style="border: thin solid #000000; text-align: left;" class="style32">
                                                            Minor Surgery</td>
                                                        <td style="border: thin solid #000000" class="style28">
                                                            <asp:Label ID="lbl_minor" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td style="border: thin solid #000000; text-align: left;" class="style32">
                                                            Operation Theaters</td>
                                                        <td style="border: thin solid #000000" class="style28">
                                                            <asp:Label ID="lbl_OT" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel9_RoundedCornersExtender" runat="server" 
                                                Corners="Bottom" Enabled="True" Radius="15" TargetControlID="Panel9">
                                            </cc1:RoundedCornersExtender>
                                            <br />
                                            <asp:Label ID="lbl_Beds" runat="server" CssClass="style12" 
                                                style="font-size: 11pt" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style33" valign="top" width="60%" align="center">
                                            <asp:Panel ID="Panel14" runat="server" Height="158px" BackColor="#9BEBFF">
                                                <asp:Panel ID="Panel2" runat="server" BackColor="#81E2F3" 
                                                    style="text-align: left" width="99%">
                                                    <table class="table table-responsive-sm" cellpadding="2" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="Panel16" runat="server" Width="100%">
                                                                    <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" class="style19" width="100%">
                                                                        <tr>
                                                                            <td align="center" colspan="3" 
                                                                                style="border: thin solid #000000; color: #000000;">
                                                                                <strong style="text-align: center">Pathologist</strong></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: thin solid #000000; color: #000000;">
                                                                                Sanctioned</td>
                                                                            <td align="center" style="border: thin solid #000000; color: #000000;">
                                                                                <span class="style24">Posted
                                                                                <asp:LinkButton ID="patho" runat="server" ForeColor="#CA0000" 
                                                                                    onclick="patho_Click" ToolTip="click to View all" Visible="False"> View </asp:LinkButton>
                                                                                </span>
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; color: #000000;">
                                                                                Lab Tests</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: thin solid #000000; color: #000000;">
                                                                                <span class="style24">
                                                                                <asp:Label ID="lbl_Patho_sanc0" runat="server" ForeColor="Black"></asp:Label>
                                                                                </span>
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; color: #000000;">
                                                                                <asp:LinkButton ID="lbl_Patho_posted" runat="server" 
                                                                                    onclick="lbl_Patho_posted_Click"></asp:LinkButton>
                                                                                <asp:Image ID="img_alert_path" runat="server" Height="16px" 
                                                                                    ImageUrl="~/Images/alert.gif" Width="16px" />
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; color: #000000;">
                                                                                <asp:Label ID="lbl_lab_test" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                                                    Corners="Top" Enabled="True" Radius="15" TargetControlID="Panel16">
                                                                </cc1:RoundedCornersExtender>
                                                            </td>
                                                            <td>
                                                                <asp:Panel ID="pnl_budget" runat="server" Width="100%">
                                                                    <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" class="style19" style="width: 100%;">
                                                                        <tr>
                                                                            <td style="border: thin solid #000000">
                                                                                <strong>Equipments</strong></td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                Generator</td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                Ambulance</td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                Blood Bank</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: thin solid #000000">
                                                                                Total</td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                <asp:Label ID="lbl_generator" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                <asp:Label ID="lbl_ambulances" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                <asp:Label ID="lbl_Bloodbnk" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: thin solid #000000">
                                                                                Functional</td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                <asp:Label ID="lbl_generator0" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                <asp:Label ID="lbl_ambulances0" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                            <td align="center" style="border: thin solid #000000; ">
                                                                                <asp:Label ID="lbl_Bloodbnk0" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" 
                                                                    Corners="Top" Enabled="True" Radius="15" TargetControlID="pnl_budget">
                                                                </cc1:RoundedCornersExtender>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table class="table table-responsive-sm" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                    <tr>
                                                                        <td align="center" colspan="3" style="border: thin solid #000000;">
                                                                            <strong>Drugs/Medicines</strong></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" style="border: thin solid #000000">
                                                                            No.of Indents for Rate Contract</td>
                                                                        <td align="center" rowspan="2" style="border: thin solid #000000">
                                                                            No.of indents for local purchase</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style="border: thin solid #000000">
                                                                            Raised</td>
                                                                        <td align="center" style="border: thin solid #000000">
                                                                            Pending for Delivery</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style="border: thin solid #000000">
                                                                            <asp:Label ID="lblMed_raised" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center" style="border: thin solid #000000">
                                                                            <asp:Label ID="lblMed_pend" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center" style="border: thin solid #000000">
                                                                            <asp:Label ID="lblMed_local" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;<asp:Panel ID="Panel15" runat="server" Width="100%">
                                                        <asp:Label ID="lblMPR_msg" runat="server" style="color: #FF0000" Text=""></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="grdall" runat="server" onrowdatabound="grdall_RowDataBound" 
                                                            Width="98%">
                                                            <AlternatingRowStyle BackColor="#BFFFE6" />
                                                            <Columns>
                                                                <asp:CommandField ShowSelectButton="True" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#333333" ForeColor="White" />
                                                            <SelectedRowStyle BackColor="#FFB3D9" />
                                                        </asp:GridView>
                                                        <br />
                                                        <asp:GridView ID="grd_dtls" runat="server" Visible="False" Width="75%">
                                                            <AlternatingRowStyle BackColor="#FDACAA" />
                                                            <HeaderStyle BackColor="Maroon" ForeColor="White" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </asp:Panel>
                                                <cc1:RoundedCornersExtender ID="Panel2_RoundedCornersExtender" runat="server" 
                                                    BorderColor="Red" Enabled="True" Radius="15" TargetControlID="Panel2">
                                                </cc1:RoundedCornersExtender>
                                            </asp:Panel>
                                            <br />
                                        </td>
                                        <td width="20%" valign="top">
                                            <asp:Panel ID="Panel10" runat="server" BackColor="#82C0FF" width="99%">
                                                <table class="table table-responsive-sm" align="center" border="1" cellpadding="0" cellspacing="1" 
                                                    style="border: 1px solid #000000; color: #000066;" width="99%">
                                                    <tr>
                                                        <td align="center" colspan="2" 
                                                            style="font-family: 'Times New Roman', Times, serif; border: thin solid #000000" 
                                                            class="style25">
                                                            <strong>Gynaecologist</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style13" style="font-family: 'Times New Roman', Times, serif; font-size: 14px; 
                                             border: thin solid #000000; text-align: left;" width="50%">
                                                            Sanctioned</td>
                                                        <td style="border: thin solid #000000;" width="50%">
                                                            <asp:Label ID="lbl_Gy_sanc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style13" style="border: thin solid #000000; text-align: left;">
                                                            Posted<asp:LinkButton ID="gyna" runat="server" onclick="LinkButton2_Click" 
                                                                style="text-decoration: none" ToolTip="click to View all" Visible="False"> View </asp:LinkButton>
                                                        </td>
                                                        <td style="border: thin solid #000000" valign="top">
                                                            <asp:LinkButton ID="lbl_Gyn_posted" runat="server" 
                                                                onclick="lbl_Gyn_posted_Click"></asp:LinkButton>
                                                            <asp:Image ID="img_alert_Gy" runat="server" Height="16px" 
                                                                ImageUrl="~/Images/alert.gif" Width="16px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel10_RoundedCornersExtender" runat="server" 
                                                BorderColor="#0079FF" Corners="Top" Enabled="True" Radius="15" 
                                                TargetControlID="Panel10">
                                            </cc1:RoundedCornersExtender>
                                            <asp:Panel ID="Panel11" runat="server" BackColor="#82C0FF" Width="100%">
                                                <table class="table table-responsive-sm" cellspacing="1" style="width: 100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <span class="style17"><strong style="text-align: center">Performance</strong></span>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="70%">
                                                            Normal Delivery</td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_normal" runat="server" CssClass="style37" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="70%">
                                                            Cesarean Delivery</td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_Ceser" runat="server" CssClass="style37" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="70%">
                                                            Female Sterlization</td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_female_ster" runat="server" CssClass="style37" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="70%">
                                                            MTP</td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_MTP" runat="server" CssClass="style37" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="70%">
                                                            Maternal Death</td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_mater_death" runat="server" CssClass="style37" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel11_RoundedCornersExtender" runat="server" 
                                                Corners="Bottom" Enabled="True" Radius="15" TargetControlID="Panel11">
                                            </cc1:RoundedCornersExtender>
                                            <div style="height: 5px; width:100%">
                                            </div>
                                            <asp:Panel ID="Panel12" runat="server" BackColor="#82C0FF" Width="100%">
                                                <table class="table table-responsive-sm" border="1" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td colspan="2" class="style42" >
                                                            <strong style="text-align: center">Radiologist</strong></td>
                                                    </tr>
                                                    <tr class="style15">
                                                        <td class="style25" style="border: thin solid #000000; text-align: left;" 
                                                            width="65%">
                                                            Sanctioned</td>
                                                        <td class="style25" style="border: thin solid #000000" width="40%">
                                                            <asp:Label ID="lbl_Rad_sanc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: thin solid #000000; text-align: left;" width="65%">
                                                            <span class="style24">Posted
                                                            <asp:LinkButton ID="radio" runat="server" onclick="radio_Click" 
                                                                style="text-decoration: none" ToolTip="click to View all" Visible="False"> View </asp:LinkButton>
                                                            </span>
                                                        </td>
                                                        <td class="style24" style="border: thin solid #000000" width="40%">
                                                            <asp:LinkButton ID="lbl_Rad_posted" runat="server" 
                                                                onclick="lbl_Rad_posted_Click"></asp:LinkButton>
                                                            <asp:Image ID="img_alert_Radio" runat="server" Height="16px" 
                                                                ImageUrl="~/Images/alert.gif" Width="16px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel12_RoundedCornersExtender" runat="server" 
                                                Corners="Top" Enabled="True" Radius="15" TargetControlID="Panel12">
                                            </cc1:RoundedCornersExtender>
                                            <asp:Panel ID="Panel13" runat="server" BackColor="#82C0FF" Width="100%">
                                                <table class="table table-responsive-sm" class="style19" width="100%">
                                                    <tr class="style18">
                                                        <td class="auto-style1" style="border: thin solid #000000" colspan="2">
                                                            <span class="style17"><strong style="text-align: center">Performance</strong></span>&nbsp;</td>
                                                    </tr>
                                                    <tr class="style18">
                                                        <td class="auto-style1" style="border: thin solid #000000; text-align: left;">
                                                            X-Rays Machine</td>
                                                        <td style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_Xray_Mc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td class="auto-style2" style="border: thin solid #000000; text-align: left;">
                                                            X-Rays</td>
                                                        <td class="style28" style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_Xrays" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td class="auto-style2" style="border: thin solid #000000; text-align: left;">
                                                            USG Machine</td>
                                                        <td class="style28" style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_USGMc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td class="auto-style2" style="border: thin solid #000000; text-align: left;">
                                                            USG</td>
                                                        <td class="style28" style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_USG" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td class="auto-style2" style="border: thin solid #000000; text-align: left;">
                                                            CT Machine</td>
                                                        <td class="style28" style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_CTMc" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="style26">
                                                        <td class="auto-style2" style="border: thin solid #000000; text-align: left;">
                                                            CT Scans</td>
                                                        <td class="style28" style="border: thin solid #000000">
                                                            <asp:Label ID="lbl_CT_Scans" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="Panel13_RoundedCornersExtender" runat="server" 
                                                Corners="Bottom" Enabled="True" Radius="15" TargetControlID="Panel13">
                                            </cc1:RoundedCornersExtender>

                                            <br />

                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                </div>           
                 </asp:Panel>
                <br />
              </div>
              
      </div>
</asp:Content>
