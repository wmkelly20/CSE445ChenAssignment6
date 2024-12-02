using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WebApplication1.ArticlesManagementService;

namespace BlogWebApp.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }

    public class ArticleReaderService
    {
        public List<Article> GetArticlesByCategory(string category)
        {
            // Instantiate the service client
            var client = new ArticleManagementService1Client();

            // Call the service method to get all articles
            var articles = client.GetAllArticles();

            // Map ArticleManagementService.Article to BlogWebApp.Models.Article
            var mappedArticles = articles.Select(a => new Article
            {
                Title = a.Title,
                Author = a.Author,
                Category = a.Tags,
                Content = a.Content
            }).ToList();

            // Optionally filter articles by category
            if (!string.IsNullOrEmpty(category))
            {
                mappedArticles = mappedArticles
                    .Where(a => a.Category?.Contains(category) ?? false)
                    .ToList();
            }

            return mappedArticles;
        }
    }
}
