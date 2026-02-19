using EShop.Application.Mappers.DTOS.Customer;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;
using EShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories;

public class CustomerReadRepository : ReadGenericRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Customer>> GetCustomerWithOrders()
    {
        return await _context.Customers
            .Include(x => x.Orders)
            .Where(x => x.Orders != null && x.Orders.Any())
            .ToListAsync();

    }
}
