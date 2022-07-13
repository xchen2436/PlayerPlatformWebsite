using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.DAL
{
    public class OrderDB
    {
        public static void SaveOrder(Order order)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Orders (Seller,Buyer,Price,ItemId,Date,Game,RateState)" +
                                    "VALUES(@Seller,@Buyer,@Price,@ItemId,@Date,@Game,@RateState)";
            cmdInsert.Parameters.AddWithValue("@Seller", order.Seller);
            cmdInsert.Parameters.AddWithValue("@Buyer", order.Buyer);
            cmdInsert.Parameters.AddWithValue("@Price", order.Price);
            cmdInsert.Parameters.AddWithValue("@ItemId", order.ItemId);
            cmdInsert.Parameters.AddWithValue("@Date", order.Date);
            cmdInsert.Parameters.AddWithValue("@Game", order.Game);
            cmdInsert.Parameters.AddWithValue("@RateState", order.RateState);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static void UpdateRateState(Order order)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Orders " +
                                        "SET RateState = @RateState " +
                                        "WHERE OrderId = @OrderId";
            cmdUpdate.Parameters.AddWithValue("@RateState", order.RateState);
            cmdUpdate.Parameters.AddWithValue("@OrderId", order.OrderId);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static Order SearchOrder(int OrderId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByOrderId = new SqlCommand();
            cmdSearchByOrderId.Connection = conn;
            cmdSearchByOrderId.CommandText = "SELECT * FROM Orders WHERE OrderId = @OrderId ";
            cmdSearchByOrderId.Parameters.AddWithValue("@OrderId", OrderId);
            SqlDataReader reader = cmdSearchByOrderId.ExecuteReader();
            Order order = new Order();
            if (reader.Read())
            {
                order.OrderId = Convert.ToInt32(reader["OrderId"]);
                return order;
            }
            return null;
        }
    }
}