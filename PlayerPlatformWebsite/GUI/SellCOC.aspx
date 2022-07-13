<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellCOC.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.SellCOC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sell</title>
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
                        PlayerPlateform
					</h1>
				</ul>
			</nav>
	</header>
        <br>
            <div>
            <asp:HyperLink NavigateUrl="Sell.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">↩Back</asp:HyperLink>
            </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="You want to sell Clash of Clans account " CssClass="lbl" Style="font-size:32px;"></asp:Label><br/>
            <asp:Label ID="Label16" runat="server" Text="TownHall Level: " CssClass="lbl"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="lbl">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                </asp:DropDownList><br/>
            <asp:Label ID="Label3" runat="server" Text="Gem: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxGem" runat="server"  CssClass="txtNewEmail"> </asp:TextBox><br>
            <asp:Label ID="Label6" runat="server" Text="Simple Description: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxDescription" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label7" runat="server" Text="Price: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxPrice" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label8" runat="server" Text="Upload Image: " CssClass="lbl"></asp:Label>
            <asp:FileUpload ID="FileUploadImg" runat="server" CssClass="txtNewEmail"/><br/><br/>
            <asp:Label ID="Label9" runat="server" Text="We will ask your account info to help us to check! " CssClass="lbl" Style="font-size:25px;"></asp:Label><br/>
            <asp:Label ID="Label10" runat="server" Text="Account Email: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label11" runat="server" Text="Account Password: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" textmode ="Password" CssClass="txtNewEmail"></asp:TextBox><br/>
            <br>
            <asp:Button ID="ButtonNext" runat="server" OnClick="ButtonNext_Click" Text="Next" CssClass="btnEmailFormSave"/>
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
