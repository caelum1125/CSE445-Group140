<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="StaffWebApp.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Staff Management</h2>

<asp:Label ID="lblUsername" runat="server" Text="Username:" />
<asp:TextBox ID="txtUsername" runat="server" /><br /><br />

<asp:Label ID="lblPassword" runat="server" Text="Password:" />
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />

<asp:Button ID="btnAddStaff" runat="server" Text="Add Staff" OnClick="btnAddStaff_Click" />
<asp:Button ID="btnViewStaff" runat="server" Text="View Staff" OnClick="btnViewStaff_Click" /><br /><br />

<asp:Label ID="lblResult" runat="server" ForeColor="Green" /><br />

<asp:GridView ID="GridViewStaff" runat="server" AutoGenerateColumns="true"></asp:GridView>
        <div>
        </div>
    </form>
</body>
</html>
