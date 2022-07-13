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
    public partial class History : System.Web.UI.Page
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
            bfield.HeaderText = "OrderId";
            bfield.DataField = "OrderId";
            datagrid.Columns.Add(bfield);

            BoundField bfield1 = new BoundField();
            bfield1.HeaderText = "Game";
            bfield1.DataField = "Game";
            datagrid.Columns.Add(bfield1);

            BoundField bfield2 = new BoundField();
            bfield2.HeaderText = "Buy From";
            bfield2.DataField = "Seller";
            datagrid.Columns.Add(bfield2);

            BoundField bfield3 = new BoundField();
            bfield3.HeaderText = "Price";
            bfield3.DataField = "Price";
            datagrid.Columns.Add(bfield3);

            BoundField bfield4 = new BoundField();
            bfield4.HeaderText = "Date";
            bfield4.DataField = "Date";
            datagrid.Columns.Add(bfield4);

            BoundField bfield5 = new BoundField();
            bfield5.HeaderText = "AccountId";
            bfield5.DataField = "ItemId";
            datagrid.Columns.Add(bfield5);

            BoundField bfield6 = new BoundField();
            bfield6.HeaderText = "Rate State";
            bfield6.DataField = "RateState";
            datagrid.Columns.Add(bfield6);
            LabelItemDisplay.Text = "Here are the items you bought from others";
            Label1.Text = "Click to see more...";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
            cmd = new SqlCommand("Select * from Orders where Buyer = @Buyer", con);
            cmd.Parameters.AddWithValue("@Buyer", Username);
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
                LabelItemDisplay.Text = "You don't complete any transaction";
                Label1.Text = "";
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorySell.aspx");
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
            int id = Convert.ToInt32(datagrid.SelectedRow.Cells[5].Text);
            int orderid = Convert.ToInt32(datagrid.SelectedRow.Cells[0].Text);
            Session["id"] = id;
            Session["orderid"] = orderid;
            string date = datagrid.SelectedRow.Cells[4].Text;
            Session["date"] = date;
            string Game = datagrid.SelectedRow.Cells[1].Text;
            if (Game == "League of Legend")
            {
                Response.Redirect("HistoryDetailLOL.aspx");
            }
            else if(Game == "Clash of Clans")
            {
                Response.Redirect("HistoryDetailCOC.aspx");
            }
            
        }

    }
}