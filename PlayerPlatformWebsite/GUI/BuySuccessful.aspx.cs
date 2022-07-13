using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlayerPlatformWebsite.GUI
{
    public partial class BuySuccessful : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            string Game = (string)Session["game"];
            if(Game == "LOL")
            {
                CreateAndDownloadFileLOL();
            }
            if(Game == "COC")
            {
                CreateAndDownloadFileCOC();
            }
            
        }
        public void CreateAndDownloadFileLOL()
        {
            //Create file
            int Id = Convert.ToInt32(Session["id"]);
            string fileSavePath = Server.MapPath("~/File");
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAccount = new SqlCommand();
            cmdSearchAccount.Connection = conn;
            cmdSearchAccount.CommandText = "SELECT * FROM LOLAccounts WHERE Id = @Id;";
            cmdSearchAccount.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmdSearchAccount.ExecuteReader();
            if (reader.Read())
            {
                string AUsername = reader["AccountUsername"].ToString();
                string APassword = reader["AccountPassword"].ToString();
                StreamWriter w;
                w = File.CreateText(fileSavePath + "/Account_" + Id + ".txt");
                w.WriteLine("Game : League of Legend");
                w.WriteLine("Accound Id:" + Id);
                w.WriteLine("Account Username:" + AUsername);
                w.WriteLine("Account Password:" + APassword);
                w.WriteLine("Thank you for choose us!");
                w.Flush();
                w.Close();
            }
            //Download file
            string filename = "Account_" + Id + ".txt";
            string filePath = Server.MapPath("~/File/") + filename;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your account username!Please try again!');</script>");
            }
        }

        public void CreateAndDownloadFileCOC()
        {
            //Create file
            int Id = Convert.ToInt32(Session["id"]);
            string fileSavePath = Server.MapPath("~/File");
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAccount = new SqlCommand();
            cmdSearchAccount.Connection = conn;
            cmdSearchAccount.CommandText = "SELECT * FROM COCAccounts WHERE Id = @Id;";
            cmdSearchAccount.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = cmdSearchAccount.ExecuteReader();
            if (reader.Read())
            {
                string AUsername = reader["AccountEmail"].ToString();
                string APassword = reader["AccountPassword"].ToString();
                StreamWriter w;
                w = File.CreateText(fileSavePath + "/Account_" + Id + ".txt");
                w.WriteLine("Game : Clash of Clans");
                w.WriteLine("Accound Id: " + Id);
                w.WriteLine("Account Email: " + AUsername);
                w.WriteLine("Account Password: " + APassword);
                w.WriteLine("Thank you for choose us!");
                w.Flush();
                w.Close();
            }
            //Download file
            string filename = "Account_" + Id + ".txt";
            string filePath = Server.MapPath("~/File/") + filename;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
    }
}