<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Regitser</title>
<link href="../CSS/RegisterStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div>
            <div>
                <asp:Button ID="ButtonBackHome" runat="server" OnClick="ButtonBackHome_Click" Text="Home" CssClass="btnBack"/>
            </div>
             <div>
             <asp:Label ID="LabelWelcome" runat="server" Text="CREATE ACCOUNT" CssClass="labelWelcome"></asp:Label>  
        </div>
         <div>
             <asp:Label ID="LabelUsername" runat="server" Text="Username :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="txtEnter"></asp:TextBox>
             <asp:Button ID="ButtonCheck" runat="server" OnClick="ButtonCheck_Click" Text="Check" CssClass="btn"/>
        </div>
        <div>
            <asp:Label ID="LabelEmail" runat="server" Text="Email Address :" CssClass="labelInfo"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
        <div>
             <asp:Button ID="ButtonSendEmailCode" runat="server" OnClick="ButtonSendEmailCode_Click" Text="Send Verification Code" CssClass="btn"/>
        </div>
        <div>
            <asp:Label ID="LabelEmailCode" runat="server" Text="Verification Code :" CssClass="labelInfo"></asp:Label>
            <asp:TextBox ID="TextBoxVerificationCode" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
            <div>
             <asp:Label ID="LabelPassword" runat="server" Text="Password :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="txtEnter"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password :" CssClass="labelInfo"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password" CssClass="txtEnter"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonRegister" runat="server" OnClick="ButtonRegister_Click" Text="Register" CssClass="btn"/>
        </div>
            <div>
             <asp:HyperLink NavigateUrl="Login.aspx" runat="server" CssClass="Hyper">Already have an account? Signin here</asp:HyperLink>
        </div>
        </div>
    </form>
</body>
</html>
