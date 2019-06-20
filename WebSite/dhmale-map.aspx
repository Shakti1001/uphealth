<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="dhmale-map.aspx.cs" Inherits="NewWebApp.WebSite.dhmale_map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CssFile/imagezoom.css" rel="stylesheet" type="text/css" />
    <link href="../CssFile/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<div class="row">
<div class="col-sm-12 text-justify">
<ul class="breadcrumb">
<li class="breadcrumb-item"><a href="index.aspx" title="Home">Home</a></li>

<li class="breadcrumb-item">District Hospital Male</li>
</ul>
<div class="h3"><center>District Hospital Male</center></div>
<div id="imag" >
<img id="myImg" src="../images1/dhmale-map.gif" alt="District Hospital Male" width="600" height="400" style="text-align:center;"/></div>
<div>&nbsp;</div>
<div id="myModal" class="modal">
  <span class="close">&times;</span>
  <img class="modal-content" id="img01" >
  <div id="caption" ></div>
</div>
 </div>
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
 </div>
</asp:Content>
