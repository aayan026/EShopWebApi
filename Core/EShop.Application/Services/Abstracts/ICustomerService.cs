using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;
using EShop.Application.Mappers.DTOS.Category;
using EShop.Application.Mappers.DTOS.Customer;
using EShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Abstracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync(PaginationDTO model);
        Task<CustomerDto> GetByIdAsync(int id);
        Task<List<CustomerDto>> GetCustomerWithOrders();

        Task<Response<bool>> AddAsync(CreateCustomerDto model);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<bool>> UpdateAsync(int id, CreateCustomerDto model);
    }
}
