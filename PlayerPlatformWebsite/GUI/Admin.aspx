<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
	<link href="../CSS/PurchaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
					<h1 id="title">
                        PlayerPlateform Admin Management Page 
					</h1>
				</ul>
			</nav>
	</header>
        <br>
        <p>
            <asp:ImageButton ID="ImageButtonrequest" runat="server" BorderColor="#FFCCCC" BorderStyle="Inset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/User.jpg" Width="500px" CssClass="imagebtn" style="margin-left:300px;" OnClick="ImageButtonrequest_Click"/>
            <asp:ImageButton ID="ImageButtonItemState" runat="server" BorderColor="Aqua" BorderStyle="Outset" Height="250px" ImageAlign="AbsMiddle" ImageUrl="~/Image/Item.png" Width="500px" CssClass="imagebtn" OnClick="ImageButtonItemState_Click"/>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" CssClass="labelUser" style="margin-left:350px;" ForeColor="black">View user's requests</asp:Label>
            <asp:Label ID="Label2" runat="server" CssClass="labelUser" style="margin-left:275px;" ForeColor="black">View user's items</asp:Label>
    </form><br><br><br><br><br>
    </body>
       <footer id="footer">
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>

