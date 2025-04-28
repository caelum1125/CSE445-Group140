<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RSTryIt.aspx.cs" Inherits="Assign5Mem3.RSTryIt" %>
<%@ Register Src="~/WelcomeMessage.ascx" TagName="WelcomeMessage" TagPrefix="uc" %>

<html>
<body>
    <form id="form1" runat="server">
        <uc:WelcomeMessage runat="server" ID="ucWelcome" />
        <br /><br />
        <asp:TextBox ID="txtInput" runat="server" />
        <asp:Button ID="btnReverse" runat="server" Text="Reverse String" OnClick="btnReverse_Click" />
        <asp:Label ID="lblResult" runat="server" />
        <br /><br />
        <asp:Button ID="btnSetSession" runat="server" Text="Set Session" OnClick="btnSetSession_Click" />
    </form>
</body>
</html>