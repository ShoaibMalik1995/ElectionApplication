using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
public partial class Elections_ConstituencyMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
   
    [WebMethod]
    public static List<MapProperties> GetMapData(string Type)
    {        
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>
            {                
                new SqlParameter("@Type",Type)
            };

        DataTable dt= ObjDBManager.ExecuteDataTable("GetMapData", parm);

        List<MapProperties> list = new List<MapProperties>();


        for (int b=0;b<dt.Rows.Count;b++)
        {
            MapProperties objMapProperties = new MapProperties();
            objMapProperties.Id = dt.Rows[b]["Id"].ToString();
            objMapProperties.Name = dt.Rows[b]["Name"].ToString();
            objMapProperties.CandidateName = dt.Rows[b]["CandidateName"].ToString();

            byte[] byt = new byte[0];
            string base64 = ""; 
            if (!string.IsNullOrEmpty(dt.Rows[b]["Picture"].ToString()))
            {
                byt = (byte[])dt.Rows[b]["Picture"];
                base64 = Convert.ToBase64String(byt);                
                //WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            objMapProperties.Picture = base64;
            objMapProperties.Category = dt.Rows[b]["Category"].ToString();
            objMapProperties.Latitude = dt.Rows[b]["Latitude"].ToString();
            objMapProperties.Longitude = dt.Rows[b]["Longitude"].ToString();
            list.Add(objMapProperties);
        }
        return list;

    }
}
public class MapProperties
{
    public string Id {get;set;}
    public string Name { get; set; }
    public string CandidateName { get; set; }
    public string Picture { get; set; }
    public string Category { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

}