using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VejleSygehus2.Database;
using VejleSygehus2.Models;
using VejleSygehus2.Service;

namespace VejleSygehus2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult List()
        {
            var mediator = new Database.Article.Mediator();
            var articles = mediator.List();
            var entityarticles = new List<Models.Article>();

            articles.ForEach(article => entityarticles.Add(
                Service.Mappers.ArticleMapper
                .ConverFromDto(article)));
            return View(entityarticles);
        }
        public ActionResult Details(int id)
        {
            var mediator = new Database.Article.Mediator();
            var service = new Service.JsonService();

            var entityarticles = mediator.Get(id);
            var article = service.LoadJson(entityarticles.Path);

            return View(article);
        }
    }
}