using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlayerPlatformWebsite.GUI
{
    public partial class Sell : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
        }

        protected void ImageButtonLOL_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SellLOL.aspx");
        }

        protected void ImageButtonCOC_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SellCOC.aspx");
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ImageButtonR6_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButtonFIFA_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}