using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VejleSygehus2.Models;

namespace VejleSygehus2.Database
{
    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("ArticleContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}