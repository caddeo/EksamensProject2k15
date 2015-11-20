namespace VejleSygehus2.Models
{
    public interface IArticle
    {
        string Path { get; set; }
        string Header { get; set; }
        string Body { get; set; }
        Category Category { get; set; }
    }
}