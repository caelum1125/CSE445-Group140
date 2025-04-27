using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecurityLibrary; // Reference your DLL namespace

namespace DLL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHash_Click(object sender, EventArgs e)
        {
            lblResult.Text = SecurityHelper.HashPassword(txtInput.Text);
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            lblResult.Text = SecurityHelper.Encrypt(txtInput.Text, txtKey.Text);
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            lblResult.Text = SecurityHelper.Decrypt(txtInput.Text, txtKey.Text);
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate a random key
            GeneratePassword.Service1Client genPass = new GeneratePassword.Service1Client();
            string password = genPass.GeneratePassword();
            txtPassword.Text = password;
        }
    }
}