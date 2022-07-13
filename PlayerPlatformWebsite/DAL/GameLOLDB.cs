using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.DAL
{
    public class GameLOLDB
    {
        public static void SaveLOL(GameLOL gamelol)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO LOLAccounts (Level,Rank,RP,BE,Description,Image,Price,Seller,State,AccountUsername,AccountPassword,Server,Champion,Skin,NoteFromAdmin,PriceF)" +
                                    "VALUES(@Level,@Rank,@RP,@BE,@Description,@Image,@Price,@Seller,@State,@AccountUsername,@AccountPassword,@Server,@Champion,@Skin,@NoteFromAdmin,@PriceF)";
            cmdInsert.Parameters.AddWithValue("@Level", gamelol.Level);
            cmdInsert.Parameters.AddWithValue("@Rank", gamelol.Rank);
            cmdInsert.Parameters.AddWithValue("@RP", gamelol.RP);
            cmdInsert.Parameters.AddWithValue("@Server", gamelol.Server);
            cmdInsert.Parameters.AddWithValue("@Champion", gamelol.Champion);
            cmdInsert.Parameters.AddWithValue("@Skin", gamelol.Skin);
            cmdInsert.Parameters.AddWithValue("@BE", gamelol.BE);
            cmdInsert.Parameters.AddWithValue("@Description", gamelol.Description);
            cmdInsert.Parameters.AddWithValue("@Image", gamelol.Image);
            cmdInsert.Parameters.AddWithValue("@Price", gamelol.Price);
            cmdInsert.Parameters.AddWithValue("@Seller", gamelol.Seller);
            cmdInsert.Parameters.AddWithValue("@State", gamelol.State);
            cmdInsert.Parameters.AddWithValue("@AccountUsername", gamelol.AccountUsername);
            cmdInsert.Parameters.AddWithValue("@AccountPassword", gamelol.AccountPassword);
            cmdInsert.Parameters.AddWithValue("@NoteFromAdmin", gamelol.NoteFromAdmin);
            cmdInsert.Parameters.AddWithValue("@PriceF", gamelol.PriceF);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static void UpdateAccount(GameLOL gamelol)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE LOLAccounts " +
                                        "SET Level = @Level, Rank = @Rank, RP = @RP, Server = @Server, Champion = @Champion, Skin = @Skin, BE = @BE, Description = @Description, Image = @Image, Price = @Price, AccountUsername = @AccountUsername, AccountPassword = @AccountPassword, PriceF = @PriceF " +
                                        "WHERE Id = @Id ";
            cmdUpdate.Parameters.AddWithValue("@Id", gamelol.Id);
            cmdUpdate.Parameters.AddWithValue("@Level", gamelol.Level);
            cmdUpdate.Parameters.AddWithValue("@Rank", gamelol.Rank);
            cmdUpdate.Parameters.AddWithValue("@RP", gamelol.RP);
            cmdUpdate.Parameters.AddWithValue("@Server", gamelol.Server);
            cmdUpdate.Parameters.AddWithValue("@Champion", gamelol.Champion);
            cmdUpdate.Parameters.AddWithValue("@Skin", gamelol.Skin);
            cmdUpdate.Parameters.AddWithValue("@BE", gamelol.BE);
            cmdUpdate.Parameters.AddWithValue("@Description", gamelol.Description);
            cmdUpdate.Parameters.AddWithValue("@Image", gamelol.Image);
            cmdUpdate.Parameters.AddWithValue("@Price", gamelol.Price);
            cmdUpdate.Parameters.AddWithValue("@AccountUsername", gamelol.AccountUsername);
            cmdUpdate.Parameters.AddWithValue("@AccountPassword", gamelol.AccountPassword);
            cmdUpdate.Parameters.AddWithValue("@PriceF", gamelol.PriceF);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public static void UpdateAccountAdmin(GameLOL gamelol)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE LOLAccounts " +
                                        "SET NoteFromAdmin = @NoteFromAdmin, State = @State " +
                                        "WHERE Id = @Id ";
            cmdUpdate.Parameters.AddWithValue("@Id", gamelol.Id);
            cmdUpdate.Parameters.AddWithValue("@NoteFromAdmin", gamelol.NoteFromAdmin);
            cmdUpdate.Parameters.AddWithValue("@State", gamelol.State);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static GameLOL SearchAccountById(int Id)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByAccountId = new SqlCommand();
            cmdSearchByAccountId.Connection = conn;
            cmdSearchByAccountId.CommandText = "SELECT * FROM LOLAccounts WHERE Id = @Id ";
            cmdSearchByAccountId.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmdSearchByAccountId.ExecuteReader();
            GameLOL gamelol = new GameLOL();
            if (reader.Read())
            {
                gamelol.Id = Convert.ToInt32(reader["Id"]);
                return gamelol;
            }
            return null;
        }
        public static GameLOL SearchAccount(string AccountUsername)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByAccountUsername = new SqlCommand();
            cmdSearchByAccountUsername.Connection = conn;
            cmdSearchByAccountUsername.CommandText = "SELECT * FROM LOLAccounts WHERE AccountUsername = @AccountUsername ";
            cmdSearchByAccountUsername.Parameters.AddWithValue("@AccountUsername", AccountUsername);
            SqlDataReader reader = cmdSearchByAccountUsername.ExecuteReader();
            GameLOL gamelol = new GameLOL();
            if (reader.Read())
            {
                gamelol.AccountUsername = reader["AccountUsername"].ToString();
                return gamelol;
            }
            return null;
        }
        public static bool IsAccountDuplicate(string AccountUsername)
        {
            GameLOL gamelol = GameLOLDB.SearchAccount(AccountUsername);
            if (gamelol != null)
            {
                return true;
            }
            return false;
        }

        public static List<GameLOL> listItemforUser(string LOLSeller)
        {
            List<GameLOL> ListItem = new List<GameLOL>();
            SqlConnection con = UtilityDB.ConnectDB();

            try
            {
                SqlCommand cmdListRecord = new SqlCommand("select * from LOLAccounts WHERE Seller = @Seller", con);
                cmdListRecord.Parameters.AddWithValue("@Seller", LOLSeller);
                SqlDataReader sqlreadRecord = cmdListRecord.ExecuteReader();

                GameLOL gameLOL;

                while (sqlreadRecord.Read())
                {
                    gameLOL = new GameLOL();
                    gameLOL.Id = Convert.ToInt32(sqlreadRecord["Id"]);
                    gameLOL.Server = sqlreadRecord["Server"].ToString();
                    gameLOL.Level = Convert.ToInt32(sqlreadRecord["Level"]);
                    gameLOL.Rank = sqlreadRecord["Rank"].ToString();
                    gameLOL.BE = Convert.ToInt32(sqlreadRecord["BE"]);
                    gameLOL.RP = Convert.ToInt32(sqlreadRecord["RP"]);
                    gameLOL.Champion = Convert.ToInt32(sqlreadRecord["Champion"]);
                    gameLOL.Skin = Convert.ToInt32(sqlreadRecord["Skin"]);
                    gameLOL.Description = sqlreadRecord["Description"].ToString();
                    gameLOL.Price = sqlreadRecord["Price"].ToString();
                    gameLOL.State = sqlreadRecord["State"].ToString();
                    gameLOL.Seller = sqlreadRecord["Seller"].ToString();
                    gameLOL.AccountUsername = sqlreadRecord["AccountUsername"].ToString();
                    gameLOL.AccountPassword = "********";
                    gameLOL.Image = "../Image/UploadImage/LoL/"+ sqlreadRecord["Image"].ToString();
                    ListItem.Add(gameLOL);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return ListItem;
        }

    }
}