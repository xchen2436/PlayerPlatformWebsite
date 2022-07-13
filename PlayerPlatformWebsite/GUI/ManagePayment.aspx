<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePayment.aspx.cs" Inherits="PlayerPlatformWebsite.GUI.ManagePayment" %>

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
					</li>
					<h1 id="title">PlayerPlateform</h1>
				</ul>
			</nav>
	</header>
        <br/>
         <div>
            <asp:HyperLink NavigateUrl="Profile.aspx" runat="server" CssClass="Hyper" ID="HyperLink1" ForeColor="Black">↩Back</asp:HyperLink>
            </div>
        <br/>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="rb">
            <asp:ListItem >VISA</asp:ListItem>
            <asp:ListItem >MasterCard</asp:ListItem>
        </asp:RadioButtonList>
            <asp:Label ID="LabelCardNumber" runat="server" Text="Card Number : " CssClass="lbl"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Cannot leave empty" ForeColor="Red" ControlToValidate="TextBoxCN" CssClass="validate"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxCN" runat="server"  CssClass="txtEnter"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter 16 Digits" ForeColor="Red" ValidationExpression="^[\d]{16,16}$" ControlToValidate="TextBoxCN" CssClass="validate"></asp:RegularExpressionValidator>
            <asp:Label ID="LabelCardName" runat="server" Text="Card Holder Name : " CssClass="lbl" ></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Cannot leave empty" ForeColor="Red" ControlToValidate="TextBoxCHN" CssClass="validate"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxCHN" runat="server" CssClass="txtEnter" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter At Least 2 characters" ValidationExpression="^(\w+\S+)$" ControlToValidate="TextBoxCHN" ForeColor="Red" CssClass="validate"></asp:RegularExpressionValidator>
            <asp:Label ID="LabelEM" runat="server" Text="Expiration MM : " CssClass="lbl"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cannot leave empty" ForeColor="Red" ControlToValidate="TextBoxEM" CssClass="validate"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxEM" runat="server" CssClass="txtEnterSmall"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter Correct Month(mm)" ValidationExpression="^((0[1-9])|(1[0-2]))" ControlToValidate="TextBoxEM" ForeColor="Red" CssClass="validate"></asp:RegularExpressionValidator>
            <asp:Label ID="LabelEY" runat="server" Text="Expiration YY :" CssClass="lbl"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Cannot leave empty" ForeColor="Red" ControlToValidate="TextBoxEY" CssClass="validate"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxEY" runat="server" CssClass="txtEnterSmall"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Please Enter Since 2022(yyyy)" ValidationExpression="^((20[2][2-9]))" ControlToValidate="TextBoxEY" ForeColor="Red" CssClass="validate"></asp:RegularExpressionValidator>
            <asp:Label ID="LabelCVV" runat="server" Text="CVV : " CssClass="lbl"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Cannot leave empty" ForeColor="Red" ControlToValidate="TextBoxCVV" CssClass="validate"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxCVV" runat="server" CssClass="txtEnterSmall"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Enter 3 Digits" ValidationExpression="^[\d]{3,3}$" ControlToValidate="TextBoxCVV" ForeColor="Red" CssClass="validate"></asp:RegularExpressionValidator>
            <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" CssClass="btn"/>
        <br/><br/>
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

