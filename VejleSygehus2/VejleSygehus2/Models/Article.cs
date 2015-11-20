using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VejleSygehus2.Models
{
    public class Article : IArticle
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public Category Category { get; set; }
    }

    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("ArticleContext") { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}