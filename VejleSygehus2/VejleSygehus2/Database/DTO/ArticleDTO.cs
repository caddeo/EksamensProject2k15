using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VejleSygehus2.Database.DTO
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public Models.Category Category { get; set; }//asasas
    }
}