using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ArticleManagementService
{
    [ServiceContract]
    public interface ArticleManagementService1
    {
        [OperationContract]
        bool CreateArticle(string title, string author, string content, string tags, string imageLink);

        [OperationContract]
        bool UpdateArticle(int id, string title, string author, string content, string tags, string imageLink);

        [OperationContract]
        bool DeleteArticle(int id);

        [OperationContract]
        Article GetArticle(int id);

        [OperationContract]
        List<Article> GetAllArticles();
    }

    [DataContract]
    public class Article
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string Tags { get; set; }

        [DataMember]
        public string ImageLink { get; set; }

        [DataMember]
        public DateTime PublicationDate { get; set; }
    }
}
