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

public partial class Reports_PartiesAnalysis : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReportDate();
        }
    }

    protected void ReportDate()
    {
        SqlConnection conn = new SqlConnection(_str);
        DataTable dt=new DataTable();
        try
        {
            SqlCommand sc = new SqlCommand("GetPartyAnalysis", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@NAId", Request.QueryString["NAId"]);
            sc.Parameters.AddWithValue("@PAId", Request.QueryString["PAId"]);
            sc.Parameters.AddWithValue("@Type", Request.QueryString["Type"]);

            SqlDataAdapter sda=new SqlDataAdapter(sc);
            sda.Fill(dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("PartiesAnalysisReport.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ReportViewer1.LocalReport.Refresh();

            //if (Request.Browser.Browser == "Chrome") 
            //{ 
            //    byte[] bytes = ReportViewer1.LocalReport.Render("PDF");
            //    Response.AddHeader("Content-Disposition", "inline; filename=MyReport.pdf");
            //    Response.ContentType = "application/pdf"; Response.BinaryWrite(bytes); Response.End();
            //}
            //else 
            //{ 
            //    ReportViewer1.Visible = true; 
            //}
        }
        catch(Exception Ex)
        {
            Response.Redirect(Ex.Message);
        }
        finally
        {

        }
    }
}