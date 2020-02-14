<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionCandidateslist.aspx.cs" Inherits="Candidates_ElectionCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Election Candidates
     
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
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
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
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Search" CssClass="btn" runat="server" OnClick="btn_save_Click" />

            </td>
        </tr>

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="td-position  table-bordered table-striped" AutoGenerateColumns="False" runat="server" Width="100%"  OnRowDataBound="grdCandidates_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Election Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblElectionYear" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Candidate">  
                                <ItemTemplate>
                                <div class="cand-pic">
                                <div style="float:left;width:80%; text-align:left;">
                                    <asp:Label ID="lblName"  CssClass="hyperlink" runat="server" Text='<%#Bind("Candidate") %>'></asp:Label>
                                </div>
                                <div style="float:left;width:20%;position:absolute;right:0;z-index:999999;">
                                    <asp:Image runat="server" ID="candPic" onmouseover="largePic(this)" CssClass="picture"  width="30" height="30"  />
                                </div>
                               </div>
                                    </ItemTemplate>                              
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Bind("PersonalPhone") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Details" HeaderStyle-Width="200px" >
                      <ItemTemplate>                          
                          <span class="icon-details" title="Details" onclick="lnkClick(this,'Details')"></span>
                          &nbsp;&nbsp;                                                   
                          <asp:HiddenField ID="hdnCandidateId" runat="server" Value='<%#Bind("CandidateId") %>'></asp:HiddenField>
                      </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>
            </td>
        </tr>
    </table>
    
    <script type="text/javascript">
        function lnkClick(elem,callFrom) {            
            var candidateId = $.trim($(elem).closest("tr").find("[id*='hdnCandidateId']").val());                       
                window.open("../Candidates/CandidateDetails.aspx?CandId=" + candidateId, "_blank");                        
        }
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
</asp:Content>

