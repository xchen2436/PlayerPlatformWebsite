<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service</title>
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
                <asp:Label ID="Label1" runat="server" Text="Terms of Service" CssClass="labelTitle"></asp:Label>
                </div><br> 
                <div>
                     <asp:Label ID="Label2" runat="server" Text="Welcome to PlayerPlateform!" CssClass="labelPolicy"></asp:Label>&nbsp;<br/><br/>
                     <asp:Label ID="Label7" runat="server" Text="Our Service :" CssClass="labelPolicy"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Our services allow users to register and log in to our website, and allows users to buy and sell game accounts." CssClass="labelPolicy"></asp:Label><br/>
                     <asp:Label ID="Label8" runat="server" Text="Who may use the Service?" CssClass="labelPolicy"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="You must be at least 13 years old to use the Service." CssClass="labelPolicy"></asp:Label><br />
                     <asp:Label ID="Label4" runat="server" Text="Limitation of Liability：" CssClass="labelPolicy"></asp:Label><br />
                     <asp:Label ID="Label9" runat="server" Text="EXCEPT AS REQUIRED BY APPLICABLE LAW, PLAYERPLATEFORM, ITS AFFILIATES, OFFICERS," CssClass="labelPolicy"></asp:Label>
                     <br />
                     <asp:Label ID="Label10" runat="server" Text="DIRECTORS, EMPLOYEES AND AGENTS WILL NOT BE RESPONSIBLE FOR ANY LOSS OF PROFITS, REVENUES, BUSINESS" CssClass="labelPolicy"></asp:Label>
                     <br />
                     <asp:Label ID="Label11" runat="server" Text="OPPORTUNITIES, GOODWILL, OR ANTICIPATED SAVINGS; LOSS OR CORRUPTION OF DATA; INDIRECT OR CONSEQUENTIAL " CssClass="labelPolicy"></asp:Label>
                     <br />
                     <asp:Label ID="Label12" runat="server" Text="LOSS ; PUNITIVE DAMAGES CAUSED BY." CssClass="labelPolicy"></asp:Label>
                     <br />

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
