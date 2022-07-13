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
    public partial class Profile : System.Web.UI.Page
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
                string CurrentUsername = reader["Username"].ToString();
                string CurrentEmail = reader["Email"].ToString();
                float CurrentBalance = float.Parse(reader["Balance"].ToString());
                float GoodRate = float.Parse(reader["GoodRate"].ToString());
                float BadRate = float.Parse(reader["BadRate"].ToString());
                LabelCurrentBalanceInfo.Text = "$ " + CurrentBalance.ToString("0.00");
                LabelEmailInfo.Text = CurrentEmail;
                LabelUsernameInfo.Text = CurrentUsername;
                if(GoodRate + BadRate == 0)
                {
                    Label2.Text = "You didn't complete any transaction";
                }
                else
                {
                    float rate = GoodRate/(GoodRate + BadRate);
                    int totalrate = Convert.ToInt32(GoodRate + BadRate);
                    float ratep = rate * 100;
                    Label2.Text = ratep.ToString("0.00") + "%(" + totalrate + ")";
                }
                
            }

        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }
        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileChangePassword.aspx");
        }

        protected void ButtonChangeEmail_Click(object sender, EventArgs e)
        {
            string currentEmail = LabelEmailInfo.Text;
            Session["CurrentEmail"] = currentEmail;
            Response.Redirect("ProfileChangeEmail.aspx");
        }

        protected void ButtonViewSellItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileViewSellItem.aspx");
            
        }

        protected void ButtonViewBuyHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryBuy.aspx");
        }

        protected void ButtonPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePayment.aspx");
        }
    }
}