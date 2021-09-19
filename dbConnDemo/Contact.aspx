<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="dbConnDemo.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style/form.css" rel="stylesheet" />
    <p>
        <br />
    </p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="name" DataValueField="contactId">
        </asp:DropDownList>

    </p>
    <p>
        <asp:DropDownList ID="ddlContact" runat="server">
        </asp:DropDownList>
    </p>
    <p>
    </p>
   
</asp:Content>
