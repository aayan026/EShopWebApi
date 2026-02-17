using EShop.Application.Repositories.Common;
using EShop.Application.Services.Category;
using EShop.Persistence.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Category
{
    internal class CategoryReadService : ReadGenericService<Domain.Entities.Concretes.Category>, IReadCategoryService
    {
        public CategoryReadService(IReadGenericRepository<Domain.Entities.Concretes.Category> readRepo) : base(readRepo)
        {
        }
    }
}
