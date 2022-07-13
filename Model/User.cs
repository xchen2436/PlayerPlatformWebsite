using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private int userId;
        private string username;
        private string password;
        private int balance;
        private string email;
        private string icon;

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Balance { get => balance; set => balance = value; }
        public string Email { get => email; set => email = value; }
        public string Icon { get => icon; set => icon = value; }
    }
}
