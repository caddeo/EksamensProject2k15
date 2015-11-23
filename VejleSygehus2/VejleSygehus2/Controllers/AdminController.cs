using System;
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
            var article = new Article();
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "Header, Body, Category")]Article article)
        {
            if (ModelState.IsValid)
            {
                return View(article);
            }

            // TODO : 
            // Bruger skal ikke kunne trykke submit flere gange
            using (var db = new ArticleContext())
            {
                var mediator = new Database.Article.Mediator();

                JsonService service = new JsonService();

                string path = service.CreateJson(article);
                article.Path = path;

                var entitydto = Service.Mappers.ArticleMapper.ConvertToDto(article);

                mediator.Save(entitydto);
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
            return View();
        }
    }
}