using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlayerPlatformWebsite.GUI
{
    public partial class AdmimChangeItemState : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            string AdminName = (string)Session["Admin"];
            LabelUsername.Text = "Welcome Back! " + AdminName;

            if (DropDownList1.SelectedItem.Text == "League of Legends")
            {

                string State = "unapproved";
                BoundField bfield = new BoundField();
                bfield.HeaderText = "Id";
                bfield.DataField = "Id";
                datagrid.Columns.Add(bfield);

                BoundField bfield1 = new BoundField();
                bfield1.HeaderText = "Server";
                bfield1.DataField = "Server";
                datagrid.Columns.Add(bfield1);

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


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where State = @State", con);
                cmd.Parameters.AddWithValue("@State", State);
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
                    LabelItemDisplay.Text = "";
                }
                else
                {
                    LabelItemDisplay.Text = "You don't have anything need to be solved";
                }


            }
            else if (DropDownList1.SelectedItem.Text == "Clash of Clans")
            {

                string State = "unapproved";

                BoundField bfield = new BoundField();
                bfield.HeaderText = "Id";
                bfield.DataField = "Id";
                datagrid.Columns.Add(bfield);

                BoundField bfield1 = new BoundField();
                bfield1.HeaderText = "TH Level";
                bfield1.DataField = "THLevel";
                datagrid.Columns.Add(bfield1);

                BoundField bfield3 = new BoundField();
                bfield3.HeaderText = "Description";
                bfield3.DataField = "Description";
                datagrid.Columns.Add(bfield3);

                BoundField bfield4 = new BoundField();
                bfield4.HeaderText = "Price";
                bfield4.DataField = "Price";
                datagrid.Columns.Add(bfield4);


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where State = @State", con);
                cmd.Parameters.AddWithValue("@State", State);
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
                    LabelItemDisplay.Text = "";
                }
                else
                {
                    LabelItemDisplay.Text = "You don't have anything need to be solved";
                }
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Home.aspx");
        }
        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(datagrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(datagrid.SelectedRow.Cells[0].Text);
            Session["changeStateId"] = Id;
           
            if (DropDownList1.SelectedItem.Text == "League of Legends")
            {
                Response.Redirect("AdminServerChangeStateLOL.aspx");

            }
            else if (DropDownList1.SelectedItem.Text == "Clash of Clans")
            {
                Response.Redirect("AdminServerChangeStateCOC.aspx");
            }
        }
    }
}