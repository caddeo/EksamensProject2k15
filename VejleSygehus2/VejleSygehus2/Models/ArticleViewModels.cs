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
        public List<SelectListItem> Categories { get; set; }
    }
}