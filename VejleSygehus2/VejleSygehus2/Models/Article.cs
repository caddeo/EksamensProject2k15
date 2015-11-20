namespace VejleSygehus2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public Category Category { get; set; }
    }
}