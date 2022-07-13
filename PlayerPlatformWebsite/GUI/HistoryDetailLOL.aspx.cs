using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class HistoryDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = Username;
            string date = (string)Session["date"];
            Label1.Text = "Here is the information of the account before the transaction ("+ date+")";
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
            int id = Convert.ToInt32(Session["id"]);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAccount = new SqlCommand();
            cmdSearchAccount.Connection = conn;
            cmdSearchAccount.CommandText = "SELECT * FROM LOLAccounts WHERE Id = @Id;";
            cmdSearchAccount.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmdSearchAccount.ExecuteReader();
            if (reader.Read())
            {
                string Id = reader["Id"].ToString();
                string Server = reader["Server"].ToString();
                int Level = Convert.ToInt32(reader["Level"]);
                string Rank = reader["Rank"].ToString();
                int RP = Convert.ToInt32(reader["RP"]);
                int BE = Convert.ToInt32(reader["BE"]);
                int Champion = Convert.ToInt32(reader["Champion"]);
                int Skin = Convert.ToInt32(reader["Skin"]);
                string Description = reader["Description"].ToString();
                string Price = reader["Price"].ToString();
                string Image = reader["Image"].ToString();
                string Seller = reader["Seller"].ToString();
                TextBoxId.Text = Id;
                TextBoxServer.Text = Server;
                TextBoxlevel.Text = Level.ToString();
                TextBoxRank.Text = Rank;
                TextBoxRP.Text = RP.ToString();
                TextBoxBE.Text = BE.ToString();
                TextBoxChampion.Text = Champion.ToString();
                TextBoxSkin.Text = Skin.ToString();
                Image1.ImageUrl = Image;
                TextBoxDescription.Text = Description.ToString();
                TextBoxPrice.Text = Price.ToString();
                TextBoxSeller.Text = Seller.ToString();
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["id"]);
            //Download file
            string filename = "Account_" + Id + ".txt";
            string filePath = "./File/" + filename;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }

        protected void ButtonGood_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            int OrderId = (int)Session["orderid"];
            order = order.SearchOrder(OrderId);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchOrder = new SqlCommand();
            cmdSearchOrder.Connection = conn;
            cmdSearchOrder.CommandText = "SELECT * FROM Orders WHERE OrderId = @OrderId;";
            cmdSearchOrder.Parameters.AddWithValue("@OrderId", OrderId);
            SqlDataReader reader = cmdSearchOrder.ExecuteReader();
            if (reader.Read())
            {
                string RateState = reader["RateState"].ToString();
                if(RateState == "Good" || RateState == "Bad")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Done", "<script>alert('You already rate this ordeer!');</script>");
                }
                else
                {
                    string newState = "Good";
                    order.RateState = newState;
                    order.UpdateRateState(order);
                    updateGoodRate();
                    MessageBox.Show("Rate Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }
        protected void ButtonBad_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            int OrderId = (int)Session["orderid"];
            order = order.SearchOrder(OrderId);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchOrder = new SqlCommand();
            cmdSearchOrder.Connection = conn;
            cmdSearchOrder.CommandText = "SELECT * FROM Orders WHERE OrderId = @OrderId;";
            cmdSearchOrder.Parameters.AddWithValue("@OrderId", OrderId);
            SqlDataReader reader = cmdSearchOrder.ExecuteReader();
            if (reader.Read())
            {
                string RateState = reader["RateState"].ToString();
                if (RateState == "Good"|| RateState == "Bad")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Done", "<script>alert('You already rate this ordeer!');</script>");
                }
                else
                {
                    string newState = "Bad";
                    order.RateState = newState;
                    order.UpdateRateState(order);
                    updateBadRate();
                    MessageBox.Show("Rate Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        protected void ButtonServer_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["id"]);
            Server server = new Server();
            if (server.IsDuplicateOrder(Id))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('We already received your request!');</script>");
            }
            else
            {
                Response.Redirect("CustomerServer.aspx");
            }
        }
        public void updateBadRate()
        {
            User user = new User();
            string Username = TextBoxSeller.Text;
            user = user.SearchUserToChangeInfo(Username);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdChangeEmail = new SqlCommand();
            cmdChangeEmail.Connection = conn;
            cmdChangeEmail.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdChangeEmail.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdChangeEmail.ExecuteReader();
            if (reader.Read())
            {
                int currentBadRate = Convert.ToInt32(reader["BadRate"].ToString());
                user.BadRate = currentBadRate + 1;
                user.UpdateBadRate(user);
            }
        }
        public void updateGoodRate()
        {
            User user = new User();
            string Username = TextBoxSeller.Text;
            user = user.SearchUserToChangeInfo(Username);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdChangeEmail = new SqlCommand();
            cmdChangeEmail.Connection = conn;
            cmdChangeEmail.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdChangeEmail.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdChangeEmail.ExecuteReader();
            if (reader.Read())
            {
                int currentGoodRate = Convert.ToInt32(reader["GoodRate"].ToString());
                user.GoodRate = currentGoodRate + 1;
                user.UpdateGoodRate(user);
            }
        }
    }
}