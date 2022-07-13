using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayerPlatformWebsite.BLL;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace PlayerPlatformWebsite.DAL
{
    public class UserDB
    {
        public static void SaveUser(User user)
        {
            //SqlConnection conn = new SqlConnection();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Users (Username,Password,Email)" +
                                    "VALUES(@Username,@Password,@Email)";
            cmdInsert.Parameters.AddWithValue("@Username", user.Username);
            cmdInsert.Parameters.AddWithValue("@Password", user.Password);
            cmdInsert.Parameters.AddWithValue("@Email", user.Email);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static User SearchUser(string username) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByUsername = new SqlCommand();
            cmdSearchByUsername.Connection = conn;
            cmdSearchByUsername.CommandText = "SELECT * FROM Users WHERE Username = @Username ";
            cmdSearchByUsername.Parameters.AddWithValue("@Username", username);
            SqlDataReader reader = cmdSearchByUsername.ExecuteReader();
            User user = new User();
            if (reader.Read())
            {
                user.Username = reader["Username"].ToString();
                return user;
            }
            return null;
        }
        public static User LoginUser(string username, string password) {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchUser = new SqlCommand();
            cmdSearchUser.Connection = conn;
            cmdSearchUser.CommandText = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password;";
            cmdSearchUser.Parameters.AddWithValue("@Username", username);
            cmdSearchUser.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = cmdSearchUser.ExecuteReader();
            User user = new User();
            if (reader.Read())
            {
                user.Username = reader["Username"].ToString();
                user.Password = reader["Password"].ToString();
                return user;
            }
            return null;
        }
        public static User FindPassword(string username, string email)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username AND Email = @Email;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", username);
            cmdSearchPassword.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            User user = new User();
            if (reader.Read())
            {
                user.Username = reader["Username"].ToString();
                user.Email = reader["Email"].ToString();
                return user;
            }
            return null;
        }
       
        public static bool IsAccountAvailable(string username, string email)
        {
            User user = UserDB.FindPassword(username, email);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsLoginValidate(string username, string password) {
            User user = UserDB.LoginUser(username,password);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsUsernameDuplicate(string username)
        {
            User user = UserDB.SearchUser(username);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public static void UpdateBalance(User user)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Users " +
                                        "SET Balance = @Balance " +
                                        "WHERE Username = @Username";
            cmdUpdate.Parameters.AddWithValue("@Username", user.Username);
            cmdUpdate.Parameters.AddWithValue("@Balance", user.Balance);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static void UpdateEmail(User user)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Users " +
                                        "SET Email = @Email " +
                                        "WHERE Username = @Username";
            cmdUpdate.Parameters.AddWithValue("@Username", user.Username);
            cmdUpdate.Parameters.AddWithValue("@Email", user.Email);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static void UpdatePassword(User user)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Users " +
                                        "SET Password = @Password " +
                                        "WHERE Username = @Username";
            cmdUpdate.Parameters.AddWithValue("@Username", user.Username);
            cmdUpdate.Parameters.AddWithValue("@Password", user.Password);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static void UpdateGoodRate(User user)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Users " +
                                        "SET GoodRate = @GoodRate  " +
                                        "WHERE Username = @Username";
            cmdUpdate.Parameters.AddWithValue("@Username", user.Username);
            cmdUpdate.Parameters.AddWithValue("@GoodRate", user.GoodRate);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public static void UpdateBadRate(User user)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Users " +
                                        "SET BadRate = @BadRate  " +
                                        "WHERE Username = @Username";
            cmdUpdate.Parameters.AddWithValue("@Username", user.Username);
            cmdUpdate.Parameters.AddWithValue("@BadRate", user.BadRate);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public static User SearchUserToChangeInfo(string username)
        {
            User user = new User();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByUsername = new SqlCommand();
            cmdSearchByUsername.Connection = conn;
            cmdSearchByUsername.CommandText = "Select * FROM Users " +
                                        "WHERE Username = @Username";
            cmdSearchByUsername.Parameters.AddWithValue("@Username", username);
            SqlDataReader reader = cmdSearchByUsername.ExecuteReader();
            if (reader.Read())
            {
                user.Username = reader["Username"].ToString();
                user.Password = reader["Password"].ToString();
                user.Balance = reader["Balance"].ToString();
                user.Email = reader["Email"].ToString();
                user.GoodRate = Convert.ToInt32(reader["GoodRate"]);
                user.BadRate = Convert.ToInt32(reader["BadRate"]);
                return user;
            }
            return null;
        }

    }
}