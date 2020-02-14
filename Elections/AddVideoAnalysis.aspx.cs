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

public partial class Election_AddVideoAnalysis : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
         //   GetProvince();
             GetDivisions();
   
            GetDistrict();
            GetNA();
            GetPA();
            
           
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
    //protected void GetProvince()
    //{
    //        CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
    //    ddlDivisions.DataSource = objCommonFunctionsProvince.GetProvince();

    //    ddlDivisions.DataTextField = "ProvinceName";
    //    ddlDivisions.DataValueField = "ProvinceId";
    //    ddlDivisions.DataBind();
    //}
    protected void GetDistrict()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlDistrict.DataSource = objCommonFunctionsGetDistrict.GetDistrictByDivisions(ddlDivisions.SelectedValue);

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();

    }
    protected void GetDivisions()
    {
        CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
        ddlDivisions.DataSource = objCommonFunctionsProvince.GetDivisions("4");

        ddlDivisions.DataTextField = "Name";
        ddlDivisions.DataValueField = "DivisionId";
        ddlDivisions.DataBind();
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
    
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {

            if (FileUpload1.HasFile)
            {
                try
                {
                   
                    
                            string filename = Path.GetFileName(FileUpload1.FileName);
                    //var convert = new NReco.VideoConverter.FFMpegConverter();
                    //convert.ConvertMedia(filename, Server.MapPath("~/Video/") + Path.GetFileName(FileUpload1.FileName), NReco.VideoConverter.Format.mp4);
                    FileUpload1.SaveAs(Server.MapPath("~/Video/") + Path.GetFileName(FileUpload1.FileName));
                    string link = "video/" + Path.GetFileName(FileUpload1.FileName);
                    link = "<video width=150  height=150 Controls><Source src=" + link + "type=video/mp4></video>";




                    string paId = "0";
                    if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
                    {
                        paId = ddlPA.SelectedValue;
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertVideoAnalysis", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
                    cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
                    cmd.Parameters.AddWithValue("@PAid", paId);
                    cmd.Parameters.AddWithValue("@ProvinceId", ddlDivisions.SelectedValue);
                    cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
                   
                    cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
                    cmd.Parameters.AddWithValue("@VideoName", filename);
                    cmd.Parameters.AddWithValue("@VideoLink", link);
                    cmd.Parameters.AddWithValue("@Analyzerid", 1);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblMsg.Text = "Save Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    txtConstituencyAnalysis.Text = "";


                }
                catch (Exception ex)
                {

                }
            }
            //    string paId = "0";
            //    if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
            //    {
            //        paId = ddlPA.SelectedValue;
            //    }
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("InsertConstituencyAnalysis", con);

            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            //    cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            //    cmd.Parameters.AddWithValue("@PAid", paId);
            //    cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
            //    cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            //    cmd.Parameters.AddWithValue("@Analysis", txtConstituencyAnalysis.Text.Trim());
            //    cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    lblMsg.Text = "Save Successfully";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;
            //    txtConstituencyAnalysis.Text = "";




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
       
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
        GetPA();
        
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

    protected void Btn_SaveVideo_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);

        try
        {

            if (FileUpload1.HasFile)
            {
                try
                {
                    string p = Path.GetFileName(FileUpload1.FileName);

                    string esa = Path.GetExtension(p);
                    if (esa == ".mp4" || esa == ".MP4")
                    {
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        // var convert = new NReco.VideoConverter.FFMpegConverter();
                        //  convert.ConvertMedia(filename, Server.MapPath("~/Video/") + Path.GetFileName(FileUpload1.FileName), NReco.VideoConverter.Format.mp4);
                        string link = null;
                        //if (filename.Length > 10)
                        //{
                        //    FileUpload1.SaveAs(Server.MapPath("~/Video/") + str.Replace(" ", String.Empty); filename.Substring(0, 10) + ".mp4");
                        //    link = "video/" + filename.Substring(0, 10) + ".mp4";
                        //    link = "<video width=150  height=150 Controls><Source src=" + link + " type=video/mp4></video>";



                        //}
                        //else
                        //{

                            FileUpload1.SaveAs(Server.MapPath("~/Video/") + filename.Replace(" ",string.Empty));
                            link = "video/" + filename.Replace(" ", string.Empty);
                            link = "<video width=250  height=150 Controls><Source src=" + link + " type=video/mp4></video>";


                       // }




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
                        SqlCommand cmd = new SqlCommand("InsertVideoAnalysis", con);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);

                        cmd.Parameters.AddWithValue("@PAid", paId);
                        cmd.Parameters.AddWithValue("@ProvinceId", ddlDivisions.SelectedValue);
                        cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);

                        cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
                        cmd.Parameters.AddWithValue("@VideoName", filename);
                        cmd.Parameters.AddWithValue("@VideoLink", link);
                        cmd.Parameters.AddWithValue("@Analyzerid", 1);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblMsg.Text = "Save Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        txtConstituencyAnalysis.Text = "";


                    }
                    else
                    {
                        lblMsg.Text = "Save .Mp4 format";
                    }
                }
                catch (Exception ex)
                {

                }
            }
            //    string paId = "0";
            //    if (!string.IsNullOrEmpty(ddlPA.SelectedValue))
            //    {
            //        paId = ddlPA.SelectedValue;
            //    }
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("InsertConstituencyAnalysis", con);

            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Electionid", ddlYear.SelectedValue);
            //    cmd.Parameters.AddWithValue("@NAid", ddlNA.SelectedValue);
            //    cmd.Parameters.AddWithValue("@PAid", paId);
            //    cmd.Parameters.AddWithValue("@ProvinceId", ddlProvince.SelectedValue);
            //    cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);
            //    cmd.Parameters.AddWithValue("@Analysis", txtConstituencyAnalysis.Text.Trim());
            //    cmd.Parameters.AddWithValue("@Type", rdoType.SelectedValue);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    lblMsg.Text = "Save Successfully";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;
            //    txtConstituencyAnalysis.Text = "";




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