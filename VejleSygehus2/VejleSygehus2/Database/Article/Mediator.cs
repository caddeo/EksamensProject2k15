using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

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
    }
}