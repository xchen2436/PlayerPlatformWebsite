<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Profile" %>


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
            <asp:HyperLink NavigateUrl="Store.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">↩Back</asp:HyperLink>
            </div>
        <p>
            <asp:Label ID="LabelUsernameDisplay" runat="server" Text="Username : " CssClass="lbl"></asp:Label>
            <asp:Label ID="LabelUsernameInfo" runat="server" Text="LabelUsernameInfo" CssClass="lblInfo"></asp:Label><br/>
            <asp:Label ID="Label1" runat="server" Text="Good rate : " CssClass="lbl"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="LabelGood" CssClass="lblInfo"></asp:Label>
            <asp:Button ID="ButtonChangePassword" runat="server" OnClick="ButtonChangePassword_Click" Text="Change Password" CssClass="btn"/><br/>
            <asp:Label ID="LabelCurrentBalanceDisplay" runat="server" Text="CurrentBalance : " CssClass="lbl"></asp:Label>
            <asp:Label ID="LabelCurrentBalanceInfo" runat="server" Text="LabelCurrentBalanceInfo" CssClass="lblInfo"></asp:Label>
             <asp:Button ID="ButtonPayment" runat="server" OnClick="ButtonPayment_Click" Text="Manage my payment" CssClass="btn"/>
            <asp:Button ID="ButtonViewSellItem" runat="server" OnClick="ButtonViewSellItem_Click" Text="View Items Sold" CssClass="btn"/>
            <asp:Button ID="ButtonViewBuyHistory" runat="server" OnClick="ButtonViewBuyHistory_Click" Text="Transaction History" CssClass="btn"/><br/>

            <asp:Label ID="LabelEmailDisplay" runat="server" Text="Email : " CssClass="lbl"></asp:Label>
            <asp:Label ID="LabelEmailInfo" runat="server" Text="LabelEmailInfo" CssClass="lblInfo"></asp:Label>
            <asp:Button ID="ButtonChangeEmail" runat="server" OnClick="ButtonChangeEmail_Click" Text="Change Email" CssClass="btnChangeEmail"/>
        </p>
    </form><br><br><br><br><br>
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

