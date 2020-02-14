using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class AdminVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            lblId.Text = Request.QueryString["Title"];
           

            //DBManager ObjDBManager = new DBManager();
            //try
            //{
            //    List<SqlParameter> parm = new List<SqlParameter>
            //    {
            //        new SqlParameter("@NAId",Request.QueryString["Id"]),
            //        new SqlParameter("@PAId",Request.QueryString["Id"]),
            //        new SqlParameter("@Type",Request.QueryString["Type"])
            //    };
            //    DataSet ds = ObjDBManager.ExecuteDataSet("GetLastFiveElectionResults", parm);
            //    //grdWinningCandidates.DataSource = ds.Tables[0];
            //    //grdWinningCandidates.DataBind();
               
            //}
            //catch (Exception exp)
            //{
            //}
        }
    
    }
}