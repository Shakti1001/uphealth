<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="parap2edit.aspx.cs" Inherits="NewWebApp.paramedicalstaff.parap2edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 90%; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 411px;" valign="top" align="center">
        <table class="table table-responsive-sm" id="TABLE1" style="border-right: #666666 thin solid; border-top: #666666 thin solid;
            font-weight: bold; border-left: #666666 thin solid; width: 80%; color: #661700;
            border-bottom: #666666 thin solid; font-family: Arial; height: 200px" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 1000px; color: #ffffff;
                    border-top-color: #666666; height: 25px; background-color: #661700; text-align: left;
                    border-right-width: thin; border-right-color: #666666; font-weight: bold;">
                    &nbsp;&nbsp;
                    <asp:Label ID="Uidt" runat="server" Visible="False"></asp:Label>Edit General Information &nbsp;&nbsp;
                    <asp:Label ID="Qmes" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Name</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="Name" runat="server" MaxLength="50" OnTextChanged="Name_TextChanged"
                        Width="90%"></asp:TextBox></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; ">
                    Father/Husband Name</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="fhname" runat="server" MaxLength="50" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Date Of Birth</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="Dob" runat="server" Width="90%"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; background-color: #ffffc0;">
                    Gender</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:DropDownList ID="Dsex" runat="server" Width="92%">
                        <asp:ListItem Value="0">Male</asp:ListItem>
                        <asp:ListItem Value="1">Female</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    Caste</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:DropDownList ID="Dcateg" runat="server" Height="22px" Width="92%">
                    </asp:DropDownList></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; ">
                    Home District</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:DropDownList ID="DhomeD" runat="server" Height="22px" Width="92%" 
                        OnSelectedIndexChanged="DhomeD_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td 
                    style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666; background-color: #ffffc0;">
                    Cadre</td>
                <td 
                    style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666; background-color: #ffffc0;">
                        <a
                                                    href="javascript:show_calendar('Content1.Dob');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;">
                    <asp:DropDownList ID="DCad" runat="server" Height="22px" Width="92%">
                    </asp:DropDownList>
                        </a></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; background-color: #ffffc0;">
                    Feeding Cadre</td>
                <td 
                    style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666; background-color: #ffffc0;">
                        <a
                                                    href="javascript:show_calendar('Content1.Dob');"
                                                    onmouseover="window.status='Date Picker';return true;"
                                                    onmouseout="window.status='';return true;">
                        <asp:DropDownList ID="ddlempcat" runat="server"  Width="92%" Height="22px">
                        </asp:DropDownList>
                        </a></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    GPF. No</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:TextBox ID="Gpfno" runat="server" MaxLength="50" OnTextChanged="Gpfno_TextChanged"
                        Width="90%" AutoPostBack="True"></asp:TextBox></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; ">
                    Seniority Number</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:TextBox ID="CSN" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" 
                    style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 100%; border-top-color: #666666;
                    background-color: #ffffc0; text-align: left; border-right-width: thin; border-right-color: #666666; height: 25px;">
                    <asp:Label ID="OtSL" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Blue"
                        Text="Please enter State then District" Visible="False"></asp:Label>
                    <asp:TextBox ID="Otherstatetext" runat="server" Visible="False" Width="60%"></asp:TextBox>&nbsp;<asp:Button
                        ID="OTSTATESUBMIT" runat="server" OnClick="OTSTATESUBMIT_Click" Text="Update"
                        Visible="False" /><asp:Label ID="ohome" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Date of Appointment</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <a
                        href="javascript:show_calendar('form1.dojs');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;"></a>
                    <asp:TextBox ID="doa" runat="server" Width="90%"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; ">
                    Date of Joining in Service</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <a
                        href="javascript:show_calendar('form1.doc');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;"></a>
                    <asp:TextBox ID="dojs" runat="server" Width="90%"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    &nbsp;Date of Confirmation<br />
                    </td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="doc" runat="server" Width="90%"></asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; background-color: #ffffc0;">
                    Spouse 
                    Comp. Id<br />
                    <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="In case of Govt. Service"
                        Width="152px"></asp:Label>
                    <br />
                    </td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="Cgpf" runat="server" MaxLength="50" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Contact Number</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="txtmobil" runat="server" Width="90%"></asp:TextBox>
                </td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; ">
                    Disability Category (if any)</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <a
                        href="javascript:show_calendar('form1.Dob');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;">
                    <asp:DropDownList ID="Dsubcat" runat="server" Width="92%">
                    </asp:DropDownList></a></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Previous Home District<br />
                    <asp:Label ID="Label6" runat="server" Font-Size="Smaller" ForeColor="#C00000" Text="if the Home district Is changed"
                        Width="232px" style="margin-top: 0px"></asp:Label></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:DropDownList ID="pDhomeD" runat="server" OnSelectedIndexChanged="pDhomeD_SelectedIndexChanged"
                        Width="92%">
                    </asp:DropDownList></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; background-color: #ffffc0;">
                    &nbsp;</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Local Address</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="ladd" runat="server" MaxLength="255" Width="92%" 
                        TextMode="MultiLine"  Height="35px"></asp:TextBox></td>
                <td style="border-color: #666666; border-width: thin; width: 27%; height: 25px; text-align: left; ">
                    Permanent Address</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="padd" runat="server" MaxLength="255" Width="92%" 
                        TextMode="MultiLine" Height="35px"></asp:TextBox></td>
            </tr>
            <%--<tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Qualification/Specialization</td>
                <td colspan="3" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:Label ID="Label2" runat="server" Font-Size="Smaller" ForeColor="#C04000"
                        Visible="False" Width="272px"></asp:Label></td>
            </tr>--%>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Remark</td>
                <td colspan="3" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="remark" runat="server" MaxLength="255" Width="90%" 
                        TextMode="MultiLine" Height="52px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;
                    height: 25px; background-color: #661700; text-align: center; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" ForeColor="White"></asp:Label>&nbsp;
                    <strong>
                    <asp:Button ID="Up" runat="server" OnClick="Up_Click" Text="Update" 
                        Visible="False" Font-Bold="True" Width="79px" /></strong>&nbsp;
                    <asp:Label ID="Label5" runat="server" Font-Size="Smaller" ForeColor="White" Visible="False"
                        Width="96px"></asp:Label><asp:Label ID="err" runat="server" ForeColor="White"></asp:Label>&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="ddlempcat" ErrorMessage="Select Feeding Cadre.." 
                        style="color: #FFFFFF"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
