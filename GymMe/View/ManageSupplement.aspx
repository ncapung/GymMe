<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Admin.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="GymMe.View.ManageSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Supplement</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" DataKeyNames="SupplementID"> 
        <Columns>
            <asp:BoundField DataField="SupplementID" HeaderText="SupplementID" SortExpression="SupplementID" />
            <asp:BoundField DataField="SupplementName" HeaderText="SupplementName" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="SupplementExpiryDate" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="SupplementPrice" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="SupplementTypeName" HeaderText="SupplementTypeName" SortExpression="SupplementTypeName" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
        </Columns>

    </asp:GridView>
    <div>
       </asp:Label> <asp:Button ID="InsertBtn" runat="server" Text="INSERT" OnClick="InsertBtn_Click" />
    </div>
</asp:Content>
