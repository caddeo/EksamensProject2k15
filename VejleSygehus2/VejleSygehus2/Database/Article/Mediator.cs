﻿using System;
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
            List<Database.DTO.CategoryDTO> list = GetCategories();

            foreach (Database.DTO.CategoryDTO cat in list)
            {
                if (cat.Name == article.Category.Name)
                {
                    article.Category.Id = cat.Id;
                }
            }

            using (var db = new ArticleContext())
            {
                db.Articles.Add(article);
                db.SaveChanges();   
            }
        }
        public void Update(Models.Article article)
        {
            List<Database.DTO.CategoryDTO> list = GetCategories();

            foreach (Database.DTO.CategoryDTO cat in list)
            {
                if (cat.Name == article.Category.Name)
                {
                    article.Category.Id = cat.Id;
                }
            }

            using (var db = new ArticleContext())
            {
                var _article = db.Articles.FirstOrDefault(a => a.Id == article.Id);
                _article.Header = article.Header;
                _article.Category = article.Category;
                db.SaveChanges();
            
            }
        }
        public List<Database.DTO.CategoryDTO> GetCategories()
        {
            using (var db = new ArticleContext())
            {
                return db.Categories
                    .Select(category => new Database.DTO.CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name
                    }).ToList();                    
            }
        }
    }
}