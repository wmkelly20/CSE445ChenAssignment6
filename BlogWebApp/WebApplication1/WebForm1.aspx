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

        <div>
            <h3>Create a New Article</h3>
            <asp:TextBox ID="txtTitle" runat="server" Placeholder="Title"></asp:TextBox><br />
            <asp:TextBox ID="txtAuthor" runat="server" Placeholder="Author"></asp:TextBox><br />
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" Placeholder="Content"></asp:TextBox><br />
            <asp:TextBox ID="txtTags" runat="server" Placeholder="Tags (comma-separated)"></asp:TextBox><br />
            <asp:TextBox ID="txtImageLink" runat="server" Placeholder="Image Link"></asp:TextBox><br />
            <asp:Button ID="btnCreateArticle" runat="server" Text="Create Article" OnClick="btnCreateArticle_Click" />
            <asp:Label ID="lblCreateArticleResult" runat="server" Text=""></asp:Label>
        </div>
        <hr />
        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
   
    </form>
</body>
</html>
