<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddFafenAnalysis.aspx.cs" Inherits="Election_AddFafenAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Add Fafen Analysis
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">

        <tr>
            <td class="label" style="width: 10%;">Year:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td class="label" style="width: 10%;">District:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>

             <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" OnSelectedIndexChanged="ddlNA_SelectedIndexChanged" runat="server" ></asp:DropDownList>
            </td>           
        </tr>      
         <tr>
             
             <td class="label" style="width: 10%;">Fafen Analysis:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtFafenAnalysis" runat="server" style="height:100px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>

        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="Btn_Save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click"  />

            </td>
        </tr>

    </table>
  <asp:hiddenfield id="hdfFefenid" runat="server" value="0"></asp:hiddenfield>
</asp:Content>

