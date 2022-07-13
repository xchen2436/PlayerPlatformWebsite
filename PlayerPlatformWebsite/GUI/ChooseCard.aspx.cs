using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class ChooseCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            float Purchase = (float)Session["purchase"];
            float TotalPrice = (float)(Purchase * 1.15);
            LabelPrice.Text = "Total Price : $" + TotalPrice;
            AutoFill.Visible = false;
            ButtonAddCard.Visible = false;
            SqlConnection con = UtilityDB.ConnectDB();
            SqlCommand cmdSearchCard = new SqlCommand();
            cmdSearchCard.Connection = con;
            cmdSearchCard.CommandText = "SELECT * FROM Cards WHERE Owner = @Owner;";
            cmdSearchCard.Parameters.AddWithValue("@Owner", Username);
            SqlDataReader reader = cmdSearchCard.ExecuteReader();
            if (reader.Read())
            {
                LabelHint.Text = "Please enter CVV to complete transaction";
                string CardNumber = reader["CardNumber"].ToString();
                string EMonth = reader["ExpiredMonth"].ToString();
                string EYear = reader["ExpiredYear"].ToString();
                string CardNumberLastFour = CardNumber.Substring(CardNumber.Length - 4);
                string CardNumberFirstFour = CardNumber.Substring(0,6);
                string star = "********";
                Label1.Text = CardNumberFirstFour+ star + CardNumberLastFour + "    " + EMonth + "/" + EYear;
                AutoFill.Visible = true;
                ButtonAddCard.Visible = false;
            }
            else
            {
                LabelHint.Text = "Please select a way to complete transaction";
                AutoFill.Visible = false;
                ButtonAddCard.Visible = true;
                ButtonPayment.Text = "Direct Payment";
            }
            
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonPayment_Click(object sender, EventArgs e)
        {
            float Purchase = (float)Session["purchase"];
            float TotalPrice = (float)(Purchase);
            float sessionpurchase = TotalPrice;
            Session["sessionpurchase"] = sessionpurchase;
            Response.Redirect("Payment.aspx");
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            SqlConnection con = UtilityDB.ConnectDB();
            SqlCommand cmdSearchCard = new SqlCommand();
            cmdSearchCard.Connection = con;
            cmdSearchCard.CommandText = "SELECT * FROM Cards WHERE Owner = @Owner;";
            cmdSearchCard.Parameters.AddWithValue("@Owner", Username);
            SqlDataReader reader = cmdSearchCard.ExecuteReader();
            if (reader.Read())
            {
                int CVV = Convert.ToInt32(reader["CVV"].ToString());
                if(TextBoxCVV.Text == CVV.ToString())
                {
                    purchaseBalance();
                    MessageBox.Show("Payment Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Response.Redirect("Store.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                    TextBoxCVV.Text = "";
                }
            }
        }
        public void purchaseBalance()
        {
            User user = new User();
            string Username = (string)Session["username"];
            user = user.SearchUserToChangeInfo(Username);
            float Purchase = (float)Session["purchase"];

            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            if (reader.Read())
            {
                float CurrentBalance = float.Parse(reader["Balance"].ToString());
                float newBalance = CurrentBalance + Purchase;
                user.Balance = newBalance.ToString();
                user.UpdateBalance(user);
            }
        }

        protected void ButtonAddCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePayment.aspx");
        }
    }
}