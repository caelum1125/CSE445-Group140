using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_WebApp
{
    public static class CookieHelper
    {
        private const string THEME = "ThemeColor";

        public static void SetTheme(HttpResponse resp, string color)
        {
            var ck = new HttpCookie(THEME, color) { Expires = DateTime.Now.AddDays(14) };
            resp.Cookies.Add(ck);
        }
        public static string GetTheme(HttpRequest req) =>
            req.Cookies[THEME]?.Value ?? "light";
    }

}