using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FafenSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    private void LoadReport()
    {
       
        try
        {
            DBManager dbMgr = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Request.QueryString["NAId"]),
                new SqlParameter("@PAId",Request.QueryString["PAId"]),
                new SqlParameter("@Type",Request.QueryString["Type"]),
                new SqlParameter("@ImageType",RBType.SelectedItem.Text.ToString())


            };
            DataSet ds = dbMgr.ExecuteDataSet("Report_GetLastFifenResults", parm);

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("FafenSummaryReport.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource repDs = new ReportDataSource();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ds.Tables[0]));
            ReportViewer1.LocalReport.Refresh();

        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
}