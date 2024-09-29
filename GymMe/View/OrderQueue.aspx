<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Admin.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="GymMe.View.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ORDER QUEUE</h1>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="TransactionID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" InsertVisible="False" ReadOnly="True" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:CommandField ButtonType="Button" HeaderText="Handle Order" ShowHeader="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" SelectCommand="SELECT TransactionID, TransactionDate, Status FROM TransactionHeader"></asp:SqlDataSource>
</asp:Content>
