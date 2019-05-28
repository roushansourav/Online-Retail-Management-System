<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="SignUp.aspx.cs" Inherits="UI.User.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div  class="container-fluid">	
	    <h1>Registration Form</h1><br />
        <asp:Label ID="RedirectMessage" runat="server" Visible="false"></asp:Label>
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;">
                    <label style="float:right;font-size:130%;margin:3px;padding:initial;">Name:</label>
                </div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Enter Name" AutoPostBack="False" MaxLength="30" /><asp:RequiredFieldValidator ID="NameValidator" runat="server" ErrorMessage="*Name Required" ControlToValidate="TxtName" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                                
		</div><br />
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">Username:</label></div>
                <div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" placeholder="Enter Username" AutoPostBack="False" MaxLength="30"/><asp:RequiredFieldValidator ID="UsernameValidator" runat="server" ErrorMessage="*Username Required" ControlToValidate="TxtUsername" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                
			</div><br />
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">Password:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" MaxLength="30" placeholder="Enter Password" TextMode="Password" /><asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="*Password Required" SetFocusOnError="True" ControlToValidate="TxtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                
			</div><br />
        
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">E-mail:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
					<asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Enter E-mail" /><asp:RequiredFieldValidator ID="Emailvalidatorrequired" runat="server" ErrorMessage="*Email Required" ControlToValidate="TxtEmail" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Email Invalid" ControlToValidate="TxtEmail" SetFocusOnError="True" ValidationExpression='\w+[@][a-z]+[\.][a-z]{2,5}' ForeColor="Red"></asp:RegularExpressionValidator>
				</div>
			</div><br />
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">Date Of Birth:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
                    
					<asp:TextBox ID="TxtDob" runat="server" CssClass="form-control" placeholder="Enter DOB" textmode="Date"/><asp:RequiredFieldValidator ID="RequiredDOBValidator" runat="server" ErrorMessage="*DOB Required" ControlToValidate="TxtDob" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="DateValidator" runat="server" ErrorMessage="Invalid Date" ControlToValidate="TxtDob" ValidationExpression="^\d{4}(-)(((0)[0-9])|((1)[0-2]))(-)([0-2][0-9]|(3)[0-1])$" SetFocusOnError="True" ForeColor="Red"></asp:RegularExpressionValidator>
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
        <div class="control-group row"style="padding-left:10%;padding-right:10%;" >
                <div class="font-weight-bold col-sm-3" style="display:inline-block;"><label style="float:right;font-size:130%;margin:3px;padding:initial;">Sex:</label></div>				
				<div class="controls col-sm-6"style="display:inline-block;">
                    <div style="float:left;">
                        <asp:RadioButton Checked="true" ID="Male" runat="server" CssClass="radio-inline" GroupName="Sex" Text="Male"/>
					    <asp:RadioButton ID="Female" runat="server" CssClass="radio-inline" GroupName="Sex" Text="Female"/>
                        <asp:RadioButton ID="Other" runat="server" CssClass="radio-inline" GroupName="Sex" Text="Others"/>
                    </div>
                    
				</div>
			</div><br />
             
        <div class="control-group">
				<label class="control-label"></label>
				<div class="controls">
					<asp:Button ID="btnSignUp" Text="Register" runat="server" Class="btn btn-primary" OnClick="btnSignUp_Click"   />
				</div>
            <br />
		</div>
    </div>
</asp:Content>