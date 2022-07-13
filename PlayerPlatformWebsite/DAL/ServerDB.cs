using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.DAL
{
    public class ServerDB
    {
        public static void SaveRequest(Server server)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Servers (OrderId,Title,Description,State,Requester,Date)" +
                                    "VALUES(@OrderId,@Title,@Description,@State,@Requester,@Date)";
            cmdInsert.Parameters.AddWithValue("@OrderId", server.OrderId);
            cmdInsert.Parameters.AddWithValue("@Title", server.Title);
            cmdInsert.Parameters.AddWithValue("@Description", server.Description);
            cmdInsert.Parameters.AddWithValue("@State", server.State);
            cmdInsert.Parameters.AddWithValue("@Requester", server.Requester);
            cmdInsert.Parameters.AddWithValue("@Date", server.Date);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static Server SearchServer(int OrderId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByUsername = new SqlCommand();
            cmdSearchByUsername.Connection = conn;
            cmdSearchByUsername.CommandText = "SELECT * FROM Servers WHERE OrderId = @OrderId ";
            cmdSearchByUsername.Parameters.AddWithValue("@OrderId", OrderId);
            SqlDataReader reader = cmdSearchByUsername.ExecuteReader();
            Server server = new Server();
            if (reader.Read())
            {
                server.OrderId = Convert.ToInt32(reader["OrderId"].ToString());
                return server;
            }
            return null;
        }
        public static bool IsServerDuplicate(int OrderId)
        {
            Server server = ServerDB.SearchServer(OrderId);
            if (server != null)
            {
                return true;
            }
            return false;
        }
        public static void UpdateState(Server server)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Servers " +
                                        "SET State = @State " +
                                        "WHERE OrderId = @OrderId";
            cmdUpdate.Parameters.AddWithValue("@State", server.State);
            cmdUpdate.Parameters.AddWithValue("@OrderId", server.OrderId);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

    }
}