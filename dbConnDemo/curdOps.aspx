<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="curdOps.aspx.cs" Inherits="dbConnDemo.curdOps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Contact ID</td>
            <td>
                <asp:TextBox ID="txtContactId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Name</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Cell</td>
            <td>
                <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Country</td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Department</td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select " />
                <br />
                <br />
                <asp:GridView ID="gvContact" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
