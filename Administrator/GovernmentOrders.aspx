<%@ Page Title="::Orders::" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="GovernmentOrders.aspx.cs" Inherits="NewWebApp.Administrator.GovernmentOrders" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="col-sm-12">
    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="od" 
        Text="Government Orders" AutoPostBack="True" 
        oncheckedchanged="RadioButton1_CheckedChanged" />  
    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="od" 
        Text="Transfer/Posting" AutoPostBack="True" 
        oncheckedchanged="RadioButton2_CheckedChanged" /> 
    </div>
    <asp:Table ID="Table1" runat="server" class="table table-responsive-sm table-active">
    <asp:TableRow><asp:TableCell colspan="4" align="right"><asp:LinkButton class="btn btn-danger" 
        ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell colspan="4" align="center" style="color:black; font-size:x-large" ><b>Government Orders Upload</b></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Title :</asp:TableCell>
<asp:TableCell style="width:250px;"><asp:TextBox class="form-control" ID="TextBox1" placeholder="Enter The Title Of Order" runat="server" required></asp:TextBox> </asp:TableCell>
<asp:TableCell style="width:300px;"> </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Description :</asp:TableCell>
<asp:TableCell style="width:250px;"><asp:TextBox class="form-control" ID="TextBox2" placeholder="Description" runat="server" required></asp:TextBox> </asp:TableCell>
<asp:TableCell style="width:300px;"> </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Order Date :</asp:TableCell>
<asp:TableCell style="width:250px;"> <ajx:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajx:ToolkitScriptManager>
    <link href="../CssFile/CSS.css" rel="stylesheet" type="text/css" />
    <script src="../JsFile/Extension.min.js" type="text/javascript"></script>
<asp:TextBox ID="TextBox3" placeholder="dd/mm/yyyy" runat="server" CssClass="disable_past_dates"  required></asp:TextBox>

                                <ajx:CalendarExtender ID="Calendar1" PopupButtonID="Imagecal" runat="server" TargetControlID="TextBox3"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender>
 </asp:TableCell>
 <asp:TableCell style="width:300px;"><asp:Image ID="Imagecal" runat="server" ImageUrl="~/Proforma2/calender/cal_img/cal.gif" /> </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Upload Order :</asp:TableCell>
<asp:TableCell style="width:250px;"> <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" required />
 <asp:TableCell style="width:300px;"> </asp:TableCell>

 </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell colspan="4" align="center"><asp:Button ID="Button1" class="btn btn-success" 
        runat="server" Text="Button" onclick="Button1_Click" /> </asp:TableCell>

</asp:TableRow>
<asp:TableRow>
<asp:TableCell colspan="4">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </asp:TableCell>
  </asp:TableRow>

    </asp:Table>

    <asp:Table ID="Table2" runat="server" class="table table-responsive-sm table-active">
   <asp:TableRow><asp:TableCell colspan="4" align="right"><asp:LinkButton class="btn btn-danger" 
        ID="LinkButton2" runat="server" onclick="LinkButton1_Click"><span class="glyphicon glyphicon-backward"></span>Back</asp:LinkButton> </asp:TableCell></asp:TableRow>
<asp:TableRow>
<asp:TableCell colspan="4" align="center" style="color:black; font-size:x-large" ><b>Transfer/Posting Orders Upload</b></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Title :</asp:TableCell>
<asp:TableCell style="width:250px;"><asp:TextBox class="form-control" ID="TextBox4" placeholder="Enter The Title Of Order" runat="server" required></asp:TextBox> </asp:TableCell>
<asp:TableCell style="width:300px;"> </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Description :</asp:TableCell>
<asp:TableCell style="width:250px;"><asp:TextBox class="form-control" ID="TextBox5" placeholder="Description" runat="server" required></asp:TextBox> </asp:TableCell>
<asp:TableCell style="width:300px;"> </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Order Date :</asp:TableCell>
<asp:TableCell style="width:250px;"> 
<asp:TextBox class="form-control" ID="TextBox6" placeholder="dd/mm/yyyy" runat="server" required></asp:TextBox>

                                <ajx:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image1" runat="server" TargetControlID="TextBox6"
    Format="dd/MM/yyyy">
</ajx:CalendarExtender>
 </asp:TableCell>
 <asp:TableCell style="width:300px;"><asp:Image ID="Image1" runat="server" ImageUrl="~/Proforma2/calender/cal_img/cal.gif" /> </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell style="width:300px;"> </asp:TableCell>
<asp:TableCell style="width:40px;"> Upload Order :</asp:TableCell>
<asp:TableCell style="width:250px;"> <asp:FileUpload class="form-control" ID="FileUpload2" runat="server" required />
 <asp:TableCell style="width:300px;"> </asp:TableCell>

 </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell colspan="4" align="center"><asp:Button ID="Button2" class="btn btn-success" 
        runat="server" Text="Button" onclick="Button2_Click" /> </asp:TableCell>

</asp:TableRow>
<asp:TableRow>
<asp:TableCell colspan="4">
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </asp:TableCell>
   </asp:TableRow>

    </asp:Table>

</div>
</asp:Content>
