<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DLLTryIt.aspx.cs" Inherits="DLL.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtKey" runat="server" placeholder="Encryption Key"></asp:TextBox>
            <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" />
            <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" />
            <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click" />
            <asp:Button ID="btnGenerate" runat="server" Text="Generate Password" OnClick="btnGenerate_Click" />
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
