using EShop.Application.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Product
{
    public interface IWriteProductService :IWriteGenericService<Domain.Entities.Concretes.Product>
    {
    }
}
