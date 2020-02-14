using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ConstituencyAnalysis : System.Web.UI.Page
{
    DataSet _dsAnalysis;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GetYears();
            //GetProvince();
            //GetDistrict();
            //GetNA();
            LoadReport();
        }
    }
    private void LoadReport()
    {
        DBManager dbmanger = new DBManager();

        List<SqlParameter> list = new List<SqlParameter>();
        list.Add(new SqlParameter("@NAId", Request.QueryString["NAID"]));
        list.Add(new SqlParameter("@ElectionId", "0"));

        _dsAnalysis = dbmanger.ExecuteDataSet("Report_GetNAAnalysis", list);

        rptAnalysisMain.DataSource = _dsAnalysis.Tables[0];
        rptAnalysisMain.DataBind();

        //DataTable dtPA = dss.Tables[1];

        //DataSet dsMain = new DataSet();
        //DataRelation newRelation = new DataRelation("processData",dss.Tables[1].Columns["EmpName"], dss.Tables[1].Columns["EmpRole"]);
        //dsMain.Relations.Add(newRelation);

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

    protected void rptAnalysisMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType==ListItemType.Item)
        {
            Repeater rpt = e.Item.FindControl("rptAnalysisSub") as Repeater;
            rpt.DataSource = _dsAnalysis.Tables[1];
            rpt.DataBind();
        }
    }
}