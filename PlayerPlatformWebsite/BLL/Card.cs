using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerPlatformWebsite.BLL
{
    public class Card
    {
        private string owner;
        private string cardNumber;
        private string cardHolder;
        private int expiredYear;
        private string expiredMonth;
        private int cVV;
        private string type;

        public string Owner { get => owner; set => owner = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string CardHolder { get => cardHolder; set => cardHolder = value; }
        public int ExpiredYear { get => expiredYear; set => expiredYear = value; }
        public string ExpiredMonth { get => expiredMonth; set => expiredMonth = value; }
        public int CVV { get => cVV; set => cVV = value; }
        public string Type { get => type; set => type = value; }

        public void SaveCard(Card card)
        {
            CardDB.SaveCard(card);
        }
        public void SearchCard(string username)
        {
            CardDB.SearchCard(username);
        }
        public bool IsDuplicateCard(string username)
        {
            return CardDB.IsCardDuplicate(username);
        }
        public void UpdateCard(Card card)
        {
            CardDB.UpdateCard(card);
        }
        public Card SearchCardToChangeInfo(string username)
        {
            return CardDB.SearchCardToChangeInfo(username);
        }
    }
}


