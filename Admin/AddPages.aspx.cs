
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

public partial class Admin_AddPages : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetLModule();
            FillGridView();

        }

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Admin_User_Module (Module_Name)VALUES (@Module_Name)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Module_Name", txtModule.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            GetLModule();

            LblMeg.Text = "Save Successfully";
            txtModule.Text = "";

        }
        catch (Exception ex)
        {


        }
        finally
        {
            con.Close();
        }
    }
    protected void GetLModule()
    {
        CommonFunctions objCommonFunctionsModule = new CommonFunctions();
        ddlModule.DataSource = objCommonFunctionsModule.GetLModule();

        ddlModule.DataTextField = "Module_Name";
        ddlModule.DataValueField = "Module_Id";
        ddlModule.DataBind();
    }

    protected void btn_AddModule_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Insert_Page", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Module_id", ddlModule.SelectedValue);
            cmd.Parameters.AddWithValue("@Page_Name", txtPageName.Text.Trim());
            cmd.Parameters.AddWithValue("@Page_Url", txtPageUrl.Text.Trim());
            cmd.ExecuteNonQuery();
            FillGridView();
            con.Close();
            LblMeg.Text = "Save Successfully";
            txtPageName.Text = "";
            txtPageUrl.Text = "";

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
        using (sSqlConnection connection = new SqlConnection(_str))
        {
            SqlCommand command = new SqlCommand("Select_ModulePages", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void lnkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkBTN = sender as LinkButton;
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();
            btn_save.Visible = false;
            btnUpdate.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from Admin_User_Module_Pages where Page_ID=" + lnkBTN.CommandName + "", con);
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                  
                    ddlModule.SelectedItem.Value = rdr["Page_ID"].ToString();
                    txtPageName.Text = rdr["Page_Name"].ToString();
                    txtPageUrl.Text = rdr["Page_Url"].ToString();
                    hdID.Value = lnkBTN.CommandName;
                }
            }

        }
        catch (Exception ex)
        {


        }

    }
    protected void deleteRecord(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        SqlConnection con = new SqlConnection(_str);
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_deleteAssignedPage", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Page_id", btn.CommandName);
        cmd.ExecuteNonQuery();
        FillGridView();
        con.Close();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_UpdateAssignedPages", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Page_Name", txtPageName.Text);
        cmd.Parameters.AddWithValue("@Page_URL", txtPageUrl.Text);

        cmd.Parameters.AddWithValue("@Page_Id", hdID.Value);


        cmd.ExecuteNonQuery();
        btn_save.Visible = true;
        btnUpdate.Visible = false;
        FillGridView();
        con.Close();

        txtPageName.Text = "";
        txtPageUrl.Text = "";

    }
    
    protected void ddlModule_Click(object sender, EventArgs e)
    {
        FillGridView();
    }
}