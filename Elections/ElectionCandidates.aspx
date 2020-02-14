<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionCandidates.aspx.cs" Inherits="Candidates_ElectionCandidates" %>

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
                <asp:DropDownList ID="ddlYear"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Division:</td>
            <td style="width: 30%;">
                 <asp:DropDownList ID="ddlDivisions"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged">
                    
                </asp:DropDownList>

                <asp:DropDownList ID="ddlProvince" Visible="false" runat="server">
                    <asp:ListItem Text="Punjab" Value="4"></asp:ListItem>
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

        </tr>
        <tr>
            <td class="label">Party:</td>
            <td>
                <asp:DropDownList ID="ddlParty" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label">Candidate:</td>
            <td>
                <asp:DropDownList ID="ddlCandidate" runat="server"></asp:DropDownList>
            </td>

        </tr>

        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />

            </td>
        </tr>

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="td-position  table-bordered table-striped" AutoGenerateColumns="False" OnRowDataBound="grdCandidates_RowDataBound" runat="server" Width="100%">
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
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Candidate">
                                <ItemTemplate>
                                    <div class="cand-pic">
                                        <div style="float: left; width: 80%">
                                            <asp:Label ID="lblName" CssClass="hyperlink" onclick="lnkClick(this,'Details')" runat="server" Text='<%#Bind("Candidate") %>'></asp:Label>
                                            <%--<span class="icon-details" title="Details" onclick="lnkClick(this,'Details')"></span>--%>
                                        </div>
                                        <div style="float: left; width: 20%; position: absolute; right: 0; z-index: 999999;">
                                            <asp:Image runat="server" ID="candPic" onmouseover="largePic(this)" CssClass="picture" Width="30" Height="30" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonalPhone" runat="server" Text='<%#Bind("PersonalPhone") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" Style="cursor: pointer;" CssClass="icon-delete" CommandName='<%# Bind("Type") %>' CommandArgument='<%# Bind("Id") %>' runat="server" OnClientClick="return confirmDelete()" OnClick="lnkDelete_Click"> </asp:LinkButton>
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
        function lnkClick(elem, callFrom) {
            var candidateId = $.trim($(elem).closest("tr").find("[id*='hdnCandidateId']").val());
            if (callFrom == "Details")
                window.open("../Candidates/CandidateProfile.aspx?CandId=" + candidateId, "_blank");
        }
        function largePic(elem) {
            $(elem).stop().animate();
            $(elem).css("height", "100px");
            $(elem).css("width", "100px");

        }

        $(document).ready(function () {
            $(".cand-pic").mouseleave(function () {
                $(this).find("img").css("height", "30px");
                $(this).find("img").css("width", "30px");
            });
        });
        function confirmDelete() {
            if (window.confirm("Do you want to delete?")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</asp:Content>

