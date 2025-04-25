using System;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace FinalProject_WebApp
{
    [WebService(Namespace = "http://cse445.memberA")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AuthUtilityService : WebService
    {
        [WebMethod(Description = "Returns a password‑strength score 0–5")]
        public int CheckStrength(string password)
        {
            int score = 0;
            if (password.Length >= 8) score++;
            if (Regex.IsMatch(password, "[A-Z]")) score++;
            if (Regex.IsMatch(password, "[a-z]")) score++;
            if (Regex.IsMatch(password, "[0-9]")) score++;
            if (Regex.IsMatch(password, "[^A-Za-z0-9]")) score++;
            return score;
        }
    }
}
