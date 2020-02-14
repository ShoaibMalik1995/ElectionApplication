using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Candidates_Children : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetChildrenInfo();
        lblMsg.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@Childid",hdnChildId.Value),
            new SqlParameter("@CandidateId",Request.QueryString["CandId"]),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@Education",txtEducation.Text),
            new SqlParameter("@Gender",ddlGender.SelectedValue),
            new SqlParameter("@Age",txtAge.Text),
            new SqlParameter("@CurrentLocation",txtCurrentLocation.Text),
            new SqlParameter("@PoliticalAffiliation",txtPoliticalAffiliation.Text),
            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

        };
            ObjDBManager.ExecuteNonQuery("CandidateChildrenAdd", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");

            txtName.Text = "";
            txtEducation.Text = "";
            txtAge.Text = "";
            txtCurrentLocation.Text = "";
            txtPoliticalAffiliation.Text = "";

            hdnChildId.Value = "0";
            GetChildrenInfo();

            divChildren.Style.Add(HtmlTextWriterStyle.Display, "block");
            formChildren.Style.Add(HtmlTextWriterStyle.Display, "none");

        }
        catch (Exception exp)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
      
    }
    protected void GetChildrenInfo()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandId",Request.QueryString["CandId"])
            };
            grdChildren.DataSource = ObjDBManager.ExecuteDataTable("GetCandidateChildren", parm);
            grdChildren.DataBind();
        }
        catch(Exception exp)
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
                txtEducation.Text = ((Label)row.FindControl("lblEducation") as Label).Text;
                ddlGender.SelectedValue = ((Label)row.FindControl("lblGender") as Label).Text;
                txtAge.Text = ((Label)row.FindControl("lblAge") as Label).Text;
                txtCurrentLocation.Text = ((Label)row.FindControl("lblCurrentLocation") as Label).Text;
                txtPoliticalAffiliation.Text = ((Label)row.FindControl("lblPoliticalAffiliation") as Label).Text;

                hdnChildId.Value = lb.CommandArgument;

                divChildren.Style.Add(HtmlTextWriterStyle.Display, "none");
                formChildren.Style.Add(HtmlTextWriterStyle.Display, "table");

                lblMsg.Text = "";
            }
        }
        catch
        {
            ;
        }
    }
}