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

public partial class Figures_AddFigureCastSectrain : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetDivisions();
            GetDistrict();
            GetPA();
            GetCast();
            GetSectain();
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
    protected void GetPA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlPA.DataSource = objCommonFunctionsGetNA.GetPA(ddlNA.SelectedValue);

        ddlPA.DataTextField = "Name";
        ddlPA.DataValueField = "PAId";
        ddlPA.DataBind();
    }
    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
    }
    protected void GetCast()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlCast.DataSource = objCommonFunctionsGetDistrict.GetCast();

        ddlCast.DataTextField = "CastName";
        ddlCast.DataValueField = "Castid";
        ddlCast.DataBind();
    }
    protected void GetSectain()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlSectrain.DataSource = objCommonFunctionsGetDistrict.GetSectrain();

        ddlSectrain.DataTextField = "sectrainName";
        ddlSectrain.DataValueField = "sectrainID";
        ddlSectrain.DataBind();
    }
    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        GetPA();
    }    
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
    }
    protected void btnSaveVoters_Click(object sender, EventArgs e)
    {
         SqlConnection con = new SqlConnection(_str);
        try
        {            
            con.Open();
            SqlCommand cmd = new SqlCommand("uspAddFigures", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", hdnFigureId.Value);
            cmd.Parameters.AddWithValue("@PAId",ddlPA.SelectedValue);
            cmd.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);

            cmd.Parameters.AddWithValue("@PSMale", txtMalePStation.Text);
            cmd.Parameters.AddWithValue("@PSFemale", txtFeMalePStation.Text);

            cmd.Parameters.AddWithValue("@MaleVoters", txtMaleVoters.Text);
            cmd.Parameters.AddWithValue("@FemaleVoters", txtFemaleVoters.Text);


            cmd.Parameters.AddWithValue("@CreatedBy", Session["UserId"]);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                                                		    
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            //FillGridView();            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
       
    }
    protected void btnSaveCast_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        int CP = CAstPercentage();
        CP=CP+Convert.ToInt32(txtboxCastPercentage.Text.Trim().ToString());
        if (CP<=100)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("uspAddCast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAId", ddlPA.SelectedValue);
                cmd.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
                cmd.Parameters.AddWithValue("@CastId", ddlCast.SelectedValue);
                cmd.Parameters.AddWithValue("@Percentage", txtboxCastPercentage.Text);
                cmd.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);
                cmd.Parameters.AddWithValue("@CreatedBy", Session["UserId"]);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);


                cmd.ExecuteNonQuery();
                con.Close();
                lblMsg.Text = "Save Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                getCasts();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Some error occurred";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblMsg.Text = "Percentage Exceed From 100 !!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            getCasts();
        }
                			 
    }

    protected int CAstPercentage()
    {
        int percentage = 0;
        SqlConnection con = new SqlConnection(_str);
        try
        {
            SqlCommand sc=new SqlCommand("SELECT ISNULL(Sum(Percentage),0) AS Percentage FROM PACasts Where PAId=@PAId AND NAId=@NAId AND ElectionId=@ElectionId",con);
            sc.CommandType = CommandType.Text;
            sc.Parameters.AddWithValue("@PAId",ddlPA.SelectedValue);
            sc.Parameters.AddWithValue("@NAId",ddlNA.SelectedValue);
            sc.Parameters.AddWithValue("@ElectionId",ddlYear.SelectedValue);
            con.Open();
            percentage =Convert.ToInt32(sc.ExecuteScalar().ToString());
        }
        catch(Exception Ex)
        {
            lblMsg.Text = "Some error occurred In Geting CAstPercentage";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            con.Close();
        }

        return percentage;
    }
    protected void btnSaveSectrain_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        int SP = SectarianPercentage();
        SP=SP+Convert.ToInt32(txtboxSectainPercentage.Text.Trim().ToString());
        if (SP <= 100)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("upsAddSectrain", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SectrainID", ddlSectrain.SelectedValue);
                cmd.Parameters.AddWithValue("@PAID", ddlPA.SelectedValue);
                cmd.Parameters.AddWithValue("@NAID", ddlNA.SelectedValue);
                cmd.Parameters.AddWithValue("@Percentage", txtboxSectainPercentage.Text);
                cmd.Parameters.AddWithValue("@ElectionID", ddlYear.SelectedValue);
                cmd.Parameters.AddWithValue("@Createdby", Session["UserId"]);
                cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);


                cmd.ExecuteNonQuery();
                con.Close();
                lblMsg.Text = "Save Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                getSectarian();
            }
            catch (Exception ex)
            {
                con.Close();
                lblMsg.Text = "Some error occurred";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblMsg.Text = "Percentage Exceed From 100 !!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            getSectarian();
        }
    }

    protected int SectarianPercentage()
    {
        int percentage = 0;
        SqlConnection con = new SqlConnection(_str);
        try
        {
            SqlCommand sc = new SqlCommand("SELECT ISNULL(Sum(Percentage),0) AS Percentage FROM PASectrain Where PAId=@PAId AND NAId=@NAId AND ElectionId=@ElectionId", con);
            sc.CommandType = CommandType.Text;
            sc.Parameters.AddWithValue("@PAId", ddlPA.SelectedValue);
            sc.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
            sc.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);
            con.Open();
            percentage = Convert.ToInt32(sc.ExecuteScalar().ToString());
        }
        catch (Exception Ex)
        {
            lblMsg.Text = "Some error occurred In Geting SectarianPercentage";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            con.Close();
        }

        return percentage;
    }

    private void getFigures()
    {
        
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),                
                new SqlParameter("@PAId",ddlPA.SelectedValue)                
            };
        DataTable dt= ObjDBManager.ExecuteDataTable("GetPAFigures", parm);
        if(dt.Rows.Count>0)
        {
            txtMalePStation.Text = dt.Rows[0]["PSMale"].ToString();
            txtFeMalePStation.Text = dt.Rows[0]["PSFemale"].ToString();
            txtMaleVoters.Text = dt.Rows[0]["VotersMale"].ToString();
            txtFemaleVoters.Text = dt.Rows[0]["VotersFemale"].ToString();
            hdnFigureId.Value = dt.Rows[0]["Id"].ToString();
        }
        else
        {
            txtMalePStation.Text = "";
            txtFeMalePStation.Text = "";
            txtMaleVoters.Text = "";
            txtFemaleVoters.Text = "";
            hdnFigureId.Value = "0";
        }
    }

    private void getCasts()
    {

        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@PAId",ddlPA.SelectedValue)
            };
        grdCasts.DataSource= ObjDBManager.ExecuteDataTable("GetPACasts", parm);
        grdCasts.DataBind();

    }
    private void getSectarian()
    {

        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@PAId",ddlPA.SelectedValue)
            };
        grdSectarian.DataSource = ObjDBManager.ExecuteDataTable("GetPASectarian", parm);
        grdSectarian.DataBind();

    }
    private void ClearForms() { 
    
    }


    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                HiddenField hdnPAId = (HiddenField)row.FindControl("hdnPAId");
                HiddenField hdnSectrainID = (HiddenField)row.FindControl("hdnSectrainID");
                HiddenField hdnElectionId = (HiddenField)row.FindControl("hdnElectionId");
                DBManager ObjDBManager = new DBManager();
                List<SqlParameter> parm = new List<SqlParameter>
                {
                    new SqlParameter("@PAId",hdnPAId.Value),
                    new SqlParameter("@SectrainID",hdnSectrainID.Value),
                    new SqlParameter("@ElectionId",hdnElectionId.Value)
                };
                ObjDBManager.ExecuteNonQuery("DeletePASectarian", parm);
                getSectarian();
            }
        }
        catch
        {
            ;
        }
    }
    protected void lnkdeleteCasts_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                HiddenField hdnPAId = (HiddenField)row.FindControl("hdnPAId");
                HiddenField hdnCastId = (HiddenField)row.FindControl("hdnCastId");
                HiddenField hdnElectionId = (HiddenField)row.FindControl("hdnElectionId");
                DBManager ObjDBManager = new DBManager();
                List<SqlParameter> parm = new List<SqlParameter>
                {
                    new SqlParameter("@PAId",hdnPAId.Value),
                    new SqlParameter("@castid",hdnCastId.Value),
                    new SqlParameter("@ElectionId",hdnElectionId.Value)
                };
                ObjDBManager.ExecuteNonQuery("DeletePACasts", parm);
                getCasts();
            }
        }
        catch
        {
            ;
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        getFigures();
        getCasts();
        getSectarian();
    }
}  