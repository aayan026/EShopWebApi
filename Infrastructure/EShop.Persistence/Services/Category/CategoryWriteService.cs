using AutoMapper;
using EShop.Application.Repositories.Common;
using EShop.Application.Services.Category;
using EShop.Application.Services.Customer;
using EShop.Persistence.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Category
{
    internal class CategoryWriteService : WriteGenericService<Domain.Entities.Concretes.Category>, ICategoryWriteService
    {
        public CategoryWriteService(IWriteGenericRepository<Domain.Entities.Concretes.Category> writeRepo, IMapper mapper) : base(writeRepo, mapper)
        {
        }
    }
}
