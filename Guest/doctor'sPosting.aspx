<%@ Page Title="" Language="C#" MasterPageFile="~/Guest/Site1.Master" AutoEventWireup="true" CodeBehind="doctor'sPosting.aspx.cs" Inherits="NewWebApp.Guest.doctor_sPosting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
 <div class=""> 
    
     <nav aria-label="breadcrumb">     
  <ol class="breadcrumb"> 
    <li class="breadcrumb-item" ><a href="../Authenticate/login.aspx">Home</a></li>   
    <li class="breadcrumb-item disabled" ><a>Doctor's Posting</a></li>   
  </ol> 
</nav>
</div>
    
     </div>
     

<div class="col-sm-12">
<div class="row">

<div class="offset-3"></div>
<div class="col-sm-6">
<div class="card bg-primary">

<div class="card card-header text-light">
<b>Medical Section/P2/Currently Posted Doctor's</b>

</div>
<div class="card card-body">
    <table class="table table-responsive-sm">
    <tr>
    <th>District</th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <td><asp:DropDownList ID="DropDownList1" class="form-control" runat="server" 
            style="width:200px; float:right;" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
           >
    
    
    
    </asp:DropDownList> </td>    
    </tr>
    <tr>
    <th>Hospital Type</th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <td><asp:DropDownList ID="DropDownList2" class="form-control" runat="server" 
            style="width:200px; float:right;" AutoPostBack="True" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
   
    
    
    </asp:DropDownList> </td>    
    </tr>
    <tr>
    <th>Hospital Name</th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <td><asp:DropDownList ID="DropDownList3" class="form-control" runat="server" 
            style="width:200px; float:right;" AutoPostBack="True" >
    

    
    
    </asp:DropDownList> </td>    
    </tr>
    <tr>
    <th>Post</th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <td><asp:DropDownList ID="DropDownList4" class="form-control" runat="server" 
            style="width:200px; float:right;" 
           >
    

    
    
    </asp:DropDownList> </td>    
    </tr>
    <tr>
    <th>Cadre</th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <td><asp:DropDownList ID="DropDownList5" class="form-control" runat="server" 
            style="width:200px; float:right;">
    

    
    
    </asp:DropDownList> </td>    
    </tr>
    <tr>
    <th>Level</th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <td><asp:DropDownList ID="DropDownList6" class="form-control" runat="server" 
            style="width:200px; float:right;" >
   

    
    
    </asp:DropDownList> </td>    
    </tr>
       
    
    
    </table>
     <div style="align:center; text-align:center;">
     <asp:Button ID="Button1" runat="server" class="bg-success text-justify" 
             Text="Submit" onclick="Button1_Click" />
     </div>
</div>


</div>


</div>
<div class="offset-3"></div>
</div>
</div>
<div>&nbsp;</div>
</asp:Content>
