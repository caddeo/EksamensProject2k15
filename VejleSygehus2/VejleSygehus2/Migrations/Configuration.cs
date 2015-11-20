using System.Data.Entity.Migrations;
using VejleSygehus2.Models;

namespace VejleSygehus2.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ArticleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ArticleContext context)
        {
            var cat = new Category {Id = 1, Name = "First"};
            context.Categories.AddOrUpdate(cat);
            context.Articles.AddOrUpdate(new Article
            {
                Body = "dette er body",
                Category = cat,
                Header = "header",
                Id = 1,
                Path = "her"
            });
            context.SaveChanges();
        }
    }
}