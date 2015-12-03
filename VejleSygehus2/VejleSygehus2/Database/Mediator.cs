using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Security;
using VejleSygehus2.Models;

namespace VejleSygehus2.Database
{
    public class ArticleMediator
    {
        public List<Database.DTO.ArticleDto> List()
        {
            using (var db = new ArticleContext())
            {
                return db.Articles
                    .Select(article => new Database.DTO.ArticleDto()
                    {
                        Id = article.Id,
                        Path = article.Path,
                        Header = article.Header,
                        Category = article.Category
                    }
                    /*Service.Mappers.ArticleMapper.ConvertToDto(article)*/)
                    .ToList();
            }
        }

        public List<Database.DTO.ArticleDto> ListFromCategory(Models.Category category)
        {
            using (var db = new ArticleContext())
            {
                return db.Articles
                   .Select(article => new Database.DTO.ArticleDto
                   {
                       Id = article.Id,
                       Path = article.Path,
                       Header = article.Header,
                       Category = article.Category
                   }
                   /*Service.Mappers.ArticleMapper.ConvertToDto(article)*/)
                   .Where(a => a.Category.Id == category.Id)
                   .ToList();
            }
        }

        public Database.DTO.ArticleDto Get(int id)
        {
            using (var db = new ArticleContext())
            {
                return db.Articles
                    .Select(article => new Database.DTO.ArticleDto()
                    {
                        Id = article.Id,
                        Path = article.Path,
                        Header = article.Header,
                        Category = article.Category
                    }
                    /*Service.Mappers.ArticleMapper.ConvertToDto(article)*/)
                    .First(a => a.Id == id);
            }
        }

        public void Save(Models.Article article)
        {
            using (var db = new ArticleContext())
            {
                db.Articles.Add(article);
                db.SaveChanges();
            }
        }

        public void Update(Models.Article article)
        {
            using (var db = new ArticleContext())
            {
                var newarticle = db.Articles.First(a => a.Id == article.Id);

                newarticle.Header = article.Header;
                newarticle.Category = article.Category;

                db.SaveChanges();

            }
        }
    }

    public class CategoryMediator
    {
        /* Evt. burde vi at lave en fil der hedder Mediator (ikke i en mappe der hedder article)
            og så kan vi lave forskellige klasse i.e. articlemediator categorymediator */

        public List<Models.Category> GetAllCategories()
        {
            using (var db = new ArticleContext())
            {
                return db.Categories.ToList();
            }
        }
    }

    public class AccountMediator
    {
        public List<User> ListUsers()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users
                    .Select(user => new User()
                    {
                        Email = user.Email,
                        Admin = Roles.IsUserInRole("canEdit")
                    })
                    .ToList();
            }
        }

        public void AddUserAsAdmin(string email)
        {
            Roles.AddUserToRole(email, "canEdit");
        }

        public void RemoveUser(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.First(x => x.Email == email);
                db.Users.Remove(user);
            }
        }
    }
}