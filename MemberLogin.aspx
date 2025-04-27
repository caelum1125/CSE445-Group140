<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="MemberLoginPage.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Login</title>
    <style>
        body { font-family: Arial; margin: 20px; }
        .login-container { max-width: 400px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 5px; }
        .form-group { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; font-weight: bold; }
        input[type="text"], input[type="password"] { width: 100%; padding: 8px; box-sizing: border-box; }
        .btn { background: #4CAF50; color: white; padding: 10px 15px; border: none; cursor: pointer; }
        .error { color: red; }
    </style>
</head>
<body>
    <div class="login-container">
        <h2>Member Login</h2>
        <form id="form1" runat="server">
            <div class="form-group">
                <label>Username:</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
        </form>
    </div>
</body>
</html>