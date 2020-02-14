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

public partial class Admin_AddTehsil : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Get_PA();
            Get_Tehsil();
        }
    }
    protected void Get_PA()
    {
        SqlConnection con = new SqlConnection(_str);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand sc = new SqlCommand("SELECT PAId,Name FROM PA ORDER BY Name", con);
            sc.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);
        }
        finally
        {
            DDL_PA.DataSource = dt;
            DDL_PA.DataTextField = "Name";
            DDL_PA.DataValueField = "PAId";
            DDL_PA.DataBind();
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        if (DDL_PA.SelectedValue != "")
        {
            try
            {
                SqlCommand sc = new SqlCommand("usp_AddTehsil", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@PAId",DDL_PA.SelectedValue);
                sc.Parameters.AddWithValue("@Name",txtTehsil.Text.Trim());
                con.Open();
                sc.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                lblMsg.Text = "Some error occured ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
                lblMsg.Text = "Save Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                Get_Tehsil();
            }
        }
        else
        {
            lblMsg.Text = "No PA Exist For Tehsil !!";
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }

    protected void Get_Tehsil()
    {
        SqlConnection con = new SqlConnection(_str);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand sc = new SqlCommand("Get_TehsilBYPA", con);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@PAId", DDL_PA.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);

        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);
        }
        finally
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void deleteRecord(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;

        SqlConnection con = new SqlConnection(_str);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_DeleteTehsil", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TehsilId", btn.CommandName);
            cmd.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);
        }
        finally
        {
            con.Close();
            Get_Tehsil();

        }
    }
    protected void DDL_PA_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Tehsil();
    }
}