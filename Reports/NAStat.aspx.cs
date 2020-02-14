using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Reports_NAStat : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        RegisteredVotersData();
        PollingStations();
       
        bindResults();
        LatestElectionCasts();
        LatestElectionSectrain();
        BindTehsilUcs();
        GetMaps();
        lblTitle.Text = Request.QueryString["Type"] + " Statistics";
        if (Request.QueryString["Type"].ToString()=="NA")
        {
            GetInfluentialFigures();
            GetSpoilers();
            lblInf.Visible = true;
            DivSpoiler.Visible = true;
        }
        if (Request.QueryString["Type"].ToString() == "PA")
        {
            lblInf.Visible = false;
            DivSpoiler.Visible = false;
        }
    }

    private void RegisteredVotersData()
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                 new SqlParameter("@Type",Request.QueryString["Type"].ToString()),
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("Report_GetNAStatistics_Voters", parm);

            ChartVoters.Series["Series1"]["PointWidth"] = "0.4";

            ChartVoters.Series["Series1"]["DrawingStyle"] = "Emboss";


            ChartVoters.Series[0].YValueMembers = "VotersFemale";
            ChartVoters.Series[0].XValueMember = "ElectionYear";
            ChartVoters.DataSource = dt;
            ChartVoters.DataBind();
        }
        catch (Exception ex)
        {
            ;
        }
    }

    private void PollingStations()
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString()),
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("usp_GetPollingStations", parm);
            if (dt.Rows.Count > 0)
            {
                DataPoint dp1 = new DataPoint();
                double[] arr1 = { Convert.ToDouble(dt.Rows[0]["PSMale"].ToString()) };
                dp1.YValues = arr1;
                dp1.LegendText = "Male";
                DataPoint dp2 = new DataPoint();
                double[] arr2 = { Convert.ToDouble(dt.Rows[0]["PSFemale"].ToString()) };
                dp2.YValues = arr2;
                dp2.LegendText = "Female";
                PieChartPolling.Series[0].Points.Add(dp1);
                PieChartPolling.Series[0].Points.Add(dp2);
            }
        }
        catch
        {
            ;
        }
    }

    private void LatestElectionCasts()
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString())

            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetNALatestElectionCasts", parm);
            foreach (DataRow row in dt.Rows)
            {
                DataPoint dp1 = new DataPoint();
                double[] arr1 = { Convert.ToDouble(row["Percentage"].ToString()) };
                dp1.YValues = arr1;
                dp1.LegendText = row["CastName"].ToString();
                ChartCasts.Series[0].Points.Add(dp1);
            }
        }
        catch
        {
            ;
        }
    }

    private void BindTehsilUcs()
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString())

            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetNA_Category_District_Ucs_Tehsils", parm);
            GV_Tehsils.DataSource = dt;
            GV_Tehsils.DataBind();
        }
        catch (Exception ex)
        {
            ;
        }
    }
    private void LatestElectionSectrain()
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString())

            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetNALatestElectionSectrain", parm);
            foreach (DataRow row in dt.Rows)
            {
                DataPoint dp1 = new DataPoint();
                double[] arr1 = { Convert.ToDouble(row["Percentage"].ToString()) };
                dp1.YValues = arr1;
                dp1.LegendText = row["SectrainName"].ToString();
                ChartSectrain.Series[0].Points.Add(dp1);
            }
        }
        catch
        {
            ;
        }
    }
    protected void GetInfluentialFigures()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"])),
                
            };
            grdVFU_LM_Candidates.DataSource = ObjDBManager.ExecuteDataTable("Report_GetInfluentialFigures", parm);
            grdVFU_LM_Candidates.DataBind();

        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
           
        }
    }

    protected void GetMaps()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"])),   
                 new SqlParameter("@Type",Request.QueryString["Type"].ToString())
             
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("usp_getmapByNA", parm);
            DataTable Tempdt = new DataTable("data");
            Tempdt.Columns.Add("MapImage");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] b = (byte[])dt.Rows[i]["MapImage"];
                DataRow dr = Tempdt.NewRow();
                dr["MapImage"] = Convert.ToBase64String(b);
                Tempdt.Rows.Add(dr);
            }
            GV_Maps.DataSource = Tempdt;
            GV_Maps.DataBind();
            showMap(Tempdt.Rows[0]["MapImage"].ToString());
            lnkPrevious.CommandArgument = "0";
            lnkNext.CommandArgument = "0";

        }
        catch (Exception ex)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");

        }
    }
    protected void GetSpoilers()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]))                
            };
            GV_Spoiler.DataSource = ObjDBManager.ExecuteDataTable("Report_GetNAStatistics_Spoilers", parm);
            GV_Spoiler.DataBind();

        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");

        }
    }

    private DataTable LastFiveYearsData(int year)
    {
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString()),
                new SqlParameter("@Year",year)

            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetTop5ElectionWinner", parm);
            //ChartPolling.DataSource = dt;
            //ChartPolling.Series[0].YValueMembers = "TotalVotes";
            //ChartPolling.Series[1].YValueMembers = "TotalVotes";

            //Set the X-axle as date value
            //ChartPolling.Series[0].XValueMember = "ElectionYear";

            //setting width
            //ChartPolling.Series["Series1"]["PointWidth"] = "0.4";
            //ChartPolling.Series["Series2"]["PointWidth"] = "0.4";

            //seting column style
            //ChartPolling.Series["Series1"]["DrawingStyle"] = "Emboss";
            //ChartPolling.Series["Series2"]["DrawingStyle"] = "Emboss";
            return dt;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private void bindResults()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Convert.ToInt32(Request.QueryString["NAID"]).ToString()),
                new SqlParameter("@Type",Request.QueryString["Type"].ToString())
            };
        DataTable dt = ObjDBManager.ExecuteDataTable("usp_GetDummy5Records", parm);
        dlData.DataSource = dt;
        dlData.DataBind();
    }
    protected void ResultCharts_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Chart Chart1 = (Chart)e.Item.FindControl("Chart1");

                DataTable dt = LastFiveYearsData(Convert.ToInt32(hfYear.Value));
                Chart1.Titles[0].Text = hfYear.Value + " Results";
                if (dt.Rows.Count > 0)
                {
                    Chart1.Titles[0].Text = dt.Rows[0]["ElectionYear"] + " Results";
                    hfYear.Value = dt.Rows[0]["ElectionYear"].ToString();
                }
                string[] x = new string[dt.Rows.Count];
                int[] y = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    x[i] = dt.Rows[i][0].ToString();
                    y[i] = Convert.ToInt32(dt.Rows[i][1]);

                }
                Chart1.Series[0].Points.DataBindXY(x, y);
                Chart1.Series[0].ChartType = SeriesChartType.Column;
                //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart1.Legends[0].Enabled = false;

                GridView GV = (GridView)e.Item.FindControl("grdCandidates");
                GV.DataSource = dt;
                GV.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
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
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        Int32 id = 0;
        if (lbtn.Text == "Previous")
        {
            id = Convert.ToInt32(lnkPrevious.CommandArgument.ToString()) - 1;
            lnkPrevious.CommandArgument = id.ToString();

        }
        else if (lbtn.Text == "Next")
        {
            id = Convert.ToInt32(lnkPrevious.CommandArgument.ToString()) + 1;
            lnkNext.CommandArgument = id.ToString();
        }
        for (int i = 0; i < GV_Maps.Rows.Count; i++)
        {
            if (i == id)
            {
                Label lbl = (Label)GV_Maps.Rows[i].FindControl("lblMap");
                showMap(lbl.Text);
            }
        }
    }

    private void showMap(string base64)
    {
        MapImage.ImageUrl = "data:Image/png;base64," + base64;
    }
}