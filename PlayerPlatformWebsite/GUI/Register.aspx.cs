using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System.Security.Cryptography;

namespace PlayerPlatformWebsite.GUI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            User user = new User();
            string EmailCode = (string)Session["EmailCode"];
            if (TextBoxUsername.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your username!Please try again!');</script>");
            }
            else if (user.IsDuplicateUsername(TextBoxUsername.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "Duplicate username", "<script>alert('Username aleady exists!');</script>");
            }
            else if (TextBoxPassword.Text == "") {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your password!Please try again!');</script>");
            }
            else if (TextBoxConfirmPassword.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your confirmed password!Please try again!');</script>");
            }
            else if (TextBoxConfirmPassword.Text != TextBoxPassword.Text)
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Two time passwords is different!Please try again!');</script>");
            }
            else if (TextBoxVerificationCode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your Email Verify Code!Please try again!');</script>");
            }
            else if (TextBoxEmail.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your Email address!Please try again!');</script>");
            }
            else if (TextBoxVerificationCode.Text != EmailCode)
            {
                ClientScript.RegisterStartupScript(GetType(), "Invalid Code", "<script>alert('Invalid Email Verify Code! Please try again!');</script>");
                TextBoxVerificationCode.Text = null;
            }
            else {
                user.Username = this.TextBoxUsername.Text;
                user.Password = getMd5Hash(this.TextBoxPassword.Text);
                user.Email = this.TextBoxEmail.Text;
                user.SaveUser(user);
                MessageBox.Show("Register Successful!", "Successful", MessageBoxButtons.OK,MessageBoxIcon.None);
                //ClientScript.RegisterStartupScript(GetType(), "Successful", "<script>alert('Register Successful!');</script>");
                Response.Redirect("Login.aspx");
            }
        }
        protected void ButtonBackHome_Click(object sender, EventArgs e) {
            Response.Redirect("Home.aspx");
        }
        
        protected void ButtonSendEmailCode_Click(object sender, EventArgs e)
        {
            var randomGenerator = new Random();
            string emailcode = randomGenerator.Next(1001, 9999).ToString();
            if (TextBoxEmail.Text == ""){
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your email!Please try again!');</script>");
            }
            else {
                string SendEmail = TextBoxEmail.Text.ToString(); //To address    
                string SystemEmail = "xchen.montreal@outlook.com"; //From address    

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(SendEmail);
                if (match.Success)
                {
                    MailMessage message = new MailMessage(SystemEmail, SendEmail);
                    string mailbody = "<h3>Do not Reply</h3>" + "<p>Your email verify code is " + emailcode + ".</p>" +
                        "<p>Welcome to PlayerPlateform!<p><p>Enjoy your shopping!</p>";
                    message.Subject = "Email verification code";
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
                        Session["EmailCode"] = emailcode;
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

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (TextBoxUsername.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your username!Please try again!');</script>");
            }
            else if (user.IsDuplicateUsername(TextBoxUsername.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "Duplicate username", "<script>alert('Username aleady exists!');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Available username", "<script>alert('You can use this Username! :)');</script>");
            }
        }
        static string getMd5Hash(string input)
        { // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes // and create a string.
            StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}