using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class FindPasswordSecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string EmailCodeForChangePassword = (string)Session["EmailCodeForChangePassword"];
            if (TextBoxPassword.Text == "")
            {
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
            else if (TextBoxVerificationCode.Text != EmailCodeForChangePassword) 
            {
                ClientScript.RegisterStartupScript(GetType(), "Invalid Code", "<script>alert('Invalid Email Verify Code! Please try again!');</script>");
                TextBoxVerificationCode.Text = null;
            }
            else
            {
                User user = new User();
                string Username = (string)Session["UsernameForChangePassword"];
                user = user.SearchUserToChangeInfo(Username);
                string NewPassword = TextBoxConfirmPassword.Text.ToString();
                SqlConnection conn = UtilityDB.ConnectDB();
                SqlCommand cmdChangePassword = new SqlCommand();
                cmdChangePassword.Connection = conn;
                cmdChangePassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
                cmdChangePassword.Parameters.AddWithValue("@Username", Username);
                SqlDataReader reader = cmdChangePassword.ExecuteReader();
                if (reader.Read())
                {
                    string newPasswordAfterHash = getMd5Hash(NewPassword);
                    user.Password = newPasswordAfterHash;
                    user.UpdatePassword(user);
                    MessageBox.Show("Change Password Successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Response.Redirect("Login.aspx");
                }
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