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

public partial class Reports_IndependantCand : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();            
        }
    }
    protected void GetYears()
    {
        CommonFunctions objCommonFunctions = new CommonFunctions();
        ddlYear.DataSource = objCommonFunctions.GetelectionYear();

        ddlYear.DataTextField = "electionyear";
        ddlYear.DataValueField = "electionid";
        ddlYear.DataBind();
    }
      
    private void FillGridView()
    {
      
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",ddlYear.SelectedValue),                
                new SqlParameter("@Type",rdoType.SelectedValue),
                new SqlParameter("@Gender",ddlGender.SelectedValue)
            };
        GridView1.DataSource = ObjDBManager.ExecuteDataTable("Report_GetIndependantCandidates", parm);
        GridView1.DataBind();
    }

    protected void grdCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("candPic");
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            byte[] b = (byte[])rowView["Picture"];
            string base64 = Convert.ToBase64String(b);
            img.ImageUrl = "data:Image/png;base64," + base64;
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGridView();
    }
}  