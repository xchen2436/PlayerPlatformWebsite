using PlayerPlatformWebsite.BLL;
using PlayerPlatformWebsite.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class ProfileChangeItemInfoLOLUnapproved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Label1.Text = "You can modify your account information here.";
                string Username = (string)Session["username"];
                LabelUsername.Text = "Hi! " + Username;
                TextBoxId.Enabled = false;
                int id = Convert.ToInt32(Session["id"]);
                SqlConnection conn = UtilityDB.ConnectDB();
                SqlCommand cmdSearchAccount = new SqlCommand();
                cmdSearchAccount.Connection = conn;
                cmdSearchAccount.CommandText = "SELECT * FROM LOLAccounts WHERE Id = @Id;";
                cmdSearchAccount.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmdSearchAccount.ExecuteReader();
                if (reader.Read())
                {
                    string Id = reader["Id"].ToString();
                    string Server = reader["Server"].ToString();
                    int Level = Convert.ToInt32(reader["Level"]);
                    string Rank = reader["Rank"].ToString();
                    int RP = Convert.ToInt32(reader["RP"]);
                    int BE = Convert.ToInt32(reader["BE"]);
                    int Champion = Convert.ToInt32(reader["Champion"]);
                    int Skin = Convert.ToInt32(reader["Skin"]);
                    string Description = reader["Description"].ToString();
                    string Price = reader["Price"].ToString();
                    string Image = reader["Image"].ToString();
                    string AccountUsername = reader["AccountUsername"].ToString();
                    string AccountPassword = reader["AccountPassword"].ToString();
                    TextBoxId.Text = Id;
                    DropDownList2.SelectedValue = Server;
                    TextBoxlevel.Text = Level.ToString();
                    DropDownList1.SelectedValue = Rank;
                    TextBoxRP.Text = RP.ToString();
                    TextBoxBE.Text = BE.ToString();
                    TextBoxChampion.Text = Champion.ToString();
                    TextBoxSkin.Text = Skin.ToString();
                    TextBoxDescription.Text = Description.ToString();
                    TextBoxPrice.Text = Price.ToString();
                    Image1.ImageUrl = Image;
                    TextBox1.Text = AccountUsername;
                    //TextBox2.Text = AccountPassword;
                }
            }
           


        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Home.aspx");
        }
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int intNumber;
            float floatNumber;
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
            else if (!float.TryParse(TextBoxPrice.Text, out floatNumber))
            {
                ClientScript.RegisterStartupScript(GetType(), "Error", "<script>alert('Please fill correct Price!Please try again!');</script>");
            }
            else if (TextBox1.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please fill your account username!Please try again!');</script>");
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
                GameLOL gamelol = new GameLOL();
                string Username = (string)Session["username"];
                int Id = Convert.ToInt32(TextBoxId.Text);
                gamelol = gamelol.SearchAccountById(Id);
                if (gamelol != null)
                {
                    gamelol.Id = Convert.ToInt32(TextBoxId.Text);
                    gamelol.Level = Int32.Parse(TextBoxlevel.Text);
                    gamelol.Rank = DropDownList1.SelectedValue.ToString();
                    gamelol.Server = DropDownList2.SelectedValue.ToString(); ;
                    gamelol.Champion = Int32.Parse(TextBoxChampion.Text);
                    gamelol.Skin = Int32.Parse(TextBoxSkin.Text);
                    gamelol.RP = Int32.Parse(TextBoxRP.Text);
                    gamelol.BE = Int32.Parse(TextBoxBE.Text);
                    gamelol.Description = TextBoxDescription.Text;
                    gamelol.Price = TextBoxPrice.Text;
                    gamelol.Seller = Username;
                    gamelol.PriceF = float.Parse(TextBoxPrice.Text);
                    gamelol.State = "unapproved";
                    string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + Path.GetExtension(FileUploadImg.FileName);
                    string filepath = "/Image/UploadImage/LoL/" + filename;
                    gamelol.Image = "../Image/UploadImage/LoL/" + filename;
                    FileUploadImg.SaveAs(MapPath(filepath));
                    gamelol.AccountUsername = TextBox1.Text;
                    gamelol.AccountPassword = TextBox2.Text;
                    gamelol.UpdateAccount(gamelol);
                    MessageBox.Show("Update Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Response.Redirect("ProfileViewSellItem.aspx");
                }

                
                
            }
        }
    }
}