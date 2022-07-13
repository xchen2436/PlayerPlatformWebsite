<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseCard.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.ChooseCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
	<link href="../CSS/PurchaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">


        .Hyper {
    color: mediumslateblue;
    font-family: Copperplate, Fantasy;
    margin-left: 35px;
    padding-bottom: 15px;
}


        </style>
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
					<h1 id="title">PlayerPlateform</h1>
				</ul>
			</nav>
	</header>
        <br/>
         <div>
            <asp:HyperLink NavigateUrl="Purchase.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black">↩Back</asp:HyperLink>
            </div>
        <br/>
            <asp:Label ID="LabelPrice" runat="server" Text="Total Price : " CssClass="lblPrice"></asp:Label>
            <asp:Label ID="LabelHint" runat="server" Text="" CssClass="lblPrice" Style="font-size:15px;"></asp:Label><br/>
        <div runat="server" id="AutoFill">
            <asp:Label ID="Label1" runat="server" Text="CardNumber" Style="color: #B4886B; font-weight: bold; width: 150px; margin-left:650px;"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="CVV:" Style="color: #B4886B; font-weight: bold; width: 150px; margin-left:15px;"></asp:Label>
            <asp:TextBox ID="TextBoxCVV" runat="server" Style="background: white; border: 1px solid #DDD; border-radius: 5px; box-shadow: 0 0 5px #DDD inset; color: #666; outline: none; height:25px; width: 50px;"></asp:TextBox>
            <asp:Button ID="Button" runat="server" OnClick="Button_Click" Text="Purchase" Style="background: linear-gradient(to bottom right, #EF4765, #FF9A5A);border: 0;border-radius: 8px;color: #FFFFFF;cursor: pointer;display: inline-block;font-family: -apple-system,system-ui,Segoe UI,Roboto,Helvetica,Arial,sans-serif;font-size: 12px;font-weight: 500;line-height: 2.5;outline: transparent;padding: 0 1rem;text-align: center;text-decoration: none;transition: box-shadow .2s ease-in-out;user-select: none;-webkit-user-select: none;touch-action: manipulation;white-space: nowrap; margin-left:15px;"/>
        </div>
        <asp:Button ID="ButtonAddCard" runat="server" OnClick="ButtonAddCard_Click" Text="Add a card" CssClass="btn"/>

        <asp:Button ID="ButtonPayment" runat="server" OnClick="ButtonPayment_Click" Text="I decide to use another card" CssClass="btn"/>

    </form><br/><br/><br/><br/><br/>

    </body>
       <footer id="footer">
            <nav id="navbar">
                <div class="container">
                    <ul>
                        <li><asp:HyperLink NavigateUrl="Service.aspx" runat="server" CssClass="Hyper">Terms of Service</asp:HyperLink></li>
                        <li><asp:HyperLink NavigateUrl="Privacy.aspx" runat="server" CssClass="Hyper">Privacy Policy</asp:HyperLink></li>
                        <li><asp:HyperLink NavigateUrl="About.aspx" runat="server" CssClass="Hyper">About Us</asp:HyperLink></li>
                        <li><asp:HyperLink NavigateUrl="Contact.aspx" runat="server" CssClass="Hyper" >Contact Us</asp:HyperLink></li>
                    </ul>
                </div>
    </nav>
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>
