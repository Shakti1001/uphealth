<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="NewWebApp.payrole.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body style="background-color: lavender">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel2" runat="server" Height="198px" Width="971px">
        </asp:Panel>
        <br />
        <br />
     <table border="0" cellpadding="0" cellspacing="0" style="width: 944px; left: 12px; position: relative; top: -213px; height: 122px;">
            <tr>
                <td style="width: 14%; background-color: #6699cc; height: 26px;">
                </td>
                <td style="font-weight: bold; color: black; background-color: #6699cc; text-align: center; font-size: 14pt; height: 26px;" colspan="2">
                    &nbsp; Search Result&nbsp;</td>
                <td style="width: 20%; background-color: #6699cc; height: 26px;">
                </td>
            </tr>
            <tr>
                <td style="width: 14%; background-color: silver;">
                </td>
                <td style="width: 30%; background-color: silver;">
                </td>
                <td style="width: 32%; background-color: silver;">
                </td>
                <td style="width: 20%; background-color: silver;">
                </td>
            </tr>
            <tr>
                <td style="background-color: silver;" colspan="4">
                      <asp:Table ID="Table1"  runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                    Font-Size="Small" Width="100%" style="background-color: gainsboro">
                                                </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 14%; height: 21px; background-color: silver;">
                </td>
                <td style="width: 30%; height: 21px; background-color: silver;">
                </td>
                <td style="width: 32%; height: 21px; background-color: silver;">
                </td>
                <td style="width: 20%; height: 21px; background-color: silver;">
                </td>
            </tr>
            <tr>
                <td style="width: 14%; height: 21px; background-color: silver;">
                </td>
                <td style="width: 30%; height: 21px; background-color: silver;">
                </td>
                <td style="width: 32%; height: 21px; background-color: silver;">
                </td>
                <td style="width: 20%; height: 21px; background-color: silver;">
                </td>
            </tr>
        </table>
    <div style="background-color: lavender">
      
    </div>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px" style="background-color: lavender; left: 0px; position: relative; top: -151px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 978px; height: 161px; background-color: lavender; left: -2px; position: relative; top: 42px;">
            <tr>
                <td style="width: 100px; background-color: lavender; height: 33px;">
                </td>
                <td style="width: 119px; background-color: #6699cc; height: 33px;">
                </td>
                <td style="color: black; background-color: #6699cc; text-align: center; font-weight: bold; font-size: 14pt; height: 33px;" colspan="2">
                    Search Form</td>
                <td style="width: 110px; background-color: #6699cc; height: 33px;">
                </td>
                <td style="width: 100px; height: 33px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 119px; height: 21px; background-color: silver;">
                </td>
                <td style="width: 124px; height: 21px; background-color: silver;">
                </td>
                <td style="width: 185px; height: 21px; background-color: silver;">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 110px; height: 21px; background-color: silver;">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="font-weight: bold; width: 119px; height: 21px; background-color: silver;
                    text-align: center">
                    Current District</td>
                <td style="width: 124px; height: 21px; background-color: silver">
                    <asp:ListBox ID="Districtdrp" runat="server"></asp:ListBox></td>
                <td style="width: 185px; height: 21px; background-color: silver"><asp:Button ID="disadd" runat="server" Text="Add" Width="44px" OnClick="disadd_Click" Font-Bold="True" Font-Italic="False" ForeColor="#0000C0" />
                    <asp:Button ID="disremove" runat="server" Text="Remove" Width="63px" OnClick="disremove_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; height: 21px; background-color: silver">
                    <asp:ListBox ID="SelDistrict" runat="server" Width="105px"></asp:ListBox></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 119px; height: 21px; background-color: silver">
                </td>
                <td style="width: 124px; height: 21px; background-color: silver">
                </td>
                <td style="width: 185px; height: 21px; background-color: silver">
                </td>
                <td style="width: 110px; height: 21px; background-color: silver">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: silver; text-align: right;" valign="top">
                    Cadre :</td>
                <td style="width: 124px; background-color: silver;" valign="top">
                    <asp:ListBox ID="Cadre" runat="server"></asp:ListBox></td>
                <td style="width: 185px; background-color: silver;" valign="top">
                    <asp:Button ID="cadadd" runat="server" Text="Add" Width="44px" OnClick="cadadd_Click" Font-Bold="True" Font-Italic="False" ForeColor="#0000C0" />
                    <asp:Button ID="cadrem" runat="server" Text="Remove" Width="63px" OnClick="cadrem_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; background-color: silver;">
                    <asp:ListBox ID="SelCadre" runat="server" Width="107px"></asp:ListBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="font-weight: bold; width: 119px; background-color: silver; text-align: right"
                    valign="top">
                </td>
                <td style="width: 124px; background-color: silver" valign="top">
                </td>
                <td style="width: 185px; background-color: silver" valign="top">
                </td>
                <td style="width: 110px; background-color: silver">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 70px;">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: silver; text-align: right; height: 70px;" valign="top">
                    Category:</td>
                <td style="width: 124px; background-color: silver; height: 70px;">
                    <asp:ListBox ID="Category" runat="server"></asp:ListBox></td>
                <td style="width: 185px; background-color: silver; height: 70px;" valign="top">
                    <asp:Button ID="catadd" runat="server" Text="Add" Width="44px" OnClick="catadd_Click" Font-Bold="True" ForeColor="#0000C0" />
                    <asp:Button ID="catrem" runat="server" Text="Remove" Width="63px" OnClick="catrem_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; background-color: silver; height: 70px;">
                    <asp:ListBox ID="SelCategory" runat="server" Width="108px"></asp:ListBox></td>
                <td style="width: 100px; height: 70px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 18px">
                </td>
                <td style="font-weight: bold; width: 119px; height: 18px; background-color: silver;
                    text-align: right" valign="top">
                </td>
                <td style="width: 124px; height: 18px; background-color: silver">
                </td>
                <td style="width: 185px; height: 18px; background-color: silver" valign="top">
                </td>
                <td style="width: 110px; height: 18px; background-color: silver">
                </td>
                <td style="width: 100px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: silver; text-align: right;" valign="top">
                    Level:</td>
                <td style="width: 124px; background-color: silver;">
                    <asp:ListBox ID="Level" runat="server"></asp:ListBox></td>
                <td style="width: 185px; background-color: silver;" valign="top">
                    &nbsp;<asp:Button ID="levadd" runat="server" Text="Add" Width="44px" OnClick="levadd_Click" Font-Bold="True" ForeColor="#0000C0" />
                    <asp:Button ID="levrem" runat="server" Text="Remove" Width="63px" OnClick="levrem_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; background-color: silver;">
                    <asp:ListBox ID="SelLevel" runat="server" Width="108px"></asp:ListBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: silver;
                    text-align: right" valign="top">
                </td>
                <td style="width: 124px; height: 19px; background-color: silver">
                </td>
                <td style="width: 185px; height: 19px; background-color: silver" valign="top">
                </td>
                <td style="width: 110px; height: 19px; background-color: silver">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: silver;
                    text-align: right" valign="top">
                    Date Of Joining :</td>
                <td style="width: 124px; height: 19px; background-color: silver">
                    <asp:DropDownList ID="optdoj" runat="server" OnSelectedIndexChanged="optdoj_SelectedIndexChanged" Width="76px">
                        <asp:ListItem Value="0">=</asp:ListItem>
                        <asp:ListItem Value="1">&gt;</asp:ListItem>
                        <asp:ListItem Value="2">&lt;</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 185px; height: 19px; background-color: silver" valign="top">
                    <asp:DropDownList ID="datedrp1" runat="server" Width="28%" OnSelectedIndexChanged="datedrp1_SelectedIndexChanged">
                    </asp:DropDownList><asp:DropDownList ID="mondrp1" runat="server" OnSelectedIndexChanged="mondrp1_SelectedIndexChanged">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
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
                    </asp:DropDownList><asp:DropDownList ID="yeardrp1" runat="server" Width="60px" OnSelectedIndexChanged="yeardrp1_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="width: 110px; height: 19px; background-color: silver">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: silver;
                    text-align: right" valign="top">
                </td>
                <td style="width: 124px; height: 19px; background-color: silver">
                </td>
                <td style="width: 185px; height: 19px; background-color: silver" valign="top">
                </td>
                <td style="width: 110px; height: 19px; background-color: silver">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: silver;
                    text-align: right" valign="top">
                    </td>
                <td style="width: 124px; height: 19px; background-color: silver">
                    </td>
                <td style="width: 185px; height: 19px; background-color: silver" valign="top">
                    </td>
                <td style="width: 110px; height: 19px; background-color: silver">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: silver; text-align: center;" valign="top">
                    </td>
                <td colspan="2" valign="top" style="background-color: silver">
                    <asp:Label ID="Label1" runat="server" Style="left: 3px; position: relative; top: -47px"
                        Text="Degree :" Font-Bold="True" Visible="False"></asp:Label>
                    &nbsp;<asp:ListBox ID="degree" runat="server" Visible="False"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="quaadd" runat="server" Text="Add" style="left: 18px; position: relative; top: -44px" Width="44px" OnClick="degadd_Click" Font-Bold="True" ForeColor="#0000C0" Visible="False" />
                    <asp:Button ID="quarem" runat="server" Text="Remove" style="left: 17px; position: relative; top: -43px" Width="63px" OnClick="degrem_Click" Font-Bold="True" ForeColor="#0000C0" Visible="False" /></td>
                <td style="width: 110px; background-color: silver;">
                    <asp:ListBox ID="Seldegree" runat="server" Width="107px" Visible="False"></asp:ListBox></td>
                <td style="width: 100px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 70px;">
                </td>
                <td style="width: 119px; background-color: silver; height: 70px;" valign="top">
                </td>
                <td colspan="2" valign="top" style="background-color: silver; height: 70px;">
                    <asp:Label ID="Label2" runat="server" Style="left: 2px; position: relative; top: -43px"
                        Text="Subject :" Font-Bold="True" Visible="False"></asp:Label>
                    <asp:ListBox ID="Subject" runat="server" style="left: 4px; position: relative; top: 0px" Visible="False"></asp:ListBox>&nbsp;
                    <asp:Button ID="subadd" runat="server" Style="left: 34px; position: relative; top: -43px"
                        Text="Add" Width="44px" OnClick="subadd_Click" Font-Bold="True" ForeColor="#0000C0" Visible="False" />
                    <asp:Button ID="subrem" runat="server" Style="left: 32px; position: relative; top: -43px"
                        Text="Remove" Width="63px" OnClick="subrem_Click" Font-Bold="True" ForeColor="#0000C0" Visible="False" /></td>
                <td style="width: 110px; background-color: silver; height: 70px;">
                    <asp:ListBox ID="Selsubject" runat="server" Width="106px" Visible="False"></asp:ListBox></td>
                <td style="width: 100px; height: 70px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 119px; font-weight: bold; height: 22px; background-color: silver; text-align: right;">
                    </td>
                <td style="width: 124px; height: 22px; background-color: silver;">
                    <asp:DropDownList ID="Optdob" runat="server" Visible="False">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">&gt;</asp:ListItem>
                        <asp:ListItem Value="2">&lt;</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 185px; height: 22px; background-color: silver;">
                    <asp:DropDownList ID="datedrp" runat="server" Width="28%" OnSelectedIndexChanged="datedrp_SelectedIndexChanged" Visible="False">
                    </asp:DropDownList><asp:DropDownList ID="mondrp" runat="server" OnSelectedIndexChanged="mondrp_SelectedIndexChanged" Visible="False">
                        <asp:ListItem>Select</asp:ListItem>
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
                    </asp:DropDownList><asp:DropDownList ID="yeardrp" runat="server" Width="60px" OnSelectedIndexChanged="yeardrp_SelectedIndexChanged" Visible="False">
                    </asp:DropDownList></td>
                <td style="width: 110px; height: 22px; background-color: silver;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 38px;">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: silver; height: 38px; text-align: right;">
                    </td>
                <td style="width: 124px; background-color: silver; height: 38px;">
                    </td>
                <td style="width: 185px; background-color: silver; height: 38px;">
                    </td>
                <td style="width: 110px; background-color: silver; height: 38px;">
                </td>
                <td style="width: 100px; height: 38px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px;">
                </td>
                <td style="width: 119px; height: 19px; background-color: silver;">
                </td>
                <td style="width: 124px; height: 19px; background-color: silver;">
                </td>
                <td style="width: 185px; height: 19px; background-color: silver;">
                </td>
                <td style="width: 110px; height: 19px; background-color: silver;">
                </td>
                <td style="width: 100px; height: 19px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 119px; background-color: silver;">
                </td>
                <td style="width: 124px; background-color: silver;">
                </td>
                <td style="width: 185px; background-color: silver;">
                </td>
                <td style="width: 110px; background-color: silver;">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 119px; background-color: #6699cc;">
                </td>
                <td style="width: 124px; text-align: center; background-color: #6699cc;">
                    </td>
                <td style="width: 185px; background-color: #6699cc;">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" Font-Bold="True" ForeColor="Black" /></td>
                <td style="width: 110px; background-color: #6699cc;">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        </asp:Panel>
    </form>
</body>
</html>

