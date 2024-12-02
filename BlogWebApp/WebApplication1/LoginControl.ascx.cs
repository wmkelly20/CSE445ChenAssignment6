using System;

namespace BlogWebApp
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Hardcoded login credentials (replace with actual authentication logic later)
            if (username == "admin" && password == "password")
            {
                lblMessage.Text = "Login successful!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                // Redirect or perform post-login actions here
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}