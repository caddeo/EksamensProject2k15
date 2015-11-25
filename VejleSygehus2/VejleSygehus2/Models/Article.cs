using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VejleSygehus2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        [NotMapped]
        public string Body { get; set; }
        public Models.Category Category { get; set; }
    }
}