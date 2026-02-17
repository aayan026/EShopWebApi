using EShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Mappers.DTOS.Category
{
    public class CategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<Product>? Products { get; set; }
    }
}
