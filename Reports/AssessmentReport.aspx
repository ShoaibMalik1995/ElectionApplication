<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AssessmentReport.aspx.cs" Inherits="Reports_AssessmentReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Pic {
            border-radius: 50px;
            border: solid 1px #ccc;
            background-color: #ccc;
            width: 25px;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScrptMng" runat="server"></asp:ScriptManager>
    <h1>Election Assessment
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <%--Graphical Representation--%>
    <asp:DataList ID="dlData" runat="server" RepeatDirection="Horizontal" OnItemDataBound="ResultCharts_OnItemDataBound"
        RepeatColumns="5">
        <ItemTemplate>
            <asp:HiddenField ID="hfYear" runat="server" Value='<%# Bind("ElectionId") %>' />
            <table class="table-form" style="width: 100%">
                <tr>
                    <td style="padding:1px">
                        <asp:Chart ID="Chart1" runat="server" Height="340px" Width="320px">
                            <Series>
                                <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="True" Legend="Legend1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend BackColor="LightSkyBlue" Name="Legend1" Title="Candidates">
                                </asp:Legend>
                            </Legends>
                            <Titles>
                                <asp:Title BackColor="CornflowerBlue" BorderColor="AliceBlue" Font="Times New Roman, 12pt, style=Bold" Name="Candidates Winning Percentage" Text="Candidates Winning Percentage">
                                </asp:Title>
                            </Titles>
                        </asp:Chart>
                    </td>
                </tr>
                <tr>
                    <td style="padding:1px">
                        <asp:GridView ID="grdCandidates" ShowHeader="false" AutoGenerateColumns="false" runat="server" Width="100%" OnRowDataBound="grdCandidates_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("CandidateId", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'>
                                            <asp:Image runat="server" ID="CandidateImage" ImageUrl="~/images/dumy.png" CssClass="Pic" />
                                        </asp:HyperLink>
                                        <asp:Label ID="lblCandidateName" CssClass="cand-text" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                        <asp:Image runat="server" ID="imgPartyLogo1" ImageUrl="~/images/dumy.png" CssClass="Pic" />
                                        <asp:Label ID="lblVotePer" CssClass="cand-text" runat="server" Text='<%#Bind("Winning_Percentage") %>'></asp:Label>
                                        <asp:Label ID="lbl_Page" CssClass="cand-text" runat="server" Text="%"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <%--END--%>
</asp:Content>

