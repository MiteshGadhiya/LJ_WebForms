<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudents.aspx.cs" Inherits="WebFormDemo.AddStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="0" />
    <table>
        <tr>
            <td>
                Name
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender  
            </td>
            <td>
                <asp:RadioButtonList ID="rblGender" runat="server">
                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Country  
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                    <asp:ListItem Text="India" Value="1"></asp:ListItem>
                    <asp:ListItem Text="USA" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                State  
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server">                   
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Address  
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server">                   
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Institute Name  
            </td>
            <td>
                <asp:TextBox ID="txtInstituteName" runat="server">                   
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">                   
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>            
        </tr>
    </table>
</asp:Content>
