<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Sell" %>


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
					
				</ul>
			</nav>
	</header>
        <br><br>
        <div>
            <asp:HyperLink NavigateUrl="Store.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-left:30px">↩Back</asp:HyperLink><br><br>
            <asp:Label ID="LabelTitle" runat="server" Text="Choose one of the game you want to sell" CssClass="labelTitle"></asp:Label>
            </div>
        <p>
            <asp:ImageButton ID="ImageButtonLOL" runat="server" BorderColor="#FFCCCC" BorderStyle="Inset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/GameIcon/league-of-legends.jpg" Width="250px" CssClass="imagebtn" OnClick="ImageButtonLOL_Click"/>
            <asp:ImageButton ID="ImageButtonCOC" runat="server" BorderColor="Aqua" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/GameIcon/Clash-of-Clans.jpg" Width="250px" CssClass="imagebtn" OnClick="ImageButtonCOC_Click"/>
            <asp:ImageButton ID="ImageButtonFIFA" runat="server" BorderColor="Yellow" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/GameIcon/FIFA-22.jpeg" Width="250px" CssClass="imagebtn" OnClick="ImageButtonFIFA_Click"/>
            <asp:ImageButton ID="ImageButtonR6" runat="server" BorderColor="Green" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/GameIcon/Rainbow-Six.jpg" Width="250px" CssClass="imagebtn" OnClick="ImageButtonR6_Click"/>
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
