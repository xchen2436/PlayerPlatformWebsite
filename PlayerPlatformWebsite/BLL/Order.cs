using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayerPlatformWebsite.DAL;

namespace PlayerPlatformWebsite.BLL
{
    public class Order
    {
        private int orderId;
        private string seller;
        private string buyer;
        private string price;
        private int itemId;
        private string date;
        private string game;
        private string rateState;


        public int OrderId { get => orderId; set => orderId = value; }
        public string Seller { get => seller; set => seller = value; }
        public string Buyer { get => buyer; set => buyer = value; }
        public string Price { get => price; set => price = value; }
        public int ItemId { get => itemId; set => itemId = value; }
        public string Date { get => date; set => date = value; }
        public string Game { get => game; set => game = value; }
        public string RateState { get => rateState; set => rateState = value; }

        public void SaveOrder(Order order)
        {
            OrderDB.SaveOrder(order);
        }
        public void UpdateRateState(Order order)
        {
            OrderDB.UpdateRateState(order);
        }
        public Order SearchOrder(int orderId)
        {
            return OrderDB.SearchOrder(orderId);
        }
    }
    
}