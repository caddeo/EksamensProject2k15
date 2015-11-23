using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VejleSygehus2.Service.Mappers
{
    public static class ArticleMapper
    {
        public static Models.Article ConverFromDto(Database.DTO.ArticleDto dto)
        {
            return new Models.Article()
            {
                Id = dto.Id,
                Path = dto.Path,
                Header = dto.Header,
                Body = dto.Body,
                Category = dto.Category
            };
        }

        public static Database.DTO.ArticleDto ConvertToDto(Models.Article article)
        {
            return new Database.DTO.ArticleDto()
            {
                Id = article.Id,
                Path = article.Path,
                Header = article.Header,
                Category = article.Category
            };
        }
    }
}