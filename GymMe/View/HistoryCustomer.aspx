<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Customer.Master" AutoEventWireup="true" CodeBehind="HistoryCustomer.aspx.cs" Inherits="GymMe.View.HistoryCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="TransactionID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" InsertVisible="False" ReadOnly="True" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
            <asp:CommandField ButtonType="Button" HeaderText="Details" ShowHeader="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" SelectCommand="SELECT TransactionID, TransactionDate FROM TransactionHeader"></asp:SqlDataSource>
</asp:Content>
