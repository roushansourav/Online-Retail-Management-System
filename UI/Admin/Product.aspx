<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="Product.aspx.cs" Inherits="UI.Admin.Product" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="Admin_Master" runat="server">
  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="pid" ForeColor="#333333" GridLines="None">
      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      <Columns>
          <asp:BoundField DataField="pid" HeaderText="Product Id" ReadOnly="True" SortExpression="pid" />
          <asp:BoundField DataField="pname" HeaderText="Product Name" SortExpression="pname" />
          <asp:BoundField DataField="pimage" HeaderText="Product Image" SortExpression="pimage" />
          <asp:BoundField DataField="scid" HeaderText="Category Id" SortExpression="scid" />
          <asp:BoundField DataField="pstock" HeaderText="Stock Left" SortExpression="pstock" />
          <asp:BoundField DataField="pdesc" HeaderText="Description" SortExpression="pdesc" />
          <asp:BoundField DataField="pprice" HeaderText="Price" SortExpression="pprice" />
          <asp:BoundField DataField="pbrand" HeaderText="Brand" SortExpression="pbrand" />
          <asp:BoundField DataField="pgender" HeaderText="Gender" SortExpression="pgender" />
          
      </Columns>
      <EditRowStyle BackColor="#999999" />
      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
      <SortedAscendingCellStyle BackColor="#E9E7E2" />
      <SortedAscendingHeaderStyle BackColor="#506C8C" />
      <SortedDescendingCellStyle BackColor="#FFFDF8" />
      <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
