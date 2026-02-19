using EShop.Application.DTOS.Product;
using EShop.Application.Repositories.Common;
using EShop.Domain.Entities.Concretes;

namespace EShop.Application.Repositories;

public interface IProductReadRepository : IReadGenericRepository<Product>
{
    Task<List<ProductDto>> GetProductsByCategoryId(int categoryId);


}
