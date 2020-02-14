<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddVideoAnalysis.aspx.cs" Inherits="Election_AddVideoAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>
        Add Video Analysis
     
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
       

         <tr style="display:none">
             
             <td class="label" style="width: 10%;">Constituency Analysis:</td>
            <td colspan="3" style="width: 20%;">
                <asp:TextBox ID="txtConstituencyAnalysis" runat="server" style="height: 72px !important;width: 96% !important;" ></asp:TextBox>
            </td>
             
            

        </tr>
         <tr >
            <td colspan="4" style="text-align: center;">
                

            </td>
        </tr>
        <tr >
            <td colspan="4" style="text-align: center;">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Btn_SaveVideo" Text="Upload" CssClass="btn" runat="server"  OnClick="Btn_SaveVideo_Click"  />

            </td>
        </tr>

    </table>
</asp:Content>

