<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Store" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store</title>
	<link href="../CSS/StoreStyleSheet.css" rel="stylesheet" type="text/css" />
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
					<asp:Label ID="LabelBalance" runat="server" Text="Label" CssClass="labelUser"></asp:Label>
				</ul>
			</nav>
	</header>
        <br><br><br><br><br>
        <p>
            <asp:ImageButton ID="ImageButtonProfile" runat="server" BorderColor="#FFCCCC" BorderStyle="Inset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/iconProfile.png" Width="250px" CssClass="imagebtn" OnClick="ImageButtonProfile_Click"/>
            <asp:ImageButton ID="ImageButtonPurchase" runat="server" BorderColor="Aqua" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/iconPurchase.png" Width="250px" CssClass="imagebtn" OnClick="ImageButtonPurchase_Click"/>
            <asp:ImageButton ID="ImageButtonBuy" runat="server" BorderColor="#000066" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/iconBuy.jpg" Width="250px" CssClass="imagebtn" OnClick="ImageButtonBuy_Click"/>
            <asp:ImageButton ID="ImageButtonSell" runat="server" BorderColor="#0066FF" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/iconSell.jpg" Width="250px" CssClass="imagebtn" OnClick="ImageButtonSell_Click"/>
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
