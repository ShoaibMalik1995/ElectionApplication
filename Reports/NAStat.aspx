<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NAStat.aspx.cs" Inherits="Reports_NAStat" MasterPageFile="~/MainMaster.master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0,  
   Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>
        <asp:Label Text="" ID="lblTitle" runat="server" /> 
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <div style="width: 100%">
        <table style="width: 100%">
            <tr>
                <td>
                    <div style="width: 350px">
                        <table class="Polling Station">
                            <tr>
                                <td width="350" height="200" class="tdchart">
                                    <asp:Chart ID="ChartVoters" runat="server" Palette="BrightPastel" BackColor="#F3DFC1" Width="350" Height="200" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Registered Voters" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
                                        </Legends>
                                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                        <Series>
                                            <asp:Series Name="Series1" IsValueShownAsLabel="true" Font="Bold" BorderColor="180, 26, 59, 105">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
                                                <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                                </AxisX>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div style="width: 350px">

                        <table class="sampleTable">
                            <tr>
                                <td width="350" class="tdchart">
                                    <asp:Chart ID="PieChartPolling" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Height="200" Width="350" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Polling Stations" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
                                        </Legends>
                                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                        <Series>
                                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                                <AxisY2>
                                                    <MajorGrid Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisY2>
                                                <AxisX2>
                                                    <MajorGrid Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisX2>
                                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
                                                <AxisY LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisX>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div runat="server" title="MAP" style="float: right; background-color: #F3DFC1; width: 400px; height: 200px; border-style: solid; border-width: 2px; margin-right: 0px;">
                        <asp:ScriptManager runat="server" ID="MS1" />
                        <asp:LinkButton CommandArgument="0" ID="lnkPrevious" OnClick="lnkPrevious_Click" Style="float: left; font-weight: bold" Text="Previous" runat="server" />
                        <asp:LinkButton CommandArgument="0" ID="lnkNext" OnClick="lnkPrevious_Click" Style="float: right; font-weight: bold" Text="Next" runat="server" />
                        <asp:Image Width="400" Height="180px" ImageUrl="~/images/map.jpg" ID="MapImage" runat="server" />
                        <asp:GridView Visible="false" ID="GV_Maps" CssClass="table-bordered table-striped td-position" AutoGenerateColumns="false" runat="server" Width="400px">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SR#">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Container.DataItemIndex+1 %>' ID="lblID" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMap" runat="server" Text='<%#Bind("MapImage") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="width: 350px">
                        <table class="sampleTable">
                            <tr>
                                <td width="350" class="tdchart">
                                    <asp:Chart ID="ChartSectrain" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Height="200" Width="350" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Sectrain" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
                                        </Legends>
                                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                        <Series>
                                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                                <AxisY2>
                                                    <MajorGrid Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisY2>
                                                <AxisX2>
                                                    <MajorGrid Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisX2>
                                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
                                                <AxisY LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisX>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div style="width: 350px">
                        <table class="sampleTable">
                            <tr>
                                <td width="350" class="tdchart">
                                    <asp:Chart ID="ChartCasts" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Height="200" Width="350" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                                        <Titles>
                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Casts" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                                        </Titles>
                                        <Legends>
                                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
                                        </Legends>
                                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                        <Series>
                                            <asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                                <AxisY2>
                                                    <MajorGrid Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisY2>
                                                <AxisX2>
                                                    <MajorGrid Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisX2>
                                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
                                                <AxisY LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                                    <MajorTickMark Enabled="False" />
                                                </AxisX>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div style="width: 400px; padding-left: 70px">
                        <asp:GridView ID="GV_Tehsils" CssClass="table-bordered table-striped td-position" AutoGenerateColumns="false" runat="server" Width="400px">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Ser">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="padding-top: 10px;">
        <div>
            <h3>
                <asp:Label Text="Influential Figures" ID="lblInf" Font-Bold="true" runat="server" />
            </h3>
        </div>
        <asp:GridView ID="grdVFU_LM_Candidates" CssClass="table-bordered table-striped td-position" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SR#">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Political Leaning">
                    <ItemTemplate>
                        <asp:Label ID="lblPolitical_leaning" runat="server" Text='<%#Bind("Political_leaning") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Profession">
                    <ItemTemplate>
                        <asp:Label ID="lblProfession" runat="server" Text='<%#Bind("Profession") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Political Relations">
                    <ItemTemplate>
                        <asp:Label ID="lblRel_poli" runat="server" Text='<%#Bind("Rel_poli") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Bueurocracy Relations">
                    <ItemTemplate>
                        <asp:Label ID="Rel_Beau" runat="server" Text='<%#Bind("Rel_Beau") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Military Relations">
                    <ItemTemplate>
                        <asp:Label ID="lblRel_Mili" runat="server" Text='<%#Bind("Rel_Mili") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>

    <div style="padding-top: 10px;">
        <div runat="server" id="DivSpoiler">
            <h3>
                <asp:Label Text="Spoiler" ID="lblSpoiler" Font-Bold="true" runat="server" />
            </h3>
        </div>
        <asp:GridView ID="GV_Spoiler" CssClass="table-bordered table-striped td-position" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sr#">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("S_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type of Influence">
                    <ItemTemplate>
                        <asp:Label ID="lblTYPE_Inf" runat="server" Text='<%#Bind("S_TYPE_Inf") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Political Leaning">
                    <ItemTemplate>
                        <asp:Label ID="lblPolitical_leaning" runat="server" Text='<%#Bind("S_Political_leaning") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Profession">
                    <ItemTemplate>
                        <asp:Label ID="lblProfession" runat="server" Text='<%#Bind("S_Profession") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Political Relations">
                    <ItemTemplate>
                        <asp:Label ID="lblRel_poli" runat="server" Text='<%#Bind("S_Rel_poli") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Bueurocracy Relations">
                    <ItemTemplate>
                        <asp:Label ID="Rel_Beau" runat="server" Text='<%#Bind("S_Rel_Beau") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Military Relations">
                    <ItemTemplate>
                        <asp:Label ID="lblRel_Mili" runat="server" Text='<%#Bind("S_Rel_Mili") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>

    <div style="width: 100%">
        <asp:HiddenField ID="hfYear" runat="server" Value="0" />
        <h2>Election Results</h2>
        <asp:DataList ID="dlData" runat="server" RepeatDirection="Horizontal" OnItemDataBound="ResultCharts_OnItemDataBound"
            RepeatColumns="5">
            <ItemTemplate>
                <table style="border: inset; margin-right: 2px; width: 300px">
                    <tr>
                        <td width="300" height="300" class="tdchart" valign="top">
                            <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="#F3DFC1" Width="300" Height="200" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
                                <Titles>
                                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                                </Titles>
                                <Legends>
                                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
                                </Legends>
                                <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                <Series>
                                    <asp:Series Name="Series1" IsValueShownAsLabel="true" BorderColor="180, 26, 59, 105">
                                    </asp:Series>
                                    <asp:Series Name="Series2" IsValueShownAsLabel="true" BorderColor="180, 26, 59, 105">
                                    </asp:Series>
                                    <asp:Series Name="Series3" IsValueShownAsLabel="true" BorderColor="180, 26, 59, 105">
                                    </asp:Series>
                                    <asp:Series Name="Series4" IsValueShownAsLabel="true" BorderColor="180, 26, 59, 105">
                                    </asp:Series>
                                    <asp:Series Name="Series5" IsValueShownAsLabel="true" BorderColor="180, 26, 59, 105">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
                                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt" />
                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                        </AxisY>
                                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt" IsEndLabelVisible="False" />
                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="padding-top: 10px; padding-bottom: 10px">

                                <asp:GridView ID="grdCandidates" CssClass="td-position table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%" OnRowDataBound="grdCandidates_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SR#">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <div class="cand-pic">
                                                    <div style="float: left; width: 80%; text-align: left;">
                                                        <asp:Label ID="lblName" CssClass="hyperlink" runat="server" Text='<%#Bind("Candidate") %>'></asp:Label>
                                                    </div>
                                                    <div style="float: left; width: 20%; position: absolute; right: 0; z-index: 999999;">
                                                        <asp:Image runat="server" ID="candPic" onmouseover="largePic(this)" CssClass="picture" Width="30" Height="30" />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party">
                                            <ItemTemplate>
                                                <asp:Label ID="lblParty" Width="10%" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <script type="text/javascript">
                                    function largePic(elem) {
                                        $(elem).stop().animate();
                                        $(elem).css("height", "120px");
                                        $(elem).css("width", "120px");
                                    }
                                    $(document).ready(function () {
                                        $(".cand-pic").mouseleave(function () {
                                            $(this).find("img").css("height", "30px");
                                            $(this).find("img").css("width", "30px");
                                        });
                                    });
                                </script>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>


        </asp:DataList>
    </div>

</asp:Content>


