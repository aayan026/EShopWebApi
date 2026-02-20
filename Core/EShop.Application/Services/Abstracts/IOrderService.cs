using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;
using EShop.Application.Mappers.DTOS.Customer;
using EShop.Application.Mappers.DTOS.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Abstracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync(PaginationDTO model);
        Task<IEnumerable<OrderDto>> GetOrderWithCustomer();
        Task<OrderDto> GetByIdAsync(int id);

        Task<Response<bool>> AddAsync(CreateOrderDto model);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<bool>> UpdateAsync(int id, CreateOrderDto model);
    }
}
