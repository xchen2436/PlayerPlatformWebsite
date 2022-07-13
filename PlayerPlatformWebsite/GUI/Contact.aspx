<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Contact" %>

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
                <asp:Label ID="Label2" runat="server" Text="Contact Us" CssClass="labelTitle"></asp:Label>
                </div><br> 
                <div>
                     <asp:Label ID="Label3" runat="server" Text="Email Address :" CssClass="labelContact"></asp:Label><br><br>
                     <asp:TextBox ID="TextEmail" runat="server" CssClass="txtEnter"></asp:TextBox><br><br>
                </div>
                 <div>
                     <asp:Label ID="Label4" runat="server" Text="Write something...." CssClass="labelContact"></asp:Label><br><br>
                     <textarea id="TextArea1" name="TextArea1" style="margin-left: text-align: center;
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
