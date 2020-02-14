using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class Reports_VFU_LM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CommonFunctions objCommonFunctions = new CommonFunctions();
            ddlParty.DataSource = objCommonFunctions.GetParties();

            ddlParty.DataTextField = "PartyName";
            ddlParty.DataValueField = "Partyid";
            ddlParty.DataBind();
            ddlParty.Items.Insert(0, new ListItem("All", "0"));
        }
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
                new SqlParameter("@VoteForUs",chkVoteForUs.Checked),
                new SqlParameter("@LikeMinded",chkLikeMinded.Checked),
                new SqlParameter("@PartyId",ddlParty.SelectedValue)
            };
            grdVFU_LM_Candidates.DataSource = ObjDBManager.ExecuteDataTable("Report_ReportForUs_LikeMonded", parm);
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
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("candPic");
            DataRowView rowView = (DataRowView)e.Row.DataItem;                        
            byte[] b = (byte[])rowView["Picture"];
            string base64 = Convert.ToBase64String(b);
            img.ImageUrl = "data:Image/png;base64," + base64;
        }
    }
}