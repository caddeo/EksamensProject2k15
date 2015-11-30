using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace VejleSygehus2.Database.Article
{
    public class Mediator
    {
        public List<Database.DTO.ArticleDto> List()
        {
            using (var db = new ArticleContext())
            {
                return db.Articles
                    .Select(article =>  new Database.DTO.ArticleDto()
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
                    .FirstOrDefault(a => a.Id == id);
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
                var _article = db.Articles.FirstOrDefault(a => a.Id == article.Id);
                _article.Header = article.Header;
                _article.Category = article.Category;
                db.SaveChanges();
            
            }
        }

        /* Evt. burde vi at lave en fil der hedder Mediator (ikke i en mappe der hedder article)
        og så kan vi lave forskellige klasse i.e. articlemediator categorymediator */
        public List<SelectListItem> GetAllCategories()
        {
            using (var db = new ArticleContext())
            {
                var categories = db.Categories
                    .Select(c => 
                    new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                return new SelectList(categories, "Value", "Text").ToList();
            }
        }

    }
}