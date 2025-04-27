using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MemberLoginPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {


            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                // Successful login
                Session["Member"] = username;
                Response.Redirect("MemberWelcome.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password";
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            string filePath = Server.MapPath("~/Member.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Find user in XML
            XmlNode userNode = doc.SelectSingleNode($"/Members/Member[Username='{username}']");
            if (userNode != null)
            {
                string storedHash = userNode.SelectSingleNode("Password").InnerText;
                string salt = userNode.SelectSingleNode("Salt").InnerText;

                // Hash the provided password with salt
                string inputHash = HashPassword(password + salt);

                // Compare hashes
                return storedHash.Equals(inputHash);
            }
            return false;
        }

        public static string HashPassword(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}