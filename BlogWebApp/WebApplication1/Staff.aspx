<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment6_2.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Welcome to the Staff Page</h1>

    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Enter Username"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Enter Password"></asp:TextBox>
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="LoginStaff" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="SVC Image Service"></asp:Label>
    <br />
    <asp:Label ID="lblStaffName" runat="server" Text="Staff Name"></asp:Label>
    <asp:FileUpload ID="fileUpload" runat="server" />
    <asp:TextBox ID="txtDescription" runat="server" Placeholder="Image Description"></asp:TextBox>
    <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" OnClick="UploadImage" />
    <asp:Image ID="imgControl" runat="server" />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
    <asp:Image ID="imgStaffProfile" runat="server" AlternateText="Staff Profile Image" Width="150px" Height="150px" />
    <asp:Label ID="lblUploadStatus" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="User Session Management"></asp:Label>
        <div>
        </div>
    </form>
</body>
</html>
