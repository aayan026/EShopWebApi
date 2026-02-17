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
    internal class CustomerReadService : ReadGenericService<Domain.Entities.Concretes.Customer>, IReadCustomerService
    {
        public CustomerReadService(IReadGenericRepository<Domain.Entities.Concretes.Customer> readRepo) : base(readRepo)
        {
        }
    }
}
