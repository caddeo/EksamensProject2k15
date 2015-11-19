using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VejleSygehus.Models
{

    public class Article : IArticle
    {

        public string Path { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public Category Category { get; set; }
    
    }

    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("DefaultConnection") { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}