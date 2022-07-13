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
    public partial class BuyCOC : System.Web.UI.Page
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
            bfield1.HeaderText = "TownHall Level";
            bfield1.DataField = "THLevel";
            datagrid.Columns.Add(bfield1);

            BoundField bfield2 = new BoundField();
            bfield2.HeaderText = "Gem";
            bfield2.DataField = "Gem";
            datagrid.Columns.Add(bfield2);

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
            cmd = new SqlCommand("Select * from COCAccounts where State = @State", con);
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
            Response.Redirect("Home.aspx");
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedItem.Text == "$0-$50")
            {
                int PriceMin = 0;
                int PriceMax = 50;
                int THLevel = Convert.ToInt32(DropDownList2.SelectedValue);
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where THLevel = @THLevel and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@THLevel", THLevel);
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
                int THLevel = Convert.ToInt32(DropDownList2.SelectedValue);
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where THLevel = @THLevel and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@THLevel", THLevel);
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
                int THLevel = Convert.ToInt32(DropDownList2.SelectedValue);
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where THLevel = @THLevel and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@THLevel", THLevel);
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
                int THLevel = Convert.ToInt32(DropDownList2.SelectedValue);
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where THLevel = @THLevel and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@THLevel", THLevel);
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
                int THLevel = Convert.ToInt32(DropDownList2.SelectedValue);
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where THLevel = @THLevel and PriceF >= @PriceMin and PriceF <= @PriceMax and State = @State", con);
                cmd.Parameters.AddWithValue("@THLevel", THLevel);
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
                int THLevel = Convert.ToInt32(DropDownList2.SelectedValue);
                string State = "approved";
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
                cmd = new SqlCommand("Select * from COCAccounts where THLevel = @THLevel and State = @State", con);
                cmd.Parameters.AddWithValue("@THLevel", THLevel);
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
        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(datagrid.SelectedRow.Cells[1].Text);
            Session["id"] = id;
            Response.Redirect("BuyCOCDetail.aspx?Id=" + id);
        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(datagrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = " ";
            string State = "approved";
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
}