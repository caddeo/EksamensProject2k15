using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VejleSygehusAPI2.Models;
using VejleSygehusAPI2.Service;

namespace VejleSygehusAPI2.Controllers
{
    public class ArticleController : ApiController
    {
        [HttpGet]
        public Article Get(string path)
        {
            JsonService jservice = new JsonService();
            Article article =  jservice.LoadJson(path);



            return article;
        }
    }
}
