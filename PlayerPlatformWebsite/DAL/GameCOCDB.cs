using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.DAL
{
    public class GameCOCDB
    {
        public static void SaveCOC(GameCOC gamecoc)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO COCAccounts (THLevel,Gem,Description,Image,Price,Seller,State,AccountEmail,AccountPassword,NoteFromAdmin,PriceF)" +
                                    "VALUES(@THLevel,@Gem,@Description,@Image,@Price,@Seller,@State,@AccountEmail,@AccountPassword,@NoteFromAdmin,@PriceF)";
            cmdInsert.Parameters.AddWithValue("@THLevel", gamecoc.THLevel);
            cmdInsert.Parameters.AddWithValue("@Gem", gamecoc.Gem);
            cmdInsert.Parameters.AddWithValue("@Description", gamecoc.Description);
            cmdInsert.Parameters.AddWithValue("@Image", gamecoc.Image);
            cmdInsert.Parameters.AddWithValue("@Price", gamecoc.Price);
            cmdInsert.Parameters.AddWithValue("@Seller", gamecoc.Seller);
            cmdInsert.Parameters.AddWithValue("@State", gamecoc.State);
            cmdInsert.Parameters.AddWithValue("@AccountEmail", gamecoc.AccountEmail);
            cmdInsert.Parameters.AddWithValue("@AccountPassword", gamecoc.AccountPassword);
            cmdInsert.Parameters.AddWithValue("@NoteFromAdmin", gamecoc.NoteFromAdmin);
            cmdInsert.Parameters.AddWithValue("@PriceF", gamecoc.PriceF);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static GameCOC SearchAccount(string AccountEmail)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByAccountUsername = new SqlCommand();
            cmdSearchByAccountUsername.Connection = conn;
            cmdSearchByAccountUsername.CommandText = "SELECT * FROM COCAccounts WHERE AccountEmail = @AccountEmail ";
            cmdSearchByAccountUsername.Parameters.AddWithValue("@AccountEmail", AccountEmail);
            SqlDataReader reader = cmdSearchByAccountUsername.ExecuteReader();
            GameCOC gamecoc = new GameCOC();
            if (reader.Read())
            {
                gamecoc.AccountEmail = reader["AccountEmail"].ToString();
                return gamecoc;
            }
            return null;
        }
        public static void UpdateAccountAdmin(GameCOC gamecoc)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE COCAccounts " +
                                        "SET NoteFromAdmin = @NoteFromAdmin, State = @State " +
                                        "WHERE Id = @Id ";
            cmdUpdate.Parameters.AddWithValue("@Id", gamecoc.Id);
            cmdUpdate.Parameters.AddWithValue("@NoteFromAdmin", gamecoc.NoteFromAdmin);
            cmdUpdate.Parameters.AddWithValue("@State", gamecoc.State);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static bool IsAccountDuplicate(string AccountEmail)
        {
            GameCOC gamecoc = GameCOCDB.SearchAccount(AccountEmail);
            if (gamecoc != null)
            {
                return true;
            }
            return false;
        }
        public static GameCOC SearchAccountById(int Id)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByAccountId = new SqlCommand();
            cmdSearchByAccountId.Connection = conn;
            cmdSearchByAccountId.CommandText = "SELECT * FROM COCAccounts WHERE Id = @Id ";
            cmdSearchByAccountId.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmdSearchByAccountId.ExecuteReader();
            GameCOC gamecoc = new GameCOC();
            if (reader.Read())
            {
                gamecoc.Id = Convert.ToInt32(reader["Id"]);
                return gamecoc;
            }
            return null;
        }
        public static void UpdateAccount(GameCOC gamecoc)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE COCAccounts " +
                                        "SET THLevel = @THLevel, Gem = @Gem, Description = @Description, Image = @Image, Price = @Price, AccountEmail = @AccountEmail, AccountPassword = @AccountPassword, PriceF = @PriceF " +
                                        "WHERE Id = @Id ";
            cmdUpdate.Parameters.AddWithValue("@Id", gamecoc.Id);
            cmdUpdate.Parameters.AddWithValue("@THLevel", gamecoc.THLevel);
            cmdUpdate.Parameters.AddWithValue("@Gem", gamecoc.Gem);
            cmdUpdate.Parameters.AddWithValue("@Description", gamecoc.Description);
            cmdUpdate.Parameters.AddWithValue("@Image", gamecoc.Image);
            cmdUpdate.Parameters.AddWithValue("@Price", gamecoc.Price);
            cmdUpdate.Parameters.AddWithValue("@AccountEmail", gamecoc.AccountEmail);
            cmdUpdate.Parameters.AddWithValue("@AccountPassword", gamecoc.AccountPassword);
            cmdUpdate.Parameters.AddWithValue("@PriceF", gamecoc.PriceF);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }
}