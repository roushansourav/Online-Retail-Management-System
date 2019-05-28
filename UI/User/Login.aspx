<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master.Master" CodeBehind="Login.aspx.cs" Inherits="UI.User.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
   <div style="max-width: 400px;"class="container-fluid">
    <h2 class="form-signin-heading">
        Login</h2>
    
    <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" placeholder="Enter Username" AutoPostBack="False" />
    <br />
       <asp:RequiredFieldValidator ID="UserNameValidator" runat="server" ErrorMessage="*Username Required" ControlToValidate="TxtUsername" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    
    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password"  AutoPostBack="False" />
       <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="*Password Required" ControlToValidate="TxtPassword" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
    <div class="checkbox">
    <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" CssClass="checkbox" AutoPostBack="False" /><asp:HyperLink ID="HLnkSignUp" runat="server" CssClass="btn-link" NavigateUrl="~/User/SignUp.aspx">Sign Up</asp:HyperLink> | 
    <asp:HyperLink ID="HLnkFrgtPwd" runat="server" CssClass="btn-link">Forgot Password</asp:HyperLink>
    </div>
    <asp:Button ID="btnLogin" Text="Login" runat="server" Class="btn btn-primary" OnClick="btnLogin_Click" />
    <br />
    <br />
    <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        <strong>Error!</strong>
        <asp:Label ID="lblMessage" runat="server" />
    </div>
</div>
</asp:Content>