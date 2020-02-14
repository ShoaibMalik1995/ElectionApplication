using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;



public partial class Admin_ChangePassword : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["UserID"] == null))
        {
            Response.Redirect("Login.aspx");
        }
        SqlConnection conn = new SqlConnection();
        SqlCommand con;
        SqlDataReader reader;
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
        conn.Open();
        con = conn.CreateCommand();
        con.CommandText = ("SELECT UserName FROM Login WHERE (UserID = " + (Session["UserID"].ToString() + ")"));
        reader = con.ExecuteReader();
        if (reader.Read())
        {
            Label_user_name.Text = reader["UserName"].ToString();
        }

        reader.Close();
        conn.Close();

    }


    protected void Button_Change_Password_Click(object sender, EventArgs e)
    {

        if ((TextBox_new_passward.Text == TextBox_confirm_new_passward.Text))
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand con = new SqlCommand();
            SqlDataReader reader;
            string pass = "";
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
            conn.Open();
            con = conn.CreateCommand();
            con.CommandText = ("SELECT Password FROM Login WHERE (UserID = " + (Session["UserID"].ToString() + ")"));
            reader = con.ExecuteReader();
            if (reader.Read())
            {
                pass = reader["Password"].ToString();
            }

            reader.Close();
            conn.Close();
            if (TextBox_old_passward.Text == pass.ToString())
            {
                HiddenField_NewPass.Value = TextBox_confirm_new_passward.Text.ToString();
                SqlDataSource1.Update();
                Label_Note.Text = "Password Changed Successfuly";
            }
            else
            {
                Label_Note.Text = "Enter Correct Old Password";
            }

        }
        else
        {
            Label_Note.Text = "New Password and confirm Passward are not Same";
        }

    }
}
