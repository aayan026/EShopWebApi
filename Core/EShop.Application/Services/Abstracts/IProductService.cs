using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;
using EShop.Application.Mappers.DTOS.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Abstracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(PaginationDTO model);
        Task<List<ProductDto>> GetProductsByCategoryId(int CategoryId);
        Task<ProductDto> GetByIdAsync(int id);

        Task<Response<bool>> AddAsync(AddProductDto model);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<bool>> UpdateAsync(int id, ProductDto model);
    }
}
