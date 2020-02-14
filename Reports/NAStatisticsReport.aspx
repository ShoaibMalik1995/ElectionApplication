<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="NAStatisticsReport.aspx.cs" Inherits="Reports_NAStatisticsReport" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScrptMng" runat="server" ></asp:ScriptManager>
    <h1>NA Statistics
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <asp:Panel ID="pnlParentResults" runat="server" ScrollBars="None" CssClass="ParentPanel" >
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="width:100%; overflow:hidden;"
                                Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Local" AsyncRendering="true" SizeToReportContent="true" ShowExportControls="False" ShowFindControls="False" ShowPrintButton="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowToolBar="False" >
                        </rsweb:ReportViewer>
                    </asp:Panel>
    
</asp:Content>

