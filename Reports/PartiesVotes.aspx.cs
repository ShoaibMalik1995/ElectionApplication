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
using System.Web.Services;
using System.Text;

public partial class Reports_PartiesVotes : System.Web.UI.Page
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
    

    [WebMethod]
    public static string GetData(string electionId)
    {
        DataTable dt = new DataTable();
        var JSONString = new StringBuilder();
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",electionId)                
            };
            dt = ObjDBManager.ExecuteDataTable("Report_GetPartiesVotes", parm);
            if (dt.Rows.Count > 0)
            {
                //Component Json Object
                JSONString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    JSONString.Append("\"");
                    JSONString.Append(dt.Rows[i]["PartyName"].ToString());
                    if (i == dt.Rows.Count - 1)
                    {
                        JSONString.Append("\"]- ");
                    }
                    else { JSONString.Append("\","); }

                }
                //----------------- END ---------------------//

                //Series Json Object  Patient Value & Target Value

                JSONString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    JSONString.Append(dt.Rows[i]["TotalVotes"].ToString());
                    if (i == dt.Rows.Count - 1)
                    {
                        JSONString.Append("] ");
                    }
                    else { JSONString.Append(","); }
                }                                
            }
        }
        catch (Exception e)
        {
        }
        return JSONString.ToString();
    }

   
}  