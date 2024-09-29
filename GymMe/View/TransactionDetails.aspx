<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Customer.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="GymMe.View.TransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="TransactionID" runat="server" Text="Transaction Details - " Font-Size="XX-Large"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="SupplementName" HeaderText="SupplementName" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="SupplementExpiryDate" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="SupplementPrice" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" SortExpression="TransactionDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT MsSupplement.SupplementName, MsSupplement.SupplementExpiryDate, MsSupplement.SupplementPrice, TransactionDetails.Quantity, TransactionHeader.TransactionDate, TransactionHeader.Status FROM TransactionDetails INNER JOIN TransactionHeader ON TransactionDetails.TransactionID = TransactionHeader.TransactionID INNER JOIN MsSupplement ON TransactionDetails.SupplementID = MsSupplement.SupplementID"></asp:SqlDataSource>
    <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
</asp:Content>
