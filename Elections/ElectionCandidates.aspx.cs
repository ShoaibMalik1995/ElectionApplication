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

public partial class Candidates_ElectionCandidates : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetDivisions();            
            GetDistrict();
            GetNA();
            GetPA();
            GetParties();
            GetCandidates();            
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            FillGridView();
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
        CommonFunctions objCommonFunctionsGetDivisions = new CommonFunctions();
        ddlDivisions.DataSource = objCommonFunctionsGetDivisions.GetDivisions("4");

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
    protected void GetParties()
    {
        CommonFunctions objCommonFunctionsGetParties = new CommonFunctions();
        ddlParty.DataSource = objCommonFunctionsGetParties.GetParties();

        ddlParty.DataTextField = "PartyName";
        ddlParty.DataValueField = "PartyId";
        ddlParty.DataBind();

    }
    protected void GetCandidates()
    {
        CommonFunctions objCommonFunctionsGetCandidate = new CommonFunctions();
        ddlCandidate.DataSource = objCommonFunctionsGetCandidate.GetPartyCandidateNotRegisteredForElection(ddlParty.SelectedValue,ddlYear.SelectedValue);

        ddlCandidate.DataTextField = "Name";
        ddlCandidate.DataValueField = "candidateid";
        ddlCandidate.DataBind();

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            string paId = "0";
            if(!string.IsNullOrEmpty(ddlPA.SelectedValue))
            {
                paId = ddlPA.SelectedValue;
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionCandidates", con);

            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@Electionid",ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@DivisionId", ddlDivisions.SelectedValue);
            cmd.Parameters.AddWithValue("@Districtid", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@PartyId", ddlParty.SelectedValue);
            cmd.Parameters.AddWithValue("@NAId", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@PAId", paId);
            cmd.Parameters.AddWithValue("@CandidateId", ddlCandidate.SelectedValue);
            cmd.Parameters.AddWithValue("@CandidateType", rdoType.SelectedValue);

            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            FillGridView();
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
       
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = sender as LinkButton;
            SqlConnection con = new SqlConnection(_str);
            con.Open();

            SqlCommand cmd = new SqlCommand("usp_deleteElectionCandidates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", btn.CommandArgument);
            cmd.Parameters.AddWithValue("@Type", btn.CommandName);
            cmd.ExecuteNonQuery();
            con.Close();
            FillGridView();
            lblMsg.Text = "Deleted Successfully!";
            lblMsg.ForeColor = System.Drawing.Color.Green;
        }
        catch
        {
            ;
        }
    }
   
    private void FillGridView()
    {
        string paId = "0";
        if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
        {
            paId = ddlPA.SelectedValue;
        }
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",rdoType.SelectedValue)
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("GetElectionCandidates", parm);
        GridView1.DataBind();
    }

    protected void grdCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("candPic");
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            byte[] b = (byte[])rowView["Picture"];
            string base64 = Convert.ToBase64String(b);
            img.ImageUrl = "data:Image/png;base64," + base64;
        }
    }
  
    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
    {
       GetDistrict();
        GetNA();
        FillGridView();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        FillGridView();
    }

    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates();
    }

    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            FillGridView();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            GetPA();
            FillGridView();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "contents");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "contents");
        }
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
        FillGridView();
    }
}  