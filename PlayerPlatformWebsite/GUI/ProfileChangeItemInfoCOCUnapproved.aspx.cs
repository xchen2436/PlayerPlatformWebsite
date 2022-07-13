using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class ProfileChangeItemInfoCOCUnapproved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Username = (string)Session["username"];
                LabelUsername.Text = "Hi! " + Username;
                Label1.Text = "You can modify your account information here.";
                int id = Convert.ToInt32(Session["id"]);
                TextBoxId.Enabled = false;
                SqlConnection conn = UtilityDB.ConnectDB();
                SqlCommand cmdSearchAccount = new SqlCommand();
                cmdSearchAccount.Connection = conn;
                cmdSearchAccount.CommandText = "SELECT * FROM COCAccounts WHERE Id = @Id;";
                cmdSearchAccount.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmdSearchAccount.ExecuteReader();
                if (reader.Read())
                {
                    string Id = reader["Id"].ToString();
                    int Level = Convert.ToInt32(reader["THLevel"]);
                    string Description = reader["Description"].ToString();
                    int Gem = Convert.ToInt32(reader["Gem"]);
                    string Price = reader["Price"].ToString();
                    string Image = reader["Image"].ToString();
                    string AccountEmail = reader["AccountEmail"].ToString();
                    TextBoxGem.Text = Gem.ToString();
                    TextBoxId.Text = id.ToString();
                    DropDownList1.SelectedValue = Level.ToString();
                    Image1.ImageUrl = Image;
                    TextBox1.Text = AccountEmail;
                    TextBoxDescription.Text = Description.ToString();
                    TextBoxPrice.Text = Price.ToString();
                }
            }
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
                int Id = Convert.ToInt32(TextBoxId.Text);
                gamecoc = gamecoc.SearchAccountById(Id);
                gamecoc.Gem = Int32.Parse(this.TextBoxGem.Text);
                gamecoc.THLevel = DropDownList1.SelectedValue.ToString();
                gamecoc.Description = this.TextBoxDescription.Text;
                gamecoc.Price = TextBoxPrice.Text;
                gamecoc.PriceF = float.Parse(TextBoxPrice.Text);
                string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Path.GetExtension(FileUploadImg.FileName);
                string filepath = "/Image/UploadImage/CoC/" + filename;
                gamecoc.Image = "../Image/UploadImage/CoC/" + filename;
                FileUploadImg.SaveAs(MapPath(filepath));
                gamecoc.AccountEmail = this.TextBox1.Text;
                gamecoc.AccountPassword = this.TextBox2.Text;
                MessageBox.Show("Update Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                gamecoc.UpdateAccount(gamecoc);
                Response.Redirect("ProfileViewSellItem.aspx");
            }
        }
    }
}