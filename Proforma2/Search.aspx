<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="NewWebApp.Proforma2.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="text-align: center">
      <table class="table table-responsive-sm table-active">   
     <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; left: -2px; position: relative; top: -198px; height: 122px;">
            <tr>
                <td style="width: 14%; background-color: #6699cc; height: 26px;">
                </td>
                <td style="font-weight: bold; color: black; background-color: #6699cc; text-align: center; font-size: 14pt; height: 26px;" colspan="2">
                    &nbsp; Search Result&nbsp;</td>
                <td style="width: 20%; background-color: #6699cc; height: 26px;">
                </td>
            </tr>
            <tr>
                <td style="width: 14%; background-color: #e8cd76;">
                </td>
                <td style="text-align: center;" colspan="2">
                    <asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
                <td style="width: 20%;">
                </td>
            </tr>
            <tr>
                <td style="height: 34px;" colspan="4">
                      <asp:Table class="table table-responsive-sm" ID="Table1"  runat="server" CellPadding="0" CellSpacing="0" Font-Bold="True"
                                                    Font-Size="Small" Width="100%" style="background-color: lavender">
                                                </asp:Table>
                </td>
            </tr>
            <tr>
                <td style="width: 14%; height: 21px;">
                </td>
                <td style="width: 30%; height: 21px;">
                </td>
                <td style="width: 32%; height: 21px;">
                </td>
                <td style="width: 20%; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 14%; height: 21px;">
                </td>
                <td style="width: 30%; height: 21px;">
                </td>
                <td style="width: 32%; height: 21px;">
                </td>
                <td style="width: 20%; height: 21px;">
                </td>
            </tr>
        </table>
        <table class="table table-responsive-sm" border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 161px; background-color: lavender; left: -2px; position: relative; top: 42px;">
            <tr>
                <td style="width: 100px; background-color: #e8cd76; height: 33px;">
                    <asp:LinkButton class="btn btn-danger" ID="LinkButton1" runat="server"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton>
                </td>
                <td style="width: 119px; background-color: maroon; height: 33px;">
                </td>
                <td style="color: yellow; background-color: maroon; text-align: center; font-weight: bold; font-size: 14pt; height: 33px;" colspan="2">
                    Search Form</td>
                <td style="width: 110px; background-color: maroon; height: 33px;">
                </td>
                <td style="width: 100px; height: 33px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; height: 21px; background-color: #e8cd76;">
                </td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76;">
                </td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76;">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76;">
                </td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; height: 21px; background-color: #e8cd76;
                    text-align: left">
                    Current District:</td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="Districtdrp" runat="server" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76"><asp:Button ID="disadd" runat="server" Text="Add" Width="44px" OnClick="disadd_Click" Font-Bold="True" Font-Italic="False" ForeColor="#0000C0" />
                    <asp:Button ID="disremove" runat="server" Text="Remove" Width="63px" OnClick="disremove_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="SelDistrict" runat="server" Width="105px"></asp:ListBox></td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="font-weight: bold; width: 119px; height: 21px; background-color: #e8cd76;
                    text-align: center">
                </td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; height: 21px; background-color: #e8cd76; font-weight: bold; text-align: left;">
                    PostName:</td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="Postdrp" runat="server" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76">
                    <asp:Button ID="Postadd" runat="server" Font-Bold="True" ForeColor="Blue" OnClick="Postadd_Click"
                        Text="Add" Width="44px" />
                    <asp:Button ID="Postrem" runat="server" Font-Bold="True" ForeColor="Blue" OnClick="Postrem_Click"
                        Text="Remove" Width="63px" /></td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="SelPostdrp" runat="server" Width="105px"></asp:ListBox></td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="font-weight: bold; width: 119px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 119px; height: 21px; background-color: #e8cd76; font-weight: bold; color: black; text-align: left;">
                    Cadre :</td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="Cadre" runat="server" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76">
                    <asp:Button ID="cadadd" runat="server" Text="Add" Width="44px" OnClick="cadadd_Click" Font-Bold="True" Font-Italic="False" ForeColor="#0000C0" />
                    <asp:Button ID="cadrem" runat="server" Text="Remove" Width="63px" OnClick="cadrem_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="SelCadre" runat="server" Width="107px"></asp:ListBox></td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 119px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
                <td style="font-weight: bold; width: 119px; color: black; height: 21px; background-color: #e8cd76;
                    text-align: left">
                    Category:</td>
                <td style="width: 124px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="Category" runat="server" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; height: 21px; background-color: #e8cd76">
                    <asp:Button ID="catadd" runat="server" Text="Add" Width="44px" OnClick="catadd_Click" Font-Bold="True" ForeColor="#0000C0" />
                    <asp:Button ID="catrem" runat="server" Text="Remove" Width="63px" OnClick="catrem_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; height: 21px; background-color: #e8cd76">
                    <asp:ListBox ID="SelCategory" runat="server" Width="108px"></asp:ListBox></td>
                <td style="width: 100px; height: 21px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; background-color: #e8cd76; text-align: right"
                    valign="top">
                </td>
                <td style="width: 124px; background-color: #e8cd76" valign="top">
                </td>
                <td style="width: 185px; background-color: #e8cd76" valign="top">
                    &nbsp;</td>
                <td style="width: 110px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 70px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: #e8cd76; text-align: left; height: 70px;" valign="top">
                    Level:</td>
                <td style="width: 124px; background-color: #e8cd76; height: 70px;">
                    <asp:ListBox ID="Level" runat="server" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; background-color: #e8cd76; height: 70px;" valign="middle">
                    <asp:Button ID="levadd" runat="server" Text="Add" Width="44px" OnClick="levadd_Click" Font-Bold="True" ForeColor="#0000C0" />
                    <asp:Button ID="levrem" runat="server" Text="Remove" Width="63px" OnClick="levrem_Click" Font-Bold="True" ForeColor="#0000C0" /></td>
                <td style="width: 110px; background-color: #e8cd76; height: 70px;">
                    <asp:ListBox ID="SelLevel" runat="server" Width="108px"></asp:ListBox></td>
                <td style="width: 100px; height: 70px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 18px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; height: 18px; background-color: #e8cd76;
                    text-align: right" valign="top">
                </td>
                <td style="width: 124px; height: 18px; background-color: #e8cd76">
                </td>
                <td style="width: 185px; height: 18px; background-color: #e8cd76" valign="top">
                </td>
                <td style="width: 110px; height: 18px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 18px; font-family: #e8cd76; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: #e8cd76; text-align: left;" valign="top">
                    Date Of Joining :</td>
                <td style="width: 124px; background-color: #e8cd76;">
                    <asp:DropDownList ID="optdoj" runat="server" OnSelectedIndexChanged="optdoj_SelectedIndexChanged" Width="100px">
                        <asp:ListItem Value="0">=</asp:ListItem>
                        <asp:ListItem Value="1">&gt;</asp:ListItem>
                        <asp:ListItem Value="2">&lt;</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 185px; background-color: #e8cd76;" valign="top">
                    <asp:DropDownList ID="datedrp1" runat="server" Width="28%" OnSelectedIndexChanged="datedrp1_SelectedIndexChanged">
                    </asp:DropDownList><asp:DropDownList ID="mondrp1" runat="server" OnSelectedIndexChanged="mondrp1_SelectedIndexChanged">
                        <asp:ListItem Value="00">Select</asp:ListItem>
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
                <td style="width: 110px; background-color: #e8cd76;">
                    </td>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: right" valign="top">
                </td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" valign="top">
                </td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: left" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Degree"></asp:Label></td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                    <asp:ListBox ID="degree" runat="server" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" valign="middle">
                    <asp:Button ID="degadd" runat="server" Font-Bold="True" ForeColor="#0000C0" OnClick="degadd_Click"
                        Text="Add" Width="44px" />
                    <asp:Button ID="degrem" runat="server" Font-Bold="True" ForeColor="#0000C0" OnClick="degrem_Click"
                        Text="Remove" Width="63px" /></td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                    <asp:ListBox ID="Seldegree" runat="server" Width="107px"></asp:ListBox></td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: normal; height: 26px; background-color: #e8cd76;
                    text-align: center" valign="top" colspan="3">
                    <asp:Label ID="Label5" runat="server" ForeColor="Maroon"
                        Visible="False"></asp:Label></td>
                <td style="width: 110px; height: 26px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 26px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: left" valign="top">
                    <asp:Label ID="Label2" runat="server" Text="Subject"></asp:Label></td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                    <asp:ListBox ID="Subject" runat="server" style="left: -146px; position: static; top: -93px" Width="100px"></asp:ListBox></td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" valign="middle">
                    <asp:Button ID="Button3" runat="server" Font-Bold="True" ForeColor="#0000C0" OnClick="subadd_Click"
                        Text="Add" Width="44px" />
                    <asp:Button ID="subrem" runat="server" Font-Bold="True" ForeColor="#0000C0" Text="Remove"
                        Width="63px" OnClick="subrem_Click" /></td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                    <asp:ListBox ID="Selsubject" runat="server" Width="106px"></asp:ListBox></td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: right" valign="top">
                </td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" valign="top">
                </td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: left" valign="top">
                    <asp:Label ID="Label6" runat="server" Text="Training"></asp:Label>
                </td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                    <asp:ListBox ID="training" runat="server" 
                        onselectedindexchanged="training_SelectedIndexChanged" 
                        style="left: -146px; position: static; top: -93px" Width="100px">
                    </asp:ListBox>
                </td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" 
                    valign="middle">
                    <asp:Button ID="Button4" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                        OnClick="Button4_Click" Text="Add" Width="44px" />
                    <asp:Button ID="train" runat="server" Font-Bold="True" ForeColor="#0000C0" 
                        OnClick="train_Click" Text="Remove" Width="63px" />
                </td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                    <asp:ListBox ID="Seltraining" runat="server" Width="106px"></asp:ListBox>
                </td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: right" valign="top">
                    &nbsp;</td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" valign="top">
                    &nbsp;</td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
                <td style="font-weight: bold; width: 119px; height: 19px; background-color: #e8cd76;
                    text-align: right" valign="top">
                    &nbsp;</td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76" valign="top">
                    &nbsp;</td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: maroon; text-align: center;" valign="top">
                    </td>
                <td colspan="2" valign="top" style="background-color: maroon; text-align: center;">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" Font-Bold="True" ForeColor="Maroon" Height="28px" Width="79px" />
                    </td>
                <td style="width: 110px; background-color: maroon;">
                    </td>
                <td style="width: 100px; background-color: #e8cd76;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 70px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; background-color: #e8cd76; height: 70px;" valign="top">
                </td>
                <td colspan="2" valign="top" style="background-color: #e8cd76; height: 70px;">
                    &nbsp; &nbsp;
                    </td>
                <td style="width: 110px; background-color: #e8cd76; height: 70px;">
                    </td>
                <td style="width: 100px; height: 70px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 22px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; font-weight: bold; height: 22px; background-color: #e8cd76; text-align: right;">
                    </td>
                <td style="width: 124px; height: 22px; background-color: #e8cd76;">
                    </td>
                <td style="width: 185px; height: 22px; background-color: #e8cd76;">
                    </td>
                <td style="width: 110px; height: 22px; background-color: #e8cd76;">
                </td>
                <td style="width: 100px; height: 22px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 38px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; font-weight: bold; background-color: #e8cd76; height: 38px; text-align: right;">
                    </td>
                <td style="width: 124px; background-color: #e8cd76; height: 38px;">
                    </td>
                <td style="width: 185px; background-color: #e8cd76; height: 38px;">
                    </td>
                <td style="width: 110px; background-color: #e8cd76; height: 38px;">
                </td>
                <td style="width: 100px; height: 38px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; background-color: #e8cd76;">
                </td>
                <td style="width: 124px; background-color: #e8cd76;">
                </td>
                <td style="width: 185px; background-color: #e8cd76;">
                </td>
                <td style="width: 110px; background-color: #e8cd76;">
                </td>
                <td style="width: 100px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
                <td style="width: 119px; background-color: #e8cd76; height: 19px;">
                </td>
                <td style="width: 124px; text-align: center; background-color: #e8cd76; height: 19px;">
                    </td>
                <td style="width: 185px; background-color: #e8cd76; height: 19px;">
                    </td>
                <td style="width: 110px; background-color: #e8cd76; height: 19px;">
                </td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 44px; background-color: #e8cd76">
                </td>
                <td style="width: 119px; height: 44px; background-color: #e8cd76">
                </td>
                <td style="width: 124px; height: 44px; background-color: #e8cd76; text-align: center">
                    </td>
                <td style="width: 185px; height: 44px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; height: 44px; background-color: #e8cd76">
                    </td>
                <td style="width: 100px; height: 44px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76">
                </td>
                <td style="width: 119px; background-color: #e8cd76">
                </td>
                <td style="width: 124px; background-color: #e8cd76; text-align: center">
                </td>
                <td style="width: 185px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; background-color: #e8cd76">
                    </td>
                <td style="width: 100px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76; height: 22px;">
                </td>
                <td style="width: 119px; background-color: #e8cd76; text-align: right; height: 22px;">
                    <asp:DropDownList ID="Optdob" runat="server" Visible="False">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">&gt;</asp:ListItem>
                        <asp:ListItem Value="2">&lt;</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 124px; background-color: #e8cd76; text-align: center; height: 22px;">
                </td>
                <td style="width: 185px; background-color: #e8cd76; height: 22px;">
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
                <td style="width: 110px; background-color: #e8cd76; height: 22px;">
                </td>
                <td style="width: 100px; background-color: #e8cd76; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76; height: 4px;">
                </td>
                <td style="width: 119px; background-color: #e8cd76; height: 4px;">
                </td>
                <td style="width: 124px; background-color: #e8cd76; text-align: center; height: 4px;">
                </td>
                <td style="width: 185px; background-color: #e8cd76; height: 4px;">
                </td>
                <td style="width: 110px; background-color: #e8cd76; height: 4px;">
                </td>
                <td style="width: 100px; background-color: #e8cd76; height: 4px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: #e8cd76">
                </td>
                <td style="width: 119px; background-color: #e8cd76">
                </td>
                <td style="width: 124px; background-color: #e8cd76; text-align: center">
                </td>
                <td style="width: 185px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; background-color: #e8cd76">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 119px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 124px; height: 19px; background-color: #e8cd76; text-align: center">
                </td>
                <td style="width: 185px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 110px; height: 19px; background-color: #e8cd76">
                </td>
                <td style="width: 100px; height: 19px; background-color: #e8cd76">
                </td>
            </tr>
        </table>
        </table>
    </div>
</asp:Content>
