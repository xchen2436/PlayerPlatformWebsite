using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using PlayerPlatformWebsite.DAL;

namespace PlayerPlatformWebsite.GUI
{
    public partial class FindPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonSendPassword_Click(object sender, EventArgs e)
        {
            if (TextBoxUsername.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter your username!');</script>");
            }
            else if (TextBoxEmail.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter your Email Address!');</script>");
            
        }
            else
            {
                User user = new User();
                if (user.IsValidateAccount(TextBoxUsername.Text, TextBoxEmail.Text) == true)
                {
                    SqlConnection conn = UtilityDB.ConnectDB();
                    SqlCommand cmdSearchPassword = new SqlCommand();
                    cmdSearchPassword.Connection = conn;
                    cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username AND Email = @Email;";
                    cmdSearchPassword.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
                    cmdSearchPassword.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
                    SqlDataReader reader = cmdSearchPassword.ExecuteReader();
                    if (reader.Read())
                    {
                        var randomGenerator = new Random();
                        string emailcode = randomGenerator.Next(1001, 9999).ToString();
                        string SendEmail = TextBoxEmail.Text.ToString(); //To address    
                        string SystemEmail = "xchen.montreal@outlook.com"; //From address    
                        MailMessage message = new MailMessage(SystemEmail, SendEmail);
                        string mailbody = "<h3>Do not Reply</h3>" + "<p>This email verify code is helping you to change password, the verify code is " + emailcode + ".</p>" +
                            "<p>Welcome to PlayerPlateform!<p><p>Enjoy your shopping!</p>";
                        message.Subject = "Email verification code for change password";
                        message.Body = mailbody;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                        System.Net.NetworkCredential basicCredential = new
                        System.Net.NetworkCredential("xchen.montreal@outlook.com", "chenxiao713");
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = basicCredential;
                        try
                        {
                            string EmailCodeForChangePassword = emailcode;
                            Session["EmailCodeForChangePassword"] = EmailCodeForChangePassword;
                            string Username = TextBoxUsername.Text;
                            Session["UsernameForChangePassword"] = Username;
                            client.Send(message);
                            Response.Redirect("FindPasswordSecondPage.aspx");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('We cannot find your information!');</script>");
                    //MessageBox.Show("We cannot find your information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

    }
}