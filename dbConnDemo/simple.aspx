<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="simple.aspx.cs" Inherits="dbConnDemo.simple" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td style="width: 161px">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 161px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 161px">
                Customer ID</td>
            <td>
                <asp:Label ID="lblCustomerId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 161px">
                Customer Name</td>
            <td>
                <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 161px">
                Country</td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 161px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select " />
                <asp:Button ID="btnTestObject" runat="server" OnClick="btnTestObject_Click" Text="Test Object" />
                <br />
                <br />
                <asp:GridView ID="gvContact" runat="server">
                </asp:GridView>
                <br />
                <br />
                <asp:GridView ID="gvSolder" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
