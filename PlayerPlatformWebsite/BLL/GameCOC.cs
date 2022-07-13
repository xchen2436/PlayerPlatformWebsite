using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.BLL
{
    public class GameCOC
    {
        private int id;
        private string tHLevel;
        private int gem;
        private string description;
        private string image;
        private string price;
        private string seller;
        private string accountEmail;
        private string accountPassword;
        private string state;
        private string noteFromAdmin;
        private float priceF;

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string Price { get => price; set => price = value; }
        public string Seller { get => seller; set => seller = value; }
        public string AccountEmail { get => accountEmail; set => accountEmail = value; }
        public string AccountPassword { get => accountPassword; set => accountPassword = value; }
        public string State { get => state; set => state = value; }
        public string NoteFromAdmin { get => noteFromAdmin; set => noteFromAdmin = value; }
        public int Gem { get => gem; set => gem = value; }
        public string THLevel { get => tHLevel; set => tHLevel = value; }
        public float PriceF { get => priceF; set => priceF = value; }

        public void SaveCOCAccount(GameCOC gamecoc)
        {
            GameCOCDB.SaveCOC(gamecoc);
        }
        public void SearchAccount(string AccountEmail)
        {
            GameCOCDB.SearchAccount(AccountEmail);
        }
        public bool IsDuplicateEmail(string AccountEmail)
        {
            return GameCOCDB.IsAccountDuplicate(AccountEmail);
        }
        public GameCOC SearchAccountById(int Id)
        {
            return GameCOCDB.SearchAccountById(Id);
        }
        public void UpdateAccount(GameCOC gamecoc)
        {
            GameCOCDB.UpdateAccount(gamecoc);
        }
        public void UpdateAccountAdmin(GameCOC gamecoc)
        {
            GameCOCDB.UpdateAccountAdmin(gamecoc);
        }
    }
}