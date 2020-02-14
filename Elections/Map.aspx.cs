using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
public partial class Elections_Map : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<MapData> GetMapData()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>{};

        DataSet ds = ObjDBManager.ExecuteDataSet("GetMapData", parm);

        List<MapData> listMapData = new List<MapData>();

        List<MapDivisions> listMapDivisions = new List<MapDivisions>();
        List<MapNA> listMapNA = new List<MapNA>();
        List<MapPA> listMapPA = new List<MapPA>();


        for (int b = 0; b < ds.Tables[0].Rows.Count; b++)
        {
            MapDivisions objMapDivisions = new MapDivisions();
            objMapDivisions.DivisionId = ds.Tables[0].Rows[b]["DivisionId"].ToString();
            objMapDivisions.Division = ds.Tables[0].Rows[b]["Name"].ToString();
            objMapDivisions.Latitude = ds.Tables[0].Rows[b]["Latitude"].ToString();
            objMapDivisions.Longitude = ds.Tables[0].Rows[b]["Longitude"].ToString();
            listMapDivisions.Add(objMapDivisions);
        }
        for (int b = 0; b < ds.Tables[1].Rows.Count; b++)
        {
            MapNA objMapNA = new MapNA();
            objMapNA.NAId = ds.Tables[1].Rows[b]["NAId"].ToString();
            objMapNA.DivisionId = ds.Tables[1].Rows[b]["DivisionId"].ToString();
            objMapNA.NAName = ds.Tables[1].Rows[b]["Name"].ToString();            
            listMapNA.Add(objMapNA);
        }
        for (int b = 0; b < ds.Tables[2].Rows.Count; b++)
        {
            MapPA objMapPA = new MapPA();
            objMapPA.NAId = ds.Tables[2].Rows[b]["NAId"].ToString();
            objMapPA.PAId = ds.Tables[2].Rows[b]["PAId"].ToString();
            objMapPA.PAName = ds.Tables[2].Rows[b]["Name"].ToString();
            listMapPA.Add(objMapPA);
        }

        MapData objMapData = new MapData();
        objMapData.listDivisions = listMapDivisions;
        objMapData.listNA = listMapNA;
        objMapData.listPA = listMapPA;

        listMapData.Add(objMapData);

        return listMapData;

    }
}
public class MapData
{
    public List<MapDivisions> listDivisions { get; set; }
    public List<MapNA> listNA { get; set; }
    public List<MapPA> listPA { get; set; }
}
    public class MapDivisions
{
    public string DivisionId { get; set; }
    public string Division { get; set; }    
    public string Latitude { get; set; }
    public string Longitude { get; set; }

}
public class MapNA
{
    public string NAId { get; set; }
    public string DivisionId { get; set; }
    public string NAName { get; set; }    

}
public class MapPA
{
    public string PAId { get; set; }
    public string NAId { get; set; }
    public string PAName { get; set; }
    
}