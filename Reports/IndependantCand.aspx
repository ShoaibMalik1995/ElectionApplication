<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="IndependantCand.aspx.cs" Inherits="Reports_IndependantCand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Independant Candidates
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">

        <tr>
            <td class="label" style="width: 10%;">Year:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" ></asp:DropDownList>
            </td>
           
            <td class="label"  style="width: 5%;">Type :</td>
            <td  style="width: 10%;">
                <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="MNA" Value="NA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="MPA" Value="PA"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
              <td class="label"  style="width: 5%;">Gender :</td>
            <td style="width: 10%;"> 
                <asp:DropDownList ID="ddlGender" runat="server">
                     <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="Both" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td  style="text-align: left;">
                <asp:Button ID="btnSearch" Text="Search" CssClass="btn" runat="server" OnClick="btnSearch_Click" />
            </td>            
        </tr>

        <tr>

            <td align="center" colspan="8">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="td-position  table-bordered table-striped" AutoGenerateColumns="False" OnRowDataBound="grdCandidates_RowDataBound" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            
                            <asp:TemplateField HeaderText="Candidate">
                                <ItemTemplate>
                                    <div class="cand-pic">
                                        <div style="float: left; width: 80%">
                                            <asp:Label ID="lblName" CssClass="hyperlink" onclick="lnkClick(this,'Details')" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                            <%--<span class="icon-details" title="Details" onclick="lnkClick(this,'Details')"></span>--%>
                                        </div>
                                        <div style="float: left; width: 20%; position: absolute; right: 0; z-index: 999999;">
                                            <asp:Image runat="server" ID="candPic" onmouseover="largePic(this)" CssClass="picture" Width="30" Height="30" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="NIC">
                                <ItemTemplate>
                                    <asp:Label ID="lblNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Phone">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonalPhone" runat="server" Text='<%#Bind("PersonalPhone") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Present Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Bind("PresentAddress") %>'></asp:Label>
                                     <asp:HiddenField ID="hdnCandidateId" runat="server" Value='<%#Bind("CandidateId") %>'></asp:HiddenField>
                                </ItemTemplate>
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

