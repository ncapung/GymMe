<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Customer.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GymMe.View.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="SupplementID">
        <Columns>
            <asp:BoundField DataField="SupplementName" HeaderText="SupplementName" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="SupplementPrice" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="SupplementExpiryDate" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementTypeName" HeaderText="SupplementTypeName" SortExpression="SupplementTypeName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="SupplementID" HeaderText="SupplementID" InsertVisible="False" ReadOnly="True" SortExpression="SupplementID" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT MsSupplement.SupplementName, MsSupplement.SupplementPrice, MsSupplement.SupplementExpiryDate, MsSupplementType.SupplementTypeName, MsCart.Quantity, MsSupplement.SupplementID FROM MsCart INNER JOIN MsSupplement ON MsSupplement.SupplementID = MsCart.SupplementID INNER JOIN MsSupplementType ON MsSupplement.SupplementTypeID = MsSupplementType.SupplementTypeID INNER JOIN MsUser ON MsUser.UserID = MsCart.UserID AND MsCart.UserID = MsUser.UserID"></asp:SqlDataSource>
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" />
    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
</asp:Content>
