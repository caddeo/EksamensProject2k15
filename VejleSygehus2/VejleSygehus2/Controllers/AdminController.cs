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
    [Authorize(Roles = "canEdit")]
    
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            var mediator = new Database.CategoryMediator();
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
        public ActionResult Create([Bind(Include = "Header, Body, Category")] Article article)
        {
            // TODO : 
            // Bruger skal ikke kunne trykke submit flere gange

            var categorymediator = new Database.CategoryMediator();
            var articlemediator = new ArticleMediator();
            
            #region itemsrep
            // skal finde en anden løsning, evt. et repository
            var items = categorymediator.GetAllCategories().Select(cat => new SelectListItem
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }).ToList();

            ViewBag.CategoryItems = items;
            #endregion

            int categoryid = article.CategoryId;
            var category = categorymediator.GetAllCategories().First(x => x.Id == categoryid);
            article.CategoryId = category.Id;

            if (ModelState.IsValid)
            {
                var service = new JsonService();

                string path = service.CreateJson(article);
                article.Path = path;

                articlemediator.Save(article);

                return RedirectToAction("List", "Article");
            }

            ViewBag.Error = "Kan ikke oprette";

            return View(article);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            var mediator = new Database.ArticleMediator();
            var service = new Service.JsonService();

            var entityarticle = mediator.Get(id);
            var article = service.LoadJson(entityarticle.Path);

            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Header, Body, Category")] Article article)
        {
            var mediator = new Database.ArticleMediator();
            var service = new Service.JsonService();
            
            mediator.Update(article);
            service.EditJson(article);

            return RedirectToAction("List", "Article");
        }

        [HttpGet]
        public ActionResult ListUsers(string message = null)
        {
            ViewBag.Message = message;

            var mediator = new AccountMediator();

            return View(mediator.ListUsers());
        }

        public ActionResult AddUserAsAdmin(string email)
        {
            var mediator = new AccountMediator();
            mediator.AddUserAsAdmin(email);

            return RedirectToAction("ListUsers", new {message = email+" added"});
        }

        public ActionResult RemoveUser(string email)
        {
            var mediator = new AccountMediator();
            mediator.RemoveUser(email);

            return RedirectToAction("ListUsers", new {message = email+" deleted"});
        }
    }
}