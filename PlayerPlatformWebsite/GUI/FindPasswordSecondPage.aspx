<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPasswordSecondPage.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.FindPasswordSecondPage" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <link href="../CSS/FindPasswordStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                 <asp:HyperLink NavigateUrl="Login.aspx" runat="server" CssClass="Hyper">Back</asp:HyperLink>
            </div>
             <div>
             <asp:Label ID="LabelWelcome" runat="server" Text="CHANGE PASSWORD" CssClass="labelWelcome"></asp:Label>  
        </div>
         <div>
             <asp:Label ID="LabelPassword" runat="server" Text="New Password :" CssClass="labelInfo"></asp:Label>
             <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelConfirmPassword" runat="server" Text="Confirm Password :" CssClass="labelInfo"></asp:Label>
            <asp:TextBox ID="TextBoxConfirmPassword" TextMode="Password" runat="server" CssClass="txtEnter"></asp:TextBox>
        </div>
            <div>
            <asp:Label ID="Label1" runat="server" Text="Verify Code :" CssClass="labelInfo"></asp:Label>
            <asp:TextBox ID="TextBoxVerificationCode" runat="server" CssClass="txtSmallEnter"></asp:TextBox>
        </div>
        <div>
             <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" CssClass="btn"/>
        </div>
            <div>
        </div>
    </form>
</body>
</html>