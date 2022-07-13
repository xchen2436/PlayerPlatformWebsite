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
    public partial class ProfileChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (TextBoxNewPassword.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('You didn't fill your Password!Please try again!');</script>");
            }
            else if (TextBoxNewPasswordConfirm.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('You didn't fill your Confirm Password!Please try again!');</script>");
            }
            else if (TextBoxNewPasswordConfirm.Text != TextBoxNewPassword.Text)
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Two time passwords is different!Please try again!');</script>");
            }
            else
            {
                User user = new User();
                string Username = (string)Session["username"];
                user = user.SearchUserToChangeInfo(Username);
                string NewPassword = TextBoxNewPasswordConfirm.Text.ToString();
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
                    //ClientScript.RegisterStartupScript(GetType(), "Success", "<script>alert('Change Password Successful!');</script>");
                    Response.Redirect("Profile.aspx");
                }
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");

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