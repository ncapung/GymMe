<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Customer.Master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="GymMe.View.OrderSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridViewSupplement" runat="server" Width="213px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridViewSupplement_SelectedIndexChanged" DataKeyNames="SupplementID" >
            <Columns>
                <asp:BoundField DataField="SupplementID" HeaderText="SupplementID" InsertVisible="False" ReadOnly="True" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Supplement Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Supplement Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Supplement Type" SortExpression="SupplementTypeName" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="SupplementTypeID" InsertVisible="False" ReadOnly="True" SortExpression="SupplementTypeID" />
                <asp:TemplateField HeaderText="Quantity">
                    <itemtemplate>
                        <asp:TextBox ID="OrderQuantity" TextMode="Number" Width="100%" runat="server"></asp:TextBox>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" HeaderText="Order Now" SelectText="Order" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT MsSupplement.SupplementID, MsSupplement.SupplementName, MsSupplement.SupplementExpiryDate, MsSupplement.SupplementPrice, MsSupplementType.SupplementTypeName, MsSupplementType.SupplementTypeID FROM MsSupplement INNER JOIN MsSupplementType ON MsSupplement.SupplementTypeID = MsSupplementType.SupplementTypeID"></asp:SqlDataSource>
    </div>
    <asp:Label ID="ErrorLbl" runat="server" Text="Error"></asp:Label>
    <div>
        <asp:Button runat="server" Text="Cart" OnClick="Unnamed1_Click" />
    </div>
</asp:Content>
