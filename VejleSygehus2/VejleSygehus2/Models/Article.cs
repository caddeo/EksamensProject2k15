using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VejleSygehus2.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        [Required]
        public string Header { get; set; }

        [NotMapped]
        [Required]
        public string Body { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Models.Category Category { get; set; }
    }
}