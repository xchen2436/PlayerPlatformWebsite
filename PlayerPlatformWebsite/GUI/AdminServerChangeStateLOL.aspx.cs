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
    public partial class AdminServerChangeStateLOL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AdminName = (string)Session["Admin"];
            LabelUsername.Text = "Welcome Back! " + AdminName;

            TextBoxServer.Enabled = false;
            TextBoxlevel.Enabled = false;
            TextBoxRank.Enabled = false;
            TextBoxRP.Enabled = false;
            TextBoxBE.Enabled = false;
            TextBoxChampion.Enabled = false;
            TextBoxSkin.Enabled = false;
            TextBoxDescription.Enabled = false;
            TextBoxPrice.Enabled = false;
            TextBoxId.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            int id = Convert.ToInt32(Session["changeStateId"]);
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
                    string Note = reader["NoteFromAdmin"].ToString();
                    TextBoxId.Text = Id;
                    TextBoxServer.Text = Server;
                    TextBoxlevel.Text = Level.ToString();
                    TextBoxRP.Text = RP.ToString();
                    TextBoxBE.Text = BE.ToString();
                    TextBoxChampion.Text = Champion.ToString();
                    TextBoxSkin.Text = Skin.ToString();
                    Image1.ImageUrl = Image;
                    TextBoxDescription.Text = Description.ToString();
                    TextBoxPrice.Text = Price.ToString();
                    TextBoxRank.Text = Rank.ToString();
                    TextBox1.Text = AccountUsername.ToString();
                    TextBox2.Text = AccountPassword.ToString();
                    DropDownList1.SelectedValue = Note;
                }
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            GameLOL gamelol = new GameLOL();
            if (DropDownList1.SelectedValue == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please choose one as note to user!');</script>");
            }
            else if(DropDownList1.SelectedValue == "Good to go")
            {
                string adminnote = DropDownList1.SelectedValue;
                string newState = "approved";
                int id = Convert.ToInt32(Session["changeStateId"]);
                gamelol = gamelol.SearchAccountById(id);
                gamelol.State = newState;
                gamelol.NoteFromAdmin = adminnote;
                gamelol.UpdateAccountAdmin(gamelol);
                MessageBox.Show("Update Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                Response.Redirect("AdmimChangeItemState.aspx");
            }
            else
            {
                string adminnote = DropDownList1.SelectedValue;
                string newState = "unapproved";
                int id = Convert.ToInt32(Session["changeStateId"]);
                gamelol = gamelol.SearchAccountById(id);
                gamelol.State = newState;
                gamelol.NoteFromAdmin = adminnote;
                gamelol.UpdateAccountAdmin(gamelol);
                MessageBox.Show("Update Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                Response.Redirect("AdmimChangeItemState.aspx");
            }
        }
    }
}