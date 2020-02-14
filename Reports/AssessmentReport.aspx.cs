using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Reports_AssessmentReport : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindResults();
        }
    }

    private void bindResults()
    {
        DBManager ObjDBManager = new DBManager();
        string id = "";
        if(Request.QueryString["Type"].ToString()=="NA")
            id= Request.QueryString["NAID"].ToString();
            else
        id = Request.QueryString["PAID"].ToString();

        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",id),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString())
            };
        DataTable dt = ObjDBManager.ExecuteDataTable("usp_GetDummy5Records", parm);
        dlData.DataSource = dt;
        dlData.DataBind();
    }

    private DataTable LastFiveYearsData(int year)
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@PAId",Convert.ToInt32(Request.QueryString["PAId"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString()),
                new SqlParameter("@ElectionId",year)

            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetLastFiveYearAssesments", parm);
            return dt;

        }
        catch (Exception ex)
        {
            return null;
        }
    }
    protected void ResultCharts_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //string country = (e.Item.FindControl("lblShipCountry") as Label).Text;
            Chart Chart1 = (Chart)e.Item.FindControl("Chart1");
            HiddenField hfY = (HiddenField)e.Item.FindControl("hfYear");
            DataTable dt = new DataTable();
            dt.Clear();
            dt = LastFiveYearsData(Convert.ToInt32(hfY.Value));
            
            if (dt.Rows.Count > 0)
            {
                //storing total rows count to loop on each Record  
                string[] XPointMember = new string[dt.Rows.Count];
                int[] YPointMember = new int[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //storing Values for X axis  
                    XPointMember[i] = dt.Rows[i]["Name"].ToString();
                    //storing values for Y Axis  
                    YPointMember[i] = Convert.ToInt32(dt.Rows[i]["Winning_Percentage"]);

                }
                //binding chart control  
                Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

                //setting Chart type   
                Chart1.Series[0].ChartType = SeriesChartType.Pie; 

                Chart1.Titles[0].Text = dt.Rows[0]["ElectionYear"].ToString();
                Chart1.DataSource = dt;
                Chart1.DataBind();

            }

            GridView GV = (GridView)e.Item.FindControl("grdCandidates");
            GV.DataSource = dt;
            GV.DataBind();
        }
    }
    protected void grdCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("CandidateImage");
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            byte[] b = (byte[])rowView["Picture"];
            string base64 = Convert.ToBase64String(b);
            img.ImageUrl = "data:Image/png;base64," + base64;

            Image Party = (Image)e.Row.FindControl("imgPartyLogo1");
            byte[] b1 = (byte[])rowView["Logo"];
            base64 = Convert.ToBase64String(b1);
            Party.ImageUrl = "data:Image/png;base64," + base64;
        }
    }

}