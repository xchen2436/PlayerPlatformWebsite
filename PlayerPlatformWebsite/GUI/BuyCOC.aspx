<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeBehind="BuyCOC.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.BuyCOC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store</title>
	<link href="../CSS/StoreStyleSheet.css" rel="stylesheet" type="text/css" />
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
        <br><br>
        <div>
            <asp:HyperLink NavigateUrl="Buy.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-left:30px">↩Back</asp:HyperLink><br><br>
        
            <asp:Label ID="Label1" runat="server" ForeColor="Black" CssClass="server">TownHall Level</asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
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
                </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" ForeColor="Black">Price</asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem> </asp:ListItem>
                <asp:ListItem>$0-$50</asp:ListItem>
                <asp:ListItem>$50-$100</asp:ListItem>
                <asp:ListItem>$100-$300</asp:ListItem>
                <asp:ListItem>$300-$500</asp:ListItem>
                <asp:ListItem>Over $500</asp:ListItem>
                </asp:DropDownList>
            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" CssClass="btn" style="margin-left:15px;"/>
            <asp:Button ID="ButtonClear" runat="server" OnClick="ButtonClear_Click" Text="Clear Form" CssClass="btn" style="margin-left:15px;"/>
            </div><br/>
        <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" UseAccessibleHeader="true" HeaderStyle-CssClass="header" EnableViewState="false" RowStyle-CssClass="rows" AllowPaging="True" OnRowDataBound="datagrid_RowDataBound" OnSelectedIndexChanged="datagrid_SelectedIndexChanged">
            <Columns>
                <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ControlStyle-Width="150" ItemStyle-Width="150" ControlStyle-Height="150" ItemStyle-Height="150" />

            </Columns>
        </asp:GridView>
        <asp:Label ID="Label6" runat="server" ForeColor="Black" CssClass="lbl"></asp:Label>
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