using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;

namespace BlogWebApp
{
    public partial class CaptchaControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        private void GenerateCaptcha()
        {
            string captchaCode = GenerateRandomText();
            Session["CaptchaCode"] = captchaCode; 
            GenerateCaptchaImage(captchaCode);
        }

        private string GenerateRandomText()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] text = new char[5];
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = chars[rand.Next(chars.Length)];
            }
            return new string(text);
        }

        private void GenerateCaptchaImage(string captchaText)
        {
            using (Bitmap bitmap = new Bitmap(100, 40))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                using (Font font = new Font("Arial", 18, FontStyle.Bold))
                {
                    g.DrawString(captchaText, font, Brushes.Gray, 10, 5);
                }

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    ImgCaptcha.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        protected void BtnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        public string GetCaptchaAnswer()
        {
            return TxtCaptchaAnswer.Text;
        }

        public bool ValidateCaptcha(string userInput)
        {
            return userInput.Equals(Session["CaptchaCode"] as string, StringComparison.OrdinalIgnoreCase);
        }
    }
}
