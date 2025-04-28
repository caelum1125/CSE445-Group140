using System;
using System.Web.UI;

namespace Assign5Mem3
{
    public partial class WelcomeMessage : System.Web.UI.UserControl
    {
        //triggered when page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            //get current username
            string user = SessionManager.GetUser();
            //displays greeting
            lblWelcome.Text = !string.IsNullOrEmpty(user) ? string.Format("Welcome, {0}!", user) : "Welcome, Guest!";

        }
    }
}
