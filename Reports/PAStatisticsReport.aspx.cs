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

public partial class Reports_PAStatisticsReport : System.Web.UI.Page
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

                new SqlParameter("@PAId",Request.QueryString["PAID"])

            };
            DataSet ds = dbMgr.ExecuteDataSet("Report_GetPAStatistics", parm);


            ReportViewer1.LocalReport.ReportPath = Server.MapPath("PAStatisticsReport.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource repDs = new ReportDataSource();            

            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetFigure", ds.Tables[0]));

            if (ds.Tables[1].Rows.Count == 0)
            {
                DataTable dtCast = new DataTable();
                dtCast.Clear();
                dtCast.Columns.Add("CastName");
                dtCast.Columns.Add("Percentage");
                DataRow _ravi = dtCast.NewRow();
                _ravi["CastName"] = "";
                _ravi["Percentage"] = "";
                dtCast.Rows.Add(_ravi);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", dtCast));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCast", ds.Tables[1]));
            }

            if (ds.Tables[2].Rows.Count == 0)
            {
                DataTable dtSectarian = new DataTable();
                dtSectarian.Clear();
                dtSectarian.Columns.Add("SectrainName");
                dtSectarian.Columns.Add("Percentage");
                DataRow _ravi = dtSectarian.NewRow();
                _ravi["SectrainName"] = "";
                _ravi["Percentage"] = "";
                dtSectarian.Rows.Add(_ravi);
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", dtSectarian));
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetSectrain", ds.Tables[2]));
            }

           
             
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetVotesObtained", ds.Tables[3]));
            
            //ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(subReports);

            // ReportViewer1.LocalReport.DataSources.Add(repDs);

            ReportViewer1.LocalReport.Refresh();

            //if (Request.Browser.Browser == "Chrome")
            //{
            //    Byte[] bytes = ReportViewer1.LocalReport.Render("PDF");
            //    Response.AddHeader("Content-Disposition", "inline; filename=MyReport.pdf");
            //    Response.ContentType = "application/pdf";
            //    Response.BinaryWrite(bytes);
            //    Response.End();
            //}

            //else
            //    ReportViewer1.Visible = true;

        }
        catch (Exception ex)
        {

        }
    }
    //public void subReports(object sender, SubreportProcessingEventArgs e)
    //{

    //    try
    //    {

    //        DBManager dbMgr = new DBManager();
    //        List<SqlParameter> parm = new List<SqlParameter>
    //        {

    //            new SqlParameter("@NAId",ddlNA.SelectedValue)

    //        };
    //        DataTable dt = dbMgr.ExecuteDataTable("Report_GetNAStatistics_Voters", parm);

    //        e.DataSources.Clear();
    //        e.DataSources.Add(new ReportDataSource("ReportAllVoters", dt));
    //    }
    //    catch (Exception)
    //    {

    //    }


    //}
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        ShowReport();
    }
}