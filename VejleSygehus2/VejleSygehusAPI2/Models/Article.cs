using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VejleSygehusAPI2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public virtual Models.Category Category { get; set; }
    }
}
