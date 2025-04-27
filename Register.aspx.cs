using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MemberLoginPage
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {


            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validation
            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match!";
                return;
            }

            if (!IsPasswordValid(password))
            {
                lblMessage.Text = "Password must be at least 8 characters with 1 uppercase, 1 number, and 1 special character";
                return;
            }

            if (UserExists(username))
            {
                lblMessage.Text = "Username already exists!";
                return;
            }

            // Generate salt and hash password
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password + salt);

            // Save to XML
            if (RegisterUser(username, hashedPassword, salt))
            {
                lblSuccess.Text = "Registration successful! Please login.";
                lblMessage.Text = "";
                ClearForm();
                Response.Redirect("MemberLogin.aspx");
            }
            else
            {
                lblMessage.Text = "Registration failed. Please try again.";
            }
        }

        private bool IsPasswordValid(string password)
        {
            // At least 8 chars, 1 uppercase, 1 number, 1 special char
            var regex = new Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
            return regex.IsMatch(password);
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
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

        private bool UserExists(string username)
        {
            string filePath = Server.MapPath("~/Member.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return doc.SelectSingleNode($"/Members/Member[Username='{username}']") != null;
        }

        private bool RegisterUser(string username, string hashedPassword, string salt)
        {
            try
            {
                string filePath = Server.MapPath("~/Member.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNode newMember = doc.CreateElement("Member");

                XmlNode usernameNode = doc.CreateElement("Username");
                usernameNode.InnerText = username;
                newMember.AppendChild(usernameNode);

                XmlNode passwordNode = doc.CreateElement("Password");
                passwordNode.InnerText = hashedPassword;
                newMember.AppendChild(passwordNode);

                XmlNode saltNode = doc.CreateElement("Salt");
                saltNode.InnerText = salt;
                newMember.AppendChild(saltNode);

                XmlNode dateNode = doc.CreateElement("JoinDate");
                dateNode.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                newMember.AppendChild(dateNode);

                doc.DocumentElement.AppendChild(newMember);
                doc.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                // Log error (ex)
                return false;
            }
        }

        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}