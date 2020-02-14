<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddTehsil.aspx.cs" Inherits="Admin_AddTehsil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Add Tehsil
       
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">
        <tr>
            <td class="label" style="width: 20%;">PA :</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="DDL_PA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_PA_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Name :</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtTehsil" runat="server" Text=""></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <div style="padding-top: 10px">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="50%">
                        <Columns>
                            <asp:TemplateField HeaderText="SR #">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Tehsil Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete Record">
                                <ItemTemplate>
                                    <asp:LinkButton ID="del" CausesValidation="false" CssClass="icon-delete" CommandName='<%# Bind("TehsilId") %>' runat="server" OnClick="deleteRecord"> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center"  />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>

        </tr>
    </table>
</asp:Content>

