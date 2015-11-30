using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VejleSygehus2.Models
{
    public class CreateArticleViewModel
    {

        public Article Article { get; set; }
        public List<Category> Categories { get; set; }
        public string SelectedCategory { get; set; }
    }
}