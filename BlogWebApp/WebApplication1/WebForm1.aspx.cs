using System;
using BlogWebApp.Models;
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

            // Define the path to the Articles.xml file
            string xmlPath = Server.MapPath("~/App_Data/Articles.xml");

            // Initialize the ArticleReaderService
            ArticleReaderService articleService = new ArticleReaderService();

            // Get articles by category
            var articles = articleService.GetArticlesByCategory(category);

            // Display the articles
            if (articles.Count > 0)
            {
                foreach (var article in articles)
                {
                    Response.Write($"<h3>{article.Title}</h3>");
                    Response.Write($"<p>Author: {article.Author}</p>");
                    Response.Write($"<p>{article.Content}</p>");
                }
            }
            else
            {
                Response.Write("<p>No articles found for the entered category.</p>");
            }
        }
    }
}
