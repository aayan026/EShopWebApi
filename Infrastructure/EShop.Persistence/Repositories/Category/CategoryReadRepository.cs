using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories;

public class CategoryReadRepository : ReadGenericRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(AppDbContext context) : base(context)
    {
    }

    public Task<List<Category>> GetCategoryWithProduct()
    {
        return _context.Categories.Include(x => x.Products).ToListAsync();
    }
}
