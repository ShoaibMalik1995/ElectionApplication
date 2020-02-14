<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddImageAnalysis.aspx.cs" Inherits="Election_AddImageAnalysis" %>

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
                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
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
            <td class="label">Select Type :</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListImageType" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" >
                    <asp:ListItem Text="Fafen" Value="Fafen" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Pildot" Value="Pildot"></asp:ListItem>                    
                    <asp:ListItem Text="BBC" Value="BBC"></asp:ListItem>
                </asp:RadioButtonList>
            </td>

        </tr>
       

      

    </table>


     
   
    
  <div style="text-align: center; width: 50%; margin: 0 auto;">
                    <%--<img src="../images/dumy.png" runat="server" id="candPic"  class="picture" width="120" height="120" />--%>
      
                    <asp:Image runat="server" ID="candPic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="120" Height="120" Visible="false" />
                    <asp:FileUpload ID="picUpload" runat="server" />
                </div>
  

         <div>
    <table>
       
        <tr>
            <td  style="width: 90%;"></td>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="Button1" Text="Save" CssClass="btn" runat="server" OnClick="Button1_Click"  />

            </td>
        </tr>

    </table>
             </div>
</asp:Content>

