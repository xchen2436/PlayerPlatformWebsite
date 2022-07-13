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
    public partial class BuyLOL : System.Web.UI.Page
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
                string state = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where State = @State", con);
                cmd.Parameters.AddWithValue("@State", state);
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
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't have anything account right now!";
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
            int id = Convert.ToInt32(datagrid.SelectedRow.Cells[1].Text);
            Session["id"] = id;
            Response.Redirect("BuyLOLDetail.aspx?Id="+ id);
        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(datagrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "$0-$50")
            {
                int PriceMin = 0;
                int PriceMax = 50;
                string Server = DropDownList2.SelectedValue;
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Server = @Server and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@Server", Server);
                cmd.Parameters.AddWithValue("@PriceMin", PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", PriceMax);
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
                    Label6.Text = "";
                }
                else
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't find anything here";
                }
            }
            else if (DropDownList1.SelectedItem.Text == "$50-$100")
            {
                int PriceMin = 50;
                int PriceMax = 100;
                string Server = DropDownList2.SelectedValue;
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Server = @Server and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@Server", Server);
                cmd.Parameters.AddWithValue("@PriceMin", PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", PriceMax);
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
                    Label6.Text = "";
                }
                else
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't find anything here";
                }
            }
            else if (DropDownList1.SelectedItem.Text == "$100-$300")
            {
                int PriceMin = 100;
                int PriceMax = 300;
                string Server = DropDownList2.SelectedValue;
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Server = @Server and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@Server", Server);
                cmd.Parameters.AddWithValue("@PriceMin", PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", PriceMax);
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
                    Label6.Text = "";
                }
                else
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't find anything here";
                }
            }
            else if (DropDownList1.SelectedItem.Text == "$300-$500")
            {
                int PriceMin = 300;
                int PriceMax = 500;
                string Server = DropDownList2.SelectedValue;
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Server = @Server and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@Server", Server);
                cmd.Parameters.AddWithValue("@PriceMin", PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", PriceMax);
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
                    Label6.Text = "";
                }
                else
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't find anything here";
                }
            }
            else if (DropDownList1.SelectedItem.Text == "Over $500")
            {
                int PriceMin = 500;
                int PriceMax = 10000;
                string Server = DropDownList2.SelectedValue;
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Server = @Server and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@Server", Server);
                cmd.Parameters.AddWithValue("@PriceMin", PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", PriceMax);
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
                    Label6.Text = "";
                }
                else
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't find anything here";
                }
            }
            else
            {
                string Server = DropDownList2.SelectedValue;
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from LOLAccounts where Server = @Server and State = @State", con);
                cmd.Parameters.AddWithValue("@Server", Server);
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
                    Label6.Text = "";
                }
                else
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                    adapter.Dispose();
                    cmd.Dispose();
                    con.Close();
                    Label6.Text = "We don't find anything here";
                }
            }

        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            string State = "approved";
            DropDownList1.SelectedValue = " ";
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
                Label6.Text = "";
            }
            else
            {
                datagrid.DataSource = dt;
                datagrid.DataBind();
                adapter.Dispose();
                cmd.Dispose();
                con.Close();
                Label6.Text = "We don't have anything account right now!";
            }
        }
    }
}