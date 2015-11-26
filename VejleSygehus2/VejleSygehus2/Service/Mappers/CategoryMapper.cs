using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VejleSygehus2.Service.Mappers
{
    public class CategoryMapper
    {
        public static Models.Category ConverFromDto(Database.DTO.CategoryDTO dto)
        {
            return new Models.Category()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Database.DTO.CategoryDTO ConvertToDto(Models.Category category)
        {
            return new Database.DTO.CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
