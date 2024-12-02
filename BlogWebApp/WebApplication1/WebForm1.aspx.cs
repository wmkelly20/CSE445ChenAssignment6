using System;
using BlogWebApp.Models;
using ArticleManagementService;
using System.Linq;
using WebApplication1.ArticlesManagementService;

using HashingLibrary; // Reference to the hashing library

namespace BlogWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnHash_Click(object sender, EventArgs e)
        {
            // Retrieve the password from the input TextBox
            string password = txtPassword.Text;

            // Validate the input
            if (string.IsNullOrWhiteSpace(password))
            {
                lblHashResult.Text = "Please enter a password to hash.";
                return;
            }

            // Hash the password using PasswordHasher
            string hashedPassword = PasswordHasher.HashPassword(password);

            // Display the hashed password in the Label
            lblHashResult.Text = $"Hashed Password: {hashedPassword}";
        }

        //Sort Articles by category
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            // Retrieve the category from the input TextBox
            string category = txtCategory.Text;

            // Validate the input
            if (string.IsNullOrWhiteSpace(category))
            {
                Response.Write("<p>Please enter a category to retrieve articles.</p>"); 
                return;
            }

            // Initialize the ArticleReaderService
            //ArticleReaderService articleService = new ArticleReaderService();
            var client = new ArticleManagementService1Client();

            // Get articles by category
            var serviceArticles = client.GetAllArticles();

            var articles = serviceArticles
                .AsEnumerable()
                .Where(a => a.Tags != null && a.Tags.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (articles.Any())
            {
                foreach (var article in articles)
                {
                    Response.Write($"<h3>{article.Title}</h3>");
                    Response.Write($"<p><strong>Author:</strong> {article.Author}</p>");
                    Response.Write($"<p><strong>Content:</strong> {article.Content}</p>");
                    Response.Write($"<p><strong>Tags:</strong> {article.Tags}</p>");
                    Response.Write($"<p><strong>Id:</strong> {article.Id}</p>");
                    Response.Write($"<p><strong>Image Link:</strong> <a href='{article.ImageLink}' target='_blank'>{article.ImageLink}</a></p>");
                    Response.Write($"<p><strong>Publication Date:</strong> {article.PublicationDate:MMMM dd, yyyy}</p>");
                }
            }
            else
            {
                Response.Write("<p>No articles found for the entered category.</p>");
            }
        }

        //Article Creation
        protected void btnCreateArticle_Click(object sender, EventArgs e)
        {
            // Get input values from the form
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string content = txtContent.Text;
            string tags = txtTags.Text;
            string imageLink = txtImageLink.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(content))
            {
                lblCreateArticleResult.Text = "Title, Author, and Content are required fields.";
                lblCreateArticleResult.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                // Initialize the service client
                var client = new WebApplication1.ArticlesManagementService.ArticleManagementService1Client();
                // Call the CreateArticle method
                bool success = client.CreateArticle(title, author, content, tags, imageLink);

                // Provide feedback to the user
                if (success)
                {
                    lblCreateArticleResult.Text = "Article created successfully!";
                    lblCreateArticleResult.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblCreateArticleResult.Text = "Failed to create the article.";
                    lblCreateArticleResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblCreateArticleResult.Text = "An error occurred: " + ex.Message;
                lblCreateArticleResult.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
