using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class SellCOC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            int intNumber;
            GameCOC gamecoc = new GameCOC();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regexPrice = new Regex(@"^[0-9]+(\.[0-9]{1,2})?$");
            if (TextBoxGem.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill Gems of your account!Please try again!');</script>");
            }
            else if (!int.TryParse(TextBoxGem.Text, out intNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct Gems of your account!Please try again!');</script>");
            }
            else if (TextBoxDescription.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill a simple description of your account!Please try again!');</script>");
            }
            else if (TextBoxPrice.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill a simple description of your account!Please try again!');</script>");
            }
            else if (!regexPrice.IsMatch(TextBoxPrice.Text.ToString()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct Price!Please try again!');</script>");
            }
            else if (TextBox1.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your account username!Please try again!');</script>");
            }
            else if (gamecoc.IsDuplicateEmail(TextBox1.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "Duplicate Account", "<script>alert('This account aleady exists!');</script>");
            }
            else if (!regex.IsMatch(TextBox1.Text.ToString()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Errot", "<script>alert('This is not email address!');</script>");
            }
            else if (TextBox2.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your account password!Please try again!');</script>");
            }
            else if (!FileUploadImg.HasFile)
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please upload an image!Please try again!');</script>");
            }
            else
            {
                string Username = (string)Session["username"];
                gamecoc.Gem = Int32.Parse(this.TextBoxGem.Text);
                gamecoc.THLevel = DropDownList1.SelectedValue.ToString();
                gamecoc.Description = this.TextBoxDescription.Text;
                gamecoc.Price = TextBoxPrice.Text;
                gamecoc.Seller = Username;
                gamecoc.State = "unapproved";
                gamecoc.PriceF = float.Parse(TextBoxPrice.Text);
                string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Path.GetExtension(FileUploadImg.FileName);
                string filepath = "/Image/UploadImage/CoC/" + filename;
                gamecoc.Image = "../Image/UploadImage/CoC/" + filename;
                FileUploadImg.SaveAs(MapPath(filepath));
                gamecoc.AccountEmail = this.TextBox1.Text;
                gamecoc.AccountPassword = this.TextBox2.Text;
                gamecoc.NoteFromAdmin = "";
                MessageBox.Show("Save Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                gamecoc.SaveCOCAccount(gamecoc);
                Response.Redirect("SellSuccess.aspx");
            }
        }
    }
}