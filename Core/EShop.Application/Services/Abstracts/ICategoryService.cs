using EShop.Application.DTOS;
using EShop.Application.DTOS.Category;
using EShop.Application.DTOS.Product;
using EShop.Application.Mappers.DTOS.Category;
using EShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Abstracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync(PaginationDTO model);
    Task<CategoryDto> GetByIdAsync(int id);
    Task<List<CategoryDto>> GetCategoryWithProduct();
    
    Task<Response<bool>> AddAsync(AddCategoryDto model);
    Task<Response<bool>> DeleteAsync(int id); 
    Task<Response<bool>> UpdateAsync(int id, AddCategoryDto model);
}
