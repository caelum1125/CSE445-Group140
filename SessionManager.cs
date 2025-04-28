using System;
using System.Web;

namespace Assign5Mem3
{
    public static class SessionManager
    {
        //stores username and login time into current session
        public static void SetUserSession(string username)
        {
            HttpContext.Current.Session["Username"] = username;
            HttpContext.Current.Session["LoginTime"] = DateTime.Now;
        }

        //retrieves the stored username from current session
        public static string GetUser()
        {
            return HttpContext.Current.Session["Username"] as string;
        }

        //clears all session data
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}


