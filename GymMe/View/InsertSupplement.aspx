<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Admin.Master" AutoEventWireup="true" CodeBehind="InsertSupplement.aspx.cs" Inherits="GymMe.View.InsertSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>INSERT SUPPLEMENT</h1>
    <div>
        <asp:Label runat="server" Text="Supplement Name: "></asp:Label>
        <asp:TextBox ID="SNameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" Text="Supplement Expiry Date: "></asp:Label>
        <asp:TextBox ID="SExpTxt" runat="server" TextMode="Date"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" Text="Supplement Price: "></asp:Label>
        <asp:TextBox ID="SPriceTxt" runat="server" TextMode="Number"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" Text="Supplement Type ID: "></asp:Label>
        <asp:TextBox ID="STypeTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <asp:Button ID="InsertBtn" runat="server" Text="INSERT" OnClick="InsertBtn_Click" />
</asp:Content>
