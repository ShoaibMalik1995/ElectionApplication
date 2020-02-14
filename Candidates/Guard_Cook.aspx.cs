using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Candidates_Guard_Cook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCookGuradInfo();
        lblMsg.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@Id",hdnCoodGuardId.Value),
            new SqlParameter("@CandidateId",Request.QueryString["CandId"]),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@NIC",txtNic.Text),
            new SqlParameter("@Phone",txtPhone.Text),
            new SqlParameter("@Type",ddlType.SelectedValue),
            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

        };
            ObjDBManager.ExecuteNonQuery("Guard_CookAdd", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");

            txtName.Text = "";
            txtNic.Text = "";
            txtPhone.Text = "";
            hdnCoodGuardId.Value = "0";
            GetCookGuradInfo();

            divCookGuard.Style.Add(HtmlTextWriterStyle.Display, "block");
            formCookGuard.Style.Add(HtmlTextWriterStyle.Display, "none");

        }
        catch (Exception exp)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
      
    }
    protected void GetCookGuradInfo()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",Request.QueryString["CandId"])
            };
            grdCookGuard.DataSource = ObjDBManager.ExecuteDataTable("GetCandidateCookFather", parm);
            grdCookGuard.DataBind();
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
                ddlType.SelectedValue= ((Label)row.FindControl("lblType") as Label).Text;

                hdnCoodGuardId.Value = lb.CommandArgument;

                divCookGuard.Style.Add(HtmlTextWriterStyle.Display, "none");
                formCookGuard.Style.Add(HtmlTextWriterStyle.Display, "table");

                lblMsg.Text = "";
            }

        }
        catch
        {
            ;
        }
    }
}