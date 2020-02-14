using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Candidates_Businesses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetBusinesses();
        lblMsg.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBManager ObjDBManager = new DBManager();
        try
        {

            List<SqlParameter> parm = new List<SqlParameter>
            {
            new SqlParameter("@BusinessId",hdnBusinessId.Value),
            new SqlParameter("@CandidateId",Request.QueryString["CandId"]),
            new SqlParameter("@BusinessType",txtBusinessType.Text),
            new SqlParameter("@Name",txtName.Text),
            new SqlParameter("@Type",rdoType.SelectedItem.Text),            
            new SqlParameter("@CreatedBy",Session["UserId"]),
            new SqlParameter("@CreatedDate",DateTime.Now)

        };
            ObjDBManager.ExecuteNonQuery("BusinessesAdd", parm);
            lblMsg.Text = "Saved successfully!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "success");

            txtName.Text = "";
            txtBusinessType.Text = "";
            rdoType.SelectedIndex = 0;
            hdnBusinessId.Value = "0";

        }
        catch (Exception ex)
        {
            lblMsg.Text = "some error occurred!";
            lblMsg.Attributes.Remove("class");
            lblMsg.Attributes.Add("class", "error");
        }
        GetBusinesses();

        divBusiness.Style.Add(HtmlTextWriterStyle.Display, "block");
        formBusiness.Style.Add(HtmlTextWriterStyle.Display, "none");

    }
    protected void GetBusinesses()
    {
        DBManager ObjDBManager = new DBManager();
        try
        {
            List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@CandidateId",Request.QueryString["CandId"])
            };
            grdBusiness.DataSource = ObjDBManager.ExecuteDataTable("GetCandidateBusinesses", parm);
            grdBusiness.DataBind();
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
                txtBusinessType.Text = ((Label)row.FindControl("lblBusinessType") as Label).Text;
                rdoType.Text = ((Label)row.FindControl("lblType") as Label).Text.Trim();
                
                hdnBusinessId.Value = lb.CommandArgument;

                divBusiness.Style.Add(HtmlTextWriterStyle.Display, "none");
                formBusiness.Style.Add(HtmlTextWriterStyle.Display, "table");

                lblMsg.Text = "";
            }

        }
        catch
        {
            ;
        }
    }
}