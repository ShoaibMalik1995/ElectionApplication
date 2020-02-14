using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Candidates_Father : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetFatherInfo();
        lblMsg.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@FatherId",hdnFatherId.Value),
            new SqlParameter("@CandidateId",Request.QueryString["CandId"]),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@NIC",txtNic.Text),
            new SqlParameter("@PoliticalRelation",txtPoliticalRelation.Text),
            new SqlParameter("@OtherAffiliations",txtOtherAffiliations.Text),
            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

        };
            ObjDBManager.ExecuteNonQuery("FatherAdd", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");

            txtName.Text = "";
            txtNic.Text = "";
            txtPoliticalRelation.Text = "";
            txtOtherAffiliations.Text = "";
            hdnFatherId.Value = "0";
            GetFatherInfo();

            divFather.Style.Add(HtmlTextWriterStyle.Display, "block");
            formFather.Style.Add(HtmlTextWriterStyle.Display, "none");

        }
        catch (Exception exp)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
      
    }
    protected void GetFatherInfo()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",Request.QueryString["CandId"])
            };
            grdFater.DataSource = ObjDBManager.ExecuteDataTable("GetCandidateFather", parm);
            grdFater.DataBind();
        }
        catch
        {
            ;
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                txtName.Text = ((Label)row.FindControl("lblName") as Label).Text;
                txtNic.Text = ((Label)row.FindControl("lblNIC") as Label).Text;
                txtPoliticalRelation.Text = ((Label)row.FindControl("lblPoliticalRelation") as Label).Text;
                txtOtherAffiliations.Text = ((Label)row.FindControl("lblOtherAffiliations") as Label).Text;

                hdnFatherId.Value = lb.CommandArgument;

                divFather.Style.Add(HtmlTextWriterStyle.Display, "none");
                formFather.Style.Add(HtmlTextWriterStyle.Display, "table");

                lblMsg.Text = "";
            }

        }
        catch
        {
            ;
        }
    }
}