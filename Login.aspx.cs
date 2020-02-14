using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void loginbtn_Click(object sender, EventArgs e)
    {
        string Username = username.Text;
        string password = txtpassword.Text;

        String con = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
        SqlConnection sq = new SqlConnection(con);
        sq.Open();
        string querry = "select * from Login where Username='" + Username + "' and Password='" + password + "'";
        SqlDataAdapter adot = new SqlDataAdapter(querry, sq);
        DataTable dt = new DataTable();
        adot.Fill(dt);
        if(dt.Rows.Count>0)
        {
            
            lblMessage.Text="Success!";
            Session.Add("UserId", dt.Rows[0]["UserID"].ToString());
            Session.Add("UserType", dt.Rows[0]["UserType"].ToString());
            Response.Redirect("~/Admin/ElectionYears.aspx");
            
        }
        else
        {
            lblMessage.Text = "Failed! ";
            
        }
        
        sq.Close();

    }
}