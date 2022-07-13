using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlayerPlatformWebsite.GUI
{
    public partial class About : System.Web.UI.Page
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

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            string sessionusername = Username;
            Session["username"] = sessionusername;
            Response.Redirect("Store.aspx");
        }
    }
}