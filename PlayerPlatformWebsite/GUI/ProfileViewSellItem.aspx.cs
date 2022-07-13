using PlayerPlatformWebsite.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PlayerPlatformWebsite.GUI
{
    public partial class ProfileViewSellItem : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = (string)Session["username"];
            LabelUsername.Text = "Hi! " + Username;

            if (DropDownList1.SelectedItem.Text == "Please select a game")
            {
                LabelItemDisplay.Text = "Please select a game you want to view.";
            }
            else if (DropDownList1.SelectedItem.Text == "League of Legends")
            {

                BoundField bfield = new BoundField();
                bfield.HeaderText = "Id";
                bfield.DataField = "Id";
                datagrid.Columns.Add(bfield);

                BoundField bfield1 = new BoundField();
                bfield1.HeaderText = "Server";
                bfield1.DataField = "Server";
                datagrid.Columns.Add(bfield1);

                BoundField bfield2 = new BoundField();
                bfield2.HeaderText = "Level";
                bfield2.DataField = "Level";
                datagrid.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.HeaderText = "Rank";
                bfield3.DataField = "Rank";
                datagrid.Columns.Add(bfield3);

                BoundField bfield4 = new BoundField();
                bfield4.HeaderText = "Description";
                bfield4.DataField = "Description";
                datagrid.Columns.Add(bfield4);

                BoundField bfield5 = new BoundField();
                bfield5.HeaderText = "Price";
                bfield5.DataField = "Price";
                datagrid.Columns.Add(bfield5);

                BoundField bfield6 = new BoundField();
                bfield6.HeaderText = "State";
                bfield6.DataField = "State";
                datagrid.Columns.Add(bfield6);

                BoundField bfield7 = new BoundField();
                bfield7.HeaderText = "NoteFromAdmin";
                bfield7.DataField = "NoteFromAdmin";
                datagrid.Columns.Add(bfield7);

                LabelItemDisplay.Text = "Here are the items you are selling about League of Legends";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Seller = @Seller", con);
                cmd.Parameters.AddWithValue("@Seller", Username);
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                }
                else
                {
                    LabelItemDisplay.Text = "You don't have any items to sell right now";
                }

                
            }
            else if (DropDownList1.SelectedItem.Text == "Clash of Clans")
            {

                BoundField bfield = new BoundField();
                bfield.HeaderText = "Id";
                bfield.DataField = "Id";
                datagrid.Columns.Add(bfield);

                BoundField bfield1 = new BoundField();
                bfield1.HeaderText = "TH Level";
                bfield1.DataField = "THLevel";
                datagrid.Columns.Add(bfield1);

                BoundField bfield2 = new BoundField();
                bfield2.HeaderText = "Gem";
                bfield2.DataField = "Gem";
                datagrid.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.HeaderText = "Description";
                bfield3.DataField = "Description";
                datagrid.Columns.Add(bfield3);

                BoundField bfield4 = new BoundField();
                bfield4.HeaderText = "Price";
                bfield4.DataField = "Price";
                datagrid.Columns.Add(bfield4);

                BoundField bfield5 = new BoundField();
                bfield5.HeaderText = "State";
                bfield5.DataField = "State";
                datagrid.Columns.Add(bfield5);

                BoundField bfield6 = new BoundField();
                bfield6.HeaderText = "NoteFromAdmin";
                bfield6.DataField = "NoteFromAdmin";
                datagrid.Columns.Add(bfield6);

                LabelItemDisplay.Text = "Here are the items you are selling about Clash of Clans";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where Seller = @Seller", con);
                cmd.Parameters.AddWithValue("@Seller", Username);
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                }
                else
                {
                    LabelItemDisplay.Text = "You don't have any items to sell right now";
                }
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["balance"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = datagrid.SelectedRow.Cells[7].Text;
            Session["State"] = state;
            int id = Convert.ToInt32(datagrid.SelectedRow.Cells[1].Text);
            Session["id"] = id;
            if (DropDownList1.SelectedItem.Text == "League of Legends")
            {
                if (datagrid.SelectedRow.Cells[7].Text == "unapproved")
                {
                    Response.Redirect("ProfileChangeItemInfoLOLUnapproved.aspx");
                }
                else
                {
                    Response.Redirect("ProfileChangeItemInfoLOLApproved.aspx");
                }

            }
            else if (DropDownList1.SelectedItem.Text == "Clash of Clans") 
            {
                if (datagrid.SelectedRow.Cells[6].Text == "unapproved")
                {
                    Response.Redirect("ProfileChangeItemInfoCOCUnapproved.aspx");
                }
                else
                {
                    Response.Redirect("ProfileChangeItemInfoCOCApproved.aspx");
                }
            }
                
        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(datagrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        
    }
}