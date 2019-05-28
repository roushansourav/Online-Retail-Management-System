<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="User.aspx.cs" Inherits="UI.Admin.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Admin_Master" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="uid"  ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="udate" HeaderText="Created On" SortExpression="udate" />
            <asp:BoundField DataField="uid" HeaderText="User Id" ReadOnly="True" SortExpression="uid" />
            <asp:BoundField DataField="uname" HeaderText="Name" SortExpression="uname" />
            <asp:BoundField DataField="uemail" HeaderText="Email" SortExpression="uemail" />
            <asp:BoundField DataField="ugender" HeaderText="Gender" SortExpression="ugender" />
            <asp:BoundField DataField="udob.Date" HeaderText="DOB" SortExpression="udob" />
            <asp:BoundField DataField="umobile" HeaderText="Mobile Number" SortExpression="umobile" />
            <asp:BoundField DataField="uaddress" HeaderText="Address" SortExpression="uaddress" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="False" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
</asp:Content>
