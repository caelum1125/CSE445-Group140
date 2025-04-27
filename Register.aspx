<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MemberLoginPage.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Registration</title>
    <style>
        body { font-family: Arial; margin: 20px; }
        .register-container { max-width: 400px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 5px; }
        .form-group { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; font-weight: bold; }
        input[type="text"], input[type="password"] { width: 100%; padding: 8px; box-sizing: border-box; }
        .btn { background: #4CAF50; color: white; padding: 10px 15px; border: none; cursor: pointer; }
        .error { color: red; }
        .success { color: green; }
        .password-rules { font-size: 0.9em; color: #666; margin-top: 5px; }
    </style>
</head>
<body>
    <div class="register-container">
        <h2>Member Registration</h2>
        <form id="form1" runat="server">
            <div class="form-group">
                <label>Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="true"></asp:TextBox>
                <div class="password-rules">(Must be at least 8 characters with 1 uppercase, 1 number, and 1 special character)</div>
            </div>
            <div class="form-group">
                <label>Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" required="true"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
            <asp:Label ID="lblSuccess" runat="server" CssClass="success"></asp:Label>
        </form>
    </div>
</body>
</html>
