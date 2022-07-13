<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicChat.aspx.cs" Inherits="PlayerPlatformWebsite.WebForm1" %>

<!DOCTYPE html>

<html>
<head>
    <title>Public Chat</title>
    <link href="../CSS/PublicChatStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form1" runat="server">
        <div>
                <asp:Button ID="ButtonBackHome" runat="server" OnClick="ButtonBackHome_Click" Text="Home" CssClass="btnBack"/>
            </div>
    <div class="container">
        <label>Hello, here a public chat room where you can share your information.</label><br>
        <label>Do not reveal your real information here.</label><br>
        <label>Respect all users within the chat.</label><br><br>
        <label id="name" style="color:indigo"></label><br><br>
        <input type="hidden" id="displayname" />
        <input type="text" id="message"/>
        
        <input type="button" id="sendmessage" value="Send" /><br>
        <ul id="discussion">

        </ul>
    </div>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.2.2.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {
            var chat = $.connection.chatHub;
            var minNumber = 1000; 
            var maxNumber = 9999;
            var randomnumber = Math.floor(Math.random() * (maxNumber + 1) + minNumber);
            var guestname = "Guest" + randomnumber;
            document.getElementById("name").innerHTML = "Hello! "+ guestname;
            chat.client.broadcastMessage = function (name, message) {
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                $('#discussion').append('<strong>' + encodedName
                    + ' says :</strong>&nbsp;' + encodedMsg + '<br>');
            };
            $('#displayname').val("Guest"+ randomnumber);
            $('#message').focus();
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    if ($('#message').val() == "") {
                        alert("You cannot send the empty message!");
                    }
                    else {
                        chat.server.send($('#displayname').val(), $('#message').val());
                    }
                    $('#message').val('').focus();
                });
            });
        });
    </script>
    </form>
</body>
</html>
