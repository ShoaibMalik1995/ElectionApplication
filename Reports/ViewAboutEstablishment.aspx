﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ViewAboutEstablishment.aspx.cs" Inherits="Reports_ViewAboutEstablishment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>View About Establishment
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <fieldset>
        <legend>Filter Parameters
        </legend>
        <table class="table-form">
            <tr>
                <td class="label" style="width: 10%;">Party:</td>
                <td style="width: 10%;">
                    <asp:DropDownList ID="ddlParty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="label" style="width: 10%;">Candidate:</td>
                <td style="width: 25%;">
                    <asp:DropDownList ID="ddlCandidate2" AutoPostBack="true" runat="server"></asp:DropDownList>
                </td>
                <td class="label" style="width: 15%;">View About Establishment:</td>
                <td>
                    <asp:TextBox ID="txtViews" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>

        </table>
    </fieldset>
    <div style="padding-top: 10px;">

        <asp:GridView ID="grdVFU_LM_Candidates" CssClass="table-bordered table-striped td-position" AutoGenerateColumns="false" runat="server" Width="100%" OnRowDataBound="grdCandidates_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Ser">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <div class="cand-pic">
                            <div style="float: left; width: 80%">
                                <asp:Label ID="lblName" CssClass="hyperlink" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                            </div>
                            <div style="float: left; width: 20%; position: absolute; right: 0; z-index: 999999;">
                                <asp:Image runat="server" ID="candPic" onmouseover="largePic(this)" CssClass="picture" Width="30" Height="30" />
                            </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Party">
                    <ItemTemplate>
                        <asp:Label ID="lblParty" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="NIC">
                    <ItemTemplate>
                        <asp:Label ID="lblNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="View Abot Estbalishment">
                    <ItemTemplate>
                        <asp:Label ID="lblEst" runat="server" Text='<%#Bind("ViewsAboutEstablishment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="100px">
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
            //$(elem).stop().animate({               
            //    height: $(elem).css("height") * (2)
            //});
            //$(elem).bind('mouseenter mouseleave', function (e) {
            //    $(this).stop().animate({
            //        height: $(this).data('height') * (e.type === 'mouseenter' ? 1.5 : 1)
            //    });
            //});
        }
        //function smallPic(elem) {
        //    $(elem).stop().animate();
        //    $(elem).css("height", "30px");
        //    $(elem).css("width", "30px");
        //}
        $(document).ready(function () {
            $(".cand-pic").mouseleave(function () {
                $(this).find("img").css("height", "30px");
                $(this).find("img").css("width", "30px");
            });
        })
    </script>
</asp:Content>

