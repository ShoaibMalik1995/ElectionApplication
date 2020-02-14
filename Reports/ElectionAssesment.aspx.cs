using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ElectionAssesment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GetYears();
            GetProvince();
            ddlProvince.SelectedValue = "4";
            ddlProvince.Enabled = false;
            GetDistrict();
            GetNA();

            

        }
    }

    private void LoadReport() {
        DBManager dbmanger = new DBManager();

        List<SqlParameter> list = new List<SqlParameter>();
        list.Add(new SqlParameter("@NAId", 6));
        list.Add(new SqlParameter("@ElectionId", 10));

        DataSet dss = dbmanger.ExecuteDataSet("Report_GetAssesment", list);


        ReportDataSource ds = new ReportDataSource();
        ds.Name = "DataSet1";
        ds.Value = dss.Tables[0];

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(ds);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("ElectionAssesment.rdlc");
        ReportViewer1.LocalReport.Refresh();
    }

         protected void GetYears()
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlYear.DataSource = objCommonFunctions.GetelectionYear();

        ddlYear.DataTextField = "electionyear";
        ddlYear.DataValueField = "electionid";
        ddlYear.DataBind();
    }
    protected void GetProvince()
    {
            CommonFunctions objCommonFunctionsProvince = new CommonFunctions();
            ddlProvince.DataSource = objCommonFunctionsProvince.GetProvince();

            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataBind();
    }
    protected void GetDistrict()
    {
        CommonFunctions objCommonFunctionsGetDistrict = new CommonFunctions();
        ddlDistrict.DataSource = objCommonFunctionsGetDistrict.GetDistrict(ddlProvince.SelectedValue);

        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "DistrictId";
        ddlDistrict.DataBind();

    }
    
    protected void GetNA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlNA.DataSource = objCommonFunctionsGetNA.GetNA(ddlDistrict.SelectedValue);

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        LoadReport();
    }


    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();
    }

     



}