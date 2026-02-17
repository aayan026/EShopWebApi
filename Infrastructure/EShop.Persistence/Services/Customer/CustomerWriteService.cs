using AutoMapper;
using EShop.Application.Repositories.Common;
using EShop.Application.Services.Customer;
using EShop.Persistence.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Customer
{
    internal class CustomerWriteService : WriteGenericService<Domain.Entities.Concretes.Customer>, IWriteCategoryService
    {
        public CustomerWriteService(IWriteGenericRepository<Domain.Entities.Concretes.Customer> writeRepo,IMapper mapper) : base(writeRepo,mapper)
        {
        }
    }
}
