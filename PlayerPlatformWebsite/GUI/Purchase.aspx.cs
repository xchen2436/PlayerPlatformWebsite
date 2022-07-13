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
    public partial class Purchase : System.Web.UI.Page
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

        protected void ImageButtonP5_Click(object sender, ImageClickEventArgs e)
        {
            float sessionpurchase = 5;
            Session["purchase"] = sessionpurchase;
            Response.Redirect("ChooseCard.aspx");
        }

        protected void ImageButtonP10_Click(object sender, ImageClickEventArgs e)
        {
            float sessionpurchase = 10;
            Session["purchase"] = sessionpurchase;
            Response.Redirect("ChooseCard.aspx");
        }

        protected void ImageButtonP20_Click(object sender, ImageClickEventArgs e)
        {
            float sessionpurchase = 20;
            Session["purchase"] = sessionpurchase;
            Response.Redirect("ChooseCard.aspx");
        }

        protected void ImageButtonP50_Click(object sender, ImageClickEventArgs e)
        {
            float sessionpurchase = 50;
            Session["purchase"] = sessionpurchase;
            Response.Redirect("ChooseCard.aspx");
        }

        protected void ImageButtonP100_Click(object sender, ImageClickEventArgs e)
        {
            float sessionpurchase = 100;
            Session["purchase"] = sessionpurchase;
            Response.Redirect("ChooseCard.aspx");
        }
    }
}