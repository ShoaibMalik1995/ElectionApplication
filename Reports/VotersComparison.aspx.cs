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

public partial class Reports_VotersComparison : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
  

    [WebMethod]
    public static string GetData()
    {
        DataSet ds = new DataSet();
        var JSONString = new StringBuilder();
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {             
            };
            ds = ObjDBManager.ExecuteDataSet("Report_GetVotersComparison", parm);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //Component Json Object
                JSONString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    JSONString.Append("\"");
                    JSONString.Append(ds.Tables[0].Rows[i]["ProvinceName"].ToString());
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JSONString.Append("\"]- ");
                    }
                    else { JSONString.Append("\","); }

                }
                //----------------- END ---------------------//
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {

                    }
                }

                    // Voters Female
                //    JSONString.Append("[");                
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    JSONString.Append("\"");
                //    JSONString.Append(dt.Rows[i]["Voters"].ToString());
                //    if (i == dt.Rows.Count - 1)
                //    {
                //        JSONString.Append("\"]- ");
                //    }
                //    else { JSONString.Append("\","); }
                //}
                
            }
        }
        catch (Exception e)
        {
        }
        return JSONString.ToString();
    }

   
}  