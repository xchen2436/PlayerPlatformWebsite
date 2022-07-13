using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class BuyLOLDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Username = (string)Session["username"];
            

            SqlConnection con = UtilityDB.ConnectDB();
            SqlCommand cmdSearchBalance = new SqlCommand();
            cmdSearchBalance.Connection = con;
            cmdSearchBalance.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchBalance.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader1 = cmdSearchBalance.ExecuteReader();
            if (reader1.Read())
            {
                float CurrentBalance = float.Parse(reader1["Balance"].ToString());
                LabelBalance.Text = CurrentBalance.ToString("0.00");
            }
            TextBoxRank.Enabled = false;
            TextBoxlevel.Enabled = false;
            TextBoxServer.Enabled = false;
            TextBoxRP.Enabled = false;
            TextBoxBE.Enabled = false;
            TextBoxChampion.Enabled = false;
            TextBoxSkin.Enabled = false;
            TextBoxDescription.Enabled = false;
            TextBoxPrice.Enabled = false;
            TextBoxId.Enabled = false;
            TextBoxSeller.Enabled = false;
            TextBoxGoodrate.Enabled = false;
            int id = Convert.ToInt32(Session["id"]);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAccount = new SqlCommand();
            cmdSearchAccount.Connection = conn;
            cmdSearchAccount.CommandText = "SELECT * FROM LOLAccounts WHERE Id = @Id;";
            cmdSearchAccount.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader2 = cmdSearchAccount.ExecuteReader();
            if (reader2.Read())
            {
                string Id = reader2["Id"].ToString();
                string Server = reader2["Server"].ToString();
                int Level = Convert.ToInt32(reader2["Level"]);
                string Rank = reader2["Rank"].ToString();
                int RP = Convert.ToInt32(reader2["RP"]);
                int BE = Convert.ToInt32(reader2["BE"]);
                int Champion = Convert.ToInt32(reader2["Champion"]);
                int Skin = Convert.ToInt32(reader2["Skin"]);
                string Seller = reader2["Seller"].ToString();
                string Description = reader2["Description"].ToString();
                float Price = float.Parse(reader2["Price"].ToString());
                string Image = reader2["Image"].ToString();
                TextBoxId.Text = Id;
                TextBoxServer.Text = Server;
                TextBoxlevel.Text = Level.ToString();
                TextBoxRank.Text = Rank;
                TextBoxRP.Text = RP.ToString();
                TextBoxBE.Text = BE.ToString();
                TextBoxChampion.Text = Champion.ToString();
                TextBoxSkin.Text = Skin.ToString();
                Image1.ImageUrl = Image;
                TextBoxSeller.Text = Seller.ToString();
                TextBoxDescription.Text = Description.ToString();
                TextBoxPrice.Text = Price.ToString();

            }
            LabelUsername.Text = Username;
            Label1.Text = "Here is the detail of the account";
            string seller = TextBoxSeller.Text.ToString();
            SqlConnection conn1 = UtilityDB.ConnectDB();
            SqlCommand cmdFindGoodRate = new SqlCommand();
            cmdFindGoodRate.Connection = conn1;
            cmdFindGoodRate.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdFindGoodRate.Parameters.AddWithValue("@Username", seller);
            SqlDataReader reader = cmdFindGoodRate.ExecuteReader();
            if (reader.Read())
            {
                float GoodRate = float.Parse(reader["GoodRate"].ToString());
                float BadRate = float.Parse(reader["BadRate"].ToString());
                if (GoodRate + BadRate == 0)
                {
                    TextBoxGoodrate.Text = "Didn't complete any transaction yet";
                }
                else
                {
                    float rate = GoodRate / (GoodRate + BadRate);
                    int totalrate = Convert.ToInt32(GoodRate + BadRate);
                    float ratep = rate * 100;
                    TextBoxGoodrate.Text = ratep.ToString("0.00") + "%(" + totalrate + ")";
                }

            }

        }


        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {
            float CurrentBalance = float.Parse(LabelBalance.Text);
            float CurrentPrice = float.Parse(TextBoxPrice.Text);
            if (TextBoxSeller.Text == LabelUsername.Text)
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('You cannot buy your own items!');</script>");
            }
            else if (CurrentBalance < CurrentPrice)
            {
                DialogResult result = MessageBox.Show("Your balance is not enough. Do you need to purchase?", "Balance not enough", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    Response.Redirect("Purchase.aspx");
                }
                else if (result == DialogResult.No)
                {

                }
            }
            else
            {
                MessageBox.Show("Payment Successfully!", "Successful", MessageBoxButtons.OK);
                
                UpdateBuyerBalance();
                UpdateSellerBalance();
                UpdateItemState();
                SendEmailToSeller();
                SaveOrder();
                int id = Convert.ToInt32(TextBoxId.Text);
                Session["id"] = id;
                string game = "LOL";
                Session["game"] = game;
                Response.Redirect("BuySuccessful.aspx");
                
                
            }
        }
        public void UpdateBuyerBalance()
        {
            User user = new User();
            string Username = (string)Session["username"];
            user = user.SearchUserToChangeInfo(Username);
            float Price = float.Parse(TextBoxPrice.Text);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            if (reader.Read())
            {
                float CurrentBalance = float.Parse(reader["Balance"].ToString());
                float newBalance = CurrentBalance - Price;
                user.Balance = newBalance.ToString();
                user.UpdateBalance(user);
            }

        }
        public void UpdateSellerBalance()
        {
            User user = new User();

            string Username = TextBoxSeller.Text;
            user = user.SearchUserToChangeInfo(Username);
            float Price = float.Parse(TextBoxPrice.Text);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            if (reader.Read())
            {
                float CurrentBalance = float.Parse(reader["Balance"].ToString());
                float newBalance = CurrentBalance + Price;
                user.Balance = newBalance.ToString();
                user.UpdateBalance(user);
            }
        }
        public void UpdateItemState()
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            string State = "sold";
            int Id = Convert.ToInt32(Session["id"]);
            cmdUpdate.CommandText = "UPDATE LOLAccounts " +
                                        "SET State = @State " +
                                        "WHERE Id = @Id ";
            cmdUpdate.Parameters.AddWithValue("@Id", Id);
            cmdUpdate.Parameters.AddWithValue("@State", State);
            cmdUpdate.Connection = conn;
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public void SaveOrder()
        {
            Order order = new Order();
            order.Seller = TextBoxSeller.Text; ;
            order.ItemId = Convert.ToInt32(Session["id"]);
            order.Buyer = (string)Session["username"];
            order.Price = TextBoxPrice.Text;
            order.Game = "League of Legend";
            order.Date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            order.RateState = "Notrated";
            order.SaveOrder(order);
        }

        public void SendEmailToSeller()
        {
            string Username = TextBoxSeller.Text;
            int Id = Convert.ToInt32(Session["id"]);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            if (reader.Read())
            {
                string SystemEmail = "xxxxxxx"; //From address    
                string SendEmail = reader["Email"].ToString();//To address 
                MailMessage message = new MailMessage(SystemEmail, SendEmail);
                string mailbody = "<h3>Do not Reply</h3>" + "<p>Your item with Id: " + Id + " has been sold.</p>" +
                    "<p>Thank you to choose PlayerPlateform!<p><p>Enjoy your life!</p>";
                message.Subject = "Item sold";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                System.Net.NetworkCredential basicCredential = new
                System.Net.NetworkCredential("xxxxxxx", "xxxxxxx");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        

        }

    }
