using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Reports_InfluentialFigure : System.Web.UI.Page
{
    CommonFunctions objCommonFunctions = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetNA();            
        }
    }

    protected void GetYears()
    {
        ddlYear.DataSource = objCommonFunctions.GetelectionYear();

        ddlYear.DataTextField = "electionyear";
        ddlYear.DataValueField = "electionid";
        ddlYear.DataBind();
    }

    protected void GetNA()
    {
        
        ddlNA.DataSource = objCommonFunctions.GetNA("0");

        ddlNA.DataTextField = "Name";
        ddlNA.DataValueField = "NAId";
        ddlNA.DataBind();
    }    
    protected void bindGrd()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),
                new SqlParameter("@NAId",ddlNA.SelectedValue)                
            };
            grdVFU_LM_Candidates.DataSource = ObjDBManager.ExecuteDataTable("Report_GetInfluentialFigures", parm);
            grdVFU_LM_Candidates.DataBind();

        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
            throw;
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindGrd();
    }
}