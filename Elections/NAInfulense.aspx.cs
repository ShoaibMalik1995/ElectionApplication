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

public partial class NAInfulense : System.Web.UI.Page
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
            if (Request.QueryString["ElecnId"] != null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
            //FillGridView();
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
    protected void btn_SaveINF_Click(object sender, EventArgs e)
    {
        
       
    }

    private void Insertinflu()
    {
        try
        {


            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("NA_ID",ddlNA.SelectedValue),
            new SqlParameter("ElectionId",ddlYear.SelectedValue),
            new SqlParameter("DivisionId",ddlDivisions.SelectedValue),
            new SqlParameter("DistrictId",ddlDistrict.SelectedValue),

            new SqlParameter("Name", txt_In_Name.Text),
            new SqlParameter("TYPE_Inf",txt_Type_inf.Text),
            new SqlParameter("Political_leaning",txt_political_leaning.Text),
            new SqlParameter("Profession",txt_political_leaning.Text),

            new SqlParameter("Rel_poli",txt_poli_Relation.Text),
            new SqlParameter("Rel_Beau",txtbureaucratic.Text),
            new SqlParameter("Rel_Mili",txtMilitary.Text),


        };

            ObjDBManager.ExecuteNonQuery("InsertNAInfluencial", parm);
            Clear();
        }
        catch (Exception)
        {

            throw;
        }
    }
    private void Clear()
    {
        txt_In_Name.Text = "";
        txt_Type_inf.Text = "";
        txt_political_leaning.Text = "";
        txt_political_leaning.Text = "";
        txt_poli_Relation.Text = "";
        txtbureaucratic.Text = "";
        txtMilitary.Text = "";

    }


    private void InsertSpoiler()
    {
        try
        {

            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter> {
             new SqlParameter("NA_ID",ddlNA.SelectedValue),
            new SqlParameter("ElectionId",ddlYear.SelectedValue),
            new SqlParameter("DivisionId",ddlDivisions.SelectedValue),
            new SqlParameter("DistrictId",ddlDistrict.SelectedValue),

            new SqlParameter("S_Name", Textbox_S_Name.Text),
            new SqlParameter("S_TYPE_Inf",Textbox_S_TYPE_Inf.Text),
            new SqlParameter("S_Political_leaning",TextboxS_Political_leaning.Text),
            new SqlParameter("S_Profession",TextboxS_Profession.Text),

            new SqlParameter("S_Rel_poli",TextboxS_Rel_poli.Text),
            new SqlParameter("S_Rel_Beau",TextboxS_Rel_Beau.Text),
            new SqlParameter("S_Rel_Mili",TextboxS_Rel_Mili.Text),
        };
            ObjDBManager.ExecuteNonQuery("InsertNASpoiler", parm);
            SpoilerClear();
        }

        catch (Exception ex)
        {

            throw;
        }
    }
    private void SpoilerClear()
    {
        Textbox_S_Name.Text = "";
        Textbox_S_TYPE_Inf.Text = "";
        TextboxS_Political_leaning.Text = "";
        TextboxS_Profession.Text = "";
        TextboxS_Rel_poli.Text = "";
        TextboxS_Rel_Beau.Text = "";
        TextboxS_Rel_Mili.Text = "";

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

    protected void Btn_Save_Spo_Click(object sender, EventArgs e)
    {
        if (Btn_Save_Spo.Text == "Save")
        { 
        Insertinflu();
        InsertSpoiler();
        }
        else
        {
            UpdateInfluencialInfo();
            UpdateSpoilerInfo();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetInfluencial();
        GetSpoilerInfo();
       
    }
    protected void GetInfluencial()
    {
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetNAInfluencial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NA_ID", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlDivisions.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                Btn_Save_Spo.Text = "Update";
                while (rdr.Read())
                {

                    ddlYear.SelectedValue = rdr["ElectionId"].ToString();
                    ddlDivisions.SelectedValue = rdr["DivisionId"].ToString();
                    ddlDistrict.SelectedValue = rdr["DistrictId"].ToString();
                    ddlNA.SelectedValue = rdr["NA_ID"].ToString();

                    txt_In_Name.Text = rdr["Name"].ToString();
                    txt_Type_inf.Text = rdr["TYPE_Inf"].ToString();
                    txt_political_leaning.Text = rdr["Political_leaning"].ToString();
                    txt_profrssion.Text = rdr["Profession"].ToString();
                    txt_poli_Relation.Text = rdr["Rel_poli"].ToString();
                    txtbureaucratic.Text = rdr["Rel_Beau"].ToString();
                    txtMilitary.Text = rdr["Rel_Mili"].ToString();
                    HF_Influence.Value = rdr["NA_INF_ID"].ToString();


                }
            }
            GetSpoilerInfo();
        }
        catch (Exception ex)
        {


        }

    }
    protected void GetSpoilerInfo()
    {
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();


            SqlCommand cmd = new SqlCommand("GetNASpoilerInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ElectionId", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@NA_ID", ddlNA.SelectedValue);
            cmd.Parameters.AddWithValue("@ProvinceId", ddlDivisions.SelectedValue);
            cmd.Parameters.AddWithValue("@DistrictId", ddlDistrict.SelectedValue);

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                Btn_Save_Spo.Text = "Update";
                while (rdr.Read())
                {

                    ddlYear.SelectedValue = rdr["ElectionId"].ToString();
                    ddlDivisions.SelectedValue = rdr["DivisionId"].ToString();
                    ddlDistrict.SelectedValue = rdr["DistrictId"].ToString();
                    ddlNA.SelectedValue = rdr["NA_ID"].ToString();

                    Textbox_S_Name.Text = rdr["S_Name"].ToString();
                    Textbox_S_TYPE_Inf.Text = rdr["S_TYPE_Inf"].ToString();
                    TextboxS_Political_leaning.Text = rdr["S_Political_leaning"].ToString();
                    TextboxS_Profession.Text = rdr["S_Profession"].ToString();
                    TextboxS_Rel_poli.Text = rdr["S_Rel_poli"].ToString();
                    TextboxS_Rel_Beau.Text = rdr["S_Rel_Beau"].ToString();
                    TextboxS_Rel_Mili.Text = rdr["S_Rel_Mili"].ToString();
                    HF_SpoilerID.Value = rdr["NA_Spo_id"].ToString();


                }
            }

        }
        catch (Exception)
        {


        }
    }
    protected void UpdateInfluencialInfo()
    {
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();


            SqlCommand cmd = new SqlCommand("UpdateInfluencialInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", txt_In_Name.Text);
            cmd.Parameters.AddWithValue("@TYPE_Inf", txt_Type_inf.Text);
            cmd.Parameters.AddWithValue("@Political_leaning", txt_political_leaning.Text);
            cmd.Parameters.AddWithValue("@Profession", txt_profrssion.Text);
            cmd.Parameters.AddWithValue("@Rel_poli", txt_poli_Relation.Text);
            cmd.Parameters.AddWithValue("@Rel_Beau", txtbureaucratic.Text);
            cmd.Parameters.AddWithValue("@Rel_Mili", txtMilitary.Text);

            cmd.Parameters.AddWithValue("@NA_INF_ID", HF_Influence.Value);

           cmd.ExecuteNonQuery();
            con.Close();
          
        }
        catch (Exception)
        {


        }
    }
    protected void UpdateSpoilerInfo()
    {
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();


            SqlCommand cmd = new SqlCommand("UpdateSpoilerInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@S_Name", Textbox_S_Name.Text);
            cmd.Parameters.AddWithValue("@S_TYPE_Inf", Textbox_S_TYPE_Inf.Text);
            cmd.Parameters.AddWithValue("@S_Political_leaning", TextboxS_Political_leaning.Text);
            cmd.Parameters.AddWithValue("@S_Profession", TextboxS_Profession.Text);
            cmd.Parameters.AddWithValue("@S_Rel_poli", TextboxS_Rel_poli.Text);
            cmd.Parameters.AddWithValue("@S_Rel_Beau", TextboxS_Rel_Beau.Text);
            cmd.Parameters.AddWithValue("@S_Rel_Mili", txtMilitary.Text);

            cmd.Parameters.AddWithValue("@NA_Spo_id", HF_SpoilerID.Value);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception ex)
        {


        }
    }

}
        
