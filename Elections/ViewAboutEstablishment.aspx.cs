using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class Reports_ViewAboutEstablishment : System.Web.UI.Page
{
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetParty();
            GetCandidates();
        }
    }

    protected void GetParty()
    {
        ddlParty.DataSource = objCommonFunctions.GetParties();

        ddlParty.DataTextField = "PartyName";
        ddlParty.DataValueField = "Partyid";
        ddlParty.DataBind();
        ddlParty.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void GetCandidates()
    {
        ddlCandidate2.DataSource = objCommonFunctions.GetPartyCatdidate(ddlParty.SelectedValue);

        ddlCandidate2.DataTextField = "Name";
        ddlCandidate2.DataValueField = "candidateid";
        ddlCandidate2.DataBind();
        ddlCandidate2.Items.Insert(0, new ListItem("", "0"));

    }
    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCandidates();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindGrd();
    }
    protected void bindGrd()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {                
                new SqlParameter("@PartyId",ddlParty.SelectedValue),
                new SqlParameter("@CandidateId",ddlCandidate2.SelectedValue),
                new SqlParameter("@ViewsAboutEstablishment",txtViews.Text)
            };
            grdVFU_LM_Candidates.DataSource = ObjDBManager.ExecuteDataTable("Report_ViewAboutEstablishment", parm);
            grdVFU_LM_Candidates.DataBind();

        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
            throw;
        }
    }


    protected void grdCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("candPic");
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            byte[] b = (byte[])rowView["Picture"];
            string base64 = Convert.ToBase64String(b);
            img.ImageUrl = "data:Image/png;base64," + base64;
        }
    }
}