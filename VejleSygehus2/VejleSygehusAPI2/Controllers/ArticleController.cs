using System;
using System.Collections.Generic;
using System.IO;
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
        public Article Get(string articlePath)
        {
            JsonService jservice = new JsonService();

            string root = AppDomain.CurrentDomain.BaseDirectory;
            string directoryPath = root + "\\Json\\";

            if (articlePath.Substring(articlePath.Length - ".json".Length, ".json".Length) != ".json")
            {
                articlePath = articlePath + ".json";
            }

            Directory.CreateDirectory(directoryPath);

            string path = Path.Combine(directoryPath, articlePath);
            Article article =  jservice.LoadJson(path);


            return article;
        }
    }
}
