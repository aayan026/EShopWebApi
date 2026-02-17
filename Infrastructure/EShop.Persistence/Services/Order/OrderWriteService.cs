using AutoMapper;
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
    internal class OrderWriteService : WriteGenericService<Domain.Entities.Concretes.Order>, IWriteOrderSevice
    {
        public OrderWriteService(IWriteGenericRepository<Domain.Entities.Concretes.Order> writeRepo, IMapper mapper) : base(writeRepo, mapper)
        {
        }
    }
}
