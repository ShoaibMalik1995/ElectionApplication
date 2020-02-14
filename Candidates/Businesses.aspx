<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Businesses.aspx.cs" Inherits="Candidates_Businesses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="div-top-heading">
        <div class="div-heading">Businesses  </div>
        <div class="div-msg">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <div class="top-link">
            <input type="button" onclick="showForm()" class="btn" value="Add Business" />
        </div>
    </div>
    <div id="divBusiness" runat="server" style="padding-top: 10px;">

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
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" CssClass="icon-edit" CommandArgument='<%#Bind("BusinessId") %>' OnClick="lnkEdit_Click" runat="server"></asp:LinkButton>                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

    <table class="table-form" id="formBusiness" runat="server" style="display: none;">
        <tr>
            <td class="label" style="width:20%;">Business Type:</td>
            <td  style="width:30%;">
                <asp:TextBox ID="txtBusinessType" runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width:20%;">Name:</td>
            <td  style="width:30%;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">Type:</td>
            <td>
                <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Known" Value="Known" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Unknown" Value="Unknown"></asp:ListItem>
                    <asp:ListItem Text="Douted" Value="Douted"></asp:ListItem>
                    <asp:ListItem Text="Share" Value="Share"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>

                 <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" />
            </td>
            
        </tr>

        
    </table>
    <asp:HiddenField ID="hdnBusinessId" runat="server" Value="0" />
    <script type="text/javascript">
        function showForm() {
            $("[id$='formBusiness']").show();
            $("[id$='divBusiness']").hide();

            $("[id$='formBusiness'] input[text]").val("");
            $("[id$='hdnBusinessId']").val("0");
        }
    </script>
</asp:Content>

