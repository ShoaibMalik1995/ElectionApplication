using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using PdfToImage;

public partial class Admin_PdfToImageConverter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPDFToImage_Click(object sender, EventArgs e)
    {
        LblMeg.Text = "";
        try
        {
            if (FileUpload1.HasFile) {
                
                FileUpload1.SaveAs(Server.MapPath("~/PDFFiles/" + FileUpload1.FileName));
                string pdf_filename = Server.MapPath("~/PDFFiles/" + FileUpload1.FileName);
                string png_filename = Server.MapPath("~/ImageFiles/" + Path.GetFileNameWithoutExtension(FileUpload1.FileName)+".png");
                List<string> errors = cs_pdf_to_image.Pdf2Image.Convert(pdf_filename, png_filename);
                LblMeg.Text = "Convert Sucessfully";

            }

        }
        catch (Exception ex)
        {

        }
   

    }
}