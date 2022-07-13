<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Purchase</title>
	<link href="../CSS/PurchaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
                .Hyper {
    color: mediumslateblue;
    font-family: Copperplate, Fantasy;
    margin-left: 35px;
    padding-bottom: 15px;
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
					<h1 id="title">PlayerPlateform</h1>
					<asp:Label ID="LabelBalance" runat="server" Text="Label" CssClass="labelUser"></asp:Label>
				</ul>
			</nav>
	</header>
            <br>
         <div>
            <asp:HyperLink NavigateUrl="Store.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black">↩Back</asp:HyperLink>
            </div>
        
        <p>
            <asp:ImageButton ID="ImageButtonP5" runat="server" BorderColor="#FFCCCC" BorderStyle="Inset" Height="210px" ImageAlign="AbsMiddle" ImageUrl="~/Image/Coin5$.jpg" Width="210px" CssClass="imagebtn" OnClick="ImageButtonP5_Click"/>
            <asp:ImageButton ID="ImageButtonP10" runat="server" BorderColor="Aqua" BorderStyle="Outset" Height="210px" ImageAlign="AbsMiddle" ImageUrl="~/Image/Coin10$.jpg" Width="210px" CssClass="imagebtn" OnClick="ImageButtonP10_Click"/>
            <asp:ImageButton ID="ImageButtonP20" runat="server" BorderColor="#000066" BorderStyle="Outset" Height="210px" ImageAlign="AbsMiddle" ImageUrl="~/Image/Coin20$.jpg" Width="210px" CssClass="imagebtn" OnClick="ImageButtonP20_Click"/>
            <asp:ImageButton ID="ImageButtonP50" runat="server" BorderColor="#0066FF" BorderStyle="Outset" Height="210px" ImageAlign="AbsMiddle" ImageUrl="~/Image/Coin50$.jpg" Width="210px" CssClass="imagebtn" OnClick="ImageButtonP50_Click"/>
            <asp:ImageButton ID="ImageButtonP100" runat="server" BorderColor="Red" BorderStyle="Outset" Height="210px" ImageAlign="AbsMiddle" ImageUrl="~/Image/Coin100$.jpg" Width="210px" CssClass="imagebtn" OnClick="ImageButtonP100_Click"/>
        </p>
    </form><br><br><br><br><br>
    </body>
       <footer id="footer">
            <nav id="navbar">
                <div class="container">
                    <ul>
                        <li><asp:HyperLink NavigateUrl="Service.aspx" runat="server" CssClass="Hyper">Terms of Service</asp:HyperLink></li>
                        <li><asp:HyperLink NavigateUrl="Privacy.aspx" runat="server" CssClass="Hyper">Privacy Policy</asp:HyperLink></li>
                        <li><asp:HyperLink NavigateUrl="About.aspx" runat="server" CssClass="Hyper">About Us</asp:HyperLink></li>
                        <li><asp:HyperLink NavigateUrl="Contact.aspx" runat="server" CssClass="Hyper">Contact Us</asp:HyperLink></li>
                    </ul>
                </div>
    </nav>
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>
