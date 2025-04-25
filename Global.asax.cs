using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FinalProject_WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // initialize a hit counter
            Application["Hits"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // bump that counter on every new session
            Application["Hits"] = (int)Application["Hits"] + 1;
        }

    }
}