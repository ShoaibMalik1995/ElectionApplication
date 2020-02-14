using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

public partial class Reports_FifenSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            DBManager ObjDBManager = new DBManager();
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>
            {
                new SqlParameter("@NAId",Request.QueryString["NAId"]),
                new SqlParameter("@PAId",Request.QueryString["PAId"]),
                new SqlParameter("@Type",Request.QueryString["Type"])
            };
                DataSet ds = ObjDBManager.ExecuteDataSet("GetLastFifenResults1", parm);
                grdWinningCandidates.DataSource = ds.Tables[0];
                grdWinningCandidates.DataBind();

               
            }
            catch(Exception exp)
            {
            }
        }
    }
    protected void grdWinningCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
   {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            byte[] b =new byte[0];
            string base64 = ""; Image WinnerPic;
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            if (!string.IsNullOrEmpty(rowView["Winner1Picture"].ToString()))
            {
                b = (byte[])rowView["Winner1Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner1Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }
            if (!string.IsNullOrEmpty(rowView["Winner1PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner1PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo1");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner2Picture"].ToString()))
            {
                b = (byte[])rowView["Winner2Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner2Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner2PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner2PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo2");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner3Picture"].ToString()))
            {
                b = (byte[])rowView["Winner3Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner3Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner3PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner3PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo3");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner4Picture"].ToString()))
            {
                b = (byte[])rowView["Winner4Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner4Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner4PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner4PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo4");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }

            if (!string.IsNullOrEmpty(rowView["Winner5Picture"].ToString()))
            {
                b = (byte[])rowView["Winner5Picture"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("Winner5Pic");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }
            if (!string.IsNullOrEmpty(rowView["Winner5PartyLogo"].ToString()))
            {
                b = (byte[])rowView["Winner5PartyLogo"];
                base64 = Convert.ToBase64String(b);
                WinnerPic = (Image)e.Row.FindControl("imgPartyLogo5");
                WinnerPic.ImageUrl = "data:Image/png;base64," + base64;
            }
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    System.Web.UI.WebControls.Image img = e.Row.FindControl("Winner1Pic") as System.Web.UI.WebControls.Image;
        //    string path = Server.MapPath(img.AlternateText);

        //    img.ImageUrl = GenerateThumbnail(path);
        //}
     }
    private string GenerateThumbnail(string path)
    {

        System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        using (System.Drawing.Image thumbnail = image.GetThumbnailImage(100, 100, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                thumbnail.Save(memoryStream, ImageFormat.Png);
                Byte[] bytes = new Byte[memoryStream.Length];
                memoryStream.Position = 0;
                memoryStream.Read(bytes, 0, (int)bytes.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                return "data:image/png;base64," + base64String;

            }
        }
    }
    public bool ThumbnailCallback()
    {
        return false;
    }
}
        