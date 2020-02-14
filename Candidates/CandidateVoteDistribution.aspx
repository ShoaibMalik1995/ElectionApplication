<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="CandidateVoteDistribution.aspx.cs" Inherits="Candidates_CandidateVoteDistribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Candidate Vote Distribution
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">
        <tr>
            <td class="label" style="width: 10%;">Party:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlParty" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Candidate</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlCandidate" runat="server" OnSelectedIndexChanged="ddlCandidate_SelectedIndexChanged"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td class="label" style="width: 10%;">Individual Vote:</td>
            <td style="width: 30%;">
                <asp:TextBox ID="txtIndividualVote"  runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width: 10%;">Party Vote:</td>
            <td style="width: 30%;">
                <asp:TextBox ID="txtPartyVote" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label" style="width: 10%;">Religious Vote:</td>
            <td style="width: 30%;">
                <asp:TextBox ID="txtReligiousVote" runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width: 10%;"></td>
            <td style="width: 30%;">
                
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />

            </td>
        </tr>
    </table>

</asp:Content>

