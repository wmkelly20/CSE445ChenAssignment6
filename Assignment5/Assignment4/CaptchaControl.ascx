<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaControl.ascx.cs" Inherits="BlogWebApp.CaptchaControl" %>
<div>
    <asp:Image ID="ImgCaptcha" runat="server" />
    <asp:TextBox ID="TxtCaptchaAnswer" runat="server" placeholder="Enter CAPTCHA" />
    <asp:Button ID="BtnRefreshCaptcha" runat="server" Text="Refresh" OnClick="BtnRefreshCaptcha_Click" />
</div>
