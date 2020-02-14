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
using System.Drawing;
using System.IO;
using System.Text;

public partial class Admin_PA : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetDivisions();            
            GetDistrict();
            GetNA();
            FillGridView();
        }
    }
    protected void GetDivisions()
    {
        CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
        ddlDivisions.DataSource = objCommonFunctionsProvince.GetDivisions("4");

        ddlDivisions.DataTextField = "Name";
        ddlDivisions.DataValueField = "DivisionId";
        ddlDivisions.DataBind();
    }
    protected void GetDistrict()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlDistrict.DataSource = objCommonFunctionsGetDistrict.GetDistrictByDivisions(ddlDivisions.SelectedValue);

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();

    }

    protected void GetNA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlNA.DataSource = objCommonFunctionsGetNA.GetNA(ddlDistrict.SelectedValue);

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }
    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
    }


    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);
        byte[] bMap = null;
        if (filePAMap.HasFile)
        {
            bMap = filePAMap.FileBytes;
        }
        else
        {
            bMap = Encoding.ASCII.GetBytes(hdnPaMap.Value);
        } 
        try
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionPA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAId", hdID.Value);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@DivisionId", ddlDivisions.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@Name", txtNAName.Text.Trim());
            cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Map", bMap);
            cmd.Parameters.AddWithValue("@FamousPlace", txtFamousPlace.Text.Trim());
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            
            cmd.ExecuteNonQuery();
            con.Close();
            FillGridView();

            if(btn_save.Text=="Save")
            {
                LblMeg.Text = "Save Successfully";
            }
            else
            {
                LblMeg.Text = "Update Successfully";
            }
        }
        catch (Exception ex)
        {}
        finally
        {
            con.Close();
            ClearField();
        }
    }
    private void FillGridView()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",ddlNA.SelectedValue),                
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_PA", parm);
        GridView1.DataBind();
       
    }
    protected void lnkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkBTN = sender as LinkButton;
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();                        
            SqlCommand cmd = new SqlCommand("select * from PA where PaId=" + lnkBTN.CommandName + "", con);
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                  while (rdr.Read())
                {
                    ddlNA.SelectedItem.Value = rdr["NAId"].ToString();
                    txtNAName.Text = rdr["Name"].ToString();
                    ddlDivisions.SelectedValue = rdr["DivisionId"].ToString();
                    ddlDistrict.SelectedValue = rdr["DistrictId"].ToString();
                    ddlCategory.SelectedItem.Value = rdr["Category"].ToString();
                    //txtLatitude.Text = rdr["Latitude"].ToString();
                    //txtLongitude.Text = rdr["Longitude"].ToString();
                    txtFamousPlace.Text = rdr["FamousPlace"].ToString();
                    txtCreatedDate.Text = rdr["CreatedDate"].ToString();


                    hdID.Value = lnkBTN.CommandName;
                    btn_save.Text = "Update";
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

        SqlCommand cmd = new SqlCommand("usp_deletePARecord", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAid", btn.CommandName);
        cmd.ExecuteNonQuery();
        FillGridView();
        con.Close();
    }
  
    void ClearField()
    {
        btn_save.Text = "Save";
        txtNAName.Text = string.Empty;
        //txtLatitude.Text = string.Empty;
        //txtLongitude.Text = string.Empty;
        txtFamousPlace.Text = string.Empty;
        
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridView();
    }

    protected void ddlDistrict_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GetNA();
        FillGridView();
    }
}