using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models; 

namespace VejleSygehus.Models {
    interface IArticle {
        public string Path { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public Category Category { get; set; }
    }
}
