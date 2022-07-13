using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class CustomerServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = Username;
            int id = Convert.ToInt32(Session["id"]);
            TextBoxId.Text = id.ToString();
            TextBoxId.Enabled = false;
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if(TextTitle.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill all textbox!');</script>");
            }
            else if(TextBoxdescribe.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill all textbox!');</script>");
            }
            else
            {
                Server server = new Server();
                int id = Convert.ToInt32(Session["id"]);
                string Username = (string)Session["username"];
                server.OrderId = id;
                server.Title = TextTitle.Text;
                server.Requester = Username;
                server.Description = TextBoxdescribe.Text.Replace(Environment.NewLine, "<br/>");
                server.State = "Processing";
                server.Date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
                server.SaveRequest(server);
                MessageBox.Show("Submitted successfully, we will process it as soon as possible", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                Response.Redirect("Profile.aspx");
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