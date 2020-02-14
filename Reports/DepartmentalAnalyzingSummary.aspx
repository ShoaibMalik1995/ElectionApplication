<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="DepartmentalAnalyzingSummary.aspx.cs" Inherits="Reports_DepartmentalAnalyzingSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 style="color: blue; width: 100%; text-align: center; font-size: 25px;">
                <asp:Label ID="lblId" runat="server"></asp:Label>
    </h1>
   
   
    <div class="winning-candidate">
        <h3>Departmental Analysis</h3>
        <asp:GridView ID="grdWinningCandidates" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%" OnRowDataBound="grdWinningCandidates_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Year">
                    <ItemTemplate>
                        <asp:Label ID="lblYear" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sub Sector" >
                    <ItemTemplate>
                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                               
                                <div>
                                    <%--<span class="cand-title">Name:</span>--%>
                                    <asp:Label ID="lblWinner1Name" CssClass="cand-text" runat="server" Text='<%#Bind("AnalysisOC") %>'></asp:Label>
                                </div>
                              
                            </div>
                          
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="30%" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Sector HQ" >
                    <ItemTemplate>

                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                            
                                    <%--<span class="cand-title">Name:</span>--%>
                                    <asp:Label ID="lblWinner2Name" CssClass="cand-text" runat="server" Text='<%#Bind("AnalysisDIV") %>'></asp:Label>
                                </div>
                             
                                <%-- <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty2" CssClass="cand-text" runat="server" Text='<%#Bind("Winner2Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                       
                        </div>
                        
                    </ItemTemplate>
                    <ItemStyle Width="30%" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField   HeaderText="Command Sector HQ" >
                    <ItemTemplate>
                        <div>
                            <div style="text-align: center; padding-top: 2px;">
                            
                            <div style="padding-left: 10px;">
                                <div>
                                    <%--<span class="cand-title">Name:</span>--%>
                                    <asp:Label ID="lblWinner3Name" CssClass="cand-text" runat="server" Text='<%#Bind("AnalysisHQ") %>'></asp:Label>
                                </div>
                              
                                <%-- <div>
                        <span class="cand-title">Party: </span>
                        <asp:Label ID="lblParty3" CssClass="cand-text" runat="server" Text='<%#Bind("Winner3Party") %>'></asp:Label>
                    </div>--%>
                            </div>
                           
                        </div>
                            </div>

                    </ItemTemplate>
                    <ItemStyle Width="30%" VerticalAlign="Top" />
                </asp:TemplateField>
         
             
            </Columns>
        </asp:GridView>
    </div>
    <div>
    </div>
</asp:Content>

