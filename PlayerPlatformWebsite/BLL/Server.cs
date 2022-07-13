using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.BLL
{
    public class Server
    {
        private int serverId;
        private int orderId;
        private string title;
        private string description;
        private string state;
        private string requester;
        private string date;

        public int ServerId { get => serverId; set => serverId = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string State { get => state; set => state = value; }
        public string Requester { get => requester; set => requester = value; }
        public string Date { get => date; set => date = value; }

        public void SaveRequest(Server server)
        {
            ServerDB.SaveRequest(server);
        }
        public void SearchOrder(int orderId)
        {
            ServerDB.SearchServer(orderId);
        }
        public bool IsDuplicateOrder(int orderId)
        {
            return ServerDB.IsServerDuplicate(orderId);
        }
        public Server SearchOrderTOChange(int orderId)
        {
            return ServerDB.SearchServer(orderId);
        }
        public void UpdateState(Server server)
        {
            ServerDB.UpdateState(server);
        }
    }

}