<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Privacy.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Privacy" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Privay</title>
	<link href="../CSS/HomeStyleSheet.css" rel="stylesheet" type="text/css" />
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
	<section>
        <br/>    
        <div>
            <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Back" CssClass="btnBack"/>
            </div>
        <div>
                <div>
                <asp:Label ID="Label1" runat="server" Text="Privacy Policy" CssClass="labelTitle"></asp:Label>
                </div><br> 
                <div>
                     <asp:Label ID="Label2" runat="server" Text="Your use of the Gamer Platform service means that you trust the way we handle your information." CssClass="labelPolicy"></asp:Label><br><br>
                     <asp:Label ID="Label4" runat="server" Text="We know how important this responsibility is and are committed to protecting your information and giving you control." CssClass="labelPolicy"></asp:Label><br><br>
                     <asp:Label ID="Label5" runat="server" Text="Information We Collect When You Use PlayerPlateform Services" CssClass="labelPolicy"></asp:Label><br><br>
                     <asp:Label ID="Label6" runat="server" Text="• EmailAddress" CssClass="labelPolicy"></asp:Label><br><br>
                     <asp:Label ID="Label7" runat="server" Text="We will not disclose personal information" CssClass="labelPolicy"></asp:Label><br><br>
                     <asp:Label ID="Label8" runat="server" Text="Our customer service will not ask you for any personal information" CssClass="labelPolicy"></asp:Label><br><br>
                </div>
                 <div>
                     <br><br>
                     </div><br>
        <div>
        </div><br/><br/><br/><br/><br/>
	</section>
	</section>
    </form>
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
