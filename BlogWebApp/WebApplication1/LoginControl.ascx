<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="BlogWebApp.LoginControl" %>
<div>
    <h3>Login</h3>
    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Enter username"></asp:TextBox><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Enter password"></asp:TextBox><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>
