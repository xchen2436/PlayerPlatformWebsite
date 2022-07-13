<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePrivacy.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.HomePrivacy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
	<link href="../CSS/HomeStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
 	<header>
		<nav class="container">
				<ul>
					<img src="../image/WebIcon.png" id="icon">
					<li><a href="../PublicChat.aspx"> Join the Public Chat room</a></li>
					<li><a href="Register.aspx"> Register</a></li>
					<li><a href="Login.aspx"> Login</a></li>
					<li><a href="Home.aspx"> Home</a></li>
					<h1 id="title">PlayerPlateform</h1>
				</ul>
			</nav>
	</header>
	<section>
        <br/> 
        <div>
            <asp:HyperLink NavigateUrl="Home.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black">↩Back</asp:HyperLink>
            </div>
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
    </form>
</body>

	<footer id="footer">
            <nav id="navbar">
                <div class="container">
                    <ul>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="HomeService.aspx" runat="server" CssClass="Hyper">Terms of Service</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="HomePrivacy.aspx" runat="server" CssClass="Hyper">Privacy Policy</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="HomeAbout.aspx" runat="server" CssClass="Hyper">About Us</asp:HyperLink></li>
                        <li style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"><asp:HyperLink NavigateUrl="HomeContact.aspx" runat="server" CssClass="Hyper">Contact Us</asp:HyperLink></li>
                    </ul>
                </div>
    </nav>
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>