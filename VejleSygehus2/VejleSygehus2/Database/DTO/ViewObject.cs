using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VejleSygehus2.Database.DTO
{
    public class ViewObject
    {
        public List<SelectListItem> CategoryList { get; set; }
        public Models.Article Article { get; set; }
    }
}
