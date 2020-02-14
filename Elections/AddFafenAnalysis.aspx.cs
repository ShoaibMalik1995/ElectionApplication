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

public partial class Election_AddFafenAnalysis : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            GetDistrict();
            GetNA();
            GetFafenInfo();
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            
        }
    }
    protected void GetYears()
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlYear.DataSource = objCommonFunctions.GetelectionYear();

        ddlYear.DataTextField = "electionyear";
        ddlYear.DataValueField = "electionid";
        ddlYear.DataBind();
    }
    protected void GetProvince()
    {
            CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
            ddlProvince.DataSource = objCommonFunctionsProvince.GetProvince();

            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataBind();
    }
    protected void GetDistrict()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlDistrict.DataSource = objCommonFunctionsGetDistrict.GetDistrict(ddlProvince.SelectedValue);

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
    
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertFafenConstituencyAnalysis", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FafenId", hdfFefenid.Value);
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@Analysis", txtFafenAnalysis.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }
    protected void GetFafenInfo()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@Electionid",ddlYear.SelectedValue),
                new SqlParameter("@DistrictId",ddlDistrict.SelectedValue),
                new SqlParameter("@ProvinceId",ddlProvince.SelectedValue)
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetFafenAnalysis", parm);
            if (dt.Rows.Count > 0)
            {
                txtFafenAnalysis.Text = dt.Rows[0]["Analysis"].ToString();
                hdfFefenid.Value = dt.Rows[0]["FafenId"].ToString();
            }
            else
            {
                txtFafenAnalysis.Text = "";
                hdfFefenid.Value = "0";
            }
        }
        catch
        {
            ;
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProvince();
        GetDistrict();
        GetNA();
        GetFafenInfo();

    }
    
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        GetFafenInfo();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetFafenInfo();
    }
   
    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetFafenInfo();
    }
   

}