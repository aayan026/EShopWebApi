using EShop.Application.DTOS.Product;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class ProductReadRepository : ReadGenericRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<ProductDto>> GetProductsByCategoryId(int categoryId)
    {
        var products = _context
                        .Products
                        .Where(x => x.CategoryId == categoryId)
                        .Select(x => new ProductDto()
                        {
                            Id = x.Id,
                            categoryId = x.CategoryId,
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Stock = x.Stock
                        }).ToList();
        return products;
    }
}
