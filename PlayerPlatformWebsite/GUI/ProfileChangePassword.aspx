<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileChangePassword.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.ProfileChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
	<link href="../CSS/PurchaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 	<header>
		<nav class="container">
				<ul>
					<img src="../image/WebIcon.png" id="icon">
                    <li>
				<asp:Label ID="LabelUsername" runat="server" CssClass="labelUser" ForeColor="White"></asp:Label>
					<asp:Button ID="ButtonLogOut" runat="server" OnClick="ButtonLogOut_Click" Text="LogOut" CssClass="btnLogout"/>
					</li>
					<h1 id="title">
                        PlayerPlateform
					</h1>
				</ul>
			</nav>
	</header>
        <br>
            <div>
            <asp:HyperLink NavigateUrl="Profile.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">↩Back</asp:HyperLink>
            </div>
        <p>
            <asp:Label ID="LabelNewPasswordDisplay" runat="server" Text="New Password: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxNewPassword" runat="server"  TextMode="Password" CssClass="txtNewEmail"></asp:TextBox><br/><br/>
            <asp:Label ID="LabelNewPasswordDisplayConfirm" runat="server" Text="Confirm Password: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxNewPasswordConfirm" runat="server"  TextMode="Password" CssClass="txtNewEmail"></asp:TextBox><br/><br/>
            <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" CssClass="btnEmailFormSave"/>
        </p>
    </form><br/><br/><br/><br/><br/>
    </body>
       <footer id="footer">
            <nav id="navbar">
                <div class="container">
                    <ul>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="Service.aspx" runat="server" CssClass="Hyper">Terms of Service</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="Privacy.aspx" runat="server" CssClass="Hyper">Privacy Policy</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="About.aspx" runat="server" CssClass="Hyper">About Us</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="Contact.aspx" runat="server" CssClass="Hyper">Contact Us</asp:HyperLink></li>
                    </ul>
                </div>
    </nav>
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>
