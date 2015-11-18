using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            // Opret et produkt som skal laves om til json fil
            Product product = new Product();
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            // find rooten af filerne
            string root = AppDomain.CurrentDomain.BaseDirectory;

            // giv det et navn
            Console.WriteLine("Gem en json fil");
            Console.WriteLine("Skriv fil navn (uden .json)");
            string path = Console.ReadLine();

            // gem filen med navnet
            string json = JsonConvert.SerializeObject(product, Formatting.Indented);
            File.WriteAllText(@root+"\\"+ path+".json", json);

            Product deserializedProduct;

            // find filen med navnet
            Console.WriteLine("Load en json fil");
            Console.WriteLine("Skriv fil navn (uden .json)");
            path = Console.ReadLine();


            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@root + "\\" + path + ".json"))
            {
                    JsonSerializer serializer = new JsonSerializer();
                    deserializedProduct = (Product)serializer.Deserialize(file, typeof(Product));
                }

            Console.WriteLine(string.Format("Produkt med {0}, {1}, {2}, {3}", deserializedProduct.Name,
                deserializedProduct.ExpiryDate.ToString("yy-MM-dd"), deserializedProduct.Price, deserializedProduct.Sizes.Length));

            Console.ReadKey();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
