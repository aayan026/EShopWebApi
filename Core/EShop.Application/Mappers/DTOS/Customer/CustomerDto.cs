using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Mappers.DTOS.Customer;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public List<EShop.Domain.Entities.Concretes.Order>? Orders { get; set; }

}
