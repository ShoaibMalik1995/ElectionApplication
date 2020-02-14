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

public partial class Elections_Election_Assessment : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    CommonFunctions objCommonFunctions = new CommonFunctions();

    DataSet Ds_Global = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack)
        {
            if (!Page.IsPostBack)
            {
                GetYears();
                GetDivisions();
                GetDistrict();
                GetNA();
                GetPA();
                if (Request.QueryString["ElecnId"] != null)
                {
                    ddlYear.SelectedValue = Request.QueryString["ElecnId"];
                }
            }
            lblMsg.Text = "";
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

        ddlDistrict.DataSource = objCommonFunctions.GetDistrictByDivisions(ddlDivisions.SelectedValue);

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();

    }
    protected void GetNA()
    {

        ddlNA.DataSource = objCommonFunctions.GetNA(ddlDistrict.SelectedValue);

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }
    protected void GetPA()
    {

        ddlPA.DataSource = objCommonFunctions.GetPA(ddlNA.SelectedValue);

        ddlPA.DataTextField = "Name";
        ddlPA.DataValueField = "PAId";
        ddlPA.DataBind();
    }
    private void FillGridView()
    {
        string paId = "0";
        if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
        {
            paId = ddlPA.SelectedValue;
        }
        string resultType = Request.QueryString["Type"];
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@NAId",ddlNA.SelectedValue),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",rdoType.SelectedValue)
            };
        Ds_Global = ObjDBManager.ExecuteDataSet("GetConstituencyAssesments", parm);
        GridView1.DataSource = Ds_Global.Tables[0];
        GridView1.DataBind();
        if (GridView1.Rows.Count > 0)
        {
            Btn_Save.Visible = true;

        }
        else
        {
            Btn_Save.Visible = false;
        }
    }
    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();

    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
    }

    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            GetPA();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "contents");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "contents");
        }
    }
    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (GridView1.Rows.Count > 0)
            {
                CheckBox Ck = new CheckBox();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    HiddenField hf_Id=(HiddenField)row.FindControl("hf_PartyId");
                    HiddenField hf_AssesmentId = (HiddenField)row.FindControl("hf_AssesmentId");
                    DropDownList DDL_Candidate=(DropDownList)row.FindControl("DDL_Candidate");
                    TextBox factor = (TextBox)row.FindControl("txtFactor");
                    TextBox Winning_Per = (TextBox)row.FindControl("txt_WinningPer");
                    string paId = "0";            
                    if(!string.IsNullOrEmpty(ddlPA.SelectedValue))            
                    {                
                        paId = ddlPA.SelectedValue;            
                    }
                    DBManager ObjDBManager = new DBManager();
                    List<SqlParameter> parm = new List<SqlParameter>  { 
                        new SqlParameter("@AssesmentId", hf_AssesmentId.Value),
                        new SqlParameter("@ElectionId", ddlYear.SelectedValue),
                        new SqlParameter("@DivisionId", ddlDivisions.SelectedValue),
                        new SqlParameter("@DistrictId", ddlDistrict.SelectedValue),
                        new SqlParameter("@NAId", ddlNA.SelectedValue), 
                        new SqlParameter("@PartyId", hf_Id.Value),
                        new SqlParameter("@CandidateId", DDL_Candidate.SelectedValue),
                        new SqlParameter("@PAId", paId), 
                        new SqlParameter("@Type", rdoType.SelectedValue), 
                        new SqlParameter("@Factors", factor.Text),
                        new SqlParameter("@Winning_Percentage", Convert.ToInt32(Winning_Per.Text.Trim().ToString())),
                        new SqlParameter("@CreatedBy",Session["UserId"])
                        
                    };
                    ObjDBManager.ExecuteNonQuery("usp_INSERT_Constituency_Assessment", parm);
                }
                lblMsg.Text = "Saved successfully!";
                lblMsg.Attributes.Remove("class");
                lblMsg.Attributes.Add("class", "success");
                FillGridView();
            }
        }
        catch(Exception exp)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
    
    }

   

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType== DataControlRowType.DataRow)
        {
            HiddenField hf_PId =(HiddenField )e.Row.FindControl("hf_PartyId");
            HiddenField hf_CandidateId = (HiddenField)e.Row.FindControl("hf_CandidateId");
            DropDownList DDL_Candidate = (DropDownList)e.Row.FindControl("DDL_Candidate");

            DataTable dt = Ds_Global.Tables[1].Select("PartyId='" + hf_PId.Value + "'").CopyToDataTable();
            DDL_Candidate.DataSource = dt;
            DDL_Candidate.DataTextField = "CandidateName";
            DDL_Candidate.DataValueField = "CandidateId";
            DDL_Candidate.DataBind();
            DDL_Candidate.Items.Insert(0, new ListItem("", "0"));
            DDL_Candidate.SelectedValue = hf_CandidateId.Value;

        }
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        FillGridView();
    }
}