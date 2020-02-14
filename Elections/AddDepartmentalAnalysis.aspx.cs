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

public partial class Election_AddDepartmentalAnalysis : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblMsg.Text = "";            
            checkanalyzer();
         
            GetYears();
            GetDivisions();
           // GetProvince();
            GetDistrict();
            GetNA();
            GetPA();
            
           
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            FillBox();
        }
    }
    private void cleartxtbox()
    {

        txtbxGenSubsectorRemarks.Text = "";
        txtbxGenSubsector.Text = "";
        DivsnalSubsectorRemarks.Text="";
        DivsnalSubsectorAna.Text = "";
        txtboxOCsubRemarks.Text = "";
        txtboxOCsubAnalysis.Text="";
    }
    protected void GetDivisions()
    {
        CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
        ddlDivisions.DataSource = objCommonFunctionsProvince.GetDivisions("4");

        ddlDivisions.DataTextField = "Name";
        ddlDivisions.DataValueField = "DivisionId";
        ddlDivisions.DataBind();
    }
    protected void checkanalyzer()
    {

        

        if (Convert.ToString(Session["UserType"]) == "HQ")
        {           
            DivsnalSubsectorRemarks.Enabled = false;
            DivsnalSubsectorAna.Enabled = false;
            txtbxGenSubsectorRemarks.Enabled = false;
            txtbxGenSubsector.Enabled = false;
            //  Subsector.Visible = false;
        }
      else  if (Convert.ToString(Session["UserType"]) == "OC")
        {

            GeneralSubsector.Visible = false;
            Subsector.Visible = false;

        }
    else    if (Convert.ToString(Session["UserType"]) == "DIV")
        {
            Subsector.Visible = false;
            txtbxGenSubsector.Enabled = false;
            txtbxGenSubsectorRemarks.Enabled = false;
        }
    }
    protected void filltextbox()
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SelectDepartmentalAnalysis", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlDivisions.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

        }
        catch (Exception ex)
        { }
    }
    protected void GetYears()
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlYear.DataSource = objCommonFunctions.GetelectionYear();

        ddlYear.DataTextField = "electionyear";
        ddlYear.DataValueField = "electionid";
        ddlYear.DataBind();
    }
    //protected void GetProvince()
    //{
    //        CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
    //        ddlProvince.DataSource = objCommonFunctionsProvince.GetProvince();

    //        ddlProvince.DataTextField = "ProvinceName";
    //        ddlProvince.DataValueField = "ProvinceId";
    //        ddlProvince.DataBind();
    //}
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
    protected void FillBox()
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            string paId = "0";
            if (rdoType.SelectedItem.Text == "NA")
            {
                if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
                {
                    paId = ddlPA.SelectedValue;
                }
            }
            else if (rdoType.SelectedItem.Text == "PA")
            {
                if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
                {
                    paId = ddlPA.SelectedValue;
                }
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("SelectDepartmentalAnalysis", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NAId", paId);
            cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlDivisions.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)

            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (Convert.ToString(dt.Rows[i]["UserType"]) == "HQ")
                    {
                        txtboxOCsubAnalysis.Text = Convert.ToString(dt.Rows[i]["Analysis"]);
                        txtboxOCsubRemarks.Text = Convert.ToString(dt.Rows[i]["Remarks"]);
                    }
                    else
                         if (Convert.ToString(dt.Rows[i]["UserType"]) == "DIV")
                    {

                        DivsnalSubsectorAna.Text = Convert.ToString(dt.Rows[i]["Analysis"]);
                        DivsnalSubsectorRemarks.Text = Convert.ToString(dt.Rows[i]["Remarks"]);
                    }
                    else
                         if (Convert.ToString(dt.Rows[i]["UserType"]) == "OC")
                    {

                        txtbxGenSubsector.Text = Convert.ToString(dt.Rows[i]["Analysis"]);
                        txtbxGenSubsectorRemarks.Text = Convert.ToString(dt.Rows[i]["Remarks"]);
                    }

            }
        }
        catch (Exception ex)
        { }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            string paId = "0";
            if (rdoType.SelectedItem.Text == "NA")
            {
                if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
                {
                    paId = ddlPA.SelectedValue;
                }
            }
            else   if (rdoType.SelectedItem.Text == "PA")
                {
                    if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
                    {
                        paId = ddlPA.SelectedValue;
                    }
                }
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertDepartmentalAnalysis", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@PAid", paId);
            cmd.Parameters.AddWithValue("@DividionId", ddlDivisions.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            if (Convert.ToString(Session["UserType"]) =="HQ")
            {
                cmd.Parameters.AddWithValue("@Analysis", txtboxOCsubAnalysis.Text.Trim());
                cmd.Parameters.AddWithValue("@remarks", txtboxOCsubRemarks.Text.Trim());
            }
            else
                if (Convert.ToString(Session["UserType"]) == "OC")
            {


                cmd.Parameters.AddWithValue("@Analysis", txtbxGenSubsector.Text.Trim());
                cmd.Parameters.AddWithValue("@remarks", txtbxGenSubsectorRemarks.Text.Trim());
            }

            else
                if (Convert.ToString(Session["UserType"]) == "DIV")
            {
                cmd.Parameters.AddWithValue("@Analysis", DivsnalSubsectorAna.Text.Trim());
                cmd.Parameters.AddWithValue("@remarks", DivsnalSubsectorRemarks.Text.Trim());
            }
            cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
           
            cmd.Parameters.AddWithValue("@Analyzerid", Session["UserId"]);
           
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            cleartxtbox();
          //  txtConstituencyAnalysis.Text = "";




        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }
    

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        FillBox();
       
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
        FillBox();
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
        FillBox();
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
        FillBox();


    }

    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
        GetPA();
    }
}  