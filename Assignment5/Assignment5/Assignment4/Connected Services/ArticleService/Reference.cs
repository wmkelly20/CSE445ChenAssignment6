﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment4.ArticleService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Article", Namespace="http://schemas.datacontract.org/2004/07/ArticleManagementService")]
    [System.SerializableAttribute()]
    public partial class Article : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PublicationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageLink {
            get {
                return this.ImageLinkField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageLinkField, value) != true)) {
                    this.ImageLinkField = value;
                    this.RaisePropertyChanged("ImageLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PublicationDate {
            get {
                return this.PublicationDateField;
            }
            set {
                if ((this.PublicationDateField.Equals(value) != true)) {
                    this.PublicationDateField = value;
                    this.RaisePropertyChanged("PublicationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tags {
            get {
                return this.TagsField;
            }
            set {
                if ((object.ReferenceEquals(this.TagsField, value) != true)) {
                    this.TagsField = value;
                    this.RaisePropertyChanged("Tags");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ArticleService.ArticleManagementService1")]
    public interface ArticleManagementService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/CreateArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/CreateArticleResponse")]
        bool CreateArticle(string title, string author, string content, string tags, string imageLink);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/CreateArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/CreateArticleResponse")]
        System.Threading.Tasks.Task<bool> CreateArticleAsync(string title, string author, string content, string tags, string imageLink);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/UpdateArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/UpdateArticleResponse")]
        bool UpdateArticle(int id, string title, string author, string content, string tags, string imageLink);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/UpdateArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/UpdateArticleResponse")]
        System.Threading.Tasks.Task<bool> UpdateArticleAsync(int id, string title, string author, string content, string tags, string imageLink);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/DeleteArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/DeleteArticleResponse")]
        bool DeleteArticle(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/DeleteArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/DeleteArticleResponse")]
        System.Threading.Tasks.Task<bool> DeleteArticleAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/GetArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/GetArticleResponse")]
        Assignment4.ArticleService.Article GetArticle(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/GetArticle", ReplyAction="http://tempuri.org/ArticleManagementService1/GetArticleResponse")]
        System.Threading.Tasks.Task<Assignment4.ArticleService.Article> GetArticleAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/GetAllArticles", ReplyAction="http://tempuri.org/ArticleManagementService1/GetAllArticlesResponse")]
        Assignment4.ArticleService.Article[] GetAllArticles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ArticleManagementService1/GetAllArticles", ReplyAction="http://tempuri.org/ArticleManagementService1/GetAllArticlesResponse")]
        System.Threading.Tasks.Task<Assignment4.ArticleService.Article[]> GetAllArticlesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ArticleManagementService1Channel : Assignment4.ArticleService.ArticleManagementService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ArticleManagementService1Client : System.ServiceModel.ClientBase<Assignment4.ArticleService.ArticleManagementService1>, Assignment4.ArticleService.ArticleManagementService1 {
        
        public ArticleManagementService1Client() {
        }
        
        public ArticleManagementService1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ArticleManagementService1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArticleManagementService1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArticleManagementService1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateArticle(string title, string author, string content, string tags, string imageLink) {
            return base.Channel.CreateArticle(title, author, content, tags, imageLink);
        }
        
        public System.Threading.Tasks.Task<bool> CreateArticleAsync(string title, string author, string content, string tags, string imageLink) {
            return base.Channel.CreateArticleAsync(title, author, content, tags, imageLink);
        }
        
        public bool UpdateArticle(int id, string title, string author, string content, string tags, string imageLink) {
            return base.Channel.UpdateArticle(id, title, author, content, tags, imageLink);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateArticleAsync(int id, string title, string author, string content, string tags, string imageLink) {
            return base.Channel.UpdateArticleAsync(id, title, author, content, tags, imageLink);
        }
        
        public bool DeleteArticle(int id) {
            return base.Channel.DeleteArticle(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteArticleAsync(int id) {
            return base.Channel.DeleteArticleAsync(id);
        }
        
        public Assignment4.ArticleService.Article GetArticle(int id) {
            return base.Channel.GetArticle(id);
        }
        
        public System.Threading.Tasks.Task<Assignment4.ArticleService.Article> GetArticleAsync(int id) {
            return base.Channel.GetArticleAsync(id);
        }
        
        public Assignment4.ArticleService.Article[] GetAllArticles() {
            return base.Channel.GetAllArticles();
        }
        
        public System.Threading.Tasks.Task<Assignment4.ArticleService.Article[]> GetAllArticlesAsync() {
            return base.Channel.GetAllArticlesAsync();
        }
    }
}
