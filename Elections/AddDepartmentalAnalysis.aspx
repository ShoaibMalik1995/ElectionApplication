<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddDepartmentalAnalysis.aspx.cs" Inherits="Election_AddDepartmentalAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Add Departmental Analysis
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">

        <tr>
            <td class="label" style="width: 10%;">Year:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>


            <td class="label" style="width: 10%;">Division:</td>

            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDivisions" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged">
                </asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td class="label" style="width: 10%;">District:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>

            <td class="label">Select Type :</td>
            <td>
                <asp:RadioButtonList ID="rdoType" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoType_SelectedIndexChanged">
                    <asp:ListItem Text="NA" Value="NA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                </asp:RadioButtonList>
            </td>

        </tr>

        <tr>

            <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNA_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" id="tdPA1" runat="server" style="display: none;">PA:</td>
            <td id="tdPA2" runat="server" style="display: none;">
                <asp:DropDownList ID="ddlPA" runat="server"></asp:DropDownList>
            </td>

        </tr>
       

      

    </table>


    <div runat="server" id="Subsector">
          <table class="table-form">
               <tr>
            <td colspan="4">
                <h2>HQ Remarks :</h2>
            </td>
        </tr>
                  </table>
          <div style="  height: 90px; width:600px;
  line-height: 90px;
  text-align: center;
  border: 2px #f69c55;">
            
              <%--<asp:Label ID="lblHQRemarks" runat="server" Font-Size="Medium" Font-Bold="true" Text="HQ Remarks :"></asp:Label>--%>
              
             </div>
    <table>

          <tr id="OcSubSector">
             
             <td class="label" style="width: 10%;">Analysis:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtboxOCsubAnalysis" runat="server" TextMode="MultiLine" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>
        </table>
     
    <table>
        <tr id="OcDividsonalSubSector">
             
             <td class="label" style="width: 10%;">Remarks:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtboxOCsubRemarks" runat="server" TextMode="MultiLine" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>

          </table>
        </div>
    
         <div id="GeneralSubsector" runat="server">
       
            <table class="table-form">
               <tr>
            <td colspan="4">
                <h2>DIV Remarks :</h2>
            </td>
        </tr>
                  </table>
             <div style="  height: 90px; width:600px;
  line-height: 90px;
  text-align: center;
  border: 2px #f69c55;">
              <%--<asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Bold="true" Text="DIV Remarks :"></asp:Label>--%>
        
         
             </div>
    <table>
          
          <tr>
             
             <td class="label" style="width: 10%;">Analysis:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="DivsnalSubsectorAna" runat="server" TextMode="MultiLine" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>
          </table>
     
    <table>
        <tr>
             
             <td class="label" style="width: 10%;">Remarks:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="DivsnalSubsectorRemarks" runat="server" TextMode="MultiLine" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>
          </table>
        </div>
         <div  runat="server" id="DivsnalSubsector">
          <table class="table-form">
               <tr>
            <td colspan="4">
                <h2>OC Remarks :</h2>
            </td>
        </tr>
                  </table>
                <div style="  height: 90px; width:600px;
  line-height: 90px;
  text-align: center;
  border: 2px #f69c55;">
                    
              <%--<asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Bold="true" Text="OC Remarks :"></asp:Label>--%>
        
             </div>
    <table>
          <tr id="GeneralSubSector">
             
             <td class="label" style="width: 10%;">Analysis:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtbxGenSubsector" runat="server" TextMode="MultiLine" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>

          </table>
       
    <table>
        <tr>
             
             <td class="label" style="width: 10%;">Remarks:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtbxGenSubsectorRemarks" runat="server" TextMode="MultiLine" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>
          </table>
        </div>

         <div>
    <table>
       
        <tr>
            <td  style="width: 90%;"></td>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="Button1" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click"  />

            </td>
        </tr>

    </table>
             </div>
</asp:Content>

