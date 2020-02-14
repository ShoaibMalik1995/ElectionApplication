using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class AdminVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            lblId.Text = Request.QueryString["Title"];
            HPNAName.NavigateUrl = "~/Reports/NAStatisticsReport.aspx?NAID=" + Request.QueryString["Id"];
            hpOwnAnalysis.NavigateUrl = "~/Reports/ConstituencyAnalysis.aspx?NAID=" + Request.QueryString["Id"];
            hpFefanAnalysis.NavigateUrl = "~/Reports/FafenAnalysisReport.aspx?NAID=" + Request.QueryString["Id"];
            hpAssesment.NavigateUrl = "~/Reports/AssessmentReport.aspx?NAID=" + Request.QueryString["Id"];
            hpRecommendations.NavigateUrl = "~/Reports/RecommendationReport.aspx?NAID=" + Request.QueryString["Id"];

            DBManager ObjDBManager = new DBManager();
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>
                {
                    new SqlParameter("@NAId",Request.QueryString["Id"]),
                    new SqlParameter("@PAId",Request.QueryString["Id"]),
                    new SqlParameter("@Type",Request.QueryString["Type"])
                };
                DataSet ds = ObjDBManager.ExecuteDataSet("GetLastFiveElectionResults", parm);
                //grdWinningCandidates.DataSource = ds.Tables[0];
                //grdWinningCandidates.DataBind();

                if (Request.QueryString["Type"] == "NA")
                {
                    ddlList.DataSource = ds.Tables[1];
                    ddlList.DataBind();
                }
            }
            catch (Exception exp)
            {
            }
        }
    
    }
}