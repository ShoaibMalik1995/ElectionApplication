<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Father.aspx.cs" Inherits="Candidates_Father" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="div-top-heading">
        <div class="div-heading">Father Information  </div>
        <div class="div-msg">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <div class="top-link">
            <input type="button" onclick="showForm()" class="btn" value="Add Father" />
        </div>
    </div>
    <div id="divFather" runat="server" style="padding-top: 10px;">

        <asp:GridView ID="grdFater" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
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

                <asp:TemplateField HeaderText="Political Relation">
                    <ItemTemplate>
                        <asp:Label ID="lblPoliticalRelation" runat="server" Text='<%#Bind("PoliticalRelation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OtherAffiliations">
                    <ItemTemplate>
                        <asp:Label ID="lblOtherAffiliations" runat="server" Text='<%#Bind("OtherAffiliations") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" CssClass="icon-edit" CommandArgument='<%#Bind("FatherId") %>' OnClick="lnkEdit_Click" runat="server"></asp:LinkButton>                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

    <table class="table-form" id="formFather" runat="server" style="display: none;">
        <tr>
            <td class="label" style="width:20%;">Name:</td>
            <td  style="width:30%;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td class="label"  style="width:20%;">NIC#:</td>
            <td  style="width:30%;">
                <asp:TextBox ID="txtNic" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">Political Relation:</td>
            <td>
                <asp:TextBox ID="txtPoliticalRelation" runat="server"></asp:TextBox>
            </td>
            <td class="label">Other Affiliations:</td>
            <td>
                <asp:TextBox ID="txtOtherAffiliations" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnFatherId" runat="server" Value="0" />
    <script type="text/javascript">
        function showForm() {
            $("[id$='formFather']").show();
            $("[id$='divFather']").hide();

            $("[id$='formFather'] input[text]").val("");
            $("[id$='hdnFatherId']").val("0");
        }
    </script>
</asp:Content>

