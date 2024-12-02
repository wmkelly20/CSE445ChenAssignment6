using Assignment4.ArticleService;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace Assignment4
{
    public partial class MemberTryIt : System.Web.UI.Page
    {
        private string xmlFilePath = HttpContext.Current.Server.MapPath("~/Articles.xml");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadArticles();
                LoadUserPreferences();
            }
        }

        protected void BtnValidateCaptcha_Click(object sender, EventArgs e)
        {
            string userCaptchaInput = CaptchaControl.GetCaptchaAnswer();
            if (CaptchaControl.ValidateCaptcha(userCaptchaInput))
            {
                LblCaptchaResult.Text = "CAPTCHA validated successfully!";
                LblCaptchaResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LblCaptchaResult.Text = "Invalid CAPTCHA. Please try again.";
                LblCaptchaResult.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void LoadUserPreferences()
        { 
            HttpCookie userPreferences = Request.Cookies["UserPreferences"];
            if (userPreferences != null)
            {
                themeDropdown.SelectedValue = userPreferences["Theme"];
                languageDropdown.SelectedValue = userPreferences["Language"];
            }
        }

        protected void btnSavePreferences_Click(object sender, EventArgs e)
        {
            HttpCookie userPreferences = new HttpCookie("UserPreferences");
            userPreferences["Theme"] = themeDropdown.SelectedValue;
            userPreferences["Language"] = languageDropdown.SelectedValue;
            userPreferences.Expires = DateTime.Now.AddDays(1); // Expires 1 days
            Response.Cookies.Add(userPreferences);

            LblPreferenceStatus.Text = "Preferences saved successfully!";
        }

        // XML Methods
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            var doc = XDocument.Load(xmlFilePath);

            int newArticleId = doc.Root.Elements("article")
                .Select(a => (int)a.Element("id"))
                .DefaultIfEmpty(0)
                .Max() + 1;

            int newAuthorId = doc.Root.Elements("article")
                .Select(a => (int)a.Element("authorId"))
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newArticle = new XElement("article",
                new XElement("id", newArticleId),
                new XElement("title", TxtTitle.Text),
                new XElement("authorId", newAuthorId),
                new XElement("author", TxtAuthor.Text),
                new XElement("publicationDate", DateTime.Now.ToString("yyyy-MM-dd")),
                new XElement("content", TxtContent.Text),
                new XElement("tags", TxtTags.Text.Split(',').Select(tag => new XElement("tag", tag.Trim()))),
                new XElement("imageLink", TxtImageLink.Text),
                new XElement("status", "Draft"),
                new XElement("views", 0)
            );

            doc.Root.Add(newArticle);
            doc.Save(xmlFilePath);
            LoadArticles();
            LblStatus.Text = "Article created successfully!";
        }

        private void LoadArticles()
        {
            var doc = XDocument.Load(xmlFilePath);
            var articles = doc.Root.Elements("article").Select(article => new
            {
                Id = article.Element("id")?.Value,
                Title = article.Element("title")?.Value,
                AuthorId = article.Element("authorId")?.Value,
                Author = article.Element("author")?.Value,
                Date = article.Element("publicationDate")?.Value,
                Content = article.Element("content")?.Value,
                Tags = article.Element("tags")?.Value
            }).ToList();

            GvArticles.DataSource = articles;
            GvArticles.DataBind();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            var doc = XDocument.Load(xmlFilePath);
            var article = doc.Root.Elements("article").FirstOrDefault(a => a.Element("id")?.Value == TxtArticleId.Text);

            if (article != null)
            {
                article.Element("title")?.SetValue(TxtTitle.Text);
                article.Element("authorId")?.SetValue(TxtAuthorGuid.Text);
                article.Element("author")?.SetValue(TxtAuthor.Text);
                article.Element("content")?.SetValue(TxtContent.Text);
                article.Element("tags")?.RemoveAll();
                article.Element("tags")?.Add(TxtTags.Text.Split(',').Select(tag => new XElement("tag", tag.Trim())));
                article.Element("imageLink")?.SetValue(TxtImageLink.Text);

                doc.Save(xmlFilePath);
                LoadArticles();
                LblStatus.Text = "Article updated successfully!";
            }
            else
            {
                LblStatus.Text = "Article not found!";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var doc = XDocument.Load(xmlFilePath);
            var article = doc.Root.Elements("article").FirstOrDefault(a => a.Element("id")?.Value == TxtArticleId.Text);

            if (article != null)
            {
                article.Remove();
                doc.Save(xmlFilePath);
                LoadArticles();
                LblStatus.Text = "Article deleted successfully!";
            }
            else
            {
                LblStatus.Text = "Article not found!";
            }
        }

        // WCF Service Methods
        protected void BtnServiceCreate_Click(object sender, EventArgs e)
        {
            using (var client = new ArticleManagementService1Client())
            {
                bool result = client.CreateArticle(TxtServiceTitle.Text, TxtServiceAuthor.Text, TxtServiceContent.Text, TxtServiceTags.Text, TxtServiceImageLink.Text);
                LblServiceStatus.Text = result ? "Article created successfully via service!" : "Failed to create article via service.";
                LoadServiceArticles();
            }
        }

        protected void BtnServiceUpdate_Click(object sender, EventArgs e)
        {
            using (var client = new ArticleManagementService1Client())
            {
                int id = int.Parse(TxtServiceArticleId.Text);
                bool result = client.UpdateArticle(id, TxtServiceTitle.Text, TxtServiceAuthor.Text, TxtServiceContent.Text, TxtServiceTags.Text, TxtServiceImageLink.Text);
                LblServiceStatus.Text = result ? "Article updated successfully via service!" : "Failed to update article via service.";
                LoadServiceArticles();
            }
        }

        protected void BtnServiceDelete_Click(object sender, EventArgs e)
        {
            using (var client = new ArticleManagementService1Client())
            {
                int id = int.Parse(TxtServiceArticleId.Text);
                bool result = client.DeleteArticle(id);
                LblServiceStatus.Text = result ? "Article deleted successfully via service!" : "Failed to delete article via service.";
                LoadServiceArticles();
            }
        }

        protected void BtnServiceGetAll_Click(object sender, EventArgs e)
        {
            LoadServiceArticles();
        }

        private void LoadServiceArticles()
        {
            using (var client = new ArticleManagementService1Client())
            {
                var articles = client.GetAllArticles();
                GvServiceArticles.DataSource = articles;
                GvServiceArticles.DataBind();
            }
        }
    }
}
