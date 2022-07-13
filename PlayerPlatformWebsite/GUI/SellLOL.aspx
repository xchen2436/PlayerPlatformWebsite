<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellLOL.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.SellLOL" %>

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
            <asp:Label ID="Label1" runat="server" Text="You want to sell League of Legend account " CssClass="lbl" Style="font-size:32px;"></asp:Label><br/>
            <asp:Label ID="Label16" runat="server" Text="Game Server: " CssClass="lbl"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="lbl">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>EU</asp:ListItem>
                <asp:ListItem>KR</asp:ListItem>
                <asp:ListItem>JP</asp:ListItem>
                </asp:DropDownList><br/>
            <asp:Label ID="Label3" runat="server" Text="Gamge Level: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxlevel" runat="server"  CssClass="txtNewEmail"> </asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Rank Level: " CssClass="lbl"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="lbl">
                <asp:ListItem>Unrank</asp:ListItem>
                <asp:ListItem>Iron IV</asp:ListItem>
                <asp:ListItem>Iron III</asp:ListItem>
                <asp:ListItem>Iron II</asp:ListItem>
                <asp:ListItem>Iron I</asp:ListItem>
                <asp:ListItem>Bronze IV</asp:ListItem>
                <asp:ListItem>Bronze III</asp:ListItem>
                <asp:ListItem>Bronze II</asp:ListItem>
                <asp:ListItem>Bronze I</asp:ListItem>
                <asp:ListItem>Silver IV</asp:ListItem>
                <asp:ListItem>Silver III</asp:ListItem>
                <asp:ListItem>Silver II</asp:ListItem>
                <asp:ListItem>Silver I</asp:ListItem>
                <asp:ListItem>Gold IV</asp:ListItem>
                <asp:ListItem>Gold III</asp:ListItem>
                <asp:ListItem>Gold I</asp:ListItem>
                <asp:ListItem>Platinum IV</asp:ListItem>
                <asp:ListItem>Platinum III</asp:ListItem>
                <asp:ListItem>Platinum II</asp:ListItem>
                <asp:ListItem>Platinum I</asp:ListItem>
                <asp:ListItem>Diamond IV</asp:ListItem>
                <asp:ListItem>Diamond III</asp:ListItem>
                <asp:ListItem>Diamond II</asp:ListItem>
                <asp:ListItem>Diamond I</asp:ListItem>
                <asp:ListItem>Master</asp:ListItem>
                <asp:ListItem>Grandmaster</asp:ListItem>
                <asp:ListItem>Challenger</asp:ListItem>
            </asp:DropDownList>
            <br>
            <asp:Label ID="Label4" runat="server" Text="Current RP(Riot Point): " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxRP" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label5" runat="server" Text="Current BE(Blue Essence): " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxBE" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label14" runat="server" Text="Number of Champions: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxChampion" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label15" runat="server" Text="Number of Skin: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxSkin" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label6" runat="server" Text="Simple Description: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxDescription" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label7" runat="server" Text="Price: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBoxPrice" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label8" runat="server" Text="Upload Image: " CssClass="lbl"></asp:Label>
            <asp:FileUpload ID="FileUploadImg" runat="server" CssClass="txtNewEmail"/><br/><br/>
            <asp:Label ID="Label9" runat="server" Text="We will ask your account info to help us to check! " CssClass="lbl" Style="font-size:25px;"></asp:Label><br/>
            <asp:Label ID="Label10" runat="server" Text="Account Username: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"  CssClass="txtNewEmail"></asp:TextBox><br/>
            <asp:Label ID="Label11" runat="server" Text="Account Password: " CssClass="lbl"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" textmode ="Password" CssClass="txtNewEmail"></asp:TextBox><br/>
            <br>
            <asp:Button ID="ButtonNext" runat="server" OnClick="ButtonSave_Click" Text="Next" CssClass="btnEmailFormSave"/>
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

