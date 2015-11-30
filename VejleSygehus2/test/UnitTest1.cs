using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VejleSygehus2;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TID001()
        {
            VejleSygehus2.Models.Article article = new VejleSygehus2.Models.Article();
            string path = "C:/Users/skole/Desktop/testmappe/Json/TID001.json";
            article.Path = path;
            article.Body = "Test body for TID001";
            article.Header = "test header for TID001";
            string json = JsonConvert.SerializeObject(article, Formatting.Indented);
            File.WriteAllText(path, json);
            VejleSygehus2.Service.JsonService jason = new VejleSygehus2.Service.JsonService();
            VejleSygehus2.Models.Article result = jason.LoadJson(path);

            Assert.AreEqual(article, result);
        }
    }
}
