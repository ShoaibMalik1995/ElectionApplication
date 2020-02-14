<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionYears.aspx.cs" Inherits="Admin_ElectionYears" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <h1>Add Election Year
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
    <table class="table-form" style="width:50%;">  
       
       <tr>
            <td  class="label" style="width:20%">Election Year:</td>
            <td  style="width:20%">
                <asp:TextBox ID="txtElecYear" runat="server" Width="250px"></asp:TextBox>                
            </td>
            <td>
              <asp:Button ID="Button1" Text="Save" CssClass="btn"  runat="server" OnClick="btn_save_Click" />
              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
          </td>
        </tr>

    

  </table> 
              <div style="width:100%; margin:0 auto;margin-top:20px;">
                <asp:GridView  ID="GridView1" CssClass="table-striped table-bordered" AutoGenerateColumns="false" runat="server"  Width="100%">
              <Columns>
                  <asp:TemplateField HeaderText="Ser">
                      <ItemTemplate>
                          <%#Container.DataItemIndex+1 %>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Election Year">
                      <ItemTemplate>
                          <asp:Label ID="lblid" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>                  
                    <asp:TemplateField HeaderText="Add" >
                      <ItemTemplate>
                          <span class="link"  onclick="lnkClick(this,'Candidate')">Add Candidate</span> &nbsp;&nbsp;
                                                    
                          <span class="link"  onclick="lnkClick(this,'Figures')">Add Figures</span> &nbsp;&nbsp;

                          <span class="link"  onclick="lnkClick(this,'Departmental')">Departmental Analysis</span> &nbsp;&nbsp;
                          
                          <span class="link"  onclick="lnkClick(this,'FAnalysis')">Fafen/Other Analysis</span> &nbsp;&nbsp;

                          <span class="link"  onclick="lnkClick(this,'VideoAnalysis')">Video Analysis</span> &nbsp;&nbsp;

                          <span class="link"  onclick="lnkClick(this,'PartyAnalysis')">Party Analysis</span> &nbsp;&nbsp;

                          <span class="link"  onclick="lnkClick(this,'Assesments')">Add Assesments</span> &nbsp;&nbsp;           
                          
                          <span class="link"  onclick="lnkClick(this,'Spoilers')">Spoilers/Influential Figures</span> &nbsp;&nbsp;                                                    

                          <span  class="link" onclick="lnkClick(this,'OnGoiningResults')">On Goining Results</span> &nbsp;&nbsp;                        
                          <span  class="link" onclick="lnkClick(this,'Results')">Add Results</span> &nbsp;&nbsp;                        
                                                                              
                          <asp:HiddenField ID="hdnElectionId" runat="server" Value='<%#Bind("ElectionId") %>'></asp:HiddenField>
                      </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <%--<asp:TemplateField HeaderText="View" >
                      <ItemTemplate>
                          <span class="link"  onclick="lnkClick(this,'ECandidate')">View Candidates</span> &nbsp;&nbsp;
                          <span  class="link" onclick="lnkClick(this,'Winner')">View Winners</span> &nbsp;&nbsp;                        
                          </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>--%>
                  <asp:TemplateField HeaderText="Delete">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" CssClass="icon-delete" CommandArgument='<%#Bind("ElectionId") %>' OnClick="LinkButton1_Click" runat="server"></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
                  </div>    
    <script type="text/javascript">
        function lnkClick(elem,callFrom) {
            
            var electionId = $.trim($(elem).closest("tr").find("[id*='hdnElectionId']").val());
            if (callFrom == "Candidate")
                window.open("../Elections/ElectionCandidates.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "ECandidate")
                window.open("../Elections/ElectionCandidatesList.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "Results")
                window.open("../Elections/ElectionResults.aspx?Type=Final&ElecnId=" + electionId, "_blank");
            else if (callFrom == "Winner")
                window.open("../Reports/ElectionWinerGraph.aspx?ElecnId=" + electionId, "_blank");            
            else if (callFrom == "Assesments")
                window.open("../Elections/Election_Assessment.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "Departmental")
                window.open("../Elections/AddDepartmentalAnalysis.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "FAnalysis")
                window.open("../Elections/AddImageAnalysis.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "VideoAnalysis")
                window.open("../Elections/AddVideoAnalysis.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "PartyAnalysis")
                window.open("../Elections/AddPartyAnalysis.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "Spoilers")
                window.open("../Elections/NAInfulense.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "Figures")
                window.open("../Elections/AddFigureCastSectrain.aspx?ElecnId=" + electionId, "_blank");
            else if (callFrom == "OnGoiningResults")
                window.open("../Elections/OnGoiningResults.aspx?ElecnId=" + electionId, "_blank");
        }
        
    </script>
</asp:Content>

