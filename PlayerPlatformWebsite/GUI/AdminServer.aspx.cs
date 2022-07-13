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
    public partial class AdminServer : System.Web.UI.Page
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
            BoundField bfield1 = new BoundField();
            bfield1.HeaderText = "OrderId";
            bfield1.DataField = "OrderId";
            datagrid.Columns.Add(bfield1);

            BoundField bfield2 = new BoundField();
            bfield2.HeaderText = "Title";
            bfield2.DataField = "Title";
            datagrid.Columns.Add(bfield2);

            BoundField bfield3 = new BoundField();
            bfield3.HeaderText = " Submite Date";
            bfield3.DataField = "Date";

            datagrid.Columns.Add(bfield3);
            BoundField bfield4 = new BoundField();
            bfield4.HeaderText = " State";
            bfield4.DataField = "State";
            datagrid.Columns.Add(bfield4);

            string State = "Processing";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString);
            cmd = new SqlCommand("Select * from Servers WHERE State = @State", con);
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
            }
            else
            {
                LabelItemDisplay.Text = "You don't have any requests need to be solved";
            }
        }
        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Orderid = Convert.ToInt32(datagrid.SelectedRow.Cells[0].Text);
            Session["Orderid"] = Orderid;
            Response.Redirect("AdminServerDetail.aspx");
        }

        protected void datagrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(datagrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Home.aspx");
        }

    }
}