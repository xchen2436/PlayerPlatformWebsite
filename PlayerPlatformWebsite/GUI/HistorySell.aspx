<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorySell.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.HistorySell" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
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
                        PlayerPlateform
					</h1>
				</ul>
			</nav>
	</header>
        <br/>
            <div>
            <asp:HyperLink NavigateUrl="Profile.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">↩Back</asp:HyperLink>
            </div>

        <div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Buy History" CssClass="btnT"/>
            </div><br/><br/>
        <asp:Label ID="LabelItemDisplay" runat="server" Text="Click to view your transaction history..." CssClass="lbl" Style="font-size:40px;" ></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="" CssClass="lbl" Style="font-size:40px;" ></asp:Label>

        <br/><br/><br/>
        <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" UseAccessibleHeader="true" HeaderStyle-CssClass="header" EnableViewState="false" RowStyle-CssClass="rows" AllowPaging="True" >
            <Columns>

            </Columns>
        </asp:GridView>

    </form><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
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