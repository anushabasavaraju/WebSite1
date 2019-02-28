<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyProfilePage.aspx.cs" Inherits="MyProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
    <p>
        Your care profile includes your personal information, care team, and allergies you&#39;ve reported to your doctor.</p>
    <p>
        &nbsp;</p>
    First Name:&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Gender:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Birthday: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Race:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Ethinicity:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Smoking:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Language:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
</asp:Content>

