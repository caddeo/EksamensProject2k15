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
            // Programmet kan lave en json fil af typen Produkt
            // som indeholder hardcodede værdier
            // Den kan gemme i en mappe som man bestemmer
            // og så læse det op igen

            // Muligvis lave try catch på metoderne
            // så at hvis f.eks. filen ikke kan findes
            // eller hvad der sker nogen skrive fejl

            Program program = new Program();

            // Opret et produkt som skal laves om til json fil
            Product product = new Product();
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2009, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            // giv det et navn
            Console.WriteLine("Gem en json fil");
            Console.WriteLine("Skriv fil navn (uden .json)");
            string filename = Console.ReadLine();

            // finder stien (og opretter den)
            string path = program.GetPath(filename);

            // Serializer objektet ( af typen produkt ) og
            // laver det om til en .json fil
            // og gemmer det på den valgte sti
            program.CreateJson(path, product);

            // Viser alle filerne i mappen 
            // Kun lavet for at teste
            Console.WriteLine("Alle json filer i mappen:");
            // Ignorer - bare for at gøre så det mindre ligner et clusterfuck
            Console.WriteLine(path.Substring(0, (path.Length - (filename.Length+".json".Length))));
            Console.WriteLine(program.ListDirectory("json"));

            // Få brugeren til at skrive et navn
            Console.WriteLine("Load en json fil");
            Console.WriteLine("Skriv fil navn (uden .json)");
            filename = Console.ReadLine();

            // finder stien
            path = program.GetPath(filename);

            // Finder filen og deserializer json om
            // til typen Produkt
            Product deserializedProduct = program.LoadJson(path);

            // Udskriver objektet hvis det ikke er null
            // Hvis den er null kunne den ikke findes
            if(deserializedProduct != null)
            {
                Console.WriteLine(string.Format("Produkt med {0}, {1}, {2}, {3}", deserializedProduct.Name,
                deserializedProduct.ExpiryDate.ToString("yy-MM-dd"), deserializedProduct.Price, deserializedProduct.Sizes.Length));
            }

            Console.WriteLine("Tast på en knap for at lukke program");
            Console.ReadKey();
        }

        public string GetPath(string filename)
        {
            // find rooten af filerne
            string root = AppDomain.CurrentDomain.BaseDirectory;

            // vi tager root folderen af projektet og den 
            // mappe json filerne skal være i (kaldet json) 
            string directorypath = @root + "\\json\\";

            // tager inputtet og sørger for
            // at det bliver til en .json fil
            filename = filename + ".json";

            // Vi opretter mappen "json"
            Directory.CreateDirectory(directorypath);

            // Vi sætter filnavnet sammen med hvor filen skal være
            // hvor vi så får en sti hvor den skal oprettes
            string path = Path.Combine(directorypath, filename);

            // retunere stien filen skal være på
            return path;
        }

        public void CreateJson(string path, Product product)
        {
            // gem filen med navnet på stien
            string json = JsonConvert.SerializeObject(product, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public Product LoadJson(string path)
        {
            // Laver et produkt, som er det produkt der kommer
            // fra json filen som bliver deserialized
            Product deserializedProduct;

            // deserialize JSON directly from a file from path
            try
            {
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    deserializedProduct = (Product)serializer.Deserialize(file, typeof(Product));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Kunne ikke finde fil");
                deserializedProduct = null;
            }

            return deserializedProduct;
        }

        public void DeleteJson(string path, string filename)
        {

        }

        public string ListDirectory(string mappath)
        {
            // Finder en fil ud fra stien
            // På trods af eksemplet er meget simpelt
            // (mappen vil altid hedde json) så laver 
            // jeg det lidt mere kompliceret

            // copy paste fra de andre metoder
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string directorypath = @root + "\\"+mappath+"\\";


            string[] filepaths = null;

            // Finder alle filerne på stien som en liste med string
            // og sortere kun de filer der er af typen .json
            try
            {
                filepaths = Directory.GetFiles(directorypath, "*.json");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Kunne ikke finde mappe");
            }

            string filepath = "";

            // filepaths == null hvis ikke den kan finde mappen
            if (filepaths != null)
            if( filepaths.Length > 0 )
            {
                // Fordi vi kun vil have en string
                // så looper vi igennem alle filerne
                // og tilføjer dem til vores return string
                foreach(string file in filepaths)
                {
                    // gør så at root folderen ikke bliver vist men kun filnavnet
                    string raw = file.Substring(directorypath.Length, (file.Length - directorypath.Length));
                    filepath += raw + "\n";
                }
                // fjern mellemrummet til sidst...
                filepath = filepath.Substring(0, (filepath.Length - "\n".Length));
            }
            else
            {
                filepath = "...ingen json filer";
            }
            return filepath;
        }
    }

    // Produkt klassen som vi de/serializere med 
    public class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
