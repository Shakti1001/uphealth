<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="usercharge.aspx.cs" Inherits="NewWebApp.WebSite.usercharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../CssFile/paging.css" rel="stylesheet" type="text/css" />
    <link href="../CssFile/imagezoom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="row">
<div class="col-sm-12 text-justify">
<ul class="breadcrumb">
<li class="breadcrumb-item"><a href="index.aspx" title="Home">Home</a></li>
<!--<li class="breadcrumb-item"><a href="norms.aspx" title="Home">Government Norms</a></li>-->
<li class="breadcrumb-item">User Charge</li>
</ul>
<div class="h3"><center>User Charge</center></div>
<div id="imag" >
<img id="myImg" src="../images1/user_1.jpg" alt="User Charges" width="400" height="600" style="text-align:center;"/>
</div>
<div id="myModal" class="modal">
  <span class="close">&times;</span>
  <img class="modal-content" alt="" id="img01" >
  <div id="caption" ></div>
</div>


  </div>
</div>
<center>
<div class="pagination">

  <a href="index.aspx">&laquo;</a>
  <a href="usercharge1.aspx">1</a> 
  <a href="usercharge2.aspx">2</a> 
  <a href="usercharge3.aspx">3</a> 
  <a href="usercharge4.aspx">4</a> 
  <a href="usercharge5.aspx">5</a> 
  <a href="usercharge6.aspx">6</a> 
  <a href="usercharge7.aspx">7</a> 
  <a href="usercharge8.aspx">8</a> 
  <a href="usercharge9.aspx">9</a> 
  <a href="usercharge10.aspx">10</a> 
  <a href="usercharge11.aspx">11</a> 
  <a href="usercharge12.aspx">&raquo;</a>
 
</div>
 </center>
</div>
<script type="text/javascript">
    // Get the modal
    var modal = document.getElementById('myModal');

    // Get the image and insert it inside the modal - use its "alt" text as a caption
    var img = document.getElementById('myImg');
    var modalImg = document.getElementById("img01");
    var captionText = document.getElementById("caption");
    img.onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
    }

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }
</script>
</asp:Content>
