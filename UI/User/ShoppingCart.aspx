<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="ShoppingCart.aspx.cs" Inherits="UI.User.ShoppingCart" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Horizontal" CellPadding="4" ItemType="Model.Cart" CssClass="table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" >   
        <Columns>
        <asp:BoundField DataField="Pid" HeaderText="ID" SortExpression="ProductID" />
        <asp:TemplateField   HeaderText="Image">            
                <ItemTemplate>
                    <img src="../Assets/Images/Product/<%#:Item.Pimage%>"
                                            width="30" height="30" style="border: none" /> 
                </ItemTemplate>        
        </asp:TemplateField>  
        <asp:BoundField DataField="Pname" HeaderText="Name" />        
        <asp:BoundField DataField="Amount" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
        <asp:TemplateField   HeaderText="Quantity" >            
                <ItemTemplate>
                    <asp:TextBox min="1" max="6" TextMode="number" ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Amount)))%>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
        <br/>
        <br />
        <span class="container-fluid">
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="BtnUpdate_Click"/>
            <span style="margin-left:100px;"><asp:Button ID="BtnCheckOut" runat="server" Text="CheckOut" CssClass="btn btn-primary" OnClick="BtnCheckOut_Click"/></span>
        </span>
        <br />
    </div>
    </asp:Content>