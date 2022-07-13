<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerServer.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.CustomerServer" %>

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
            <asp:HyperLink NavigateUrl="HistoryBuy.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-left: 40px;">↩Back</asp:HyperLink>
            </div><br/>
                <div>
                <asp:Label ID="Label2" runat="server" Text="Please fill in your question below and submit" CssClass="labelTitle"></asp:Label>
                </div><br/> 
                <div>
                     <asp:Label ID="Label1" runat="server" Text="OrderId :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxId" runat="server" CssClass="txtEnter"></asp:TextBox>
                </div><br/>
                <div>
                     <asp:Label ID="Label3" runat="server" Text="Ttile :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextTitle" runat="server" CssClass="txtEnter" style = "resize:none"></asp:TextBox>
                </div><br/>
                 <div>
                     <asp:Label ID="Label4" runat="server" Text="Please describe your problem...." CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxdescribe" TextMode="MultiLine" runat="server" Height="212px" Width="591px" Style="margin-left: auto; margin-right: auto; display: block;  width: 350px; min-height: 25px; max-height: 200px; resize: none;"></asp:TextBox></div><br>
        <div><br/>
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
