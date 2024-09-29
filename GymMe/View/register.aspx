<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="GymMe.View.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            REGISTER
        </div>
        <div>
            <asp:Label ID="usernameLbl" runat="server" Text="Username :"></asp:Label>
            <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="emailLbl" runat="server" Text="Email :"></asp:Label>
            <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="genderLbl" runat="server" Text="Gender :"></asp:Label>
            <asp:RadioButtonList ID="genderList"  runat="server">
                <asp:ListItem Text ="Male" Value ="Male"> </asp:ListItem>
                <asp:ListItem Text ="Female" Value ="Female"> </asp:ListItem>
            </asp:RadioButtonList>        
        </div>
        <div>
            <asp:Label ID="passwordLbl" runat="server" Text="Password :"></asp:Label>
            <asp:TextBox ID="passwordTxt" TextMode="Password" runat="server"></asp:TextBox>
        </div> 
        <div>
            <asp:Label ID="cpasswordLbl" runat="server" Text="Confirmation Password :"></asp:Label>
            <asp:TextBox ID="cpasswordTxt" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="dobLbl" runat="server" Text="Date of Birth :"></asp:Label>
            <asp:TextBox ID="dobTxt" TextMode="Date" runat="server"></asp:TextBox>
        </div>
        <p>
            click here to <a href="loginForm.aspx">login</a>
        </p>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text="Error Message" ForeColor ="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
        </div>
       
    </form>
</body>
</html>
