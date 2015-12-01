using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VejleSygehusAPI2.Models;

namespace VejleSygehusAPI2.Service
{
    public class JsonService
    {
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
    }
}
