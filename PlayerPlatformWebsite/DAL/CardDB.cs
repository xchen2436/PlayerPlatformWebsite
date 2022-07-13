using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.DAL
{
    public class CardDB
    {
        public static void SaveCard(Card card)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Cards (Owner,CardNumber,CardHolder,ExpiredYear,ExpiredMonth,CVV,Type)" +
                                    "VALUES(@Owner,@CardNumber,@CardHolder,@ExpiredYear,@ExpiredMonth,@CVV,@Type)";
            cmdInsert.Parameters.AddWithValue("@Owner", card.Owner);
            cmdInsert.Parameters.AddWithValue("@CardNumber", card.CardNumber);
            cmdInsert.Parameters.AddWithValue("@CardHolder", card.CardHolder);
            cmdInsert.Parameters.AddWithValue("@ExpiredYear", card.ExpiredYear);
            cmdInsert.Parameters.AddWithValue("@ExpiredMonth", card.ExpiredMonth);
            cmdInsert.Parameters.AddWithValue("@CVV", card.CVV);
            cmdInsert.Parameters.AddWithValue("@Type", card.Type);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public static Card SearchCard(string username)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByUsername = new SqlCommand();
            cmdSearchByUsername.Connection = conn;
            cmdSearchByUsername.CommandText = "SELECT * FROM Cards WHERE Owner = @Owner ";
            cmdSearchByUsername.Parameters.AddWithValue("@Owner", username);
            SqlDataReader reader = cmdSearchByUsername.ExecuteReader();
            Card card = new Card();
            if (reader.Read())
            {
                card.CardNumber = reader["CardNumber"].ToString();
                card.CardHolder = reader["CardHolder"].ToString();
                card.ExpiredMonth = reader["ExpiredMonth"].ToString();
                card.ExpiredYear = Convert.ToInt32(reader["ExpiredYear"]);
                card.CVV = Convert.ToInt32(reader["CVV"]);
                card.Type = reader["Type"].ToString();
                return card;
            }
            return null;
        }
        public static bool IsCardDuplicate(string username)
        {
            Card card = CardDB.SearchCard(username);
            if (card != null)
            {
                return true;
            }
            return false;
        }
        public static void UpdateCard(Card card)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Cards " +
                                        "SET CardNumber = @CardNumber,CardHolder = @CardHolder, ExpiredMonth = @ExpiredMonth,ExpiredYear = @ExpiredYear,CVV = @CVV,Type = @Type " +
                                        "WHERE Owner = @Owner";
            cmdUpdate.Parameters.AddWithValue("@Owner", card.Owner);
            cmdUpdate.Parameters.AddWithValue("@CardNumber", card.CardNumber);
            cmdUpdate.Parameters.AddWithValue("@CardHolder", card.CardHolder);
            cmdUpdate.Parameters.AddWithValue("@ExpiredMonth", card.ExpiredMonth);
            cmdUpdate.Parameters.AddWithValue("@ExpiredYear", card.ExpiredYear);
            cmdUpdate.Parameters.AddWithValue("@CVV", card.CVV);
            cmdUpdate.Parameters.AddWithValue("@Type", card.Type);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static Card SearchCardToChangeInfo(string username)
        {
            Card card = new Card();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByUsername = new SqlCommand();
            cmdSearchByUsername.Connection = conn;
            cmdSearchByUsername.CommandText = "Select * FROM Cards " +
                                        "WHERE Owner = @Owner";
            cmdSearchByUsername.Parameters.AddWithValue("@Owner", username);
            SqlDataReader reader = cmdSearchByUsername.ExecuteReader();
            if (reader.Read())
            {
                card.CardNumber = reader["CardNumber"].ToString();
                card.CardHolder = reader["CardHolder"].ToString();
                card.ExpiredMonth = reader["ExpiredMonth"].ToString();
                card.ExpiredYear = Convert.ToInt32(reader["ExpiredYear"]);
                card.CVV = Convert.ToInt32(reader["CVV"]);
                card.Type = reader["Type"].ToString();
                return card;
            }
            return null;
        }

    }
}