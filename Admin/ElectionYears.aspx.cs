using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;



public partial class Admin_ElectionYears : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
     
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
       
        SqlConnection con = new SqlConnection(_str);

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionYear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ElectionYear", txtElecYear.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();

            lblMsg.Text = "Save Successfully";
            FillGridView();
            txtElecYear.Text = "";
        }
           
        catch (Exception ex)
        {


        }
        finally
        {
            con.Close();
        }
    }  
    private void FillGridView()
    {
        using (SqlConnection connection = new SqlConnection(_str))
        {
            SqlCommand command = new SqlCommand("Select_electionYear", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;

        using (SqlConnection con = new SqlConnection(_str))
        {
            string comand = @"DELETE from ElectionYears where ElectionId=@ElectionId";
            SqlCommand command = new SqlCommand(comand, con);
            command.Parameters.AddWithValue("@ElectionId", lb.CommandArgument);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        FillGridView();
    }

}