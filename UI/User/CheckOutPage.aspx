<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="CheckOutPage.aspx.cs" Inherits="UI.User.CheckOutPage" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div>
    <div>
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
                <li class="active"><a><span class="badge pull-right"><p runat="server" id="amount"></p></span> Amount To Pay</a>
                </li>
            </ul>
                </div>
            </div>
            
    </div>
    <div  class="container-fluid">	
	    <h1>Enter Shipping Details</h1><br />
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;">
                    <label style="float:right;font-size:130%;margin:3px;padding:initial;">Name:</label>
                </div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtName" MaxLength="30" runat="server" CssClass="form-control" placeholder="Enter Name" AutoPostBack="False" /><asp:RequiredFieldValidator ID="NameValidator" runat="server" ErrorMessage="*Name Required" ControlToValidate="TxtName" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                                
		</div><br />
                
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">E-mail:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtEmail" MaxLength="30" runat="server" CssClass="form-control" placeholder="Enter E-mail" /><asp:RequiredFieldValidator ID="Emailvalidatorrequired" runat="server" ErrorMessage="*Email Required" ControlToValidate="TxtEmail" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Email Invalid" ControlToValidate="TxtEmail" SetFocusOnError="True" ValidationExpression='\w+[@][a-z]+[\.][a-z]{2,5}' ForeColor="Red"></asp:RegularExpressionValidator>
				</div>
			</div><br />
       
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">Mobile Number:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtMobile" MaxLength="10" runat="server" CssClass="form-control" placeholder="Enter Mobile Number" /><asp:RequiredFieldValidator ID="RequiredMobileValidator" runat="server" ErrorMessage="*Mobile Number Required" ControlToValidate="TxtMobile" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="MobileNumberValidator" runat="server" ErrorMessage="Mobile Number Invalid" ControlToValidate="TxtMobile" ValidationExpression="^\d{10}$" SetFocusOnError="True" ForeColor="Red"></asp:RegularExpressionValidator>
				</div>
			</div><br />
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">Address:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtAddress" MaxLength="50" runat="server" CssClass="form-control" placeholder="Enter Address" /><asp:RequiredFieldValidator ID="AddressValidator" runat="server" ErrorMessage="*Address Empty" SetFocusOnError="True" ForeColor="Red" ControlToValidate="TxtAddress"></asp:RequiredFieldValidator>
				</div>
			</div><br />		
             
        <div class="control-group">
				<label class="control-label"></label>
				<div class="controls">
					<asp:Button ID="btnContinue" Text="Continue" runat="server" Class="btn btn-primary" OnClick="btnContinue_Click"   />
				</div>
            <br />
		</div>
    </div>
</div>
</asp:Content>
