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

public partial class Election_ElectionRecommendation : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            ddlProvince.SelectedValue = "4";
            ddlProvince.Enabled = false;
            GetDistrict();
            GetNA();
            GetPA();
            GetParties();
            GetCandidates("P1"); GetCandidates("P2");
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            GetRecommendations();
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
        DataTable dt= objCommonFunctionsGetParties.GetParties();
        ddlLWParty.DataSource = dt;

        ddlLWParty.DataTextField = "PartyName";
        ddlLWParty.DataValueField = "PartyId";
        ddlLWParty.DataBind();

        ddlOLWParty.DataSource = dt;

        ddlOLWParty.DataTextField = "PartyName";
        ddlOLWParty.DataValueField = "PartyId";
        ddlOLWParty.DataBind();


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
            SqlCommand cmd = new SqlCommand("InsertNAPARecommendation", con);

            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@Provinceid", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@Districtid", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@CandidateType", rdoType.SelectedValue);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@PAid", paId);
            
            cmd.Parameters.AddWithValue("@FWParty", ddlLWParty.SelectedValue);
            cmd.Parameters.AddWithValue("@FirstWiningCandidate", ddlCandidate1.SelectedValue);
            cmd.Parameters.AddWithValue("@FirstFactors", txtLWFactor.Text);
            

            cmd.Parameters.AddWithValue("@SWParty", ddlOLWParty.SelectedValue);
            cmd.Parameters.AddWithValue("@SecondWiningCandidate", ddlCandidate2.SelectedValue);
            cmd.Parameters.AddWithValue("@SecondFactors", txtOLWFactor.Text);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@CreatedBy", Session["UserId"].ToString());



            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            GetRecommendations();
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
       
    }
  
    private void GetRecommendations()
    {
        string paId = "0";
        if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
        {
            paId = ddlPA.SelectedValue;
        }
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",rdoType.SelectedValue),
                new SqlParameter("@ElectionId",ddlYear.SelectedValue)
            };
        DataTable dt = ObjDBManager.ExecuteDataTable("GetRecommandations", parm);
        if(dt.Rows.Count>0)
        {
            ddlLWParty.SelectedValue = dt.Rows[0]["FWPartyId"].ToString();
            GetCandidates("P1");
            ddlCandidate1.SelectedValue = dt.Rows[0]["FirstWiningCandidateId"].ToString();
            txtLWFactor.Text = dt.Rows[0]["FirstFactors"].ToString();

            ddlOLWParty.SelectedValue = dt.Rows[0]["SWPartyId"].ToString();
            GetCandidates("P2");
            ddlCandidate2.SelectedValue = dt.Rows[0]["SecondWiningCandidateId"].ToString();
            txtOLWFactor.Text = dt.Rows[0]["SecondFactors"].ToString();
        }
        else
        {
            txtLWFactor.Text = "";
            txtOLWFactor.Text = "";
        }

    }


    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        GetRecommendations();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
        GetRecommendations();
    }

    protected void ddlLWParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates("P1");
    }
    protected void ddlOLWParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates("P2");
    }

    protected void GetCandidates(string type)
    {
        CommonFunctions objCommonFunctionsGetCandidate = new CommonFunctions();

        if (type == "P1")
        {
            ddlCandidate1.DataSource = objCommonFunctionsGetCandidate.GetPartyCatdidate(ddlLWParty.SelectedValue);

            ddlCandidate1.DataTextField = "Name";
            ddlCandidate1.DataValueField = "candidateid";
            ddlCandidate1.DataBind();
        }
        else
        {
            ddlCandidate2.DataSource = objCommonFunctionsGetCandidate.GetPartyCatdidate(ddlOLWParty.SelectedValue);

            ddlCandidate2.DataTextField = "Name";
            ddlCandidate2.DataValueField = "candidateid";
            ddlCandidate2.DataBind();
        }


    }
    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            GetRecommendations();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            GetPA();
            GetRecommendations();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "contents");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "contents");
        }
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
        GetRecommendations();
    }
    protected void ddlPA_SelectedIndexChanged(object sender, EventArgs e)
    {        
        GetRecommendations();
    }
}  