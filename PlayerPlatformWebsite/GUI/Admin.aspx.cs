using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlayerPlatformWebsite.GUI
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AdminName = (string)Session["Admin"];
            LabelUsername.Text = "Welcome Back! " + AdminName;
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ImageButtonrequest_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdminServer.aspx");
        }

        protected void ImageButtonItemState_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdmimChangeItemState.aspx");
        }
    }
}