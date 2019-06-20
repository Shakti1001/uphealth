<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="editp2.aspx.cs" Inherits="NewWebApp.Proforma2.editp2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/disableprint.js" type="text/javascript" language="javascript">
</script>
<div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style=" height: 100%; width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100%; height: 0px; text-align: right;" valign="top">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; height: 411px;" valign="top">
        <table class="table table-responsive-sm" id="TABLE1" style="border-right: #666666 thin solid; border-top: #666666 thin solid;
            font-weight: bold; border-left: #666666 thin solid; width: 100%; color: #661700;
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
                    Seniority No</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="Gpfno" runat="server" Height="16px" MaxLength="50" OnTextChanged="Gpfno_TextChanged"
                        Width="90%" AutoPostBack="True"></asp:TextBox></td>
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
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Fathers/Husband Name&nbsp;</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="fhname" runat="server" Height="16px" MaxLength="50" Width="90%"></asp:TextBox></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Sex</td>
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
                    Cadre</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:DropDownList ID="DCad" runat="server" Width="92%">
                    </asp:DropDownList></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    Cader Seniority Number</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:TextBox ID="CSN" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Category&nbsp;
                </td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:DropDownList ID="Dcateg" runat="server" Height="24px" Width="92%">
                    </asp:DropDownList></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Sub Category</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:DropDownList ID="Dsubcat" runat="server" Width="92%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Home District</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:DropDownList ID="DhomeD" runat="server" Height="24px" Width="92%" OnSelectedIndexChanged="DhomeD_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Previous Home District<br />
                    <asp:Label ID="Label6" runat="server" Font-Size="Smaller" ForeColor="#C00000" Text="if the Home district Is changed"
                        Width="232px"></asp:Label></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:DropDownList ID="pDhomeD" runat="server" OnSelectedIndexChanged="pDhomeD_SelectedIndexChanged"
                        Width="92%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 100%; border-top-color: #666666;
                    background-color: moccasin; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:Label ID="OtSL" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Blue"
                        Text="Please enter State then District" Visible="False"></asp:Label>&nbsp;
                    <asp:TextBox ID="Otherstatetext" runat="server" Visible="False" Width="60%"></asp:TextBox>&nbsp;<asp:Button
                        ID="OTSTATESUBMIT" runat="server" OnClick="OTSTATESUBMIT_Click" Text="Save"
                        Visible="False" />
                    <asp:Label ID="ohome" runat="server" Visible="False"></asp:Label></td>
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
                    <asp:TextBox ID="Dob" runat="server" Height="16px" Width="136px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="dob"
                    Display="Dynamic" ErrorMessage="invalid!" SetFocusOnError="True"
                    ValidationExpression="^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label><a
                        href="javascript:show_calendar('Content1.Dob');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;"></a></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Date Of Appointment</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="doa" runat="server" Height="16px" Width="136px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="doa"
                    Display="Dynamic" ErrorMessage="invalid!" SetFocusOnError="True"
                    ValidationExpression="^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                    
                    
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label><a
                        href="javascript:show_calendar('Content1.doa');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;"></a></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Date Of Joining In Services</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="dojs" runat="server" Height="16px" Width="136px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="dojs"
                    Display="Dynamic" ErrorMessage="invalid!" SetFocusOnError="True"
                    ValidationExpression="^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label><a
                        href="javascript:show_calendar('Content1.dojs');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;"></a></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Date Of Confirmation</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    
                    <asp:TextBox ID="doc" runat="server" Height="16px" Width="136px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="doc"
                    Display="Dynamic" ErrorMessage="invalid!" SetFocusOnError="True"
                    ValidationExpression="^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$" Font-Size="XX-Small"></asp:RegularExpressionValidator>
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="X-Small" Text="mm/dd/yyyy"></asp:Label><a
                        href="javascript:show_calendar('Content1.doc');" onmouseout="window.status='';return true;"
                        onmouseover="window.status='Date Picker';return true;"></a></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Couple Id
                    <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="In case of Govt. Service"
                        Width="152px"></asp:Label><br />
                    <asp:Label ID="Label4" runat="server" Font-Size="Smaller" ForeColor="#C00000" Text="(Gpf No for Same dept. 99 for others)"
                        Width="232px"></asp:Label></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:TextBox ID="Cgpf" runat="server" MaxLength="50" Width="90%"></asp:TextBox></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    Level</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666; background-color: #ffffc0;">
                    <asp:DropDownList ID="DLavel" runat="server" Width="91%">
                    </asp:DropDownList></td>
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
                    <asp:TextBox ID="ladd" runat="server" MaxLength="255" Width="90%" TextMode="MultiLine" Height="50%"></asp:TextBox></td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Permanent Address</td>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="padd" runat="server" MaxLength="255" Width="90%" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
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
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    Remark</td>
                <td colspan="3" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:TextBox ID="remark" runat="server" MaxLength="255" Width="99%" 
                        TextMode="MultiLine" Height="81%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:Label ID="docimage" runat="server" Text="Doctor's Image"></asp:Label></td>
                <td colspan="3" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; width: 25%; border-top-color: #666666;
                    height: 25px; text-align: left; border-right-width: thin; border-right-color: #666666">
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="4" style="border-top-width: thin; border-left-width: thin; border-left-color: #666666;
                    border-bottom-width: thin; border-bottom-color: #666666; border-top-color: #666666;
                    height: 25px; background-color: #661700; text-align: center; border-right-width: thin;
                    border-right-color: #666666">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" ForeColor="White"></asp:Label>&nbsp;
                    <asp:Button ID="Up" class="btn btn-success" runat="server" OnClick="Up_Click" Text="Update" Visible="False" />&nbsp;
                    <asp:Label ID="Label5" runat="server" Font-Size="Smaller" ForeColor="White" Visible="False"
                        Width="96px"></asp:Label><asp:Label ID="err" runat="server" ForeColor="White"></asp:Label>
                        <asp:Button ID="PFsheet" runat="server" OnClick="PFsheet_Click" 
                        Text="Print FactSheet" Width="112px" Visible="False" /></td>
            </tr>
        </table>
    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
