<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginForm.aspx.cs" Inherits="GymMe.View.loginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            LOGIN
        </div>
        <div>
            <asp:Label ID="usernameLbl" runat="server" Text="Username :"></asp:Label>
            <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox>
        </div>        
        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password :"></asp:Label>
            <asp:TextBox ID="passwordTxt" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="CB" Text="Remember Me" runat="server" />
        </div>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text="Error Message" ForeColor ="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="loginBtn" runat="server" Text="LOGIN" OnClick="loginBtn_Click" />
        </div>
    </form>
</body>
</html>
