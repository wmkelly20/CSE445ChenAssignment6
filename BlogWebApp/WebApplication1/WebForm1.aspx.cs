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

            var articles =
                serviceArticles
                .AsEnumerable()
                .Where(a => a.Tags?.Contains(category, StringComparison.OrdinalIgnoreCase) ?? false)
                .ToList();

            if (articles.Any())
            {
                foreach (var article in articles)
                {
                    Response.Write($"<h3>{article.Title}</h3>");
                    Response.Write($"<p>Author: {article.Author}</p>");
                    Response.Write($"<p>Content: {article.Content}</p>");
                    Response.Write($"<p>Tags: {article.Tags}</p>");
                }
            }
            else
            {
                Response.Write("<p>No articles found for the entered category.</p>");
            }
        }
    }
}
