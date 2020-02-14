<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="FafenSummaryReport.aspx.cs" Inherits="Reports_FafenSummaryReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Fafen / Other Analysis
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">
        <tr>
            <td class="label" style="width: 40%;">Type:</td>
            <td style="width: 20%;">
                <asp:RadioButtonList ID="RBType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Fafen" Value="Fafen" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Pildot" Value="Pildot"></asp:ListItem>
                    <asp:ListItem Text="BBC" Value="BBC"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="text-align:center">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
       
    </table>
    <hr />
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" Height="900px" ShowBackButton="False" ShowExportControls="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False">
        </rsweb:ReportViewer>

    </div>
</asp:Content>


