using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Any initialization code if needed
        }

        protected void btnLoginTest_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginTest.aspx");
        }
    }
}