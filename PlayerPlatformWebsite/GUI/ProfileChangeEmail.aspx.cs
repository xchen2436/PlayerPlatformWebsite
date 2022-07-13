using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class ProfileChangeEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
            string CurrentEmail = (string)Session["currentEmail"];
            LabelEmailInfo.Text = CurrentEmail;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string ChangeEmailCode = (string)Session["ChangeEmailCode"];
            if (TextBoxCode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('You didn't fill your Email Verify Code!Please try again!');</script>");
            }
            else if (TextBoxCode.Text != ChangeEmailCode)
            {
                ClientScript.RegisterStartupScript(GetType(), "Invalid", "<script>alert('Invalid Email Verify Code! Please try again!');</script>");
                TextBoxCode.Text = null;
            }
            else
            {
                User user = new User();
                string Username = (string)Session["username"];
                user = user.SearchUserToChangeInfo(Username);
                string NewEmail = TextBoxNewEmail.Text.ToString();

                SqlConnection conn = UtilityDB.ConnectDB();
                SqlCommand cmdChangeEmail = new SqlCommand();
                cmdChangeEmail.Connection = conn;
                cmdChangeEmail.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
                cmdChangeEmail.Parameters.AddWithValue("@Username", Username);
                SqlDataReader reader = cmdChangeEmail.ExecuteReader();
                if (reader.Read())
                {
                    user.Email = NewEmail;
                    user.UpdateEmail(user);
                    //ClientScript.RegisterStartupScript(GetType(), "Success", "<script>alert('Change Email Address Successful!');</script>");
                    MessageBox.Show("Change Email Address Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Response.Redirect("Profile.aspx");
                }

                
            }
        }

        protected void SendCode_Click(object sender, EventArgs e)
        {
            if (TextBoxNewEmail.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('You didn't fill your Email address!Please try again!');</script>");
            }
            else
            {
                var randomGenerator = new Random();
                string emailcode = randomGenerator.Next(1001, 9999).ToString();
                string OldEmail = LabelEmailInfo.Text.ToString();
                string NewEmail = TextBoxNewEmail.Text.ToString(); //To address    
                string SystemEmail = "xxxxxxx.xxxxxxx@outlook.com"; //From address    
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(NewEmail);
                if (match.Success)
                {
                    MailMessage message = new MailMessage(SystemEmail, OldEmail);
                    string mailbody = "<h3>Do not Reply</h3>" + "<p>Your are changing your Email address from "+ OldEmail+ " TO "+NewEmail + ".</p><P>email verify code is " + emailcode + ".</p>" +
                        "<p>Welcome to PlayerPlateform!<p><p>Enjoy your shopping!</p>";
                    message.Subject = "Email verification code";
                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                    System.Net.NetworkCredential basicCredential = new
                    System.Net.NetworkCredential("xxxxxxx.xxxxxxx@outlook.com", "xxxxxxx");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential;
                    try
                    {
                        
                        Session["ChangeEmailCode"] = emailcode;
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('The Email has sent!');</script>");
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "Invalid Email", "<script>alert('This is not the valid email address!Please try again!');</script>");
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}