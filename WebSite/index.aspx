<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NewWebApp.WebSite.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
<link href="../CssFile/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="overlay" class="container-fluid">
    <div id="progstat"></div>
    <div id="progress"></div>
  </div>
<div>
<div class="col-sm-9 col-md-9 col-lg-9 title2">
 <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="3000">
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
    <img class="d-block w-100" src="../Images/download.jpg" width="120%" height="300px" alt="First slide"/>
     <div class="carousel-caption d-none d-md-block">
    <h5>Doctors Treating Patients</h5>
    <p>We have a well experienced group of doctors who are always ready to handle any critical situation related with the patients health.</p>
  </div>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="../Images/images (1).jpg" width="100%" height="300px" alt="Second slide"/>
       <div class="carousel-caption d-none d-md-block">
    <h5>Doctors Treating Patients</h5>
    <p>We have a well experienced group of doctors who are always ready to handle any critical situation related with the patients health.</p>
  </div>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="../Images/pexels-photo.jpg" width="100%" height="300px" alt="Third slide"/>
       <div class="carousel-caption d-none d-md-block">
    <h5>Doctors Treating Patients</h5>
    <p>We have a well experienced group of doctors who are always ready to handle any critical situation related with the patients health.</p>
  </div>
    </div>
  </div>
  <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</div>
<div>
<asp:Panel ID="Panel7" runat="server" class="col-sm-3 col-md-3 col-lg-3 title1" style="height:150;">
<div class="panel panel-group">
<div class="panel panel-primary">
<div class="panel-heading"> <center><h5> Minister</h5></center></div>

<div class="panel panel-body">
<center>
<img alt="#" src="../Images/yogi.jpg" width="150px" height="93px" class="img-circle" /></center>
<center><b>Honourable Chief Minister</b></center>
<center>Shri Yogi Adityanath Ji</center>

</div>
<div class="panel panel-body">
<center>
<img alt="#" src="../Images/siddharth-nath-singh.jpg" width="150px" height="94px" class="img-circle" /></center>
<center><b>Honourable Health Minister</b></center>
<center>Shri Siddharth Nath Singh Ji</center>

</div>
</div>
</div>
</asp:Panel>

</div>
</div>
<div>&nbsp;</div>
<div class="container" style="height:300px;">
<div class="row">
<div class="col-sm-12 wow fadeIn" data-wow-duration="6s" style="float:left;">
<div class="card" style=" height:300px;">
<div class="card card-header" style="background-color:#ff9910;">
<div class="h4"><center>News/Events<span class="glyphicon glyphicon-pushpin"></span></center></div>
</div>
<div class="card card-body position-relative">

<marquee direction="up" OnMouseOver=this.stop(); OnMouseOut=this.start(); scrollAmount="2">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
        text='<%#Eval("Description")+"&nbsp;&nbsp;&nbsp;&nbsp;"+Eval("PublishedDate").ToString()+"<br/><br/>" %>'
        NavigateUrl='<%#Eval("Link")+"\n" %>'></asp:HyperLink>
    
    </ItemTemplate>


    </asp:Repeater></marquee>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBCS %>" 
        
        
        SelectCommand="SELECT top 10 [Description], [Link], [PublishedDate], [id] FROM [Feeds] ORDER BY [id] DESC"></asp:SqlDataSource>
       

</div>
<div class="card card-footer" style="background-color:#ff9910;"><center><a href="orders.aspx" title="News" target="_blank"> Click here<span class="glyphicon glyphicon-check"></span></a></center></div>
</div>
</div>
</div>
<div>&nbsp;</div>
</div> 

<div class="col-sm-12">

<div>&nbsp;</div>
<div>
    <br />
     <br />
<div class="row">
<div class="col-sm-2 col-md-2 col-lg-2 title2 wow slideInLeft" data-wow-duration="2s">
<asp:Panel ID="Panel1" runat="server" aria-hidden="true" style="text-align:center;">
<a href="citizenCharter.aspx" target="_blank" title="Citizen Charter">
<img alt="Citizen Charter" src="../Images/citizen.jpg" width="70px" height="34px" /><h6>Citizen's Charter</h6>

</a>
</asp:Panel>
</div>
<div class="col-sm-2 col-md-2 col-lg-2 title2 wow slideInLeft" data-wow-duration="2s">
<asp:Panel ID="Panel2" runat="server" aria-hidden="true" style="text-align:center;">
<a href="directives.aspx" target="_self" title="Important Phone Numbers">
<img alt="Telephone Numbers" src="../Images/directive.jpg" width="70px" height="34px" /><br />
<h6>Directives</h6></a>

</asp:Panel>
</div>


<div class="col-sm-2 col-md-2 col-lg-2 title2 wow slideInLeft" data-wow-duration="2s">
<asp:Panel ID="Panel4" runat="server" aria-hidden="true" style="text-align:center;">
<a href="orders.aspx" target="_blank" title="Documents">
<img alt="#" src="../Images/orders.jpg" width="70px" height="34px" />
<h6>Recent Government Orders</h6></a>

</asp:Panel>
</div>
<div class="col-sm-2 col-md-2 col-lg-2 title2 wow slideInLeft" data-wow-duration="2s">
<asp:Panel ID="Panel15" runat="server" aria-hidden="true" style="text-align:center;">
<a href="transfer.aspx" target="_blank" title="Documents">
<img alt="#" src="../Images/transfer.jpg" width="70px" height="34px" />
<h6>Transfer Posting</h6></a>

</asp:Panel>
</div>
<div class="col-sm-2 col-md-2 col-lg-2 title2 wow slideInLeft" data-wow-duration="2s">
<asp:Panel ID="Panel16" runat="server" aria-hidden="true" style="text-align:center;">
<a href="rti.aspx" target="_blank" title="Documents">
<img alt="Right To Information" src="../Images/rti.png" width="70px" height="34px" />
<h6>Right To Information</h6></a>

</asp:Panel>
</div>
</div>
</div>
</div>
<div class="col-sm-12">
    <br /><br />
<div align='center'><a href='http://localhost:1060/Website/index.aspx'>You Are Visitor Number :</a><br /><a href='http://www.hit-counts.com'><img src='http://www.hit-counts.com/counter.php?t=MTQyNjg2Mg==' border='0' alt='Web Counter'></a></div>
   

</div>




  
    

 
  <!--  <script type="text/javascript">
    debugger;
var multilines = $('#multilines .newsticker').newsTicker({

row_height: 100,

speed: 800,

prevButton: $('#multilines .prev-button'),

nextButton: $('#multilines .next-button'),

stopButton: $('#multilines .stop-button'),

startButton: $('#multilines .start-button'),

});

</script>
-->

<script type="text/javascript">
    $(document).ready(function () {
        $('#myCarousel').carousel({
        //options here
    });
});
    </script>


     <script type="text/javascript">

var multilines = $('#multilines .newsticker').newsTicker({

row_height: 100, // the height (in px) of one row

max_rows: 3, // the number of rows displayed at the same time

speed: 900, //  the animation speed (in ms)of the rows moving up or down

direction: 'up', // the direction of the rows movement

time: 2500, // the times (in ms) before the rows automatically move

autostart: 1, // enable/disable auto start on load

stopOnHover: 1, // enable/disable pause when mouse hovers the newsTicker element

nextButton: null, // set the element triggering next action on click

prevButton: null, // set the element triggering previous action on click

startButton: null, // set the element triggering start action on click

stopButton: null, // set the element triggering stop action on click

hasMoved: function() {}, // function

movingUp: function() {}, // function

movingDown: function() {}, // function

start: function() {}, // function

stop: function() {}, // function

pause: function() {}, // function

unpause: function() {} // function

});

</script>
    


</asp:Content>
