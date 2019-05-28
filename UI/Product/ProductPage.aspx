<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="ProductPage.aspx.cs" Inherits="UI.Product.ProductPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <asp:FormView ID="productDetail" runat="server" ItemType="Model.Product" RenderOuterTable="false">
     <ItemTemplate>
         <div>
             <h1><%#:Item.Pname %></h1>

         </div>
         <br />
         <div class="table-responsive">
         <table class="table">
             <tr>
                 <td>
                     <img src="../Assets/Images/Product/<%#:Item.Pimage%>" style="border:solid; height:300px" alt="<%#:Item.Pname %>"/>

                 </td>
                 <td>&nbsp;</td>
                 <td style="vertical-align: top; text-align:left;">
                     <b>Description:</b><br /><%#:Item.Pdesc %>
                     <br />
                     <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.Pprice) %></span>
                     <br />
                     <span><b>Product Number:</b>&nbsp;<%#:Item.Pid %></span>
                     <br />
                      <a href="../User/Cart.aspx?productID=<%#:Item.Pid %>">               
                                        <span class="ProductListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>
                 </td>

             </tr>

         </table>
             </div>

     </ItemTemplate>

 </asp:FormView>

</asp:Content>
