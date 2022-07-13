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
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            if (reader.Read())
            {
                float CurrentBalance = float.Parse(reader["Balance"].ToString());
                LabelBalance.Text = "Current Balance: $ " + CurrentBalance.ToString("0.00");
            }
        }


        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ImageButtonPurchase_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Purchase.aspx");
        }

        protected void ImageButtonSell_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Sell.aspx");
        }

        protected void ImageButtonProfile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void ImageButtonBuy_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Buy.aspx");
        }
    }
    
}