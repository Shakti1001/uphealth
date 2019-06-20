<%@ Page Title="::Add Personal Details::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap2.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript"  src="../js/date-picker.js">     function ImageButton1_onclick() {
     }

</script>
    <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="text-align:center" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>   </td>
               
                </tr>
                <tr>
                    <td style="width: 100%;" valign="top" align="center">
            <table class="table table-responsive-sm" style="font-weight: bold;  font-family: Georgia; height: 100%; border-right: #666666 thin solid; border-top: #666666 thin solid; border-left: #666666 thin solid; color: #661700; border-bottom: #666666 thin solid;" id="TABLE1" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="width:100%; text-align: center; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 10%; border-right-width: thin; border-right-color: #666666; color: #ffffc0; background-color: #661700; font-weight: bold;">
                        (Proforma-1 To Be Filled By Individuals Verified By CMO)</td>
                </tr>
                <tr>
                    <td align="left">
                        Name</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:TextBox ID="Name" runat="server" Width="90%" MaxLength="50" ></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Father/Husband Name</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:TextBox ID="fhname" runat="server" Width="90%" Height="22px" 
                            MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="background-color: #fff8dc;" align="left">
                        Date 
                        Of Birth</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList ID="DB1" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DB2" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DB3" runat="server" Width="30%">
                        </asp:DropDownList></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Gender</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList ID="Dsex" runat="server" Width="92%" Height="21px">
                            <asp:ListItem Value="0">Male</asp:ListItem>
                            <asp:ListItem Value="1">Female</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="left">
                        Caste </td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:DropDownList ID="ddlcaste" runat="server" Width="92%" Height="22px">
                        </asp:DropDownList>
                    </td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Home District</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:DropDownList ID="DhomeD" runat="server" Width="92%" Height="22px" 
                            AutoPostBack="True" OnSelectedIndexChanged="DhomeD_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="background-color: #fff8dc;" align="left">
                        Cadre</td>
                    <td style="background-color: #fff8dc;" align="left">
                        <a
                                                    href="javascript:show_calendar('Content1.Dob');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;">
                        <asp:DropDownList ID="ddlcadre" runat="server"  Width="92%" Height="22px">
                        </asp:DropDownList>
                        </a></td>
                    <td style="background-color: #fff8dc;" align="left">
                        Feeding
                        Cadre</td>
                    <td style="background-color: #fff8dc;" align="left">
                        <asp:DropDownList ID="ddlfcadre" runat="server" Width="92%" Height="22px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 100%; border-top-color: #666666;
                        height: 20px; background-color: moccasin; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:Label ID="OtSL" runat="server" Font-Size="X-Small" ForeColor="Blue" Text="Please enter State then District"
                            Visible="False"></asp:Label>
                        <asp:TextBox ID="Otherstatetext" runat="server" Visible="False" Width="60%" 
                            ontextchanged="Otherstatetext_TextChanged"></asp:TextBox><asp:Button
                            ID="OTSTATESUBMIT" runat="server" OnClick="OTSTATESUBMIT_Click" Text="Save" Visible="False" /></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        GPF No</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        <asp:TextBox ID="Gpfno" runat="server" Width="90%" Height="22px" MaxLength="50"></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666;">
                        Seniority Number</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:TextBox ID="CSN" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Date of Appointment</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <asp:DropDownList ID="DA1" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DA2" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DA3" runat="server" Width="30%">
                        </asp:DropDownList></td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Date 
                        of Joining in Service</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 20px; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        <a
                                                    href="javascript:show_calendar('Content1.doa');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;">
                        <asp:DropDownList ID="DJ1" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DJ2" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DJ3" runat="server" Width="30%">
                        </asp:DropDownList></a></td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        &nbsp;</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        &nbsp;</td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        &nbsp;
                    </td>
                    <td style="width: 25%; text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666; height: 25px; border-right-width: thin; border-right-color: #666666;">
                        <a
                                                    href="javascript:show_calendar('Content1.doc');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;"></a></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Date of Confirmation      </td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        <a
                                                    href="javascript:show_calendar('Content1.dojs');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;">
                        <asp:DropDownList ID="DC1" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DC2" runat="server" Width="30%">
                        </asp:DropDownList><asp:DropDownList ID="DC3" runat="server" Width="30%">
                        </asp:DropDownList></a></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Spouse Comp. Id <asp:Label ID="Label3" runat="server" Font-Size="X-Small" Text="(if in service)"
                            ></asp:Label></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 25px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                                        <asp:TextBox ID="Cgpf" runat="server" Width="90%" MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        Contact Number</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:TextBox ID="txtmobil" runat="server" ontextchanged="txtmobil_TextChanged" 
                            Width="182px"></asp:TextBox>
                    </td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        Disability Category (if any)</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:DropDownList ID="Dsubcat" runat="server" Width="92%" Height="22px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Permanent Address</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        <asp:TextBox ID="padd" runat="server" Width="90%" MaxLength="255" TextMode="MultiLine"></asp:TextBox></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        Local Address</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666; background-color: #fff8dc;">
                        <asp:TextBox ID="ladd" runat="server" Width="90%" MaxLength="255" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        Previous Home District<br />
                        <asp:Label ID="Label6" runat="server" Font-Size="Smaller" ForeColor="Red" Text="If  Home district Is changed"
                            Width="232px"></asp:Label></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        <asp:DropDownList ID="pDhomeD" runat="server" OnSelectedIndexChanged="pDhomeD_SelectedIndexChanged"
                            Width="92%" Height="22px">
                        </asp:DropDownList></td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        &nbsp;</td>
                    <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                        height: 20px; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;
                        height: 20px;width: 100%; text-align: left; border-right-width: thin; border-right-color: #666666; background-color: #fff8dc;">
                        Qualification/Specialization &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:DropDownList ID="Dmqual" runat="server" Width="25%" AutoPostBack="True" OnSelectedIndexChanged="Dmqual_SelectedIndexChanged">
                        </asp:DropDownList>/<asp:DropDownList ID="Dmsub" runat="server" Width="10%" AutoPostBack="True">
                        </asp:DropDownList><asp:Button ID="QSsave" runat="server" Text="More" OnClick="QSsave_Click" />
                        <asp:Label ID="Qmes" runat="server" Font-Size="Smaller" ForeColor="Red"
                            Visible="False" Width="20%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;width: 100%; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        Remarks &nbsp;<asp:TextBox ID="remark" runat="server" Width="90%" 
                            MaxLength="250" TextMode="MultiLine" Height="52px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;width: 100%; text-align: left; border-right-width: thin;
                        border-right-color: #666666">
                        &nbsp;<br />
                        </td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                        border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;
                        height: 3%; width: 100%; background-color: #fff8dc; text-align: center; border-right-width: thin;
                        border-right-color: #666666; font-weight: bold; color: #ffffc0;">
                        &nbsp; &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666; border-bottom-width: thin; border-bottom-color: #666666;
                        border-top-color: #666666; height: 10%;width: 100%; text-align: center; border-right-width: thin;
                        border-right-color: #666666; background-color: #661700;">
                        <asp:Label ID="maxid" runat="server" Visible="False"></asp:Label>.<asp:Button class="btn btn-success" ID="s1" runat="server" Text="Submit" OnClick="s1_Click" OnClientClick="return funct()" Width="104px" /><asp:Label ID="err" runat="server" ForeColor="White"></asp:Label></td>
                </tr>
            </table>
        &nbsp;
   </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
