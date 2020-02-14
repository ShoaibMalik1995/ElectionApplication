<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionsSummaryPA.aspx.cs" Inherits="Elections_ElectionsSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 style="color: blue; width: 100%; text-align: center; font-size: 25px;">
        <asp:label id="lblId" runat="server"></asp:label>
    </h1>
    <div style="width:100%;float:left; margin-top: 10px;">
    <div class="summary-links-na">
        <nav id="fh5co-menu-wrap" role="navigation" style="width: 100%;margin: 0;padding-top: 10px;">
            <ul class="sf-menu summary-li" id="fh5co-primary-menu" style="padding: 0;height: 37px;line-height: 0px;width: 100%;">
                <li style="margin:0 5%;">
                    <asp:hyperlink id="hpStatistics" runat="server" target="_blank" text="Statistics"></asp:hyperlink>
                </li>
                <li  style="margin:0 5%;">
                    <asp:hyperlink id="hpAssesment" runat="server" target="_blank" text="Assesment"></asp:hyperlink>
                </li>
                <li  style="margin:0 5%;">
                    <a href="services.html" class="fh5co-sub-ddown">Analysis</a>
                    <ul class="fh5co-sub-menu">
                        <li style="cursor:pointer;">
                            <asp:hyperlink id="hpDepartmentalAnalysis" runat="server" target="_blank" text="Departmental Analysis"></asp:hyperlink>
                        </li>
                        <li style="cursor:pointer;">
                            <asp:hyperlink id="hpFafenAnalysis" runat="server" target="_blank" text="Fafen / Other Analysis"></asp:hyperlink>
                        </li>
                        <li style="cursor:pointer;">
                            <asp:hyperlink id="hpVideoAnalysis" runat="server" target="_blank" text="Video Analysis"></asp:hyperlink>
                        </li>
                        <li style="cursor:pointer;">
                            <asp:hyperlink id="hpPartyAnalysis" runat="server" target="_blank" text="Parties Analysis"></asp:hyperlink>
                        </li>
                    </ul>
                </li>
            </ul>
        </nav>
    </div>
        </div>
    
    <div class="winning-candidate">
        <h3>Winning Candidates</h3></div>
        <asp:gridview id="grdWinningCandidates" cssclass="table-bordered table-striped" autogeneratecolumns="false" runat="server" width="100%" onrowdatabound="grdWinningCandidates_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Year">
                    <ItemTemplate>
                        <asp:Label ID="lblYear" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Winner 1">
                    <ItemTemplate>
                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                                <div class="logo-both">
                                    <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("Winner1Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'>
                                        <asp:Image runat="server" ID="Winner1Pic" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                    </asp:HyperLink>
                                </div>
                                <div class="logo-both">
                                    <asp:Image runat="server" ID="imgPartyLogo1" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                </div>
                            </div>
                            <div style="padding-left: 10px;">
                                <div>
                                    <span class="cand-title">Name:</span>
                                    <asp:Label ID="lblWinner1Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner1") %>'></asp:Label>
                                </div>
                                <div>
                                    <span class="cand-title">Votes: </span>
                                    <asp:Label ID="lblWinner1Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner1Votes") %>'></asp:Label>
                                </div>
                                <%--<div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty1" CssClass="cand-text" runat="server" Text='<%#Bind("Winner1Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                            <asp:HiddenField ID="hdnWinner1Id" runat="server" Value='<%#Bind("Winner1Id") %>'></asp:HiddenField>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="19%" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Winner 2">
                    <ItemTemplate>

                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                                <div class="logo-both">
                                    <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("Winner2Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'>
                                        <asp:Image runat="server" ID="Winner2Pic" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                    </asp:HyperLink>
                                </div>
                                <div class="logo-both">
                                    <asp:Image runat="server" ID="imgPartyLogo2" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                </div>
                            </div>
                            <div style="padding-left: 10px;">

                                <div>
                                    <span class="cand-title">Name:</span>
                                    <asp:Label ID="lblWinner2Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2") %>'></asp:Label>
                                </div>
                                <div>
                                    <span class="cand-title">Votes: </span>
                                    <asp:Label ID="lblWinner2Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2Votes") %>'></asp:Label>
                                </div>
                                <%-- <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty2" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                            <asp:HiddenField ID="hdnWinner2Id" runat="server" Value='<%#Bind("Winner2Id") %>'></asp:HiddenField>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="19%" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Winner 3">
                    <ItemTemplate>
                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                                <div class="logo-both">
                                    <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("Winner3Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'>
                                        <asp:Image runat="server" ID="Winner3Pic" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                    </asp:HyperLink>
                                </div>
                                <div class="logo-both">
                                    <asp:Image runat="server" ID="imgPartyLogo3" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                </div>
                            </div>
                            <div style="padding-left: 10px;">
                                <div>
                                    <span class="cand-title">Name:</span>
                                    <asp:Label ID="lblWinner3Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3") %>'></asp:Label>
                                </div>
                                <div>
                                    <span class="cand-title">Votes: </span>
                                    <asp:Label ID="lblWinner3Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3Votes") %>'></asp:Label>
                                </div>
                                <%-- <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty3" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                            <asp:HiddenField ID="hdnWinner3Id" runat="server" Value='<%#Bind("Winner3Id") %>'></asp:HiddenField>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="19%" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Winner 4">
                    <ItemTemplate>
                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                                <div class="logo-both">
                                    <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("Winner4Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'>
                                        <asp:Image runat="server" ID="Winner4Pic" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                    </asp:HyperLink>
                                </div>
                            </div>
                            <div class="logo-both">
                                <asp:Image runat="server" ID="imgPartyLogo4" ImageUrl="~/images/dumy.png" CssClass="picture" />
                            </div>
                            <div style="padding-left: 10px;">
                                <div>
                                    <span class="cand-title">Name:</span>
                                    <asp:Label ID="lblWinner4Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner4") %>'></asp:Label>
                                </div>
                                <div>
                                    <span class="cand-title">Votes: </span>
                                    <asp:Label ID="lblWinner4Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner4Votes") %>'></asp:Label>
                                </div>
                                <%-- <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty4" CssClass="cand-text" runat="server" Text='<%#Bind("Winner4Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                            <asp:HiddenField ID="hdnWinner4Id" runat="server" Value='<%#Bind("Winner4Id") %>'></asp:HiddenField>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="19%" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Winner 5">
                    <ItemTemplate>
                        <div>
                            <div style="padding-top: 2px;">
                                <div class="logo-both">
                                    <div class="logo-both">
                                        <asp:HyperLink runat="server" Target="_blank" NavigateUrl='<%# Eval("Winner5Id", "~/Candidates/CandidateProfile.aspx?CandId={0}") %>'>
                                            <asp:Image runat="server" ID="Winner5Pic" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                        </asp:HyperLink>
                                    </div>
                                </div>
                                <div class="logo-both">
                                    <asp:Image runat="server" ID="imgPartyLogo5" ImageUrl="~/images/dumy.png" CssClass="picture" />
                                </div>
                            </div>
                            <div style="padding-left: 10px;">
                                <div>
                                    <span class="cand-title">Name:</span>
                                    <asp:Label ID="lblWinner5Name" CssClass="cand-text" runat="server" Text='<%#Bind("Winner5") %>'></asp:Label>
                                </div>
                                <div>
                                    <span class="cand-title">Votes: </span>
                                    <asp:Label ID="lblWinner5Votes" CssClass="cand-text" runat="server" Text='<%#Bind("Winner5Votes") %>'></asp:Label>
                                </div>
                                <%--<div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty5" CssClass="cand-text" runat="server" Text='<%#Bind("Winner5Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                            <asp:HiddenField ID="hdnWinner5Id" runat="server" Value='<%#Bind("Winner5Id") %>'></asp:HiddenField>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="19%" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
    

    <script type="text/javascript">
        function showAnalysis(elem) {
            $(elem).next().show();
        }
        //function hideAnalysis(elem) {
        //    $(".divAnalysis").hide();
        //}
        $(document).on("mousemove", function (event) {

            if (!$($(event)[0].target).hasClass("divAnalysis")) {
                $(".divAnalysis").hide();
            }
            if ($($(event)[0].target).hasClass("divAnalysis")) {
                $(".divAnalysis").hide();
            }
        })
    </script>
</asp:Content>

