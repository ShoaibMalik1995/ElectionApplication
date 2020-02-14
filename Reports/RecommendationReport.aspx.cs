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
using Microsoft.Reporting.WebForms;

public partial class Reports_RecommendationReport : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ShowReport();

        }
    }

    private void ShowReport()
    {
        try
        {
            DBManager dbMgr = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Request.QueryString["NAID"])                
            };
            DataSet ds = dbMgr.ExecuteDataSet("Report_GetNAStatistics_Recommandations", parm);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("RecommendationReport.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource repDs = new ReportDataSource();            
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetGetNAStatistics_Recommandations", ds.Tables[0]));
            ReportViewer1.LocalReport.Refresh();

        }
        catch (Exception ex)
        {

        }
    }
   
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        ShowReport();
    }
}