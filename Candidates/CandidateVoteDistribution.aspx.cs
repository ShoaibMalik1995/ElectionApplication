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

public partial class Candidates_CandidateVoteDistribution : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetParties();
            GetCandidates();
            FillDate();
        }

    }

    protected void GetParties()
    {
        CommonFunctions objCommonFunctionsGetParties = new CommonFunctions();
        ddlParty.DataSource = objCommonFunctionsGetParties.GetParties();

        ddlParty.DataTextField = "PartyName";
        ddlParty.DataValueField = "PartyId";
        ddlParty.DataBind();
        ddlParty.Items.Insert(0, new ListItem("", "0"));
    }
    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates();
    }

    protected void ddlCandidate_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDate();
    }
    protected void GetCandidates()
    {
        CommonFunctions objCommonFunctionsGetCandidate = new CommonFunctions();
        ddlCandidate.DataSource = objCommonFunctionsGetCandidate.GetPartyCatdidate(ddlParty.SelectedValue);

        ddlCandidate.DataTextField = "Name";
        ddlCandidate.DataValueField = "candidateid";
        ddlCandidate.DataBind();
        ddlCandidate.Items.Insert(0, new ListItem("", "0"));

    }

    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_INSERT_CandidateVoteDistribution", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyId", ddlParty.SelectedValue);
            cmd.Parameters.AddWithValue("@CandidateId", ddlCandidate.SelectedValue);
            cmd.Parameters.AddWithValue("@IndividualVote", Convert.ToInt32(txtIndividualVote.Text.ToString().Trim()));
            cmd.Parameters.AddWithValue("@PartyVote", Convert.ToInt32(txtPartyVote.Text.ToString().Trim()));
            cmd.Parameters.AddWithValue("@ReligiousVote", Convert.ToInt32(txtReligiousVote.Text.ToString().Trim()));

            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Save Successfully";
            lblMsg.ForeColor = System.Drawing.Color.Green;

            FillDate();
        }
        catch
        {
            lblMsg.Text = "Some error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }

    private void FillDate()
    {

        if (ddlParty.SelectedValue != "0" || ddlCandidate.SelectedValue != "0")
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@PartyId",ddlParty.SelectedValue),
                new SqlParameter("@CandidateId",ddlCandidate.SelectedValue)
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetCandidatesVoteDistribution", parm);
            if (dt.Rows.Count > 0)
            {
                txtIndividualVote.Text = dt.Rows[0]["IndividualVote"].ToString();
                txtPartyVote.Text = dt.Rows[0]["PartyVote"].ToString();
                txtReligiousVote.Text = dt.Rows[0]["ReligiousVote"].ToString();

            }
            else
            {
                txtIndividualVote.Text = "0";
                txtPartyVote.Text = "0";
                txtReligiousVote.Text = "0";

            }
        }
        else
        {
            txtIndividualVote.Text = "0";
            txtPartyVote.Text = "0";
            txtReligiousVote.Text = "0";

        }

    }

}