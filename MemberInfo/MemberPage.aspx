<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="CSCI213.MemberInfo.MemberPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Hi,
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
<p>
    &nbsp;</p>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    <br />
</p>
<p>
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>
