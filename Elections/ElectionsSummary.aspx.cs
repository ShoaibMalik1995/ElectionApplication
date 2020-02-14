using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Elections_ElectionsSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblId.Text = Request.QueryString["Title"];
            hpStatistics.NavigateUrl = "~/Reports/NAStat.aspx?NAId=" + Request.QueryString["NAId"] + "&PAId=" + Request.QueryString["PAId"] + "&Type=NA";
            hpAssesment.NavigateUrl = "~/Reports/AssessmentReport.aspx?NAId=" + Request.QueryString["NAId"] + "&PAId=" + Request.QueryString["PAId"] + "&Type=NA";

            hpDepartmentalAnalysis.NavigateUrl = "~/Reports/DepartmentalAnalyzingSummary.aspx?NAId=" + Request.QueryString["NAId"] + "&PAId=" + Request.QueryString["PAId"] + "&Type=NA";
            hpFafenAnalysis.NavigateUrl = "~/Reports/FafenSummaryReport.aspx?NAId=" + Request.QueryString["NAId"] + "&PAId=" + Request.QueryString["PAId"] + "&Type=NA";
            hpVideoAnalysis.NavigateUrl = "~/AdminVideo.aspx?NAId=" + Request.QueryString["NAId"] + "&PAId=" + Request.QueryString["PAId"] + "&Type=NA";
            hpPartyAnalysis.NavigateUrl = "~/Reports/PartiesAnalysis.aspx?NAId=" + Request.QueryString["NAId"] + "&PAId=" + Request.QueryString["PAId"] + "&Type=NA";



            DBManager ObjDBManager = new DBManager();
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Request.QueryString["NAId"]),
                new SqlParameter("@PAId",Request.QueryString["PAId"]),
                new SqlParameter("@Type",Request.QueryString["Type"])
            };
                DataSet ds = ObjDBManager.ExecuteDataSet("GetLastFiveElectionResults", parm);
                grdWinningCandidates.DataSource = ds.Tables[0];
                grdWinningCandidates.DataBind();

                if (Request.QueryString["Type"] == "NA")
                {
                    ddlList.DataSource = ds.Tables[1];
                    ddlList.DataBind();
                }
            }
            catch(Exception exp)
            {
            }
        }
    }
    protected void grdWinningCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
   {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            byte[] b =new byte[0];
            string base64 = ""; Image WinnerPic;
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            if (!string.IsNullOrEmpty(rowView["Winner1Picture"].ToString()))
            {
                b = (byte[])rowView["Winner1Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner1Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }
            if (!string.IsNullOrEmpty(rowView["Winner1PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner1PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo1");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner2Picture"].ToString()))
            {
                b = (byte[])rowView["Winner2Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner2Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner2PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner2PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo2");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner3Picture"].ToString()))
            {
                b = (byte[])rowView["Winner3Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner3Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner3PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner3PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo3");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner4Picture"].ToString()))
            {
                b = (byte[])rowView["Winner4Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner4Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner4PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner4PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo4");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner5Picture"].ToString()))
            {
                b = (byte[])rowView["Winner5Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner5Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }
            if (!string.IsNullOrEmpty(rowView["Winner5PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner5PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo5");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }
        }
    }
    
}
        