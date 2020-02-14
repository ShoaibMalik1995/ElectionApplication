using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;

public partial class Candidates_AddCandidates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CommonFunctions objCommonFunctions = new CommonFunctions();
            ddlParty.DataSource = objCommonFunctions.GetParties();

            ddlParty.DataTextField = "PartyName";
            ddlParty.DataValueField = "Partyid";
            ddlParty.DataBind();


            string candId = Request.QueryString["CandId"];
            if (!string.IsNullOrEmpty(candId))
            {
                GetCandidateInfo(candId);
            }
        }
    }
    protected void GetCandidateInfo(string candId)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",candId)                
            };
            DataTable dt = ObjDBManager.ExecuteDataTable("GetCandidateInfo", parm);            
            if(dt.Rows.Count>0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtNic.Text = dt.Rows[0]["NIC"].ToString();
                ddlParty.SelectedValue = dt.Rows[0]["PartyId"].ToString();

                byte[] b = (byte[])dt.Rows[0]["Picture"];
                string base64 = Convert.ToBase64String(b);
                candPic.ImageUrl = "data:Image/png;base64," + base64;

                txtEdu.Text = dt.Rows[0]["Education"].ToString();
                txtPresentAdd.Text = dt.Rows[0]["PresentAddress"].ToString();
                txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                
                hdnNadraVerises.Value = dt.Rows[0]["NadraVerises"].ToString();
                chkVoteForUs.Checked=bool.Parse(dt.Rows[0]["VoteForUs"].ToString());
                chkLikeMinded.Checked = bool.Parse(dt.Rows[0]["LikeMinded"].ToString());

                rdoGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                txtPersonalPhone.Text = dt.Rows[0]["PersonalPhone"].ToString();
                txtConfidentPhone.Text = dt.Rows[0]["ConfidentialPhone"].ToString();

                txtPastAffiliation.Text= dt.Rows[0]["PastAffiliation"].ToString();
                txtCurrentAffiliation.Text= dt.Rows[0]["CurrentAffiliation"].ToString();
                txtChangingAffiliation.Text= dt.Rows[0]["ChangingAffiliation"].ToString();

                txtRWM.Text = dt.Rows[0]["RelationWithMilitary"].ToString();
                txtRWB.Text = dt.Rows[0]["RelationWithBureaucracy"].ToString();
                txtRWJ.Text = dt.Rows[0]["RelationWithJudiciary"].ToString();
                txtRWP.Text = dt.Rows[0]["RelationWithPolitics"].ToString();

                txtMC.Text = dt.Rows[0]["MoralCharacteristics"].ToString();
                txtFC.Text = dt.Rows[0]["FinancialCharacteristics"].ToString();

                txtVAE.Text = dt.Rows[0]["ViewsAboutEstablishment"].ToString();
                txtImpApp.Text = dt.Rows[0]["ImpotantAppoinments"].ToString();
                txtScandles.Text = dt.Rows[0]["InvolvedScandals"].ToString();                
                txtObservations.Text = dt.Rows[0]["OtherObservations"].ToString();                
                hdnCandidateId.Value= candId;
            }
        }
        catch
        {
            ;      
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        byte[] b=null;
        if (picUpload.HasFile)
        {
            b = picUpload.FileBytes;
        }   
        else
        {
            if (candPic.ImageUrl.Contains("dumy"))
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/images/dumy.png"));
                b = imgToByteArray(img);
            }
            else
            {
                b =Convert.FromBase64String(candPic.ImageUrl.Replace("data:Image/png;base64,", ""));                        
            }
        }

        byte[] nadraVerises = null;
        if (fileNadraVerises.HasFile)
        {
            nadraVerises = fileNadraVerises.FileBytes;
        }     
        else
        {
            nadraVerises = Encoding.ASCII.GetBytes(hdnNadraVerises.Value);            
        }   
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@CandidateId",hdnCandidateId.Value),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@NIC",txtNic.Text),
            new SqlParameter("@PartyId",ddlParty.SelectedValue),
            new SqlParameter("@Picture",b),
            new SqlParameter("@Education",txtEdu.Text),
            new SqlParameter("@PresentAddress",txtPresentAdd.Text),
            new SqlParameter("@PermanentAddress",txtPermanentAddress.Text),
            new SqlParameter("@NadraVerises",nadraVerises),
            new SqlParameter("@PersonalPhone",txtPersonalPhone.Text),
            new SqlParameter("@ConfidentialPhone",txtConfidentPhone.Text),
            new SqlParameter("@Gender",rdoGender.SelectedValue),

            new SqlParameter("@PastAffiliation",txtPastAffiliation.Text),
            new SqlParameter("@CurrentAffiliation",txtCurrentAffiliation.Text),
            new SqlParameter("@ChangingAffiliation",txtChangingAffiliation.Text),

            new SqlParameter("@RelationWithJudiciary",txtRWJ.Text),
            new SqlParameter("@RelationWithMilitary",txtRWM.Text),
            new SqlParameter("@RelationWithPolitics",txtRWP.Text),
            new SqlParameter("@RelationWithBureaucracy",txtRWB.Text),

            new SqlParameter("@ImpotantAppoinments",txtImpApp.Text),
            new SqlParameter("@InvolvedScandals",txtScandles.Text),
            new SqlParameter("@ViewsAboutEstablishment",txtVAE.Text),

            new SqlParameter("@MoralCharacteristics",txtMC.Text),
            new SqlParameter("@FinancialCharacteristics",txtFC.Text),
            new SqlParameter("@OtherObservations",txtObservations.Text),

            new SqlParameter("@VoteForUs",chkVoteForUs.Checked),
            new SqlParameter("@LikeMinded",chkLikeMinded.Checked),

            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

        };
            ObjDBManager.ExecuteNonQuery("AddCandidate", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");
            ClearFields();
        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
            
        }
    }
    public byte[] imgToByteArray(System.Drawing.Image img)
    {
        using (MemoryStream mStream = new MemoryStream())
        {
            img.Save(mStream, img.RawFormat);
            return mStream.ToArray();
        }
    }
    protected void ClearFields()
    {
        hdnCandidateId.Value = "0";
        txtName.Text = "";
        txtNic.Text = "";
        txtEdu.Text = "";
        txtPresentAdd.Text = "";
        txtPermanentAddress.Text = "";
        ddlParty.SelectedIndex = 0;

        txtPastAffiliation.Text = "";
        txtCurrentAffiliation.Text = "";
        txtChangingAffiliation.Text = "";

        txtPersonalPhone.Text = "";
        txtConfidentPhone.Text = "";

        chkVoteForUs.Checked = false;
        chkLikeMinded.Checked = false;

        txtRWJ.Text = "";
        txtRWM.Text = "";
        txtRWP.Text = "";
        txtRWB.Text = "";
        txtImpApp.Text = "";
        txtScandles.Text = "";
        txtVAE.Text = "";
        txtMC.Text = "";
        txtFC.Text = "";
        txtObservations.Text = "";
        candPic.ImageUrl = "~/images/dumy.png";

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
}