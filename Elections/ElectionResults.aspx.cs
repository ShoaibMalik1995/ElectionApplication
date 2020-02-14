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

public partial class Candidates_ElectionResults : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
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
  
    //protected void Update_Record(string Result, string Remarks, string id,String type)
    //{
        
    //    SqlConnection con = new SqlConnection(_str);
    //    con.Open();

    //    SqlCommand cmd = new SqlCommand("UpdateElectionResult", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@Id", id);
    //    cmd.Parameters.AddWithValue("@Result", Result);
    //    cmd.Parameters.AddWithValue("@Remarks", Remarks);

    //    cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
    //    cmd.ExecuteNonQuery();
    //    con.Close();
    //    FillGridView();        
    //    lblMsg.Text = "Result Saved Successfully!";
    //    lblMsg.ForeColor = System.Drawing.Color.Green;
    //}
 
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
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Select_ElectionCandidates", parm);
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
    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
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
                TextBox result = new TextBox();
                TextBox remarks = new TextBox();

                HiddenField ID = new HiddenField();
                HiddenField Div_ID = new HiddenField();
                HiddenField Dis_ID = new HiddenField();
                HiddenField PA_ID = new HiddenField();
                HiddenField NA_ID = new HiddenField();
                HiddenField P_ID = new HiddenField();
                HiddenField El_ID = new HiddenField();
                HiddenField C_ID = new HiddenField();
                CheckBox Ck = new CheckBox();
                foreach (GridViewRow row in GridView1.Rows)
                {

                    result = (TextBox)row.FindControl("txt_result");
                    remarks = (TextBox)row.FindControl("txt_remarks");

                    ID = (HiddenField)row.FindControl("EC_ID");
                    Div_ID = (HiddenField)row.FindControl("Pro_ID");
                    Dis_ID = (HiddenField)row.FindControl("Dis_ID");
                    NA_ID = (HiddenField)row.FindControl("NA_ID");
                    PA_ID = (HiddenField)row.FindControl("PA_ID");
                    P_ID = (HiddenField)row.FindControl("P_ID");
                    El_ID = (HiddenField)row.FindControl("El_ID");
                    C_ID = (HiddenField)row.FindControl("C_ID");


                    Update_Record(result.Text, remarks.Text, ID.Value, Div_ID.Value, Dis_ID.Value, PA_ID.Value, P_ID.Value, El_ID.Value, C_ID.Value, NA_ID.Value);
                }
                lblMsg.Text = "Saved successfully!";
                lblMsg.Attributes.Remove("class");
                lblMsg.Attributes.Add("class", "success");
            }
        }
        catch
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
        FillGridView();
    }

    private void Update_Record(string Result, string Remarks, string ID, string Div_ID, string Dis_ID, string PA_ID, string P_ID, string El_ID, string C_ID ,string NA_ID)
    {
        SqlConnection con = new SqlConnection(_str);
        con.Open();

        SqlCommand cmd = new SqlCommand("InsertElectionResult", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", ID);
        cmd.Parameters.AddWithValue("@Result", Result);
        cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
        cmd.Parameters.AddWithValue("@ResultType", Request.QueryString["Type"]);

        cmd.Parameters.AddWithValue("@Remarks", Remarks);

        cmd.Parameters.AddWithValue("@Div_ID", Div_ID);
        cmd.Parameters.AddWithValue("@C_ID", C_ID);
        cmd.Parameters.AddWithValue("@Dis_ID", Dis_ID);
        cmd.Parameters.AddWithValue("@NA_ID", NA_ID);
        cmd.Parameters.AddWithValue("@PA_ID", PA_ID);
        cmd.Parameters.AddWithValue("@P_ID", P_ID);
        cmd.Parameters.AddWithValue("@El_ID", El_ID);
        

        cmd.ExecuteNonQuery();
        con.Close();
        FillGridView();
        lblMsg.Text = "Result Saved Successfully!";
        lblMsg.ForeColor = System.Drawing.Color.Green;
    }
}  