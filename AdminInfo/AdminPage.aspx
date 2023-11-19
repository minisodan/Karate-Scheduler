<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="CSCI213.AdminInfo.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 386px;
        }
        .auto-style2 {
            width: 593px;
        }
        .auto-style3 {
            width: 82%;
        }
        .auto-style4 {
            width: 502px;
        }
        .auto-style5 {
            width: 547px;
        }
        .auto-style9 {
            width: 113px;
        }
        .auto-style10 {
            width: 174px;
        }
        .auto-style11 {
            width: 25%;
        }
        .auto-style12 {
            width: 26%;
        }
        .auto-style13 {
            height: 26px;
        }
        .auto-style14 {
            height: 26px;
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Members:</p>
<p>
    <asp:GridView ID="memberGridView" runat="server">
    </asp:GridView>
</p>
<p>
    Instructors:</p>
<p>
    <asp:GridView ID="InstructorsGridView" runat="server">
    </asp:GridView>
</p>
    <p>
        Add a new user:</p>
    <p>
        set Username:
        <asp:TextBox ID="userName" runat="server"></asp:TextBox>
    </p>
    <p>
        Set Password: <asp:TextBox ID="password" runat="server"></asp:TextBox>
    </p>
    <p>
        Add a Type:
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="17px" Width="163px">
                        <asp:ListItem>Instructor</asp:ListItem>
                        <asp:ListItem>Memeber</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" Height="44px" OnClick="Button3_Click" Text="Set User " Width="167px" />
</p>
<p>
    Add new member:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add new Instructor:</p>
    <p>
        <table class="auto-style3">
            <tr>
                <td class="auto-style1">Member ID:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">Instructor ID:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Member First Name:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">Instructor First Name:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Member Last Name:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">Instructor Last Name:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Member Phone Number:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">Instructor Phone Number:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Member Email:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Date Joined:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Add to Section:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="17px" Width="163px">
                        <asp:ListItem>Karate Age-Uke</asp:ListItem>
                        <asp:ListItem>Karate Chudan-Uke</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
    </p>
<p>
    <asp:Button ID="Button1" runat="server" Height="58px" OnClick="Button1_Click" Text="Add New Member" Width="205px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Height="56px" Text="Add New Instructor" Width="195px" />
    </p>
    <p>
        Delete a Member:</p>
    <p>
        <table class="auto-style11">
            <tr>
                <td class="auto-style9">Member ID:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <p>
        Delete an Instructor:</p>
    <p>
        <table class="auto-style12">
            <tr>
                <td class="auto-style14">Instructor ID:</td>
                <td class="auto-style13">
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
