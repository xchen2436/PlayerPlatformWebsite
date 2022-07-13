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
    public partial class ManagePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            if (!IsPostBack)
            {
                Card card = new Card();
                if (card.IsDuplicateCard(Username))
                {
                    ButtonSave.Text = "Update";
                    SqlConnection conn = UtilityDB.ConnectDB();
                    SqlCommand cmdSearchCard = new SqlCommand();
                    cmdSearchCard.Connection = conn;
                    cmdSearchCard.CommandText = "SELECT * FROM Cards WHERE Owner = @Owner;";
                    cmdSearchCard.Parameters.AddWithValue("@Owner", Username);
                    SqlDataReader reader = cmdSearchCard.ExecuteReader();
                    if (reader.Read())
                    {
                        string CardNumber = reader["CardNumber"].ToString();
                        string CardHolder = reader["CardHolder"].ToString();
                        string ExpiredMonth = reader["ExpiredMonth"].ToString();
                        int ExpiredYear = Convert.ToInt32(reader["ExpiredYear"]);
                        int CVV = Convert.ToInt32(reader["CVV"]);
                        string Type = reader["Type"].ToString();
                        TextBoxCN.Text = CardNumber;
                        TextBoxCHN.Text = CardHolder;
                        TextBoxEM.Text = ExpiredMonth.ToString();
                        TextBoxEY.Text = ExpiredYear.ToString();
                        //TextBoxCVV.Text = CVV.ToString();
                        RadioButtonList1.Items.FindByValue(Type).Selected = true;
                    }
                }
                
            }
        }
        public void savecard()
        {
            Card card = new Card();
            string Username = (string)Session["username"];
            card.Owner = Username;
            card.CardNumber = TextBoxCN.Text;
            card.CardHolder = TextBoxCHN.Text;
            card.ExpiredMonth = TextBoxEM.Text;
            card.ExpiredYear = Convert.ToInt32(TextBoxEY.Text);
            card.CVV = Convert.ToInt32(TextBoxCVV.Text);
            card.Type = RadioButtonList1.SelectedValue;
            card.SaveCard(card);
        }
        public void updatecard()
        {
            Card card = new Card();
            string Username = (string)Session["username"];
            card = card.SearchCardToChangeInfo(Username);
            if (card != null)
            {
                card.Owner = Username;
                card.CardNumber = TextBoxCN.Text;
                card.CardHolder = TextBoxCHN.Text;
                card.ExpiredMonth = TextBoxEM.Text;
                card.ExpiredYear = Convert.ToInt32(TextBoxEY.Text);
                card.CVV = Convert.ToInt32(TextBoxCVV.Text);
                card.Type = RadioButtonList1.SelectedValue;
                card.UpdateCard(card);
            }
        }
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Card card = new Card();
            string Username = (string)Session["username"];
            if (card.IsDuplicateCard(Username))
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
                        else
                        {
                            if (Regex.Match(cardnumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
                            {
                                updatecard();
                                MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                                Response.Redirect("Profile.aspx");
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
                            updatecard();
                            MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                            Response.Redirect("Profile.aspx");

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
                                updatecard();
                                MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                                Response.Redirect("Profile.aspx");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                            }
                        }
                    }
                    else
                    {
                        if (Regex.Match(cardnumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
                        {
                            updatecard();
                            MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                            Response.Redirect("Profile.aspx");
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
            else
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
                        else
                        {
                            if (Regex.Match(cardnumber, @"^4[0-9]{12}(?:[0-9]{3})?$").Success)
                            {
                                savecard();
                                MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                                Response.Redirect("Profile.aspx");
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
                            savecard();
                            MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                            Response.Redirect("Profile.aspx");

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
                                savecard();
                                MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                                Response.Redirect("Profile.aspx");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Payment failed, please try again or change another card!');</script>");
                            }
                        }
                    }
                    else
                    {
                        if (Regex.Match(cardnumber, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$").Success)
                        {
                            savecard();
                            MessageBox.Show("Save Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                            Response.Redirect("Profile.aspx");
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
            
        }
    }
}