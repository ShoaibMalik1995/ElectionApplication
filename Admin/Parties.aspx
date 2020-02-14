<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Parties.aspx.cs" Inherits="Admin_Parties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <h1>Add/Edit Parties
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
     <table class="table-form">

        <tr>
            <td class="label" style="width: 20%" >Party Name:</td>
            <td style="width: 30%">
                <asp:TextBox ID="txtPartyName" runat="server"></asp:TextBox>
            </td>
            <td class="label" style="width: 20%">Chairman:</td>
            <td style="width: 30%">
                <asp:TextBox ID="TxtChairman" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="label">Registration Date:</td>
            <td>
                <asp:TextBox ID="txtRegistrationDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td class="label">Reg #:</td>
            <td>
                <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td class="label">Party Sadar:</td>
            <td>
                <asp:TextBox ID="Partyoff" runat="server"></asp:TextBox>
            </td>
            <td class="label">Logo:</td>
            <td>
                <asp:FileUpload ID="picUpload" runat="server" />
                
            </td>

        </tr>



        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Save" CssClass="btn" runat="server" OnClick="btn_save_Click" />
                 <asp:Button CausesValidation="false"  ID="btnUpdate" Visible="false" ValidationGroup="validate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>

            <td align="center" colspan="4">
                <div style="padding-top:10px;">
                <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CssClass="table-bordered table-striped" Width="100%" OnRowDataBound="GridView1_RowDataBound"> 
                    <Columns>
                        <asp:TemplateField HeaderText="Ser">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Chairmain">
                            <ItemTemplate>
                                <asp:Label ID="lblChairmain" runat="server" Text='<%#Bind("Chairmain") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Registration Date">
                            <ItemTemplate>
                                <asp:Label ID="lblRegistrationDate" runat="server" Text='<%#Bind("RegistrationDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party No">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyNo" runat="server" Text='<%#Bind("PartyNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party Off">
                            <ItemTemplate>
                                <asp:Label ID="lblPartyOff" runat="server" Text='<%#Bind("PartyOff") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Party Logo">
                                 <ItemTemplate>
                                    <asp:Image ID="lblLogo" Width="50px" Height="50px" ImageUrl='<%# Bind("Logo") %>' runat="server" />
                                      <asp:HiddenField ID="hfvalue" runat="server" Value='<%# Bind("Partyid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                         <asp:TemplateField HeaderText="Edit Record">
                               <ItemTemplate>
                                 <asp:LinkButton CausesValidation="false" ID="lnkbtnedit" Text="Edit" CommandName='<%# Bind("Partyid") %>' runat="server" OnClick="lnkbtnedit_Click" > </asp:LinkButton>
                           </ItemTemplate>
                              </asp:TemplateField>
           
                               <asp:TemplateField HeaderText="Delete Record">
                  <ItemTemplate>
                    <asp:LinkButton ID="del" CausesValidation="false" Text="Delete" CommandName='<%# Bind("Partyid") %>' runat="server" OnClick="deleteRecord" > </asp:LinkButton>
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

