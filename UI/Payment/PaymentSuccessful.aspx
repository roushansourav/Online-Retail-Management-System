<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="PaymentSuccessful.aspx.cs" Inherits="UI.Payment.PaymentSuccessful" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order Received</h1>
    <div class="row">
    <div class="col-xs-12 col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Payment Successful
                    </h3>
                   
                </div>
                <div class="panel-body">
                    <div><h4>OrderId:</h4><p runat="server" id="OrderId"></p></div>
                    <div><h4>PaymentId:</h4><p runat="server" id="PaymentId"></p></div>
                </div>
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Shipping Details
                    </h3>                   
                </div>
                <div class="panel-body">
                    <div><p runat="server" id="Name"></p></div>
                    <div><p runat="server" id="Email"></p></div>
                    <div><p runat="server" id="Contact"></p></div>
                    <div><p runat="server" id="Address"></p></div>
                </div>
            </div>            
    </div>
    <div class="col-xs-12 col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Cart Summary
                    </h3>                    
                </div>
                <div class="panel-body">
                    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Horizontal" CellPadding="4"
                        ItemType="Model.Cart" 
                        CssClass="table table-striped table-bordered" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" >   
                        <Columns>
                        <asp:TemplateField   HeaderText="Image">            
                                <ItemTemplate>
                                    <img src="../Assets/Images/Product/<%#:Item.Pimage%>" width="30" height="30" style="border: none" />
                                </ItemTemplate>        
                        </asp:TemplateField>  
                               
                        <asp:BoundField DataField="Amount" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
                        <asp:TemplateField   HeaderText="Quantity" >            
                                <ItemTemplate>
                                    <%#: Item.Quantity %>
                                </ItemTemplate>        
                        </asp:TemplateField>    
                        <asp:TemplateField HeaderText="Item Total">            
                                <ItemTemplate>
                                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Amount)))%>
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
                    <ul class="nav nav-pills nav-stacked">
                <li class="active"><a><span class="badge pull-right"><p runat="server" id="amount"></p></span> Amount Paid</a>
                </li>
            </ul>
                </div>
            </div>
            
        </div>
    </div>


</asp:Content>
