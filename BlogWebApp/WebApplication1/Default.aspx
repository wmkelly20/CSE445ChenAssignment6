<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogWebApp.Default" %>
<%@ Register TagPrefix="uc1" TagName="LoginControl" Src="~/LoginControl.ascx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TryIt Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>TryIt Page</h2>
            <h3>Test Services and Components</h3>
            
            <!-- Service Directory Table -->
            <table border="1" style="width: 100%; border-collapse: collapse;">
                <thead>
                    <tr>
                        <th>Component</th>
                        <th>Description</th>
                        <th>Test Link</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Password Hashing</td>
                        <td>Encrypts or hashes passwords</td>
                        <td><a href="WebForm1.aspx">Test Hashing</a></td>
                    </tr>
                    <tr>
                        <td>Article Retrieval Service</td>
                        <td>Fetches articles based on category</td>
                        <td><a href="WebForm1.aspx">Test Article Retrieval</a></td>
                    </tr>
                    <tr>
                        <td>Member Services</td>
                        <td>Tests member-specific services (CAPTCHA, Article Management, Preferences)</td>
                        <td><a href="MemberTryIt.aspx">Test Member Services</a></td>
                    </tr>
                    <tr>
                        <td>Login Functionality</td>
                        <td>Tests login with user credentials (User: admin | Pass: password)</td>
                        <td>
                            <uc1:LoginControl ID="LoginControl" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Staff Services</td>
                        <td>Tests staff-related functionality and operations</td>
                        <td><a href="Staff.aspx">Test Staff Services</a></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
