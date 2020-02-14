<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConstituencyAnalysis.aspx.cs" Inherits="Reports_ConstituencyAnalysis" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div style="width: 100%">
        <table class="table-form">

            <tr style="display:none;">
                <td class="label" style="width: 10%;">Year:</td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="label" style="width: 10%;">Province:</td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                </td>

            </tr>
            <tr style="display:none">
                <td class="label" style="width: 10%;">District:</td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                </td>

                <td class="label">NA:</td>
                <td>
                    <asp:DropDownList ID="ddlNA" AutoPostBack="false" runat="server"></asp:DropDownList>
                </td>


            </tr>

            <tr style="display:none">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="btn_save" Text="Search" CssClass="btn" runat="server" OnClick="btn_save_Click" />

                </td>
            </tr>
        </table>


    </div>
    <table style="width: 100%;">
        <thead>
            <tr>
                <th colspan="2" style="background-color: #999; color: #fff;text-align:center">Constituency Analysis
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptAnalysisMain" runat="server" OnItemDataBound="rptAnalysisMain_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td style="width: 50%; background-color: lightgreen; vertical-align: top;">
                            <div style="border-bottom: solid 1px #000; text-align: center;background-color: bisque">
                                <asp:Label ID="lblNAName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                            </div>
                            <div style="padding: 5px;">
                                <asp:Label ID="lblAnalysis" runat="server" Text='<%#Bind("Analysis") %>'></asp:Label>
                            </div>
                        </td>
                        <td style="width: 50%;">
                            <table style="width: 100%;">
                                <thead>
                                    <tr>
                                        <td style="text-align: center; background-color: Silver">PP*</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptAnalysisSub" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;border-bottom:solid 1px #000;border-top:solid 1px #000;background-color: bisque">
                                                    <asp:Label ID="lblNAName" runat="server" Text='<%#Bind("Name") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td  class="row_<%#Container.ItemIndex+1 %>">
                                                    <div style="padding: 5px;">
                                                        <asp:Label ID="lblAnalysis" runat="server" Text='<%#Bind("Analysis") %>'></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <style>
        .row_1
        {
            background-color:yellow;
        }
        .row_2
        {
            background-color:pink;
        }
        .row_3
        {
            background-color:ghostwhite;
        }
        .row_4
        {
            background-color:lightsteelblue;
        }
    </style>
</asp:Content>


