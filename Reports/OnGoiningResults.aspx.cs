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

public partial class Elections_OnGoiningResults : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            GetDistrict();
            GetNA();
            GetPA();
            //if (Request.QueryString["ElecnId"] != null)
            //{
            //    ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            //}
        }
        lblMsg.Text = "";
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
    
            ddlProvince.DataSource = objCommonFunctions.GetProvince();

            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataBind();
    }
    protected void GetDistrict()
    {
        
        ddlDistrict.DataSource = objCommonFunctions.GetDistrict(ddlProvince.SelectedValue);

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
    
  
    protected void Update_Record(string Result,string id,String type)
    {
        
        SqlConnection con = new SqlConnection(_str);
        con.Open();

        SqlCommand cmd = new SqlCommand("UpdateElectionResult", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Parameters.AddWithValue("@Result", Result);
        cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
        cmd.ExecuteNonQuery();
        con.Close();
        FillGridView();        
        lblMsg.Text = "Result Saved Successfully!";
        lblMsg.ForeColor = System.Drawing.Color.Green;
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
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_ElectionCandidatesOnGng", parm);
        GridView1.DataBind();
        if (GridView1.Rows.Count>0)
        {
            Btn_Save.Visible = true;

        }
        else
        {
            Btn_Save.Visible = false;
        }
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        FillGridView();
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
        FillGridView();
    }
    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
        FillGridView();
    }
    protected void ddlPA_SelectedIndexChanged(object sender, EventArgs e)
    {        
        FillGridView();
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

                    TextBox txt_result = (TextBox)row.FindControl("txt_result");
                    TextBox txt_PollingStation = (TextBox)row.FindControl("txt_PollingStation");
                    TextBox txt_Time = (TextBox)row.FindControl("txt_Time");

                    HiddenField NAId = (HiddenField)row.FindControl("NAId");
                    HiddenField PAId = (HiddenField)row.FindControl("PAId");
                    HiddenField Provinceid = (HiddenField)row.FindControl("Provinceid");
                    HiddenField Districtid = (HiddenField)row.FindControl("Districtid");
                    HiddenField ElectionId = (HiddenField)row.FindControl("ElectionId");
                    HiddenField CandidateId = (HiddenField)row.FindControl("CandidateId");

                    DBManager ObjDBManager = new DBManager();
                    List<SqlParameter> parm = new List<SqlParameter>
                    {
                    new SqlParameter("@NAId",NAId.Value),
                    new SqlParameter("@PAId",PAId.Value),
                    new SqlParameter("@Provinceid",Provinceid.Value),
                    new SqlParameter("@Dstrictid",Districtid.Value),
                    new SqlParameter("@ElectionId",ElectionId.Value),
                    new SqlParameter("@CandidateId",CandidateId.Value),
                    new SqlParameter("@TotalVotes",txt_result.Text),
                    new SqlParameter("@PollingStation",txt_PollingStation.Text),
                    new SqlParameter("@ResultTime",txt_Time.Text),
                    new SqlParameter("@Type",rdoType.SelectedValue),


                    new SqlParameter("@CreatedBy",Session["UserId"]),
                    new SqlParameter("@CreatedDate",DateTime.Now)
                    };

                    ObjDBManager.ExecuteNonQuery("AddOnGoiningResults", parm);                    
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
    
}  