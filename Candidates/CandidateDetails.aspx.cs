using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class Candidates_CandidateDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCandidateInfo();
    }
    protected void GetCandidateInfo()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",Request.QueryString["CandId"])
            };
            DataSet ds = ObjDBManager.ExecuteDataSet("GetCandidateDetails", parm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lblNic.Text = ds.Tables[0].Rows[0]["NIC"].ToString();
                lblParty.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                lblEdu.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                lblRWM.Text = ds.Tables[0].Rows[0]["RelationWithMilitary"].ToString();
                lblRWB.Text = ds.Tables[0].Rows[0]["RelationWithBureaucracy"].ToString();
                lblRWJ.Text = ds.Tables[0].Rows[0]["RelationWithJudiciary"].ToString();
                lblRWP.Text = ds.Tables[0].Rows[0]["RelationWithPolitics"].ToString();
                lblMC.Text = ds.Tables[0].Rows[0]["MoralCharacteristics"].ToString();
                lblFC.Text = ds.Tables[0].Rows[0]["FinancialCharacteristics"].ToString();
                lblVAE.Text = ds.Tables[0].Rows[0]["ViewsAboutEstablishment"].ToString();
                lblImpApp.Text = ds.Tables[0].Rows[0]["ImpotantAppoinments"].ToString();
                lblScandles.Text = ds.Tables[0].Rows[0]["InvolvedScandals"].ToString();
                lblPresentAdd.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                lblPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                lblObservations.Text = ds.Tables[0].Rows[0]["OtherObservations"].ToString();

                byte[] b = (byte[])ds.Tables[0].Rows[0]["Picture"];
                string base64 = Convert.ToBase64String(b);
                candPic.ImageUrl = "data:Image/png;base64," + base64;

            }

            grdFather.DataSource = ds.Tables[1];
            grdFather.DataBind();

            grdSpouse.DataSource = ds.Tables[2];
            grdSpouse.DataBind();

            grdBusiness.DataSource = ds.Tables[3];
            grdBusiness.DataBind();


            grdCookGuard.DataSource = ds.Tables[4];
            grdCookGuard.DataBind();
        }
        catch
        {
            ;
        }
    }

}