<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="NewWebApp.Administrator.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-sm-12 col-xs-12">
<div class="card" style="background-color:#6666ff;">

<div class="card card-header" style="color:White;">
<center><b>Registration Form</b></center>
</div>

<div class="card card-body">
<table class="table table-responsive-sm" width="90%">
<tr>
<th style="width:170px;">Your IP Address Is :- </th>
<th style="width:300px;"><asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Text="Label"></asp:Label> </th>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">GPF Number :- </th>
<td style="width:300px;"><asp:TextBox ID="TextBox1" runat="server" class="form-control" name="name" style="width:100px;" required></asp:TextBox> </td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Name :- </th>
<td style="width:300px;"><asp:TextBox ID="TextBox2" runat="server" class="form-control" name="name" required></asp:TextBox> </td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Father's Name :- </th>
<td style="width:300px;"><asp:TextBox ID="TextBox3" runat="server" class="form-control" name="name" required></asp:TextBox> </td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Gender :- </th>
<td style="width:300px;"><asp:RadioButton ID="male" runat="server" Text="Male" GroupName="gen" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="female" runat="server" Text="Female" GroupName="gen" /></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Date Of Birth :- </th>
<td style="width:300px;"><asp:TextBox ID="TextBox4" runat="server" class="form-control" name="name" required></asp:TextBox>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Home District :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList1"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Previous Home District :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList2"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Category Id :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList3"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Sub Category :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList4"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Cadre :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList5"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:150px;">Cadre Serial No :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList6"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:200px;">Date Of Appointment :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList7"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:200px;">Date Of Joining :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList8"  class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:200px;">Date Of Confirmation :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList9" class="form-control" runat="server"></asp:DropDownList>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:200px;">Degree 1 :- </th>
<td style="width:300px;"><asp:DropDownList ID="DropDownList10" class="form-control" runat="server"></asp:DropDownList>
</td>
<th style="width:200px;">Specialization# :-</th>
<td><asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Degree 2 :- </th>
<td style="width:200px;"><asp:DropDownList ID="DropDownList11" class="form-control" runat="server"></asp:DropDownList>
</td>
<th>Specialization# :-</th>
<td><asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Degree 3 :- </th>
<td style="width:200px;"><asp:DropDownList ID="DropDownList12" class="form-control" runat="server"></asp:DropDownList>
</td>
<th>Specialization# :-</th>
<td><asp:TextBox ID="TextBox7" class="form-control" runat="server"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Level :- </th>
<td style="width:200px;"><asp:DropDownList ID="DropDownList13" class="form-control" runat="server"></asp:DropDownList>
</td>
<th>&nbsp;</th>
<td>&nbsp;</td>
</tr>
<tr>
<th style="width:200px;">Couple Id :- </th>
<td style="width:200px;"><asp:TextBox ID="TextBox8" class="form-control" runat="server"></asp:TextBox></td>
<th>Couple Name :-</th>
<td><asp:TextBox ID="TextBox9" class="form-control" runat="server"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Local Address :- </th>
<td style="width:200px;"><asp:TextBox ID="TextBox10" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox></td>
<th>Permanent Address :-</th>
<td><asp:TextBox ID="TextBox11" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Creator User Id :- </th>
<td style="width:200px;"><asp:TextBox ID="TextBox12" class="form-control" runat="server" ReadOnly="True"></asp:TextBox></td>
<th>Last Update Time :-</th>
<td><asp:TextBox ID="TextBox13" class="form-control"  runat="server" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Posting Status:- </th>
<td style="width:200px;"><asp:DropDownList ID="DropDownList14" class="form-control" runat="server"></asp:DropDownList> </td>
<th>Order No :-</th>
<td><asp:TextBox ID="TextBox15" class="form-control"  runat="server" ReadOnly="false"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Current Date:- </th>
<td style="width:200px;"><asp:TextBox ID="TextBox16" class="form-control"  runat="server" ReadOnly="true"></asp:TextBox></td>
<th>Cadre Status :-</th>
<td><asp:TextBox ID="TextBox14" class="form-control"  runat="server" ReadOnly="false"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Order By:- </th>
<td style="width:200px;"><asp:DropDownList ID="DropDownList15" class="form-control" runat="server"></asp:DropDownList></td>
<th>Modifier User Id :-</th>
<td><asp:TextBox ID="TextBox18" class="form-control"  runat="server" ReadOnly="True"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">Cadre Seniority:- </th>
<td style="width:200px;"><asp:TextBox ID="TextBox19" class="form-control"  runat="server" ReadOnly="false"></asp:TextBox></td>
<th>Update Date :-</th>
<td><asp:TextBox ID="TextBox17" class="form-control"  runat="server" ReadOnly="false"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">BoApp</th>
<td style="width:200px; text-align:center;"><asp:TextBox ID="TextBox20" class="form-control" runat="server"></asp:TextBox></td>
<th style="width:200px;">Email Id :-</th>
<td><asp:TextBox ID="TextBox21" name="email" type="email" class="form-control" runat="server"></asp:TextBox></td>
</tr>
<tr>
<th style="width:200px;">&nbsp;</th>
<td style="width:200px; text-align:center;"><asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server"><span class="glyphicon glyphicon-send"></span>Submit</asp:LinkButton></td>
<td style="width:200px; text-align:center;"><asp:LinkButton ID="LinkButton2" class="btn btn-danger" runat="server"><span class="glyphicon glyphicon-refresh"></span>Reset</asp:LinkButton> </td>
<td>&nbsp;</td>
</tr>

</table>

</div>

</div>
<br />
</div>

</asp:Content>
