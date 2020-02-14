using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ProviceWiseVoters : System.Web.UI.Page
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

            new SqlParameter("@ElectionId",Request.QueryString["ElectionId"])

            };
            DataSet ds = dbMgr.ExecuteDataSet("Report_GetProvinceWiseVoters", parm);

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("ProvinceWiseVoters.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource repDs = new ReportDataSource();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetProviceWiseVoters", ds.Tables[0]));
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