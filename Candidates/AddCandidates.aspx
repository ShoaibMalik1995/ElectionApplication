<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddCandidates.aspx.cs" EnableViewState="true" Inherits="Candidates_AddCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Add/Edit Candidate
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    <table class="table-form">
        <tr>
            <td colspan="4">
                <h2>Basic Data</h2>
            </td>
        </tr>
        <tr>
            <td class="label">Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td colspan="2" rowspan="3" style="text-align: center">
                <div style="text-align: center; width: 50%; margin: 0 auto;">
                    <%--<img src="../images/dumy.png" runat="server" id="candPic"  class="picture" width="120" height="120" />--%>
                    <asp:Image runat="server" ID="candPic" ImageUrl="~/images/dumy.png" CssClass="picture" Width="120" Height="120" />
                    <asp:FileUpload ID="picUpload" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="label">NIC#:</td>
            <td>
                <asp:TextBox ID="txtNic" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">Party:</td>
            <td>
                <asp:DropDownList ID="ddlParty" runat="server"></asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td class="label" style="width: 20%">Education:</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtEdu" runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width: 20%">Present Address:</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtPresentAdd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">Nadra Verises:</td>
            <td>
                <asp:FileUpload ID="fileNadraVerises" runat="server" />
                <asp:HiddenField ID="hdnNadraVerises" runat="server" />
            </td>

            <td class="label">Permanent Address:</td>
            <td>
                <asp:TextBox ID="txtPermanentAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td class="label">Gender:
            </td>
            <td>
                <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="label">Personal Phone:
            </td>
            <td>
                <asp:TextBox ID="txtPersonalPhone" runat="server"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            
            <td colspan="2" style="text-align: center">
                <label for="ContentPlaceHolder1_chkVoteForUs" class="label">Vote for Us:</label>
                <asp:CheckBox ID="chkVoteForUs" runat="server" />
                &nbsp;&nbsp;
                <label for="ContentPlaceHolder1_chkLikeMinded" class="label">Like Minded:</label>
                <span>
                    <asp:CheckBox ID="chkLikeMinded" runat="server" /></span>
            </td>
             <td class="label">Confident Phone:
            </td>
            <td>
                <asp:TextBox ID="txtConfidentPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <h2>Political Data</h2>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="label-sub border">Political Affiliation
            </td>
            <td colspan="3" class="border">
                <table style="width: 100%;">
                    <tr>
                        <td class="label" style="width: 25%;">Past Affiliation, if Any:</td>
                        <td>
                            <asp:TextBox ID="txtPastAffiliation" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">Current Affiliation:</td>
                        <td>
                            <asp:TextBox ID="txtCurrentAffiliation" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">Any likelyhood of Changing Affiliation:</td>
                        <td>
                            <asp:TextBox ID="txtChangingAffiliation" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="label-sub border">Important Relationships
            </td>
            <td colspan="3" class="border">
                <table style="width: 100%;">
                    <tr>
                        <td class="label" style="width: 20%;">Judiciary:</td>
                        <td>
                            <asp:TextBox ID="txtRWJ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">Military:</td>
                        <td>
                            <asp:TextBox ID="txtRWM" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">Bureaucracy:</td>
                        <td>
                            <asp:TextBox ID="txtRWB" runat="server"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="label">Politics:</td>
                        <td>
                            <asp:TextBox ID="txtRWP" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="label">Important Appointments Held in Past Govts:</td>
            <td colspan="3">
                <asp:TextBox ID="txtImpApp" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>

            <td class="label">Involved in any Major Incident/ Event/ Scandal:</td>
            <td colspan="3">
                <asp:TextBox ID="txtScandles" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">View About Establishment:</td>
            <td>
                <asp:TextBox ID="txtVAE" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="label-sub border">Moral and Financial Characteristics
            </td>
            <td colspan="3" class="border">
                <table style="width: 100%;">
                    <tr>

                        <td class="label">Moral:</td>
                        <td>
                            <asp:TextBox ID="txtMC" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="label">Financial:</td>
                        <td>
                            <asp:TextBox ID="txtFC" runat="server"></asp:TextBox>
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="label">Any Special Observation (Heard/In Record):</td>
            <td colspan="3">
                <asp:TextBox ID="txtObservations" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" />
                &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnClear" runat="server" CssClass="btn" Text="Clear" OnClick="btnClear_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnCandidateId" runat="server" Value="0" />
</asp:Content>

