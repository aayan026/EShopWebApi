using AutoMapper;
using EShop.Application.Repositories.Common;
using EShop.Application.Services.Product;
using EShop.Persistence.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Product
{
    internal class ProductWriteService : WriteGenericService<Domain.Entities.Concretes.Product>, IWriteProductService
    {
        public ProductWriteService(IWriteGenericRepository<Domain.Entities.Concretes.Product> writeRepo,IMapper mapper) : base(writeRepo,mapper)
        {
        }
    }
}
