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
using System.IO;

public partial class Election_AddImageAnalysis : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    string File_Path = "";
    string fileName = "";
    string name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            File_Path = Server.MapPath("~/Picture/");            
            //checkanalyzer();
         
            GetYears();
            GetDivisions();
            GetDistrict();
            GetNA();
            GetPA();
            
           
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
           // FillBox();
        }
    }
    //protected void checkanalyzer()
    //{

    //    Session["AnalyzerTYpeID"] = "DIV";

    //    if (Convert.ToString(Session["AnalyzerTYpeID"]) == "HQ")
    //    {
           

          
    //        DivsnalSubsectorRemarks.Enabled = false;
    //        DivsnalSubsectorAna.Enabled = false;
    //        txtbxGenSubsectorRemarks.Enabled = false;
    //        txtbxGenSubsector.Enabled = false;
    //        //  Subsector.Visible = false;
    //    }
    //  else  if (Convert.ToString(Session["AnalyzerTYpeID"]) == "OC")
    //    {

    //        GeneralSubsector.Visible = false;
    //        Subsector.Visible = false;

    //    }
    //else    if (Convert.ToString(Session["AnalyzerTYpeID"]) == "DIV")
    //    {
    //        Subsector.Visible = false;
    //        txtbxGenSubsector.Enabled = false;
    //        txtbxGenSubsectorRemarks.Enabled = false;
    //    }
    //}
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
            cmd.Parameters.AddWithValue("@DividionId", ddlDivisions.SelectedValue);
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
    //protected void FillBox()
    //{

    //    SqlConnection con = new SqlConnection(_str);

    //    try
    //    {
    //        string paId = "0";
    //        if (rdoType.SelectedItem.Text == "NA")
    //        {
    //            if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
    //            {
    //                paId = ddlPA.SelectedValue;
    //            }
    //        }
    //        else if (rdoType.SelectedItem.Text == "PA")
    //        {
    //            if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
    //            {
    //                paId = ddlPA.SelectedValue;
    //            }
    //        }
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("SelectDepartmentalAnalysis", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
    //        cmd.Parameters.AddWithValue("@NAId", paId);
    //        cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
    //        cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
    //        cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
    //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        sda.Fill(dt);
    //        if (dt.Rows.Count > 0)

    //        {
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //                if (Convert.ToString(dt.Rows[i]["UserType"]) == "HQ")
    //                {
    //                    txtboxOCsubAnalysis.Text = Convert.ToString(dt.Rows[i]["Analysis"]);
    //                    txtboxOCsubRemarks.Text = Convert.ToString(dt.Rows[i]["Remarks"]);
    //                }
    //                else
    //                     if (Convert.ToString(dt.Rows[i]["UserType"]) == "DIV")
    //                {

    //                    DivsnalSubsectorAna.Text = Convert.ToString(dt.Rows[i]["Analysis"]);
    //                    DivsnalSubsectorRemarks.Text = Convert.ToString(dt.Rows[i]["Remarks"]);
    //                }
    //                else
    //                     if (Convert.ToString(dt.Rows[i]["UserType"]) == "OC")
    //                {

    //                    txtbxGenSubsector.Text = Convert.ToString(dt.Rows[i]["Analysis"]);
    //                    txtbxGenSubsectorRemarks.Text = Convert.ToString(dt.Rows[i]["Remarks"]);
    //                }

    //        }
    //    }
    //    catch (Exception ex)
    //    { }
    //}
    //protected void btn_save_Click(object sender, EventArgs e)
    //{

    //    SqlConnection con = new SqlConnection(_str);

    //    try
    //    {
    //        string paId = "0";
    //        if (rdoType.SelectedItem.Text == "NA")
    //        {
    //            if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
    //            {
    //                paId = ddlPA.SelectedValue;
    //            }
    //        }
    //        else   if (rdoType.SelectedItem.Text == "PA")
    //            {
    //                if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
    //                {
    //                    paId = ddlPA.SelectedValue;
    //                }
    //            }
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("InsertDepartmentalAnalysis", con);

    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
    //        cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
    //        cmd.Parameters.AddWithValue("@PAid", paId);
    //        cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
    //        cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
    //        if (Convert.ToString(Session["AnalyzerTYpeID"]) =="HQ")
    //        {
    //            cmd.Parameters.AddWithValue("@Analysis", txtboxOCsubAnalysis.Text.Trim());
    //            cmd.Parameters.AddWithValue("@remarks", txtboxOCsubRemarks.Text.Trim());
    //        }
    //        else
    //            if (Convert.ToString(Session["AnalyzerTYpeID"]) == "OC")
    //        {


    //            cmd.Parameters.AddWithValue("@Analysis", txtbxGenSubsector.Text.Trim());
    //            cmd.Parameters.AddWithValue("@remarks", txtbxGenSubsectorRemarks.Text.Trim());
    //        }

    //        else
    //            if (Convert.ToString(Session["AnalyzerTYpeID"]) == "DIV")
    //        {
    //            cmd.Parameters.AddWithValue("@Analysis", DivsnalSubsectorAna.Text.Trim());
    //            cmd.Parameters.AddWithValue("@remarks", DivsnalSubsectorRemarks.Text.Trim());
    //        }
    //        cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
           
    //        cmd.Parameters.AddWithValue("@Analyzerid", Session["UserID"]);
           
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //        lblMsg.Text = "Save Successfully";
    //        lblMsg.ForeColor = System.Drawing.Color.Green;
    //      //  txtConstituencyAnalysis.Text = "";




    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "Some error occurred";
    //        lblMsg.ForeColor = System.Drawing.Color.Red;
    //    }

    //}
    

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDivisions();
        GetNA();
     //   FillBox();
       
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
       // FillBox();
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
      //  FillBox();
    }

    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
      //  FillBox();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {

            if (picUpload.HasFile)
            {
                try
                {

                    //To create a PostedFile
                    HttpPostedFile File = picUpload.PostedFile;

                    //Create byte Array with file len
                    byte[] Data = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(Data, 0, File.ContentLength);

                    


                    string paId = "0";
                    if (rdoType.SelectedItem.Text == "PA")
                    {
                        if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
                        {
                            paId = ddlPA.SelectedValue;
                        }
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertImageAnalysis", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
                    
                    cmd.Parameters.AddWithValue("@PAid", paId);
                    cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
                    cmd.Parameters.AddWithValue("@DivisionId", ddlDivisions.SelectedValue);
                    cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);

                    cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
                    cmd.Parameters.AddWithValue("@ImageType", RadioButtonListImageType.SelectedValue);
                    cmd.Parameters.AddWithValue("@Image", Data);
                    
                    cmd.Parameters.AddWithValue("@Analyzerid", 1);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblMsg.Text = "Save Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                  

                }
                catch (Exception ex)
                {

                }
            }
        




        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }
    protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();

    }
}  