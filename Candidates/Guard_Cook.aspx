<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Guard_Cook.aspx.cs" Inherits="Candidates_Guard_Cook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="div-top-heading">
        <div class="div-heading">Cook/Guard Information  </div>
        <div class="div-msg">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <div class="top-link">
            <input type="button" onclick="showForm()" class="btn" value="Add Cook/Guard" />
        </div>
    </div>
    <div id="divCookGuard" runat="server" style="padding-top: 10px;">

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
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" CssClass="icon-edit" CommandArgument='<%#Bind("Id") %>' OnClick="lnkEdit_Click" runat="server"></asp:LinkButton>                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

    <table class="table-form" id="formCookGuard" runat="server" style="display: none;">
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
            <td class="label">Phone:</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
            <td class="label">Type:</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Text="Cook" Value="Cook"></asp:ListItem>
                    <asp:ListItem Text="Driver" Value="Driver"></asp:ListItem>
                    <asp:ListItem Text="Guard" Value="Guard"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnCoodGuardId" runat="server" Value="0" />
    <script type="text/javascript">
        function showForm() {
            $("[id$='formCookGuard']").show();
            $("[id$='divCookGuard']").hide();

            $("[id$='formCookGuard'] input[text]").val("");
            $("[id$='hdnCoodGuardId']").val("0");
        }
    </script>
</asp:Content>

