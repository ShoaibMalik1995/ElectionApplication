<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="CandidateDetails.aspx.cs" Inherits="Candidates_CandidateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Candidate Info</h3>
    <table class="table-form">
        <tr>
            <td class="label">Name:</td>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
            <td colspan="2" rowspan="3" style="text-align: center">

                <asp:Image runat="server" ID="candPic" ImageUrl="~/images/dumy.png" CssClass="picture"  width="120" height="120"  />

            </td>
        </tr>
        <tr>
            <td class="label">NIC#:</td>
            <td>
                <asp:Label ID="lblNic" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="label">Party:</td>
            <td>
                <asp:Label ID="lblParty" runat="server"></asp:Label>


            </td>
        </tr>
        <tr>
            <td class="label" style="width: 20%">Education:</td>
            <td style="width: 30%">
                <asp:Label ID="lblEdu" runat="server"></asp:Label>

            </td>
            <td class="label" style="width: 20%">Relation With Military:</td>
            <td style="width: 30%">
                <asp:Label ID="lblRWM" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="label">Relation With Bureaucracy:</td>
            <td>
                <asp:Label ID="lblRWB" runat="server"></asp:Label>

            </td>
            <td class="label">Relation With Judiciary:</td>
            <td>
                <asp:Label ID="lblRWJ" runat="server"></asp:Label>

            </td>

        </tr>
        <tr>
            <td class="label">Relation With Politics:</td>
            <td>
                <asp:Label ID="lblRWP" runat="server"></asp:Label>

            </td>
            <td class="label">Moral Characteristics:</td>
            <td>
                <asp:Label ID="lblMC" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="label">Financial Characteristics:</td>
            <td>
                <asp:Label ID="lblFC" runat="server"></asp:Label>

            </td>

            <td class="label">View About Establishment:</td>
            <td>
                <asp:Label ID="lblVAE" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="label">Important Appointments:</td>
            <td>
                <asp:Label ID="lblImpApp" runat="server"></asp:Label>

            </td>
            <td class="label">Scandles:</td>
            <td>
                <asp:Label ID="lblScandles" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>

            <td class="label">Present Address:</td>
            <td>
                <asp:Label ID="lblPresentAdd" runat="server"></asp:Label>

            </td>
            <td class="label">Permanent Address:</td>
            <td>
                <asp:Label ID="lblPermanentAddress" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="label">Other Observations:</td>
            <td colspan="3">
                <asp:Label ID="lblObservations" runat="server"></asp:Label>

            </td>

        </tr>
    </table>

    <h3 style="margin-top: 30px;">Father Info</h3>
    <div style="padding-top: 10px;">

        <asp:GridView ID="grdFather" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="NIC#">
                    <ItemTemplate>
                        <asp:Label ID="lblFNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Political Relation">
                    <ItemTemplate>
                        <asp:Label ID="lblFNIC" runat="server" Text='<%#Bind("PoliticalRelation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other Affiliations">
                    <ItemTemplate>
                        <asp:Label ID="lblFNIC" runat="server" Text='<%#Bind("OtherAffiliations") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>
    <h3 style="margin-top: 30px;">Spouse Info</h3>
    <div style="padding-top: 10px;">

        <asp:GridView ID="grdSpouse" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="NIC#">
                    <ItemTemplate>
                        <asp:Label ID="lblFNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Political Relation">
                    <ItemTemplate>
                        <asp:Label ID="lblFNIC" runat="server" Text='<%#Bind("PoliticalRelation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other Affiliations">
                    <ItemTemplate>
                        <asp:Label ID="lblFNIC" runat="server" Text='<%#Bind("OtherAffiliations") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>
    <h3 style="margin-top: 30px;">Businesses Info</h3>

    <div style="padding-top: 10px;">

        <asp:GridView ID="grdBusiness" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Business Type">
                    <ItemTemplate>
                        <asp:Label ID="lblBusinessType" runat="server" Text='<%#Bind("BusinessType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%#Bind("Type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>

      <h3 style="margin-top: 30px;">Cook / Guard Info</h3>

    <div style="padding-top: 10px;">
        <asp:GridView ID="grdCookGuard" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="NIC#">
                    <ItemTemplate>
                        <asp:Label ID="lblNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%#Bind("Phone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%#Bind("Type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>

