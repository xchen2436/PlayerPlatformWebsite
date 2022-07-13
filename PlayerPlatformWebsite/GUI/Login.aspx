<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../CSS/LoginStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div>
                <asp:Button ID="ButtonBackHome" runat="server" OnClick="ButtonBackHome_Click" Text="Home" CssClass="btnBack"/>
            </div>
        <div>
             <asp:Label ID="LabelWelcome" runat="server" Text="LOGIN ACCOUNT" CssClass="labelWelcome"></asp:Label>
        </div>
        <div>
             <asp:Label ID="LabelUsername" runat="server" Text="Username :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
         <div>
             <asp:Label ID="LabelPassword" runat="server" Text="Password :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="txtEnter"></asp:TextBox>
        </div>
        <div>
             <img src="./CheckCode.aspx" alt="Code" style="width: 70px; height: 24px;margin-left:35px;"/><br>
             <asp:Label ID="LabelCheckCode" runat="server" Text="Verification Code :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxCheckCode" runat="server" CssClass="txtSmallEnter"></asp:TextBox>
        </div>

        <div>
             <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" CssClass="btn"/>
        </div>
        <div>
            <asp:HyperLink NavigateUrl="FindPassword.aspx" runat="server" CssClass="Hyper">Forgot your password?</asp:HyperLink>
        </div>
        <div>
             <asp:HyperLink NavigateUrl="Register.aspx" runat="server" CssClass="Hyper">Need an account? Register here</asp:HyperLink>
        </div>

        
    </form>
</body>
</html>
