<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About</title>
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
