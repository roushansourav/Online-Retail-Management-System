using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Session["UserId"] = Session["UserId"] != null ? Session["UserId"] : rnd.Next(1, 2345); 
            Session["Name"] = Session["Name"] != null ? Session["Name"] : null;
            Session["Username"] = Session["Username"] != null ? Session["Username"] : null;
            Session["Role"] = Session["Role"] != null ? Session["Role"] : "guest";
            Session["CartId"] = Session["CartId"] != null ? Session["CartId"] : rnd.Next(2346, 9999);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}