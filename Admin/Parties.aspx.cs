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


public partial class Admin_Parties : System.Web.UI.Page
{
    String _str = ConfigurationManager.ConnectionStrings["ElecConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillGridView();
        }

    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(_str);

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertElectionParties", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyName", txtPartyName.Text.Trim());
            cmd.Parameters.AddWithValue("@Chairmain", TxtChairman.Text.Trim());
            cmd.Parameters.AddWithValue("@RegistrationDate", txtRegistrationDate.Text.Trim());
            cmd.Parameters.AddWithValue("@PartyNo", txtRegNo.Text.Trim());
            cmd.Parameters.AddWithValue("@PartyOff", Partyoff.Text.Trim());

            if (picUpload.HasFile)
            {
                cmd.Parameters.AddWithValue("@file", picUpload.FileBytes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@file", DBNull.Value);
            }

            
            cmd.ExecuteNonQuery();
            con.Close();

            LblMeg.Text = "Save Successfully";
            FillGridView();
            txtPartyName.Text = "";
            TxtChairman.Text = "";
            txtRegistrationDate.Text = "";
            txtRegNo.Text = "";
            Partyoff.Text = "";
            

        }

        catch (Exception ex)
        {


        }
        finally
        {
            con.Close();
        }
    }
    protected void deleteRecord(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        SqlConnection con = new SqlConnection(_str);
        con.Open();
        
        SqlCommand cmd = new SqlCommand("usp_deletePartiesRecord", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Partyid", btn.CommandName);
        cmd.ExecuteNonQuery();
        FillGridView();
        con.Close();
    }
    private void FillGridView()
    {
        using (SqlConnection connection = new SqlConnection(_str))
        {
            SqlCommand command = new SqlCommand("Select_Parties", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(_str);
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_UpdateParties", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PartyName", txtPartyName.Text);
        cmd.Parameters.AddWithValue("@Chairmain", TxtChairman.Text);
        cmd.Parameters.AddWithValue("@RegistrationDate", txtRegistrationDate.Text);
        cmd.Parameters.AddWithValue("@PartyNo", txtRegNo.Text);
        cmd.Parameters.AddWithValue("@PartyOff", Partyoff.Text);

        cmd.Parameters.AddWithValue("@Partyid", hdID.Value);

        if (picUpload.HasFile)
        {
            byte[] imgByteOne = picUpload.FileBytes;
            cmd.Parameters.AddWithValue("@file", imgByteOne);
        }
        else
        {
            cmd.Parameters.Add("@file", SqlDbType.VarBinary, -1);
            cmd.Parameters["@file"].Value = DBNull.Value;
        }
       

        cmd.ExecuteNonQuery();
        btn_save.Visible = true;
        btnUpdate.Visible = false;
        FillGridView();
        ClearField();
        con.Close();

    }
    void ClearField()
    {

        txtPartyName.Text = string.Empty;
        TxtChairman.Text = string.Empty;
        txtRegistrationDate.Text = string.Empty;
        txtRegNo.Text = string.Empty;
        Partyoff.Text = string.Empty;


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (DataControlRowType.DataRow == e.Row.RowType)
        {
            HiddenField PK = e.Row.FindControl("hfvalue") as HiddenField;
            Image img1 = e.Row.FindControl("lblLogo") as Image;
          

            SqlConnection con = new SqlConnection(_str);
            con.Open();

            SqlCommand cmd = new SqlCommand("select Logo  from Parties where Partyid=" + PK.Value + "", con);
            cmd.CommandType = CommandType.Text;


            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                if (!Convert.IsDBNull(reader["Logo"]))
                {
                    byte[] byt = (byte[])reader["Logo"];
                    string imageString1 = Convert.ToBase64String(byt);
                    img1.ImageUrl = "data:Image/png;base64," + imageString1;
                }
               


            }

            con.Close();
        }
        

    }


    protected void lnkbtnedit_Click(object sender, EventArgs e)
    {
        LinkButton lnkBTN = sender as LinkButton;
        try
        {
            SqlConnection con = new SqlConnection(_str);
            con.Open();
            btn_save.Visible = false;
            btnUpdate.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from Parties where Partyid=" + lnkBTN.CommandName + "", con);
            cmd.CommandType = CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    txtPartyName.Text = rdr["PartyName"].ToString();
                    TxtChairman.Text = rdr["Chairmain"].ToString();
                    txtRegistrationDate.Text = Convert.ToDateTime(rdr["RegistrationDate"]).ToString("MM/dd//yyyy");
                    txtRegNo.Text = rdr["PartyNo"].ToString();
                    Partyoff.Text = rdr["PartyOff"].ToString();
                    
                    hdID.Value = lnkBTN.CommandName;
                }
            }

        }
        catch (Exception)
        {

           
        }
    }
}