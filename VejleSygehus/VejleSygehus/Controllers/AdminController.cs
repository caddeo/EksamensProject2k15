using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VejleSygehus.Models;

namespace VejleSygehus.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Create()
        {
             var article = new Article();
            return View(article);
        }
        [HttpPost]
        public ActionResult Create(IArticle article)
        {
            return View();
        }
    }
}