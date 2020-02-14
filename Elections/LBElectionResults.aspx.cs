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

public partial class Election_LBElectionResults : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetLBYears();
            GetProvince();
            ddlProvince.SelectedValue = "4";
            ddlProvince.Enabled = false;
            GetDistrict();
            GetParties();
            FillGridView();
            
           
            //if (Request.QueryString["ElecnId"] != null)
            //{
            //    ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            //}
        }
        lblMsg.Text = "";
    }
    protected void GetLBYears()
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlYear.DataSource = objCommonFunctions.GetLBelectionYear();

        ddlYear.DataTextField = "LBelectionyear";
        ddlYear.DataValueField = "LBelectionid";
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

    protected void GetParties()
    {
        CommonFunctions objCommonFunctionsGetParties = new CommonFunctions();
        ddlParty.DataSource = objCommonFunctionsGetParties.GetParties();

        ddlParty.DataTextField = "PartyName";
        ddlParty.DataValueField = "PartyId";
        ddlParty.DataBind();

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertLBElectionResults", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LBElectionid", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@Provinceid", ddlProvince.SelectedValue);
            cmd.Parameters.AddWithValue("@Dstrictid", ddlDistrict.SelectedValue);
            cmd.Parameters.AddWithValue("@PartyId", ddlParty.SelectedValue);
            cmd.Parameters.AddWithValue("@PartyType", ddlType.SelectedValue);
            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Relation", txtRelationship.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            FillGridView();

            Clear();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void Clear()
    {
        txtName.Text = "";
        txtRelationship.Text = "";
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetParties();
            
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        FillGridView();
        GetParties();
    }
    private void FillGridView()
    {
        using (SqlConnection connection = new SqlConnection(_str))
        {
            SqlCommand command = new SqlCommand("Select_LBelectionResults", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;

        using (SqlConnection con = new SqlConnection(_str))
        {
            string comand = @"DELETE FROM LBElectionResults WHERE (LBResultId = @LBResultId)";
            SqlCommand command = new SqlCommand(comand, con);
            command.Parameters.AddWithValue("@LBResultId", lb.CommandArgument);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        FillGridView();
    }


}  