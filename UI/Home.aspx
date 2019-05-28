<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="Home.aspx.cs" Inherits="UI.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
 <div id="saleCarousel" class="carousel slide" data-ride="carousel" style="position:relative;top:-20px;">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" style="align-items:center;">
    <div class="item active">
      <img src="../Assets/Images/Homepage/sales1.jpeg" alt="sale1" style="width:100%;height:350px;">
    </div>

    <div class="item">
      <img src="../Assets/Images/Homepage/sales2.jpg"  alt="sale2"  style="width:100%;height:350px;">
    </div>

    <div class="item">
      <img src="../Assets/Images/Homepage/sales3.jpg"  alt="sale3"  style="width:100%;height:350px;">
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#saleCarousel" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#saleCarousel" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</div>
</asp:Content>