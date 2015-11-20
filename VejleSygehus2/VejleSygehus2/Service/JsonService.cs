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
            string json = JsonConvert.SerializeObject(article, Formatting.Indented);
            File.WriteAllText(path, json);

            return path;
        }
        public void EditJson(int id)
        {
            
        }
        /*public Article LoadJson(int id)
        {

            return 
        }*/
        public void DeleteJson(int id)
        {
            
        }
    }
}