using EShop.Application.Repositories.Common;
using EShop.Application.Services.Common;
using EShop.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Common
{
    public class ReadGenericService<T> : GenericService<T>, IReadGenericService<T> where T : IBaseEntity, new()
    {
        private readonly IReadGenericRepository<T> _readRepo;
        public ReadGenericService(IReadGenericRepository<T> readRepo)
        {
            _readRepo = readRepo;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var data = await _readRepo.GetAllAsync();
            return data.ToList();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _readRepo.GetByIdAsync(id);
        }
        public async Task<List<T>> GetExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _readRepo.GetExpressionAsync(expression);
        }
    }
}
