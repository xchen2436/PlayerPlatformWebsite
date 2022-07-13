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
    public partial class ProfileChangeItemInfoCOCApproved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            Label1.Text = "Your account information has been approved";
            TextBoxTHLevel.Enabled = false;
            TextBoxDescription.Enabled = false;
            TextBoxPrice.Enabled = false;
            TextBoxGem.Enabled = false;
            TextBoxId.Enabled = false;
            int id = Convert.ToInt32(Session["id"]);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAccount = new SqlCommand();
            cmdSearchAccount.Connection = conn;
            cmdSearchAccount.CommandText = "SELECT * FROM COCAccounts WHERE Id = @Id;";
            cmdSearchAccount.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmdSearchAccount.ExecuteReader();
            if (reader.Read())
            {
                string Id = reader["Id"].ToString();
                int Level = Convert.ToInt32(reader["THLevel"]);
                int Gem = Convert.ToInt32(reader["Gem"]);
                string Description = reader["Description"].ToString();
                string Price = reader["Price"].ToString();
                string Image = reader["Image"].ToString();
                TextBoxId.Text = Id;
                TextBoxGem.Text = Gem.ToString();
                TextBoxTHLevel.Text = Level.ToString();
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