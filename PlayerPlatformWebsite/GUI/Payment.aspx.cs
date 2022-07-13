using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            float Purchase = (float)Session["sessionpurchase"];
            float TotalPrice = (float)(Purchase * 1.15);
            LabelPrice.Text = "Total Price : $" + TotalPrice;
        }

        protected void ButtonPurchase_Click(object sender, EventArgs e)
        {
            string cardnumber = TextBoxCN.Text;
            string year = TextBoxEY.Text;
            string month = TextBoxEM.Text;
            
                if (RadioButtonList1.SelectedValue == "VISA")
                {
                    if (year == "2022")
                    {
                        if (month == "01" || month == "02" || month == "03" || month == "04" || month == "05")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Incorrect", "<script>alert('Invalid Date,please try again!');</script>");
                        }
                        else {
                            if (Regex.Match(cardnumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
                            {
                                purchaseBalance();
                                MessageBox.Show("Payment Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                                Response.Redirect("Store.aspx");
                        }
                            else
                            {
                            ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                            }
                        }
                    }
                    else
                    {
                        if (Regex.Match(cardnumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
                        {

                            purchaseBalance();
                        MessageBox.Show("Payment Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Response.Redirect("Store.aspx");
                            
                    }
                        else
                        {
                                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                    }
                    }
                }
                else if (RadioButtonList1.SelectedValue == "MasterCard")
                {
                if (year == "2022")
                {
                    if (month == "01" || month == "02" || month == "03" || month == "04" || month == "05")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Incorrect", "<script>alert('Invalid Date,please try again!');</script>");
                    }
                    else
                    {
                        if (Regex.Match(cardnumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
                        {
                            purchaseBalance();
                            MessageBox.Show("Payment Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                            Response.Redirect("Store.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                        }
                    }
                }
                    else {
                        if (Regex.Match(cardnumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
                        {
                            purchaseBalance();
                        MessageBox.Show("Payment Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Response.Redirect("Store.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                        }
                }
                }
                else if (RadioButtonList1.SelectedValue == "")
                {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please choose the type of card!');</script>");
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

           

            

        }
       
    }
