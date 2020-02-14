<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Children.aspx.cs" Inherits="Candidates_Children" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="div-top-heading">
        <div class="div-heading">Children Information  </div>
        <div class="div-msg">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <div class="top-link">
            <input type="button" onclick="showForm()" class="btn" value="Add Children" />
        </div>
    </div>
    <div id="divChildren" runat="server" style="padding-top: 10px;">

        <asp:GridView ID="grdChildren" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%#Bind("Gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PoliticalAge">
                    <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server" Text='<%#Bind("Age") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Education">
                    <ItemTemplate>
                        <asp:Label ID="lblEducation" runat="server" Text='<%#Bind("Education") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Current Location">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentLocation" runat="server" Text='<%#Bind("CurrentLocation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Political Affiliation">
                    <ItemTemplate>
                        <asp:Label ID="lblPoliticalAffiliation" runat="server" Text='<%#Bind("PoliticalAffiliation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" CssClass="icon-edit" CommandArgument='<%#Bind("Childid") %>' OnClick="lnkEdit_Click" runat="server"></asp:LinkButton>                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

    <table class="table-form" id="formChildren" runat="server" style="display: none;">
        <tr>
            <td class="label" style="width:20%;">Name:</td>
            <td  style="width:30%;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td class="label"  style="width:20%;">Education:</td>
            <td  style="width:30%;">
                <asp:TextBox ID="txtEducation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="label">Gender:</td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Text="Son" Value="Son"></asp:ListItem>
                    <asp:ListItem Text="Daughter" Value="Daughter"></asp:ListItem>
                </asp:DropDownList>
            </td>
             <td class="label">Age:</td>
            <td>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="label">Current Location:</td>
            <td>
                <asp:TextBox ID="txtCurrentLocation" runat="server"></asp:TextBox>
            </td>
            <td class="label">Political Affiliation:</td>
            <td>
                <asp:TextBox ID="txtPoliticalAffiliation" runat="server"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
              <td colspan="4" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnChildId" runat="server" Value="0" />
    <script type="text/javascript">
        function showForm() {
            $("[id$='formChildren']").show();
            $("[id$='divChildren']").hide();

            $("[id$='formChildren'] input[text]").val("");
            $("[id$='hdnChildId']").val("0");
        }
    </script>
</asp:Content>

