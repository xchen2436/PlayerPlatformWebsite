using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TextBoxUsername.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter your username!');</script>");
            }
            else if (TextBoxPassword.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter your password!');</script>");
            }
            else if (TextBoxCheckCode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please enter the verification code!');</script>");
            }
            else if (FormsAuthentication.Authenticate(TextBoxUsername.Text, TextBoxPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(TextBoxUsername.Text,false);
                string sessionusername = TextBoxUsername.Text;
                Session["admin"] = sessionusername;
            }
            else
            {
                User user = new User();
                if (user.IsValidateLogin(TextBoxUsername.Text, getMd5Hash(TextBoxPassword.Text)) == true) {
                    string sessionusername = TextBoxUsername.Text;
                    Session["username"] = sessionusername;
                    SqlConnection conn = UtilityDB.ConnectDB();
                    SqlCommand cmdSearchPassword = new SqlCommand();
                    cmdSearchPassword.Connection = conn;
                    cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
                    cmdSearchPassword.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
                    SqlDataReader reader = cmdSearchPassword.ExecuteReader();
                        if (reader.Read())
                        {
                        if (Request.Cookies["CheckCode"] != null)
                        {
                            string CheckCodeimg = Request.Cookies["CheckCode"].Value;
                            CheckCodeimg = Server.HtmlEncode(CheckCodeimg);
                            if (TextBoxCheckCode.Text == CheckCodeimg)
                            {
                                Response.Redirect("Store.aspx");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Incorrect", "<script>alert('Verification code incorrect!');</script>");
                                TextBoxCheckCode.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Incorrect", "<script>alert('Invalid Username or Password!');</script>");
                }
            }
        }
        protected void ButtonBackHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        static string getMd5Hash(string input)
        { 
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create(); // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder(); // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}