using AutoMapper;
using EShop.Application.Repositories.Common;
using EShop.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Common
{
    public interface IWriteGenericService<T> : IGenericService<T> where T : IBaseEntity, new()
    {
        Task<Response<T>> AddAsync(T entity);

        Task<Response<List<T>>> AddRangeAsync(List<T> entities);

        Task<Response<T>> UpdateAsync(T entity);

        Task<Response<bool>> DeleteAsync(int id);

        Task<Response<bool>> DeleteRange(List<T> entities);

    }
}