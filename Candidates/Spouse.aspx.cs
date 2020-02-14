using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Candidates_Spouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetSpouseInfo();
        lblMsg.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@SpouseId",hdnSpouseId.Value),
            new SqlParameter("@CandidateId",Request.QueryString["CandId"]),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@NIC",txtNic.Text),
            new SqlParameter("@Phone",txtPhone.Text),
            new SqlParameter("@PoliticalRelation",txtPoliticalRelation.Text),
            new SqlParameter("@OtherAffiliations",txtOtherAffiliations.Text),
            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

        };
            ObjDBManager.ExecuteNonQuery("SpouseAdd", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");

            txtName.Text = "";
            txtNic.Text = "";
            txtPoliticalRelation.Text = "";
            txtOtherAffiliations.Text = "";
            txtPhone.Text = "";
            hdnSpouseId.Value = "0";

        }
        catch (Exception)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
        GetSpouseInfo();

        divSpouse.Style.Add(HtmlTextWriterStyle.Display, "block");
        formSpouse.Style.Add(HtmlTextWriterStyle.Display, "none");

    }
    protected void GetSpouseInfo()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",Request.QueryString["CandId"])
            };
            grdSpouse.DataSource = ObjDBManager.ExecuteDataTable("GetCandidateSpouse", parm);
            grdSpouse.DataBind();
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
                txtPhone.Text = ((Label)row.FindControl("lblPhone") as Label).Text;
                txtPoliticalRelation.Text = ((Label)row.FindControl("lblPoliticalRelation") as Label).Text;
                txtOtherAffiliations.Text = ((Label)row.FindControl("lblOtherAffiliations") as Label).Text;

                hdnSpouseId.Value = lb.CommandArgument;

                divSpouse.Style.Add(HtmlTextWriterStyle.Display, "none");
                formSpouse.Style.Add(HtmlTextWriterStyle.Display, "table");

                lblMsg.Text = "";
            }

        }
        catch
        {
            ;
        }
    }
}