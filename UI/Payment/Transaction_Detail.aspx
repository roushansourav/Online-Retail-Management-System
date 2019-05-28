<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="Transaction_Detail.aspx.cs" Inherits="UI.Payment.Transaction_Detail" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="display:inline-block;">
    <div class="row">
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
                </div>
            </div>
            
        </div>


        <div class="col-xs-12 col-md-4">
            <div class="panel panel-default">
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
                        Payment Details
                    </h3>
                    
                </div>
                <div class="panel-body">
                    
                    <div class="form-group">
                        <label for="cardNumber">
                            CARD NUMBER</label>
                        <div class="input-group">
                        <asp:RegularExpressionValidator ID="RegularExpressionCardValidator" runat="server" ErrorMessage="*Enter Valid Card Number" ControlToValidate="DebitCard" ValidationExpression="\d{4}-\d{4}-\d{4}-\d{4}" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox maxlength="20" placeholder="####-####-####-####" ID="DebitCard" CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="CardNumberValidator" runat="server" ErrorMessage="*Card Number Required" ControlToValidate="DebitCard" ForeColor="Red"></asp:RequiredFieldValidator>
                           <!-- <input runat="server" type="text" class="form-control" id="cardNumber" title="Debit Card Number" pattern="\d{4}-\d{4}-\d{4}-\d{4}" placeholder="####-####-####-####"
                                required autofocus />-->
                           
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-7 col-md-7">
                            <div class="form-group">
                                <label for="expityMonth">
                                    EXPIRY DATE</label>
                                <div class="col-xs-6 col-lg-6 pl-ziro">
                            
                                    <asp:TextBox ID="ExpiryMonth" maxlength="2" CssClass="form-control" runat="server" placeholder="MM" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMonth" runat="server" ErrorMessage="*Month Required" ControlToValidate="ExpiryMonth"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidatorMonth" runat="server" ErrorMessage="*Month Out of Bound" Type="Integer" MaximumValue="12" MinimumValue="1" ForeColor="Red" ControlToValidate="ExpiryMonth"></asp:RangeValidator></div>
                                <div class="col-xs-6 col-lg-6 pl-ziro">
                                    <asp:TextBox ID="ExpiryYear" maxlength="2" CssClass="form-control" runat="server" placeholder="YY"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorYear" runat="server" ErrorMessage="*Year Required" ControlToValidate="ExpiryYear"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorYear" runat="server" ErrorMessage="*Valid Year" ValidationExpression="\d{2}" ControlToValidate="ExpiryYear"></asp:RegularExpressionValidator>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="">
                            <div class="form-group">
                                <asp:TextBox ID="CVVCode" CssClass="form-control" MaxLength="3" runat="server" TextMode="Password" placeholder="CVV" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCVV" runat="server" ErrorMessage="*Enter Valid CVV" ControlToValidate="CVVCode" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCVV" runat="server" ErrorMessage="*CVV Required" ControlToValidate="CVVCode"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
            <ul class="nav nav-pills nav-stacked">
                <li class="active"><a><span class="badge pull-right"><p runat="server" id="amount"></p></span> Amount To Pay</a>
                </li>
            </ul>
            <br/>
                        <asp:Button ID="BtnConfirm" runat="server" Text="Confirm Payment" class="btn btn-success" OnClick="BtnConfirm_Click" />
            
        </div>

    </div>
    </div>
</asp:Content>