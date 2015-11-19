using System.Runtime.ExceptionServices;
using VejleSygehus2.Models;

namespace VejleSygehus2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VejleSygehus2.Models.ArticleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VejleSygehus2.Models.ArticleContext context)
        {
            Category cat = new Category() {Id = 1, Name = "First"};
            context.Categories.AddOrUpdate(cat);
            context.Articles.AddOrUpdate(new Article() {Body = "dette er body", Category = cat, Header = "header", Id = 1, Path = "her"});
            context.SaveChanges();
        }
    }
}
