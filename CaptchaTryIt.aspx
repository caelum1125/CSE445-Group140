<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaptchaTryIt.aspx.cs" Inherits="Captcha.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgCaptcha" runat="server" Width="150px" Height="50px"/>
            <asp:TextBox ID="txtCaptcha" runat="server" placeholder="Enter CAPTCHA text" Width="150px"></asp:TextBox>
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click"/>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <asp:Button ID="validateCaptcha" runat="server" Text="Enter" OnClick="btnValidate_Click"/>
        </div>
    </form>
</body>
</html>
