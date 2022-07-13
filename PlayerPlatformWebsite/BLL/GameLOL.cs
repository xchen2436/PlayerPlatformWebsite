using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.BLL
{
    public class GameLOL
    {
        private int id;
        private string server;
        private int level;
        private string rank;
        private int rP;
        private int bE;
        private int champion;
        private int skin;
        private string description;
        private string image;
        private string price;
        private string seller;
        private string accountUsername;
        private string accountPassword;
        private string state;
        private string noteFromAdmin;
        private float priceF;


        public int Id { get => id; set => id = value; }
        public string Server { get => server; set => server = value; }
        public int Level { get => level; set => level = value; }
        public string Rank { get => rank; set => rank = value; }
        public int RP { get => rP; set => rP = value; }
        public int BE { get => bE; set => bE = value; }
        public int Champion { get => champion; set => champion = value; }
        public int Skin { get => skin; set => skin = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string Price { get => price; set => price = value; }
        public string Seller { get => seller; set => seller = value; }
        public string AccountUsername { get => accountUsername; set => accountUsername = value; }
        public string AccountPassword { get => accountPassword; set => accountPassword = value; }
        public string State { get => state; set => state = value; }
        public string NoteFromAdmin { get => noteFromAdmin; set => noteFromAdmin = value; }
        public float PriceF { get => priceF; set => priceF = value; }

        public void SaveLOLAccount(GameLOL gamelol)
        {
            GameLOLDB.SaveLOL(gamelol);
        }
        public void SearchAccount(string AccountUsername)
        {
            GameLOLDB.SearchAccount(AccountUsername);
        }
        public GameLOL SearchAccountById(int Id)
        {
            return GameLOLDB.SearchAccountById(Id);
        }
        public bool IsDuplicateAccountUsername(string AccountUsername)
        {
            return GameLOLDB.IsAccountDuplicate(AccountUsername);
        }
        public List<GameLOL> listItems(string Seller)
        {
            return GameLOLDB.listItemforUser(Seller);
        }
        public void UpdateAccount(GameLOL gamelol)
        {
            GameLOLDB.UpdateAccount(gamelol);
        }
        public void UpdateAccountAdmin(GameLOL gamelol)
        {
            GameLOLDB.UpdateAccountAdmin(gamelol);
        }
    }
}