<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="DemoStringbuilder.Insert" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <h1>Contact Information</h1>

    <table class="w-100">
        <tr>
            <td style="width: 277px">ID</td>
            <td>
                <asp:TextBox ID="id" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr> 
            <td style="width: 277px">Name</td>
            <td>
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 277px">Address</td>
            <td>
                <asp:TextBox ID="add" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 277px">Age</td>
            <td>
                <asp:TextBox ID="age" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 277px">Salary</td>
            <td>
                <asp:TextBox ID="sal" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 277px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            </td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hiddenFieldEditID" runat="server" />

    

</asp:Content>


