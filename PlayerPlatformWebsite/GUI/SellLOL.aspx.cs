using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PlayerPlatformWebsite.GUI
{
    public partial class SellLOL : System.Web.UI.Page
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
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int intNumber;
            Regex regexPrice = new Regex(@"^[0-9]+(\.[0-9]{1,2})?$");
            GameLOL gamelol = new GameLOL();
            if (TextBoxlevel.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill level!Please try again!');</script>");
            }
            else if (!int.TryParse(TextBoxlevel.Text, out intNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct level!Please try again!');</script>");
            }
            if (TextBoxChampion.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill number of champions!Please try again!');</script>");
            }
            else if (!int.TryParse(TextBoxChampion.Text, out intNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct number of champions!Please try again!');</script>");
            }
            if (TextBoxSkin.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill number of skin!Please try again!');</script>");
            }
            else if (!int.TryParse(TextBoxSkin.Text, out intNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct number of skin!Please try again!');</script>");
            }
            else if (TextBoxRP.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill RP in your account!Please try again!');</script>");
            }
            else if (!int.TryParse(TextBoxRP.Text, out intNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct RP!Please try again!');</script>");
            }
            else if (TextBoxBE.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill BE in your account!Please try again!');</script>");
            }
            else if (!int.TryParse(TextBoxBE.Text, out intNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct BE!Please try again!');</script>");
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
            else if (gamelol.IsDuplicateAccountUsername(TextBox1.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "Duplicate Account", "<script>alert('This account aleady exists!');</script>");
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
                gamelol.Level = Int32.Parse(this.TextBoxlevel.Text);
                gamelol.Rank = DropDownList1.SelectedValue.ToString();
                gamelol.Server = DropDownList2.SelectedValue.ToString(); ;
                gamelol.Champion = Int32.Parse(this.TextBoxChampion.Text);
                gamelol.Skin = Int32.Parse(this.TextBoxSkin.Text);
                gamelol.RP = Int32.Parse(this.TextBoxRP.Text);
                gamelol.BE = Int32.Parse(this.TextBoxBE.Text);
                gamelol.Description = this.TextBoxDescription.Text;
                gamelol.Price = TextBoxPrice.Text.ToString();
                gamelol.PriceF = float.Parse(TextBoxPrice.Text);
                gamelol.Seller = Username;
                gamelol.State = "unapproved";
                string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Path.GetExtension(FileUploadImg.FileName);
                string filepath = "/Image/UploadImage/LoL/" + filename;
                gamelol.Image = "../Image/UploadImage/LoL/" + filename;
                FileUploadImg.SaveAs(MapPath(filepath));
                gamelol.AccountUsername = this.TextBox1.Text;
                gamelol.AccountPassword = this.TextBox2.Text;
                gamelol.NoteFromAdmin = "";
                gamelol.SaveLOLAccount(gamelol);
                Response.Redirect("SellSuccess.aspx");
            }

        }
    }
}