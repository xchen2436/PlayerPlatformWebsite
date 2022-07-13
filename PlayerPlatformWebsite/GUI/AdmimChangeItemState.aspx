<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AdmimChangeItemState.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.AdmimChangeItemState" %>

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
        <br/>
            <div>
            <asp:HyperLink NavigateUrl="Admin.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">↩Back</asp:HyperLink>
            </div>

        <div>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="lbl" AutoPostBack = "true" >
                <asp:ListItem>Please select a game</asp:ListItem>
                <asp:ListItem>League of Legends</asp:ListItem>
                <asp:ListItem>Clash of Clans</asp:ListItem>
                </asp:DropDownList><br/>
            </div>
        <asp:Label ID="LabelItemDisplay" runat="server" Text="" CssClass="lbl" Style="font-size:40px;" ></asp:Label>
        <br/>
        <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" AutoGenerateColumns="false" UseAccessibleHeader="true" HeaderStyle-CssClass="header" EnableViewState="false" RowStyle-CssClass="rows" AllowPaging="True" OnRowDataBound="datagrid_RowDataBound" OnSelectedIndexChanged="datagrid_SelectedIndexChanged">
            <Columns>

            </Columns>
        </asp:GridView>

    </form><br/><br/>
    </body>
       <footer id="footer">
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>

