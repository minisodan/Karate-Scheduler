<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InstructorPage.aspx.cs" Inherits="CSCI213.InstructorInfo.InstructorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Hi,
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
<p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</p>
<p>
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
</p>
</asp:Content>
