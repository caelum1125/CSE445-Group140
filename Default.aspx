<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="FinalProject_WebApp.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Final Project Demo – Assignment 5</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        table { border-collapse: collapse; width: 100%; margin-bottom: 20px; }
        th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }
        h2, h3 { color: #2a6ebb; }
        .result { margin-left: 10px; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 1) Intro -->
        <h2>My CSE445 Final Project Prototype</h2>
        <p>
            This demo shows all required components for Assignment 5:<br />
            local components, a personal Web service, and integration.
        </p>

        <!-- 2) Service Directory -->
        <!-- 2) Service / Component Directory -->
<h3>Service / Component Directory</h3>
<table border="1" cellpadding="4" cellspacing="0">
  <tr>
    <th>Provider Name</th>
    <th>Component Type</th>
    <th>Inputs</th>
    <th>Outputs</th>
    <th>Description</th>
    <th>Usage / Try‑It Link</th>
  </tr>
  <tr>
    <td>Caelum Terrell</td>
    <td>Global.asax</td>
    <td>Application_Start, Session_Start</td>
    <td>None</td>
    <td>Increments visitor count on application &amp; session start</td>
    <td>Directory table on this page</td>
  </tr>
  <tr>
    <td>Caelum Terrell</td>
    <td>Cookie Helper (App_Code\CookieHelper.cs)</td>
    <td>color (string)</td>
    <td>Sets “ThemeColor” HTTP cookie</td>
    <td>Persists selected theme color for 14 days</td>
    <td>Directory table on this page</td>
  </tr>
  <tr>
    <td>Caelum Terrell</td>
    <td>ASMX Web Service (AuthUtilityService.asmx)</td>
    <td>password (string)</td>
    <td>score (int)</td>
    <td>Evaluates password strength, returning 0–4</td>
    <td>
      <a href="https://webstrar.asu.edu/~a22807/FinalProject_WebApp/AuthUtilityService.asmx?op=CheckStrength"
         target="_blank">CheckStrength</a>
    </td>
  </tr>
</table>


        <!-- 3) Try‑It Demos -->
        <h3>Try‑It Demos</h3>

        <!-- 3a) Password strength (Web service) -->
        <asp:Panel runat="server" ID="pnlStrength">
            <b>Check password strength:</b><br />
            <asp:TextBox runat="server" ID="txtPwd" Width="200px" />
            <asp:Button runat="server" ID="BtnCheck" Text="Check" OnClick="BtnCheck_Click" />
            <asp:Label runat="server" ID="lblScore" CssClass="result" />
        </asp:Panel>
        <hr />

        <!-- 3b) Theme cookie demo -->
        <asp:Panel runat="server" ID="pnlTheme">
            <b>Select Theme Color (saved to cookie):</b><br />
            <asp:DropDownList runat="server" ID="ddlTheme" Width="120px">
                <asp:ListItem>light</asp:ListItem>
                <asp:ListItem>dark</asp:ListItem>
            </asp:DropDownList>
            <asp:Button runat="server" ID="BtnSaveTheme" Text="Save Theme" OnClick="BtnSaveTheme_Click" />
            <asp:Label runat="server" ID="lblThemeMsg" CssClass="result" />
        </asp:Panel>
        <hr />

        <!-- 4) Navigation stubs -->
        <asp:Button runat="server" Text="Member Page (A6)" PostBackUrl="~/Member.aspx" />
        <asp:Button runat="server" Text="Staff Page (A6)" PostBackUrl="~/Staff.aspx" />

        <!-- 5) Hit counter display -->
        <p>
            <em>Total unique visits: <%: Application["Hits"] ?? 0 %></em>
        </p>

    </form>
</body>
</html>

