using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BlogWebApp.Models // Add this namespace
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
        public List<Article> GetArticlesByCategory(string category, string xmlPath)
        {
            XDocument doc = XDocument.Load(xmlPath);

            var articles = doc.Descendants("article")
                .Where(a => a.Element("category")?.Value == category)
                .Select(a => new Article
                {
                    Title = a.Element("title")?.Value,
                    Author = a.Element("author")?.Value,
                    Category = a.Element("category")?.Value,
                    Content = a.Element("content")?.Value
                }).ToList();

            return articles;
        }
    }
}
