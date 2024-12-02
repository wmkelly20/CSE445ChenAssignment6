using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ArticleManagementService
{
    public class ArticleManagementService : ArticleManagementService1
    {
        private string xmlFilePath = HttpContext.Current.Server.MapPath("~/Articles.xml");

        public bool CreateArticle(string title, string author, string content, string tags, string imageLink)
        {
            var doc = XDocument.Load(xmlFilePath);

            // Make new Article ID
            int newArticleId = doc.Root.Elements("article")
                .Select(a => (int)a.Element("id"))
                .DefaultIfEmpty(0)
                .Max() + 1;

            var newArticle = new XElement("article",
                new XElement("id", newArticleId),
                new XElement("title", title),
                new XElement("author", author),
                new XElement("publicationDate", DateTime.Now.ToString("yyyy-MM-dd")),
                new XElement("content", content),
                new XElement("tags", tags.Split(',').Select(tag => new XElement("tag", tag.Trim()))),
                new XElement("imageLink", imageLink),
                new XElement("status", "Draft"),
                new XElement("views", 0)
            );

            doc.Root.Add(newArticle);
            doc.Save(xmlFilePath);
            return true;
        }

        public bool UpdateArticle(int id, string title, string author, string content, string tags, string imageLink)
        {
            var doc = XDocument.Load(xmlFilePath);
            var article = doc.Root.Elements("article").FirstOrDefault(a => (int)a.Element("id") == id);

            if (article == null)
                return false;

            article.Element("title")?.SetValue(title);
            article.Element("author")?.SetValue(author);
            article.Element("content")?.SetValue(content);
            article.Element("tags")?.RemoveAll();
            article.Element("tags")?.Add(tags.Split(',').Select(tag => new XElement("tag", tag.Trim())));
            article.Element("imageLink")?.SetValue(imageLink);

            doc.Save(xmlFilePath);
            return true;
        }

        public bool DeleteArticle(int id)
        {
            var doc = XDocument.Load(xmlFilePath);
            var article = doc.Root.Elements("article").FirstOrDefault(a => (int)a.Element("id") == id);

            if (article == null)
                return false;

            article.Remove();
            doc.Save(xmlFilePath);
            return true;
        }

        public Article GetArticle(int id)
        {
            var doc = XDocument.Load(xmlFilePath);
            var articleElement = doc.Root.Elements("article").FirstOrDefault(a => (int)a.Element("id") == id);

            if (articleElement == null)
                return null;

            return new Article
            {
                Id = (int)articleElement.Element("id"),
                Title = (string)articleElement.Element("title"),
                Author = (string)articleElement.Element("author"),
                Content = (string)articleElement.Element("content"),
                Tags = string.Join(", ", articleElement.Element("tags").Elements("tag").Select(t => t.Value)),
                ImageLink = (string)articleElement.Element("imageLink"),
                PublicationDate = DateTime.Parse((string)articleElement.Element("publicationDate"))
            };
        }

        public List<Article> GetAllArticles()
        {
            var doc = XDocument.Load(xmlFilePath);
            return doc.Root.Elements("article").Select(a => new Article
            {
                Id = (int)a.Element("id"),
                Title = (string)a.Element("title"),
                Author = (string)a.Element("author"),
                Content = (string)a.Element("content"),
                Tags = string.Join(", ", a.Element("tags").Elements("tag").Select(t => t.Value)),
                ImageLink = (string)a.Element("imageLink"),
                PublicationDate = DateTime.Parse((string)a.Element("publicationDate"))
            }).ToList();
        }
    }
}
