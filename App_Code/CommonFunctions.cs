using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public class CommonFunctions
{
    public CommonFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public DataTable GetParties()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter>{};
        return ObjDBManager.ExecuteDataTable("GetParties", parm);
    }
    public DataTable GetProvince()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetProvince", parm);
    }
    public DataTable GetDivisions(string provinceid)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@ProvinceId",provinceid)
        };
        return ObjDBManager.ExecuteDataTable("GetDivisions", parm);
    }
    public DataTable GetDistrictByDivisions(string divisionId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@DivisionId",divisionId)
        };
        return ObjDBManager.ExecuteDataTable("GetDistrictByDivisions", parm);
    }
    //public DataTable GetDistrict(string provinceid)
    //{
    //    DBManager ObjDBManager = new DBManager();
    //    List<SqlParameter> parm = new List<SqlParameter> {
    //        new SqlParameter("@ProvinceId",provinceid)
    //    };
    //    return ObjDBManager.ExecuteDataTable("GetDistrict", parm);
    //}

    public DataTable GetNA(string DistrictId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@DistrictId",DistrictId)
        };
        return ObjDBManager.ExecuteDataTable("GetNa", parm);
    }
    public DataTable GetPA(string NAId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@NAId",NAId)
        };
        return ObjDBManager.ExecuteDataTable("GetPA", parm);
    }
    public DataTable GetPartyCatdidate(string partyId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@PartyId",partyId)
        };
        return ObjDBManager.ExecuteDataTable("GetPartyCandidate", parm);
    }
    public DataTable GetPartyCandidateNotRegisteredForElection(string partyId,string electionId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@PartyId",partyId),
            new SqlParameter("@ElectionId",electionId)
        };
        return ObjDBManager.ExecuteDataTable("GetPartyCandidateNotRegisteredForElection", parm);
    }
    public DataTable GetelectionYear()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetElectionYear", parm);
    }
    public DataTable GetLBelectionYear()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetLBElectionYear", parm);
    }
    public DataTable GetLModule()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetModule", parm);
    }
    public DataTable GetUsers()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("GetUsers", parm);
    }

    public DataTable GetPages(string Module_ID)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {new SqlParameter("@Module_ID", Module_ID) };
        return ObjDBManager.ExecuteDataTable("SelectModulePages", parm);
    }
    public DataTable GetPAByDistrict(string DistrictId)
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> {
            new SqlParameter("@DistrictId",DistrictId)
        };
        return ObjDBManager.ExecuteDataTable("GetPAByDistrict", parm);
    }
    public DataTable GetCast()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("uspGetCast", parm);
    }

    public DataTable GetSectrain()
    {
        DBManager ObjDBManager = new DBManager();
        List<SqlParameter> parm = new List<SqlParameter> { };
        return ObjDBManager.ExecuteDataTable("uspGetSectrain", parm);
    }

}