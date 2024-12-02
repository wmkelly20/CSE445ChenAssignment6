<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment6_2.Staff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard - Medium Clone</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #fafafa;
        }
        .nav {
            background-color: #ffffff;
            border-bottom: 1px solid #e0e0e0;
            padding: 15px 20px;
            position: fixed;
            width: 100%;
            top: 0;
            z-index: 999;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .nav .logo {
            font-size: 24px;
            font-weight: bold;
            color: #02b875;
        }

        .nav ul {
            list-style: none;
            margin: 0;
            padding: 0;
            display: flex;
        }

        .nav ul li {
            margin-left: 20px;
        }

        .nav ul li a {
            text-decoration: none;
            color: #333;
            font-weight: 500;
        }

        .sidebar {
            width: 200px;
            background-color: #ffffff;
            position: fixed;
            top: 60px;
            bottom: 0;
            padding: 20px;
            border-right: 1px solid #e0e0e0;
        }

        .sidebar ul {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .sidebar ul li {
            margin-bottom: 20px;
        }

        .sidebar ul li a {
            text-decoration: none;
            color: #555;
            font-size: 16px;
        }

        .sidebar ul li a:hover {
            color: #02b875;
        }

        .main-content {
            margin-left: 220px;
            padding: 80px 20px 20px 20px;
        }

        .dashboard-card {
            background-color: #ffffff;
            border: 1px solid #e0e0e0;
            padding: 20px;
            margin-bottom: 20px;
            border-radius: 4px;
        }

        .dashboard-card h2 {
            margin-top: 0;
            font-size: 22px;
            color: #333;
        }

        .login-container {
            width: 300px;
            margin: 150px auto;
            padding: 30px;
            background-color: #ffffff;
            border: 1px solid #e0e0e0;
            border-radius: 4px;
        }

        .login-container h2 {
            text-align: center;
            margin-bottom: 30px;
            color: #333;
        }

        .login-container .input-group {
            margin-bottom: 20px;
        }

        .login-container .input-group label {
            display: block;
            margin-bottom: 5px;
            color: #555;
        }

        .login-container .input-group input {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
            border: 1px solid #e0e0e0;
            border-radius: 4px;
        }

        .login-container .input-group button {
            width: 100%;
            padding: 12px;
            background-color: #02b875;
            color: #ffffff;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        .login-container .input-group button:hover {
            background-color: #029f5b;
        }

        .error-message {
            color: red;
            text-align: center;
            margin-bottom: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <% if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"]) { %>
            <div class="nav">
                <div class="logo">Medium Clone Admin</div>
                <ul>
                    <li><a href="#" onclick="document.getElementById('<%= btnLogout.ClientID %>').click(); return false;">Logout</a></li>
                </ul>
            </div>

            <div class="sidebar">
                <ul>
                    <li><a href="#">Dashboard</a></li>
                    <li><a href="#">Stories</a></li>
                    <li><a href="#">Stats</a></li>
                    <li><a href="#">Comments</a></li>
                    <li><a href="#">Users</a></li>
                    <li><a href="#">Settings</a></li>
                </ul>
            </div>

            <div class="main-content">
                <h1>Dashboard</h1>
                <div class="dashboard-card">
                    <h2>Total Stories</h2>
                    <p>42</p>
                </div>
                <div class="dashboard-card">
                    <h2>Total Views</h2>
                    <p>1,234</p>
                </div>
                <div class="dashboard-card">
                    <h2>New Comments</h2>
                    <p>12</p>
                </div>
            </div>

            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="Logout_Click" Style="display:none;" />
        <% } else { %>
            <div class="login-container">
                <h2>Admin Login</h2>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
                <div class="input-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Enter Username"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Enter Password"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click" />
                </div>
            </div>
        <% } %>
    </form>
</body>
</html>
