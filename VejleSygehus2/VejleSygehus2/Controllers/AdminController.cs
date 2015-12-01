using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VejleSygehus2.Database;
using VejleSygehus2.Database.DTO;
using VejleSygehus2.Models;
using VejleSygehus2.Service;

namespace VejleSygehus2.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Create()
        {
            var mediator = new Database.Article.Mediator();
            var article = new Article();

            var items = mediator.GetAllCategories().Select(category => new SelectListItem
            {
                Text = category.Name, Value = category.Id.ToString()
            }).ToList();

            ViewBag.CategoryItems = items;

            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            // TODO : 
            // Bruger skal ikke kunne trykke submit flere gange
            using (var db = new ArticleContext())
            {
                int categoryid = article.CategoryId;

                var mediator = new Database.Article.Mediator();

                JsonService service = new JsonService();

                string path = service.CreateJson(article);
                article.Path = path;

                var category = mediator.GetAllCategories().First(x => x.Id == categoryid);

                article.CategoryId = category.Id;

                mediator.Save(article);
            }

            return RedirectToAction("List", "Article");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            var mediator = new Database.Article.Mediator();
            var service = new Service.JsonService();

            var entityarticle = mediator.Get(id);
            var article = service.LoadJson(entityarticle.Path);

            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            var mediator = new Database.Article.Mediator();
            var service = new Service.JsonService();
            
            mediator.Update(article);
            service.EditJson(article);

            return RedirectToAction("List", "Article");
        }
    }
}