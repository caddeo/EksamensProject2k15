using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VejleSygehus2.Database
{
    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("ArticleContext")
        {
        }

        public virtual DbSet<Models.Article> Articles { get; set; }
        public virtual DbSet<Models.Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}