<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminServerChangeStateLOL.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.AdminServerChangeStateLOL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
	<link href="../CSS/PurchaseStyleSheet.css" rel="stylesheet" type="text/css" />
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
                        PlayerPlateform Admin Management Page 
					</h1>
				</ul>
			</nav>
	</header>
        <br>
            <div>
            <asp:HyperLink NavigateUrl="AdmimChangeItemState.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">↩Back</asp:HyperLink>
            </div>
        <p>
             <asp:Label ID="Label9" runat="server" Text="Account Id: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxId" runat="server"  CssClass="txtNewEmail"> </asp:TextBox><br>
            <asp:Label ID="Label16" runat="server" Text="Game Server: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxServer" runat="server"  CssClass="txtNewEmail"> </asp:TextBox><br/>
            <asp:Label ID="Label3" runat="server" Text="Game Level: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxlevel" runat="server"  CssClass="txtNewEmail"> </asp:TextBox><br>
            <asp:Label ID="Label2" runat="server" Text="Rank Level: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxRank" runat="server"  CssClass="txtNewEmail"> </asp:TextBox><br>
            <asp:Label ID="Label4" runat="server" Text="Current RP(Riot Point): " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxRP" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label5" runat="server" Text="Current BE(Blue Essence): " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxBE" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label14" runat="server" Text="Number of Champions: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxChampion" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label15" runat="server" Text="Number of Skin: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxSkin" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label6" runat="server" Text="Description: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxDescription" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label7" runat="server" Text="Price: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxPrice" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label8" runat="server" Text="Image: " CssClass="lbl"></asp:Label><br/>
            <asp:Image ID="Image1" runat="server" ControlStyle-Width="500" ItemStyle-Width="500" ControlStyle-Height="300" ItemStyle-Height="300" CssClass="lbl"/><br/>
            <asp:Label ID="Label10" runat="server" Text="AccountUsername: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label11" runat="server" Text="AccountPassword: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <br><br><br>
            <asp:Label ID="Label1" runat="server" Text="Please choose one... " CssClass="lbl"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="lbl">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Good to go</asp:ListItem>
                <asp:ListItem>Incorrect price</asp:ListItem>
                <asp:ListItem>Incorrect phote</asp:ListItem>
                <asp:ListItem>Incorrect information</asp:ListItem>
                </asp:DropDownList><br/>
            <asp:Button ID="ButtonNext" runat="server" OnClick="ButtonNext_Click" Text="I guarantee that I have verified the information" CssClass="btnEmailFormSave" style="width:40%;"/>
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
