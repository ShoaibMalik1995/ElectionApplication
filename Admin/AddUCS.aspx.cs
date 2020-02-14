using System;
using System.Collections.Generic;
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

public partial class Admin_AddUCS : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack)
        {
            Get_PA();
            Get_Tehsil();

            Get_UCS();
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
        catch(Exception Ex)
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

    protected void Get_Tehsil()
    {
        SqlConnection con = new SqlConnection(_str);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand sc = new SqlCommand("SELECT TehsilId,Name FROM Tehsil WHERE PAId=@PAId ORDER By Name", con);
            sc.CommandType = CommandType.Text;
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
            DDL_Tehsil.DataSource = dt;
            DDL_Tehsil.DataTextField = "Name";
            DDL_Tehsil.DataValueField = "TehsilId";
            DDL_Tehsil.DataBind();
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        if ( DDL_PA.SelectedValue !="" && DDL_Tehsil.SelectedValue !="")
        {
            try
            {
                SqlCommand sc = new SqlCommand("usp_AddUCS", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@PAId", DDL_PA.SelectedValue);
                sc.Parameters.AddWithValue("@TehsilId", DDL_Tehsil.SelectedValue);
                sc.Parameters.AddWithValue("@Name", txtUCS.Text.Trim());
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
                lblMsg.Text = "Save Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                Get_UCS();
            }
        }
        else
        {
            lblMsg.Text = "No PA And Tehsil Exist For UCS !!";
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }

    protected void Get_UCS()
    {
        SqlConnection con = new SqlConnection(_str);
        DataTable dt = new DataTable();
        try
        {
            SqlCommand sc = new SqlCommand("Get_UCSByPA_Tehsil", con);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@PAId", DDL_PA.SelectedValue);
            sc.Parameters.AddWithValue("@TehsilId", DDL_Tehsil.SelectedValue);
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
            SqlCommand cmd = new SqlCommand("usp_DeleteUCS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAId", DDL_PA.SelectedValue);
            cmd.Parameters.AddWithValue("@TehsilId", DDL_Tehsil.SelectedValue);
            cmd.Parameters.AddWithValue("@UCSId", btn.CommandName);
            cmd.ExecuteNonQuery();
        }
        catch(Exception Ex)
        {
            Response.Write(Ex.Message);
        }
        finally
        {
            con.Close();
            Get_UCS();
            
        } 
    }
    protected void DDL_PA_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Tehsil();
    }
}