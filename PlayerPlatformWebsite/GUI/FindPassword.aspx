<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.FindPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="../CSS/FindPasswordStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                 <asp:HyperLink NavigateUrl="Login.aspx" runat="server" CssClass="Hyper">Back</asp:HyperLink>
            </div>
             <div>
             <asp:Label ID="LabelWelcome" runat="server" Text="FORGOT PASSWORD" CssClass="labelWelcome"></asp:Label>  
        </div>
         <div>
             <asp:Label ID="LabelUsername" runat="server" Text="Username :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelEmail" runat="server" Text="Email Address :" CssClass="labelInfo"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
        <div>
             <asp:Button ID="ButtonSendPassword" runat="server" OnClick="ButtonSendPassword_Click" Text="Send" CssClass="btn"/>
        </div>
            <div>
        </div>
    </form>
</body>
</html>
