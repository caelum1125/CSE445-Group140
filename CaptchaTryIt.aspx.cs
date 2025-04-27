using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace Captcha
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GenerateCaptcha();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            // Generate random 5-character CAPTCHA
            Random rand = new Random();
            string captchaText = new string(
                Enumerable.Repeat("ABCDEFGHJKLMNPQRSTUVWXYZ23456789", 5)
                .Select(s => s[rand.Next(s.Length)]).ToArray());

            // Store in Session for validation
            Session["Captcha"] = captchaText;

            // Generate image
            Bitmap bmp = new Bitmap(150, 50);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawString(captchaText, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 10, 10);

            // Add noise
            for (int i = 0; i < 500; i++)
                bmp.SetPixel(rand.Next(bmp.Width), rand.Next(bmp.Height), Color.Gray);

            // Convert to base64 for display
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imgCaptcha.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
        }

        // Public method to validate user input
        public bool ValidateCaptcha()
        {
            if (Session["Captcha"] == null || txtCaptcha.Text != Session["Captcha"].ToString())
            {
                lblMessage.Text = "Invalid CAPTCHA!";
                GenerateCaptcha(); // Refresh CAPTCHA on failure
                return false;
            }
            lblMessage.Text = "CAPTCHA verified!";
            return true;
        }
        protected void btnValidate_Click(object sender, EventArgs e)
        {
            ValidateCaptcha();
        }
    }
}