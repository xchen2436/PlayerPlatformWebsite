using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlayerPlatformWebsite.GUI
{
    public partial class ProfileChangeItemInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            Label1.Text = "Your account information has been approved";
            DropDownList2.Enabled = false;
            TextBoxlevel.Enabled = false;
            DropDownList1.Enabled = false;
            TextBoxRP.Enabled = false;
            TextBoxBE.Enabled = false;
            TextBoxChampion.Enabled = false;
            TextBoxSkin.Enabled = false;
            TextBoxDescription.Enabled = false;
            TextBoxPrice.Enabled = false;
            TextBoxId.Enabled = false;
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
                string AccountUsername = reader["AccountUsername"].ToString();
                TextBoxId.Text = Id;
                DropDownList2.SelectedValue = Server;
                TextBoxlevel.Text = Level.ToString();
                DropDownList1.SelectedValue = Rank;
                TextBoxRP.Text = RP.ToString();
                TextBoxBE.Text = BE.ToString();
                TextBoxChampion.Text = Champion.ToString();
                TextBoxSkin.Text = Skin.ToString();
                Image1.ImageUrl = Image;
                TextBoxDescription.Text = Description.ToString();
                TextBoxPrice.Text = Price.ToString();

            }
            
            
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}