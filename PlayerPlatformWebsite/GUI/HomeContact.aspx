<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeContact.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.ContactHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
	<link href="../CSS/HomeStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 248px;
            height: 149px;
        }
    </style>
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
                <asp:Label ID="Label1" runat="server" Text="Contact Us" CssClass="labelTitle"></asp:Label>
                </div><br> 
                <div>
                     <asp:Label ID="Label2" runat="server" Text="Email Address :" CssClass="labelContact"></asp:Label><br><br>
                     <asp:TextBox ID="TextEmail" runat="server" CssClass="txtEnter"></asp:TextBox><br><br>
                </div>
                 <div>
                     <asp:Label ID="Label3" runat="server" Text="Write something...." CssClass="labelContact"></asp:Label><br><br>
                     <textarea id="TextArea1" name="S1" style="text-align: center;
    margin-left: auto;
    margin-right: auto;
    display: block;" class="auto-style1"></textarea></div><br>
        <div>
             <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" CssClass="btn"/>
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