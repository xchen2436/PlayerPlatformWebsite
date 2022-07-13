<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAbout.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.AboutHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About Us</title>
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
                <asp:Label ID="Label1" runat="server" Text="About Us" CssClass="labelTitle"></asp:Label>
                </div><br> 
                <div>
                     <asp:Label ID="Label2" runat="server" Text="Email Address :" CssClass="labelAbout"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="PlayerPlateform@gameplateform.com" CssClass="labelAbout"></asp:Label><br/>
                     <asp:Label ID="Label7" runat="server" Text="Linkedin :" CssClass="labelAbout"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Text="https://www.linkedin.com/in/xiao-chen-835878221/" CssClass="labelAbout"></asp:Label><br/>
                     <asp:Label ID="Label8" runat="server" Text="GitHub :" CssClass="labelAbout"></asp:Label>
                            <asp:Label ID="Label10" runat="server" Text="Email Address :" CssClass="labelAbout"></asp:Label><br/>
                     <asp:Label ID="Label4" runat="server" Text="https://github.com/xchen2436" CssClass="labelAbout"></asp:Label>
                                <asp:Label ID="Label11" runat="server" Text="+1(514)444-5555" CssClass="labelAbout"></asp:Label><br/>
                     <asp:Label ID="Label5" runat="server" Text="Company Address :" CssClass="labelAbout"></asp:Label>
                                    <asp:Label ID="Label12" runat="server" Text="2000 Rue Sainte-Catherine O, Montréal, QC" CssClass="labelAbout"></asp:Label><br/>
                     <asp:Label ID="Label6" runat="server" Text="Postal code :" CssClass="labelAbout"></asp:Label>
                                        <asp:Label ID="Label13" runat="server" Text="H3H 2T2" CssClass="labelAbout"></asp:Label>
                </div>
                <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
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
