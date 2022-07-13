using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class AdminServerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AdminName = (string)Session["Admin"];
            LabelUsername.Text = "Welcome Back! " + AdminName;
            TextBoxId.Enabled = false;
            TextTitle.Enabled = false;
            TextBoxdescribe.Enabled = false;
            TextBoxDate.Enabled = false;
            TextBoxRequester.Enabled = false;
            int OrderId = Convert.ToInt32(Session["Orderid"]);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchAccount = new SqlCommand();
            cmdSearchAccount.Connection = conn;
            cmdSearchAccount.CommandText = "SELECT * FROM Servers WHERE OrderId = @OrderId;";
            cmdSearchAccount.Parameters.AddWithValue("@OrderId", OrderId);
            SqlDataReader reader = cmdSearchAccount.ExecuteReader();
            if (reader.Read())
            {
                int Orderid = Convert.ToInt32(reader["OrderId"].ToString());
                string Title = reader["Title"].ToString();
                string Date = reader["Date"].ToString();
                string Description = reader["Description"].ToString();
                string Buyer = reader["Requester"].ToString();
                TextBoxId.Text = Orderid.ToString();
                TextTitle.Text = Title.ToString();
                TextBoxDate.Text = Date.ToString();
                TextBoxRequester.Text = Buyer.ToString();
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");
                TextBoxdescribe.Text = regex.Replace(Description, "\r\n"); ;
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            string Username = TextBoxRequester.Text;
            int OrderId = Convert.ToInt32(Session["Orderid"]);
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchPassword = new SqlCommand();
            cmdSearchPassword.Connection = conn;
            cmdSearchPassword.CommandText = "SELECT * FROM Users WHERE Username = @Username;";
            cmdSearchPassword.Parameters.AddWithValue("@Username", Username);
            SqlDataReader reader = cmdSearchPassword.ExecuteReader();
            if (reader.Read())
            {
                string ReplyMessage = TextBoxReply.Text.Replace(Environment.NewLine, "<br/>"); ;
                string SystemEmail = "xxxxxxx"; //From address    
                string SendEmail = reader["Email"].ToString();//To address 
                MailMessage message = new MailMessage(SystemEmail, SendEmail);
                string mailbody = "<h3>Hello " + Username  +"</h3>" + "<p>" + ReplyMessage + "</p>"+
                    "<p>Thank you to choose PlayerPlateform!<p><p>Enjoy your life!</p>";
                message.Subject = "PlayerPlateform Support";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                System.Net.NetworkCredential basicCredential = new
                System.Net.NetworkCredential("xxxxxxx", "xxxxxxx");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
                try
                {
                    client.Send(message);
                    Server server = new Server();
                    server = server.SearchOrderTOChange(OrderId);
                    server.State = "Done";
                    server.UpdateState(server);
                    MessageBox.Show("The email has been send to user", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Response.Redirect("AdminServer.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}