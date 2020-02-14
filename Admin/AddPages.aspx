<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddPages.aspx.cs" Inherits="Admin_AddPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>Add Pages
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
      <table class="table-form">
        <tr>
            <td class="label" style="width: 40%;">Module:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtModule" runat="server"  ></asp:TextBox>
            
            <td colspan="0" style="text-align: left;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click"  />
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
     
     <tr>
            <td class="label" style="width: 30%;">Module:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ddlModule_Click" ></asp:DropDownList>
            </td>
    
    </tr>

    <tr>
            <td class="label" style="width: 30%;">Page Name:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
            </td>
        </tr>
                <tr>
         <td class="label" style="width: 30%;">Page Url:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtPageUrl" runat="server"></asp:TextBox>
         </td>
                    </tr>
    
    </tr>
          <tr>
              <td colspan="15" style="text-align: center;">
                <asp:Button ID="btnAddPages" Text="Add Page" CssClass="btn" runat="server" OnClick="btn_AddModule_Click"  />
                   <asp:Button CausesValidation="false" ID="btnUpdate" Visible="false" ValidationGroup="validate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
          </tr>
          <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Module Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblModule_Name" runat="server" Text='<%#Bind("Module_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Page Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPage_Name" runat="server" Text='<%#Bind("Page_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Page URL">
                                <ItemTemplate>
                                    <asp:Label ID="lblPage_URL" runat="server" Text='<%#Bind("Page_URL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            

                            <asp:TemplateField HeaderText="Edit Record">
                                <ItemTemplate>
                                    <asp:LinkButton CausesValidation="false" ID="lnkbtnedit" Text="Edit" CommandName='<%# Bind("Page_ID") %>' runat="server" OnClick="lnkbtnedit_Click"> </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete Record">
                                <ItemTemplate>
                                    <asp:LinkButton ID="del" CausesValidation="false" Text="Delete" CommandName='<%# Bind("Page_ID") %>' runat="server" OnClick="deleteRecord"> </asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hdID" runat="server" />
                </div>
            </td>
        </tr>
     </table>
</asp:Content>

