using System.Data.Entity.Migrations;
using System.Linq;
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

            var firstcategory = new Category { Id = 1, Name = "First" };
            if (context.Categories.FirstOrDefault(x => x.Name == firstcategory.Name) == null)
            {
                context.Categories.Add(firstcategory);
            }

            var secondcategory = new Category { Id = 2, Name = "Second" };
            if (context.Categories.FirstOrDefault(x => x.Name == secondcategory.Name) == null)
            {

                context.Categories.Add(secondcategory);
            }

            Article article = new Article
            {
                Body = "dette er body",
                Category = firstcategory,
                Header = "header",
                Id = 1,
            };
            article.Path = service.CreateJson(article);

            if (context.Articles.FirstOrDefault(x => x.Header == article.Header) == null)
            {
                context.Articles.Add(article);
            }

            context.SaveChanges();
        }
    }
}