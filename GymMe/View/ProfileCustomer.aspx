<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Customer.Master" AutoEventWireup="true" CodeBehind="ProfileCustomer.aspx.cs" Inherits="GymMe.View.ProfileCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Customer Profile</h1>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server" Text=""></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="EmailTxt" runat="server" TextMode="Email" Text=""></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="genderLbl" runat="server" Text="Gender :"></asp:Label>
        <asp:RadioButtonList ID="genderList"  runat="server">
            <asp:ListItem Text ="Male" Value ="Male"> </asp:ListItem>
            <asp:ListItem Text ="Female" Value ="Female"> </asp:ListItem>
        </asp:RadioButtonList>        
    </div>

    <div>
        <asp:Label ID="Label5" runat="server" Text="Date of Birth: "></asp:Label>
        <asp:TextBox ID="DOBTxt" runat="server" TextMode="Date"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Update Profile" OnClick="Button1_Click" />

    <h3>Update Password</h3>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Old Password: "></asp:Label>
        <asp:TextBox ID="opasswordTxt" TextMode="Password" runat="server"></asp:TextBox>
    </div> <div>
        <asp:Label ID="Label6" runat="server" Text="New Password: "></asp:Label>
        <asp:TextBox ID="npasswordTxt" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLbl1" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="UpdatePwdBtn" runat="server" Text="Update Password" OnClick="UpdatePwdBtn_Click" />
    </div>

</asp:Content>
