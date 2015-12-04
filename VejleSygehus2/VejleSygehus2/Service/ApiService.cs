using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VejleSygehus2.Models;

namespace VejleSygehus2.Service
{
    public class ApiService
    {
        public Article GetArticle(string path)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jser = new System.Web.Script.Serialization.JavaScriptSerializer();

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.Headers["Content-Type"] = "application/json";
            string uriAdr = "http://localhost:33553/api/Article/Details/" + path;
            string response = webClient.DownloadString(uriAdr);
            Article article = jser.Deserialize<Article>(response);

            return article;
        }
    }
}