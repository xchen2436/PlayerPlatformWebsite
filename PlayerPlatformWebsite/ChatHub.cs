using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace PlayerPlatformWebsite
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}