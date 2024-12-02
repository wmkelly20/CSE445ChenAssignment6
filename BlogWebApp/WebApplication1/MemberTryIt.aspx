<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberTryIt.aspx.cs" Inherits="Assignment4.MemberTryIt" %>
<%@ Register Src="~/CaptchaControl.ascx" TagName="CaptchaControl" TagPrefix="uc" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Article Management</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            display: flex;
            justify-content: center;
            padding-top: 50px;
            margin: 0;
        }
        .main-container {
            display: flex;
            flex-direction: column;
            gap: 20px;
            max-width: 1000px;
            width: 100%;
        }
        .container {
            width: 100%;
            background-color: #fff;
            padding: 20px;
            box-sizing: border-box;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }
        .form-group {
            margin: 10px 0;
            box-sizing: border-box;
        }
        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }
        .input-field, .button {
            width: 100%;
            padding: 8px;
            font-size: 1em;
            box-sizing: border-box;
        }
        .button-container {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            justify-content: space-between;
        }
        .button {
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            flex: 1 1 30%;
            min-width: 100px;
        }
        .button:hover {
            background-color: #0056b3;
        }
        .status-label {
            color: green;
            font-weight: bold;
            text-align: center;
            display: block;
            margin-top: 10px;
        }
        .grid-container {
            margin-top: 20px;
        }
        .grid-container h3 {
            text-align: center;
            color: #333;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
             <div class="container">
                <h2>CAPTCHA Demo</h2>
                <uc:CaptchaControl ID="CaptchaControl" runat="server" />

                <asp:Button ID="BtnValidateCaptcha" runat="server" Text="Validate CAPTCHA" OnClick="BtnValidateCaptcha_Click" />
                <asp:Label ID="LblCaptchaResult" runat="server" ForeColor="Red" />
            </div>

            <!-- XML-based CRUD Section -->
            <div class="container">
                <h2>XML Article Management</h2>
                <div class="form-group">
                    <label for="TxtArticleId">Article ID (for Update/Delete):</label>
                    <asp:TextBox ID="TxtArticleId" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtTitle">Title:</label>
                    <asp:TextBox ID="TxtTitle" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtAuthorGuid">Author ID:</label>
                    <asp:TextBox ID="TxtAuthorGuid" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtAuthor">Author Name:</label>
                    <asp:TextBox ID="TxtAuthor" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtContent">Content:</label>
                    <asp:TextBox ID="TxtContent" TextMode="MultiLine" Rows="4" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtTags">Tags (comma-separated):</label>
                    <asp:TextBox ID="TxtTags" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtImageLink">Image Link:</label>
                    <asp:TextBox ID="TxtImageLink" runat="server" CssClass="input-field" />
                </div>
                <div class="button-container">
                    <asp:Button ID="BtnCreate" runat="server" Text="Create Article" CssClass="button" OnClick="BtnCreate_Click" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update Article" CssClass="button" OnClick="BtnUpdate_Click" />
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete Article" CssClass="button" OnClick="BtnDelete_Click" />
                </div>
                <asp:Label ID="LblStatus" runat="server" CssClass="status-label"></asp:Label>
                <div class="grid-container">
                    <h3>Existing Articles</h3>
                    <asp:GridView ID="GvArticles" runat="server" AutoGenerateColumns="true" CssClass="input-field" />
                </div>
            </div>

            <!-- WCF Service Testing Section -->
            <div class="container">
                <h2>WCF Service Article Management</h2>
                <div class="form-group">
                    <label for="TxtServiceArticleId">Article ID (for Update/Delete):</label>
                    <asp:TextBox ID="TxtServiceArticleId" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtServiceTitle">Title:</label>
                    <asp:TextBox ID="TxtServiceTitle" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtServiceAuthor">Author Name:</label>
                    <asp:TextBox ID="TxtServiceAuthor" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtServiceContent">Content:</label>
                    <asp:TextBox ID="TxtServiceContent" TextMode="MultiLine" Rows="4" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtServiceTags">Tags (comma-separated):</label>
                    <asp:TextBox ID="TxtServiceTags" runat="server" CssClass="input-field" />
                </div>
                <div class="form-group">
                    <label for="TxtServiceImageLink">Image Link:</label>
                    <asp:TextBox ID="TxtServiceImageLink" runat="server" CssClass="input-field" />
                </div>
                <div class="button-container">
                    <asp:Button ID="BtnServiceCreate" runat="server" Text="Create Article (Service)" CssClass="button" OnClick="BtnServiceCreate_Click" />
                    <asp:Button ID="BtnServiceUpdate" runat="server" Text="Update Article (Service)" CssClass="button" OnClick="BtnServiceUpdate_Click" />
                    <asp:Button ID="BtnServiceDelete" runat="server" Text="Delete Article (Service)" CssClass="button" OnClick="BtnServiceDelete_Click" />
                    <asp:Button ID="BtnServiceGetAll" runat="server" Text="Get All Articles (Service)" CssClass="button" OnClick="BtnServiceGetAll_Click" />
                </div>
                <asp:Label ID="LblServiceStatus" runat="server" CssClass="status-label"></asp:Label>
                <div class="grid-container">
                    <h3>Service Articles</h3>
                    <asp:GridView ID="GvServiceArticles" runat="server" AutoGenerateColumns="true" CssClass="input-field" />
                </div>
            </div>

            <!-- Cookies Testing Section -->
             <div class="container">
                <h2>User Preferences</h2>
                <div class="form-group">
                    <label for="themeDropdown">Theme:</label>
                    <asp:DropDownList ID="themeDropdown" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Light">Light</asp:ListItem>
                        <asp:ListItem Value="Dark">Dark</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="languageDropdown">Language:</label>
                    <asp:DropDownList ID="languageDropdown" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="English">English</asp:ListItem>
                        <asp:ListItem Value="Spanish">Spanish</asp:ListItem>
                        <asp:ListItem Value="French">French</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="button-container">
                    <asp:Button ID="btnSavePreferences" runat="server" Text="Save Preferences" CssClass="button" OnClick="btnSavePreferences_Click" />
                </div>
                <asp:Label ID="LblPreferenceStatus" runat="server" CssClass="status-label"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
