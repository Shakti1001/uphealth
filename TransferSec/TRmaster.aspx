<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="TRmaster.aspx.cs" Inherits="NewWebApp.TransferSec.TRmaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../../js/disableprint.js" type="text/javascript" language="javascript">
</script>
    <div class="container" style="text-align: center">
        <div style="text-align: center">
            <table class="table table-responsive-sm table-active" style="  width: 100%">
                <tr>
                    <td style="width: 100%;  text-align: right;" valign="top">
                        <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server" 
                            onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>  </td>
               
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" valign="top">
                        <div style="text-align: center">
                                    <table class="table table-responsive-sm" style="font-weight: bold; width: 100%; color: #74211f;
            font-family: Georgia; text-align: center; border-right: #2c2713 thin solid; border-top: #2c2713 thin solid; border-left: #2c2713 thin solid; border-bottom: #2c2713 thin solid;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; font-size: 14px; width: 100%; color: maroon;
                                                text-align: center">
                                                <div style="text-align: center">
                                                    <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                                        <tr>
                                                            <td align="left" style="font-weight: bold; width: 25%; color: khaki; height: 17px;
                                                                background-color: #661700; text-align: left">
                                                                &nbsp;Add &nbsp;&nbsp; Transfer Order</td>
                                                            <td align="left" style="font-weight: bold; width: 25%; color: khaki; height: 17px;
                                                                background-color: #661700">
                    </td>
                                                            <td align="left" style="font-weight: bold; width: 25%; color: khaki; height: 17px;
                                                                background-color: #661700">
                                                                <asp:Label ID="Fnamet" runat="server" Visible="False"></asp:Label></td>
                                                            <td align="left" style="font-weight: bold; width: 25%; color: khaki; height: 17px;
                                                                background-color: #661700">
                                                                <asp:Label ID="Uidt" runat="server"
                        Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                Order No</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                    <asp:TextBox ID="TrNo" runat="server" Width="80%"></asp:TextBox></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                        </tr>
                                                        
                                                        
                                                        
                                                        <tr>
                                                            <td align="left" style="width: 25%; height: 17px;">
                                                                <asp:DropDownList ID="DDD" runat="server" Visible="False">
                                                                </asp:DropDownList><asp:DropDownList ID="DMM" runat="server" Visible="False">
                                                                </asp:DropDownList><asp:DropDownList ID="DYYYY" runat="server" Visible="False">
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; height: 17px;">
                                                                Order Date</td>
                                                            <td align="left" style="width: 25%; height: 17px;">
                                                            <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajx:ToolkitScriptManager>
                                                                <asp:TextBox ID="OrDate" runat="server" Height="18px" Style="background-color: white"
                                                                    Width="82px"></asp:TextBox><asp:Image ID="Imagecal" runat="server" ImageUrl="~/Proforma2/calender/cal_img/cal.gif" />
                                                                     <ajx:CalendarExtender ID="Calendar1" PopupButtonID="Imagecal" runat="server" TargetControlID="OrDate"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender>
                                                                    </td>
                                                            <td align="left" style="width: 25%; height: 17px;">
                                                            </td>
                                                        </tr>
                                                        
                                                        
                                                        
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                Issued By</td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                <asp:DropDownList ID="JORDERDD" runat="server" AutoPostBack="True" 
                                                                    Width="98%">
                                                                </asp:DropDownList></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc">
                                                                <asp:TextBox ID="maxid" runat="server" AutoPostBack="True" 
                        Visible="False" Width="8px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%">
                                                            </td>
                                                            <td align="left" style="width: 25%">
                                                                Remark If Any</td>
                                                            <td align="left" style="width: 25%">
                                                                <asp:TextBox ID="Retext" runat="server" Width="80%"></asp:TextBox></td>
                                                            <td align="left" style="width: 25%">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc;">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc;">
                                                            </td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc;">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="80px" /></td>
                                                            <td align="left" style="width: 25%; background-color: #fff8dc;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4" style="width: 100%; text-align: left; font-size: 12px;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4" style="width: 100%; background-color: #661700; text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="#FFFFC0" Width="100%" Height="18px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
        </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        </div>
</asp:Content>
