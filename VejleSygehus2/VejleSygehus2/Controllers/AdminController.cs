using System.Web.Mvc;
using VejleSygehus2.Models;

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
        public ActionResult Create(Article article)
        {
            using (var db = new ArticleContext())
            {
                db.Articles.Add(article);
                db.SaveChanges();
            }
            return RedirectToAction("List", "Article");
        }
    }
}