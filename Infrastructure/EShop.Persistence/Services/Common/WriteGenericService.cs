using AutoMapper;
using EShop.Application;
using EShop.Application.Repositories.Common;
using EShop.Application.Services.Common;
using EShop.Domain;
using EShop.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Common
{
    public class WriteGenericService<T> : GenericService<T>, IWriteGenericService<T> where T : IBaseEntity, new()
    {
        private readonly IWriteGenericRepository<T> _writeRepo;
        private readonly IMapper _mapper;

        public WriteGenericService(IWriteGenericRepository<T> writeRepo, IMapper mapper)
        {
            _writeRepo = writeRepo;
            _mapper = mapper;
        }

        public async Task<Response<T>> AddAsync(T entity)
        {
            await _writeRepo.AddAsync(entity);
            await _writeRepo.SaveChangeAsync();

            return new Response<T>
            {
                Data = entity,
                Success = true,
                Message = $"{typeof(T).Name} əlavə olundu"
            };
        }

        public async Task<Response<List<T>>> AddRangeAsync(List<T> entities)
        {
            await _writeRepo.AddRangeAsync(entities);
            await _writeRepo.SaveChangeAsync();

            return new Response<List<T>>
            {
                Data = entities,
                Success = true,
                Message = $"{entities.Count} {typeof(T).Name} əlavə olundu"
            };
        }

        public async Task<Response<T>> UpdateAsync(T entity)
        {
            await _writeRepo.Update(entity);
            await _writeRepo.SaveChangeAsync();

            return new Response<T>
            {
                Data = entity,
                Success = true,
                Message = $"{typeof(T).Name} yeniləndi"
            };
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            await _writeRepo.Delete(id);
            await _writeRepo.SaveChangeAsync();

            return new Response<bool>
            {
                Data = true,
                Success = true,
                Message = $"{typeof(T).Name} silindi"
            };
        }

        public async Task<Response<bool>> DeleteRange(List<T> entities)
        {
            await _writeRepo.DeleteRange(entities);
            await _writeRepo.SaveChangeAsync();

            return new Response<bool>
            {
                Data = true,
                Success = true,
                Message = $"{entities.Count} {typeof(T).Name} silindi"
            };
        }

    }
}