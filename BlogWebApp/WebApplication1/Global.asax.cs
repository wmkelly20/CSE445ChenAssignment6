using System;
using System.Web;

namespace BlogWebApp
{
    public class Global : HttpApplication
    {
        // Triggered when the application starts
        protected void Application_Start(object sender, EventArgs e)
        {
            // Log or initialize global resources
            Application["AppStartCount"] = (int)(Application["AppStartCount"] ?? 0) + 1;
            System.Diagnostics.Debug.WriteLine("Application Started");
        }

        // Triggered when a new session starts
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["SessionStartTime"] = DateTime.Now;
            System.Diagnostics.Debug.WriteLine("New Session Started at: " + Session["SessionStartTime"]);
        }

        // Triggered when a session ends
        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session Ended. Start Time: " + Session["SessionStartTime"]);
        }

        // Triggered when an application error occurs
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            System.Diagnostics.Debug.WriteLine("Application Error: " + ex.Message);
        }
    }
}
