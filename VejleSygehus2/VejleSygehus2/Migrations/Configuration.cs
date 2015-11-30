using System.Data.Entity.Migrations;
using VejleSygehus2.Database;
using VejleSygehus2.Models;
using VejleSygehus2.Service;

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
            var service = new JsonService();

            var firstcategory = new Category {Id = 1, Name = "First"};
            context.Categories.AddOrUpdate(firstcategory);

            var secondcategory = new Category { Id = 2, Name = "Second" };
            context.Categories.AddOrUpdate(secondcategory);

            Article article = new Article
            {
                Body = "dette er body",
                Category = firstcategory,
                Header = "header",
                Id = 1,
        };
            article.Path = service.CreateJson(article);

            context.Articles.AddOrUpdate(article);
            context.SaveChanges();
        }
    }
}