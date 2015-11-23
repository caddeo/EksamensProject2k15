using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using VejleSygehus2.Models;

namespace VejleSygehus2.Service
{
    public class JsonService
    {
        public string GetPath(string filename)
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string directoryPath = root + "\\Json\\";

            if(filename.Substring(filename.Length - ".json".Length, ".json".Length) != ".json")
            {
                filename = filename + ".json";
            }

            Directory.CreateDirectory(directoryPath);

            string path = Path.Combine(directoryPath, filename);

            return path;
        }
        public string CreateJson(Article article)
        {
            string path = GetPath(Guid.NewGuid().ToString());

            // Skal gøre så at den ikke har path og id med
            string json = JsonConvert.SerializeObject(article, Formatting.Indented);
            File.WriteAllText(path, json);
            
            return path;
        }
        public void EditJson(Article article)
        {
            string json = JsonConvert.SerializeObject(article, Formatting.Indented);
            File.WriteAllText(article.Path, json);
        }
        public Article LoadJson(string path)
        {
            Article deserializedArticle;

            try
            {
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    deserializedArticle = (Article)serializer.Deserialize(file, typeof(Article));
                }
            }
            catch (FileNotFoundException)
            {
                deserializedArticle = null;
            }

            return deserializedArticle;
        }
        public void DeleteJson(Article article)
        {
            try
            {
                File.Delete(article.Path);
            }
            catch (FileNotFoundException)
            {

            }
        }
    }
}