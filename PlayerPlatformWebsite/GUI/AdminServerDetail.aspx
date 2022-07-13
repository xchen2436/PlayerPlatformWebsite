<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminServerDetail.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.AdminServerDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
	<link href="../CSS/HomeStyleSheet.css" rel="stylesheet" type="text/css" />
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
            <asp:HyperLink NavigateUrl="AdminServer.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black" Font-Bold="true" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin-left:30px">↩Back</asp:HyperLink><br><br>
            <div>
                     <asp:Label ID="Label1" runat="server" Text="OrderId :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxId" runat="server" CssClass="txtEnter"></asp:TextBox>
                </div><br/>
                <div>
                     <asp:Label ID="Label3" runat="server" Text="Ttile :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextTitle" runat="server" CssClass="txtEnter" style = "resize:none"></asp:TextBox>
                </div><br/>
                 <div>
                     <asp:Label ID="Label4" runat="server" Text="Describe of the problem :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxdescribe" TextMode="MultiLine" runat="server" Height="212px" Width="591px" Style="margin-left: auto; margin-right: auto; display: block;  width: 350px; min-height: 25px; max-height: 200px; resize: none;"></asp:TextBox>
                 </div><br>
                <div>
                     <asp:Label ID="Label6" runat="server" Text="Requester :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxRequester"  runat="server" CssClass="txtEnter" style = "resize:none"></asp:TextBox>
                 </div><br>
                <div>
                     <asp:Label ID="Label5" runat="server" Text="Date :" CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxDate"  runat="server" CssClass="txtEnter" style = "resize:none"></asp:TextBox>
                 </div><br>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Please Reply Here...." CssClass="labelContact"></asp:Label>
                     <asp:TextBox ID="TextBoxReply" TextMode="MultiLine" runat="server" Height="212px" Width="591px" Style="margin-left: auto; margin-right: auto; display: block;  width: 350px; min-height: 25px; max-height: 200px; resize: none;"></asp:TextBox>
                </div><br>
                <div>
             <asp:Button ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" Text="Submit" CssClass="btn"/>
        </div><br/><br/><br/><br/><br/>


        </p>
    </form><br><br><br><br><br>
    </body>
       <footer id="footer">
        <p>Copyright &copy; 2022 - PlayerPlateform</p>
    </footer>
</html>