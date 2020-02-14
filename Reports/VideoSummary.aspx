<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="VideoSummary.aspx.cs" Inherits="Reports_VideoSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
    $(document).ready(function () {
        $("video").bind("play", OnVideoPlay);
        $("audio").bind("play", OnAudioPlay);
    });

    function OnAudioPlay(evt) {
        var a = $("audio[id!='" + evt.target.id + "']").get();
        for (var i = 0; i < a.length; i++) {
            a[i].pause();
        }
            
    }

    function OnVideoPlay(evt) {
        var v = $("video[id!='" + evt.target.id + "']").get();
        for (var i = 0; i < v.length; i++) {
            v[i].pause();
        }
    }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 style="color: blue; width: 100%; text-align: center; font-size: 25px;">
        <asp:HyperLink ID="HPNAName" runat="server" Target="_blank">
            <asp:Label ID="lblId" runat="server"></asp:Label>
        </asp:HyperLink>
    </h1>
    <div class="link-Summary" style="width: 100%;">
        <asp:HyperLink ID="hpOwnAnalysis" runat="server"  Target="_blank" Text="Own Analysis"></asp:HyperLink>
        <asp:HyperLink ID="hpFefanAnalysis" runat="server"  Target="_blank" Text="FAFEN Analysis"></asp:HyperLink>
        <asp:HyperLink ID="hpAssesment" runat="server" Target="_blank" Text="Assesment"></asp:HyperLink>
        <asp:HyperLink ID="hpRecommendations" runat="server" Target="_blank" Text="Recommendations"></asp:HyperLink>
    </div>
    <div class="affiliated-pp" style="width: 100%;">
        <div style="float: left; width: 10%; white-space: nowrap; color: #008d4c">Affiliated PPs:</div>
        <div class="affiliated-pp-sub">
            <asp:DataList ID="ddlList" runat="server" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:HyperLink ID="HPPAName" Target="_blank" runat="server" NavigateUrl='<%# Eval("PAId","~/Reports/PAStatisticsReport.aspx?PAId={0}") %>'>
                        <asp:Label ID="lblPaName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </asp:HyperLink>,
                </ItemTemplate>
            </asp:DataList>
        </div>
      
    </div>
    <div class="winning-candidate">
        <h3>Winning Candidates</h3>
     
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElecConnection %>" SelectCommand="GetLastFiveVideoResults1" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="NAId" QueryStringField="Id" Type="Int32" />
                <asp:QueryStringParameter Name="PAId" QueryStringField="Id" Type="Int32" />
                <asp:QueryStringParameter Name="Type" QueryStringField="Type" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
          <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <table class="auto-style1">
                    <tr>
                        <td   >                        <asp:Label ID="lbl1" runat="server" Text='<%# Eval("ElectionYear") %>'></asp:Label></td>
                        <td>                           <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Winner1") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("Winner2") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("Winner3") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Winner4") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("Winner5") %>'></asp:Literal></td>
                    </tr>
      <%--              <tr>
                        <td   >                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ElectionYear") %>'></asp:Label></td>
                        <td>                           <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Winner1") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("Winner2") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal8" runat="server" Text='<%# Eval("Winner3") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal9" runat="server" Text='<%# Eval("Winner4") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal10" runat="server" Text='<%# Eval("Winner5") %>'></asp:Literal></td>
                    </tr>
                    <tr>
                      <td   >                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ElectionYear") %>'></asp:Label></td>
                        <td>                           <asp:Literal ID="Literal11" runat="server" Text='<%# Eval("Winner1") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal12" runat="server" Text='<%# Eval("Winner2") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal13" runat="server" Text='<%# Eval("Winner3") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal14" runat="server" Text='<%# Eval("Winner4") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal15" runat="server" Text='<%# Eval("Winner5") %>'></asp:Literal></td>
                    </tr>
                    <tr>
                      <td   >                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ElectionYear") %>'></asp:Label></td>
                        <td>                           <asp:Literal ID="Literal16" runat="server" Text='<%# Eval("Winner1") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal17" runat="server" Text='<%# Eval("Winner2") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal18" runat="server" Text='<%# Eval("Winner3") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal19" runat="server" Text='<%# Eval("Winner4") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal20" runat="server" Text='<%# Eval("Winner5") %>'></asp:Literal></td>
                    </tr>
                    <tr>
                       <td   >                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("ElectionYear") %>'></asp:Label></td>
                        <td>                           <asp:Literal ID="Literal21" runat="server" Text='<%# Eval("Winner1") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal22" runat="server" Text='<%# Eval("Winner2") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal23" runat="server" Text='<%# Eval("Winner3") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal24" runat="server" Text='<%# Eval("Winner4") %>'></asp:Literal></td>
                        <td>                           <asp:Literal ID="Literal25" runat="server" Text='<%# Eval("Winner5") %>'></asp:Literal></td>
                    </tr>--%>
                </table>
            </ItemTemplate>
        </asp:DataList>
    <div>
       
    </div>
</asp:Content>

