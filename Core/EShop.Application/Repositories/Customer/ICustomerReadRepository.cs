using EShop.Domain.Entities.Concretes;
using EShop.Application.Repositories.Common;
using EShop.Application.Mappers.DTOS.Customer;

namespace EShop.Application.Repositories;

public interface ICustomerReadRepository : IReadGenericRepository<Customer>
{
    Task<List<Customer>> GetCustomerWithOrders();
}
