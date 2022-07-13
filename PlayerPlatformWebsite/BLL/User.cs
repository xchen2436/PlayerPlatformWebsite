using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayerPlatformWebsite.DAL;

namespace PlayerPlatformWebsite.BLL
{
    public class User
    {
        private int userId;
        private string username;
        private string password;
        private string balance;
        private string email;
        private float goodRate;
        private float badRate;

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Balance { get => balance; set => balance = value; }
        public string Email { get => email; set => email = value; }
        public float GoodRate { get => goodRate; set => goodRate = value; }
        public float BadRate { get => badRate; set => badRate = value; }

        public void SaveUser(User user)
        {
            UserDB.SaveUser(user);
        }
        public void SearchUser(string username)
        {
            UserDB.SearchUser(username);
        }
        public bool IsDuplicateUsername(string username)
        {
            return UserDB.IsUsernameDuplicate(username);
        }
        public void LoginUser(string username,string password)
        {
            UserDB.LoginUser(username,password);
        }
        public bool IsValidateLogin(string username,string password)
        {
            return UserDB.IsLoginValidate(username,password);
        }
        public void FindUserPassword(string username, string email)
        {
            UserDB.FindPassword(username, email);
        }
        public bool IsValidateAccount(string username, string email)
        {
            return UserDB.IsAccountAvailable(username, email);
        }
        public void UpdateBalance(User user)
        {
            UserDB.UpdateBalance(user);
        }
        public void UpdateEmail(User user)
        {
            UserDB.UpdateEmail(user);
        }
        public void UpdatePassword(User user)
        {
            UserDB.UpdatePassword(user);
        }
        public User SearchUserToChangeInfo(string username)
        {
            return UserDB.SearchUserToChangeInfo(username);
        }
        public void UpdateGoodRate(User user)
        {
            UserDB.UpdateGoodRate(user);
        }
        public void UpdateBadRate(User user)
        {
            UserDB.UpdateBadRate(user);
        }
    }
}




