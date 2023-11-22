<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="CSCI213.AdminInfo.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
        .auto-style15 {
            width: 245px;
        }
        .auto-style16 {
            width: 524px;
        }
        .auto-style17 {
            width: 61%;
        }
        .auto-style18 {
            width: 245px;
            height: 29px;
        }
        .auto-style19 {
            width: 524px;
            height: 29px;
        }
        .auto-style20 {
            width: 936px;
            height: 311px;
        }
        .auto-style22 {
            width: 58%;
        }
        .auto-style23 {
            width: 338px;
        }
        .auto-style24 {
            width: 188px;
        }
        .auto-style25 {
            width: 245px;
            height: 26px;
        }
        .auto-style26 {
            width: 524px;
            height: 26px;
        }
        .auto-style27 {
            margin-left: 40px;
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
        <strong>Add a new user:</strong></p>
    <p>
        Set Username:
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
    <div id="memberDiv" aria-hidden="False" class="auto-style20">
        <table class="auto-style17">
            <tr>
                <td class="auto-style18"><strong>Add New Member:</strong></td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">Member ID:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Member First Name:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Member Last Name:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Member Phone Number:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Member Email:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style25">Date Joined:</td>
                <td class="auto-style26">
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Add to Section:</td>
                <td class="auto-style16">
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="17px" Width="163px">
                        <asp:ListItem>Karate Age-Uke</asp:ListItem>
                        <asp:ListItem>Karate Chudan-Uke</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Instructor name</td>
                <td class="auto-style16">
                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
<<<<<<< HEAD
                <td class="auto-style15">Section price:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
=======
>>>>>>> master
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style16">
    <asp:Button ID="Button1" runat="server" Height="58px" OnClick="Button1_Click" Text="Add New Member" Width="205px" />
                </td>
            </tr>
        </table>
    </div>
    <p>
        &nbsp;&nbsp;</p>
<<<<<<< HEAD
    <p>
        &nbsp;</p>
=======
>>>>>>> master
    <div aria-hidden="False">
        <table id="instructorDiv" class="auto-style22">
            <tr>
                <td class="auto-style24"><strong>Add New Instructor:</strong></td>
                <td class="auto-style23">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">Instructor ID:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Instructor First Name:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Instructor Last Name:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Instructor Phone Number:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style23">
    <asp:Button ID="Button2" runat="server" Height="56px" Text="Add New Instructor" Width="195px" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
    </div>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Refresh" Width="129px" />
    </p>
    <p>
        <strong>Delete a Member:</strong></p>
    <p>
        <table class="auto-style11">
            <tr>
                <td class="auto-style9">Member user name:</td>
                <td class="auto-style10">
                    &nbsp;<asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" Height="43px" OnClick="Button4_Click" Text="Button" Width="189px" />
    </p>
    <p>
<<<<<<< HEAD
=======
        Section ID:
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
    </p>
    <p>
>>>>>>> master
        <strong>Delete an Instructor:</strong></p>
    <p>
        <table class="auto-style12">
            <tr>
                <td class="auto-style14">Instructor ID:</td>
                <td class="auto-style13">
                    <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </p>
    <p class="auto-style27">
        <asp:Button ID="Button5" runat="server" Height="43px" OnClick="Button5_Click" Text="Button" Width="189px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
