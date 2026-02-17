using EShop.Application.Repositories.Common;
using EShop.Application.Services.Order;
using EShop.Persistence.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Order
{
    internal class OrderReadService : ReadGenericService<Domain.Entities.Concretes.Order>, IReadOrderService
    {
        public OrderReadService(IReadGenericRepository<Domain.Entities.Concretes.Order> readRepo) : base(readRepo)
        {
        }
    }
}
