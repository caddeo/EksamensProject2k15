using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VejleSygehus2.Models;

namespace VejleSygehus2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult List()
        {
            var articles = new List<Article>();
            using (var db = new ArticleContext())
            {
                articles = db.Articles.ToList();
            }
            return View(articles);
        }
    }
}