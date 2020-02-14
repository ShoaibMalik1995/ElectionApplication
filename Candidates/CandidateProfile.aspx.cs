using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Candidate_CandidateProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadReport();

        }
    }
    private void LoadReport()
    {
        try
        {
            DBManager dbMgr = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {

                new SqlParameter("@CandidateId",Request.QueryString["CandId"])

            };

            DataSet ds = dbMgr.ExecuteDataSet("GetCandidateDetails", parm);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("CandidateProfile.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource repDs = new ReportDataSource();

            
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidateProfile", ds.Tables[0]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidateFather", ds.Tables[1]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetBusinesses", ds.Tables[2]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidateCookfather", ds.Tables[3]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidateSpouse", ds.Tables[4]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidateChildren", ds.Tables[5]));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidateDriverSpousePhone", ds.Tables[6]));
            ReportViewer1.LocalReport.Refresh();
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    
}