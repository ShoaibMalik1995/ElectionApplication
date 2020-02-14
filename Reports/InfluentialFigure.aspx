<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="InfluentialFigure.aspx.cs" Inherits="Reports_InfluentialFigure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Influential Figures
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <fieldset>
        <legend>Filter Parameters
        </legend>
        <table class="table-form">
            <tr>
                <td class="label" style="width: 10%;">Year:</td>
                <td style="width: 10%;">
                    <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server"></asp:DropDownList>
                </td>
                <td class="label" style="width: 10%;">NA:</td>                
                <td class="label" style="width: 15%;">
                    <asp:DropDownList ID="ddlNA"  runat="server"></asp:DropDownList>
                </td>
                  <td align="left">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
            
        </table>
    </fieldset>
     <div style="padding-top: 10px;">

        <asp:GridView ID="grdVFU_LM_Candidates" CssClass="table-bordered table-striped td-position" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Ser">
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

                <asp:TemplateField HeaderText="Type of Influence">
                    <ItemTemplate>
                        <asp:Label ID="lblTYPE_Inf" runat="server" Text='<%#Bind("TYPE_Inf") %>'></asp:Label>
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
        })
    </script>
</asp:Content>


