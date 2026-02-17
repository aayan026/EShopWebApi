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
    internal class ProductReadService : ReadGenericService<Domain.Entities.Concretes.Product>, IReadProductService
    {
        public ProductReadService(IReadGenericRepository<Domain.Entities.Concretes.Product> readRepo) : base(readRepo)
        {
        }
    }
}
