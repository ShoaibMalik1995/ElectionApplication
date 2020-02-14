<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="PdfToImageConverter.aspx.cs" Inherits="Admin_PdfToImageConverter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>PDF Document Convert to Image
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    <table class="table-form">
        <tr>
            <td class="label" style="width: 10%;">PDF to Image:</td>
            <td style="width: 20%;">
               <asp:FileUpload ID="FileUpload1" runat="server" /> 
                
            </td>
         </tr>

        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnPDFToImage" runat="server" Text="Convert Pdf into Images" OnClick="btnPDFToImage_Click" />
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
       
               
    </table>
</asp:Content>

