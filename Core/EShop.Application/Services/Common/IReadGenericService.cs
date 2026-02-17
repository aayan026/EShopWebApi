using EShop.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Common
{
    public interface IReadGenericService<T> : IGenericService<T> where T : IBaseEntity, new()
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetExpressionAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(int id);

    }
}
