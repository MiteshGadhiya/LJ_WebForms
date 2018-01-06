<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListStudents.aspx.cs" Inherits="WebFormDemo.ListStudents" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView ID="gvListStudent" runat="server" AutoGenerateColumns="false" OnRowCommand="gvListStudent_RowCommand" OnRowDeleting="gvListStudent_RowDeleting" OnRowEditing="gvListStudent_RowEditing">
        <Columns>
            <asp:BoundField ItemStyle-Width="150px" DataField="StudentName" HeaderText="Customer ID" />
            <asp:BoundField ItemStyle-Width="150px" DataField="Gender" HeaderText="Gender" />
            <asp:BoundField ItemStyle-Width="150px" DataField="CountryId" HeaderText="Country" />
            <asp:BoundField ItemStyle-Width="150px" DataField="StateId" HeaderText="State" />
            <asp:BoundField ItemStyle-Width="150px" DataField="Address" HeaderText="Address" />
            <asp:BoundField ItemStyle-Width="150px" DataField="InstituteName" HeaderText="Institute Name" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("StudentId") %>' CommandName="Edit"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("StudentId") %>' CommandName="Delete"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
