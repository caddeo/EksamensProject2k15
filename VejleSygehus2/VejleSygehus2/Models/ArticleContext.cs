using System.Data.Entity;

namespace VejleSygehus2.Models
{
    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("ArticleContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}