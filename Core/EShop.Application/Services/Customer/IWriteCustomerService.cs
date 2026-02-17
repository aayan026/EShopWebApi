using EShop.Application.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Customer
{
    public interface IWriteCategoryService: IWriteGenericService<Domain.Entities.Concretes.Customer>
    {
    }
}
