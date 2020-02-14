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

public partial class Reports_ElectionWinerGraph : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetYears();
            GetProvince();
            ddlProvince.SelectedValue = "4";
            ddlProvince.Enabled = false;
            GetDistrict();
            GetNA();
            GetPA();            
            if(Request.QueryString["ElecnId"] !=null)
            {
                ddlYear.SelectedValue = Request.QueryString["ElecnId"];
            }
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
    protected void GetPA()
    {
        CommonFunctions objCommonFunctionsGetNA = new CommonFunctions();
        ddlPA.DataSource = objCommonFunctionsGetNA.GetPA(ddlNA.SelectedValue);

        ddlPA.DataTextField = "Name";
        ddlPA.DataValueField = "PAId";
        ddlPA.DataBind();
    }

    [WebMethod]
    public static string GetData(string electionId,string naId,string paId,string type)
    {
        DataTable dt = new DataTable();
        var JSONString = new StringBuilder();
        try
        {
            DBManager ObjDBManager = new DBManager();
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@ElectionId",electionId),
                new SqlParameter("@NAId",naId),
                new SqlParameter("@PAId",paId),
                new SqlParameter("@Type",type)
            };
            dt = ObjDBManager.ExecuteDataTable("GetElectionWinner", parm);
            if (dt.Rows.Count > 0)
            {
                //Component Json Object
                JSONString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    JSONString.Append("\"");
                    JSONString.Append(dt.Rows[i]["Candidate"].ToString());
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

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDistrict();
        GetNA();        
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNA();        
    }


    protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoType.SelectedValue == "NA")
        {
            GetNA();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "none");            
        }
        else
        {
            GetPA();
            tdPA1.Style.Add(HtmlTextWriterStyle.Display, "contents");
            tdPA2.Style.Add(HtmlTextWriterStyle.Display, "contents");            
        }
    }
    protected void ddlNA_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPA();
    }
}  