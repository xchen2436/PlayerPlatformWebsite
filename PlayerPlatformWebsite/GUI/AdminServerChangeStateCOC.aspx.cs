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
    public partial class AdminServerChangeStateCOC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AdminName = (string)Session["Admin"];
                LabelUsername.Text = "Welcome Back! " + AdminName;

                TextBoxTHlevel.Enabled = false;
                TextBoxGem.Enabled = false;
                TextBoxDescription.Enabled = false;
                TextBoxPrice.Enabled = false;
                TextBoxId.Enabled = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                int id = Convert.ToInt32(Session["changeStateId"]);
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
                    int Gem = Convert.ToInt32(reader["Gem"]);
                    string Description = reader["Description"].ToString();
                    string Price = reader["Price"].ToString();
                    string Image = reader["Image"].ToString();
                    string AccountUsername = reader["AccountEmail"].ToString();
                    string AccountPassword = reader["AccountPassword"].ToString();
                    string Note = reader["NoteFromAdmin"].ToString();
                    TextBoxId.Text = Id;
                    TextBoxTHlevel.Text = Level.ToString();
                    TextBoxGem.Text = Gem.ToString();
                    Image1.ImageUrl = Image;
                    TextBoxDescription.Text = Description.ToString();
                    TextBoxPrice.Text = Price.ToString();
                    TextBox1.Text = AccountUsername.ToString();
                    TextBox2.Text = AccountPassword.ToString();
                    DropDownList1.SelectedValue = Note;
                }
            }
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            GameCOC gamecoc = new GameCOC();
            if (DropDownList1.SelectedValue == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Empty", "<script>alert('Please choose one as note to user!');</script>");
            }
            else if (DropDownList1.SelectedValue == "Good to go")
            {
                string adminnote = DropDownList1.SelectedValue;
                string newState = "approved";
                int id = Convert.ToInt32(Session["changeStateId"]);
                gamecoc = gamecoc.SearchAccountById(id);
                gamecoc.State = newState;
                gamecoc.NoteFromAdmin = adminnote;
                gamecoc.UpdateAccountAdmin(gamecoc);
                MessageBox.Show("Update Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                Response.Redirect("AdmimChangeItemState.aspx");
            }
            else
            {
                string adminnote = DropDownList1.SelectedValue;
                string newState = "unapproved";
                int id = Convert.ToInt32(Session["changeStateId"]);
                gamecoc = gamecoc.SearchAccountById(id);
                gamecoc.State = newState;
                gamecoc.NoteFromAdmin = adminnote;
                gamecoc.UpdateAccountAdmin(gamecoc);
                MessageBox.Show("Update Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.None);
                Response.Redirect("AdmimChangeItemState.aspx");
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}