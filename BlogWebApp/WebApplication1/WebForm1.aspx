<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BlogWebApp.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blog WebApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Hash a Password</h3>
            <asp:TextBox ID="txtPassword" runat="server" Placeholder="Enter password"></asp:TextBox>
            <asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" />
            <asp:Label ID="lblHashResult" runat="server"></asp:Label>
        </div>

        <div>
            <h3>Retrieve Articles (example: money)</h3>
            <asp:TextBox ID="txtCategory" runat="server" Placeholder="Enter category"></asp:TextBox>
            <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" />
        </div>
    </form>
</body>
</html>
