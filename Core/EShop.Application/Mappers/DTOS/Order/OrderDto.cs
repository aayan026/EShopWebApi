using EShop.Application.Mappers.DTOS.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Mappers.DTOS.Order
{
    public class OrderDto
    {
        public string? OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string? OrderNote { get; set; }
        public decimal? Total { get; set; }

        public CustomerDto Customer { get; set; } 
    }
}
