<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Admin.Master" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="GymMe.View.UpdateSupplement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Supplement</h1>
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
        <asp:Label ID="errorLbl" runat="server" Text="Error"></asp:Label>
    </div>
    <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
    <asp:Button ID="ConfirmBtn" runat="server" Text="Update" OnClick="ConfirmBtn_Click" />
</asp:Content>
