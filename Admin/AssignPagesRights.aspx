<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AssignPagesRights.aspx.cs" Inherits="Admin_AssignPagesRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>Assign Pages Rights
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
      <table class="table-form">
        <tr>
            <td class="label" style="width:10%;">User:</td>
            <td style="width: 10%;">
                <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" ></asp:DropDownList>
            </td>
            <td></td>
       </tr>
    <tr>
        <td class="label" style="width: 10%;">Module:</td>
        <td style="width: 10%;">
        <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="ddlModule_Click" ></asp:DropDownList>
        </td>
   </tr>
   <tr>
        <td class="label" style="width: 10%;">Pages:</td>
        <td style="width: 10%;">
        <asp:checkboxList ID="CBL" runat="server" AutoPostBack="true" ></asp:checkboxList>
        </td>
   </tr>

   
          <tr>
              <td colspan="15" style="text-align: center;">
               
                  <asp:Button ID="btn_UserPages" Text="Save" CssClass="btn" runat="server" OnClick="btn_UserPages_Click"  />
                  <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
                
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
                                    <asp:Label ID="LblUserName" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
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
                            

                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hdID" runat="server" />
                </div>
            </td>
        </tr>
     </table>
</asp:Content>

