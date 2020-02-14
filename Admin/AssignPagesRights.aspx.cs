
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

public partial class Admin_AssignPagesRights : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetUsers();
            GetLModule();
            GetPages();
            FillGridView();

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
    protected void GetUsers()
    {
        CommonFunctions objCommonFunctionsUsers = new CommonFunctions();
        ddlUser.DataSource = objCommonFunctionsUsers.GetUsers();

        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserID";
        ddlUser.DataBind();
    }
    protected void GetPages()
    {
        CommonFunctions objCommonFunctionsPages = new CommonFunctions();
        CBL.DataSource = objCommonFunctionsPages.GetPages(ddlModule.SelectedValue);

        CBL.DataTextField = "Page_Name";
        CBL.DataValueField = "Page_id";
        CBL.DataBind();
    }
    protected void btn_UserPages_Click(object sender, EventArgs e)
    {

        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {

                new SqlParameter("@UserID",ddlUser.SelectedValue),
                new SqlParameter("@Module_ID",ddlModule.SelectedValue)
            };
         ObjDBManager.ExecuteNonQuery("Delete_UserModulePages", parm);
        

        SqlConnection con = new SqlConnection(_str);

        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Insert_UserModulePages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < CBL.Items.Count; i++)
                
            {
                cmd.Parameters.AddWithValue("@UserID", ddlUser.SelectedValue);
                cmd.Parameters.AddWithValue("@Module_ID", ddlModule.Text.Trim());
                cmd.Parameters.AddWithValue("@Page_ID", CBL.Items[i].Value);
                cmd.ExecuteNonQuery();
            }
            FillGridView();
            con.Close();
            LblMeg.Text = "Save Successfully";
           

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
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
             
                new SqlParameter("@UserID",ddlUser.SelectedValue),
                new SqlParameter("@Module_ID",ddlModule.SelectedValue)
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_UserModulePages", parm);
        GridView1.DataBind();
       
        
    }

    protected void ddlModule_Click(object sender, EventArgs e)
    {
        GetPages();
    }
}