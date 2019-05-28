<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="ProductListSearch.aspx.cs" Inherits="UI.Category.ProductListSearch" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<asp:ListView ID="productList" runat="server" DataKeyNames="Pid" GroupItemCount="4" ItemType="Model.Product">
         <EmptyDataTemplate>
             <table class="container-fluid">
                 <tr>
                     <td>No Prod.</td>
                 </tr>
             </table>
         </EmptyDataTemplate>
         <EmptyItemTemplate>
             <td/>
         </EmptyItemTemplate>
         <GroupTemplate>
             <tr id="itemPlaceholderContainer" runat="server">
                 <td id="itemPlaceholder" runat="server"></td>
             </tr>
         </GroupTemplate>
         <ItemTemplate>
             <!--
             <td runat="server">
                 <table>
                     <tr>
                         <td>
                             <a href="../Product/ProductPage.aspx?productID=<%#:Item.Pid%>"> 
                                        <img src="../Assets/Images/Product/<%#:Item.Pimage%>"
                                            width="300" height="225" style="border: none" /></a>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <a href="../Product/ProductPage.aspx?productID=<%#:Item.Pid%>">
                                 <span>
                                     <%#:Item.Pname%>
                                 </span>
                             </a>
                             <br />
                             <span>
                                 <b>Price: </b><%#:String.Format("{0:c}", Item.Pprice)%>
                             </span>
                             <br />
                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
                 </table>
                 </p>
             </td>-->
             <div class="card stretched-link shadow-lg p-3 mb-5 bg-white rounded" style="width:400px;display:inline;">
                    <a href="../Product/ProductPage.aspx?productID=<%#:Item.Pid%>">
                    <img class="card-img-top" src="../Assets/Images/Product/<%#:Item.Pimage%>" alt="Product image" height="250" width="300">
                    <div class="card-body">
                    <h4 class="card-title"><%#:Item.Pname%></h4>
                    <p class="card-text"><b>Price: </b><%#:String.Format("{0:c}", Item.Pprice)%></p>
                    </a>
                    <a href="../User/Cart.aspx?productID=<%#:Item.Pid %>" class="btn btn-primary">Add To Cart</a>
            </div>
</div>
         </ItemTemplate>
         <LayoutTemplate>
             <table style="width:100%;">
                 <tbody>
                     <tr>
                         <td>
                             <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                 <tr id="groupPlaceholder"></tr>

                             </table>

                         </td>

                     </tr>
                     <tr>
                         <td></td>

                     </tr>
                     <tr></tr>

                 </tbody>

             </table>

         </LayoutTemplate>

     </asp:ListView>
</asp:Content>