using AutoMapper;
using EShop.Application;
using EShop.Application.DTOS;
using EShop.Application.DTOS.Category;
using EShop.Application.Mappers.DTOS.Category;
using EShop.Application.Repositories;
using EShop.Application.Services.Abstracts;
using EShop.Domain.Entities.Concretes;

namespace EShop.Persistence.Services.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _mapper = mapper;
    }

    public async Task<Response<bool>> AddAsync(AddCategoryDto model)
    {
        var all = await _categoryReadRepository.GetAllAsync();
        var isExist = all.FirstOrDefault(x => x.Name == model.Name);

        if (isExist != null)
        {
            return new Response<bool>
            {
                Success = false,
                Message = "Bu adda kateqoriya artiq movcuddur"
            };
        }

        var newCategory = new Category
        {
            Name = model.Name,
            Description = model.Description
        };

        await _categoryWriteRepository.AddAsync(newCategory);
        await _categoryWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{newCategory.Name} elave olundu"
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var isExist = await _categoryReadRepository.GetByIdAsync(id);

        if (isExist == null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu id-de kateqoriya tapilmadi"
            };
        }

        await _categoryWriteRepository.Delete(id);
        await _categoryWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{isExist.Name} silindi"
        };
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync(PaginationDTO model)
    {
        var categories = await _categoryReadRepository.GetAllAsync();

        var paginated = categories
            .Skip(model.Page * model.PageSize)
            .Take(model.PageSize)
            .ToList();

        return _mapper.Map<List<CategoryDto>>(paginated);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _categoryReadRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> GetCategoryWithProduct()
    {
        var categories = await _categoryReadRepository.GetCategoryWithProduct();

        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<Response<bool>> UpdateAsync(int id, CategoryDto model)
    {
        var category = await _categoryReadRepository.GetByIdAsync(id);

        if (category == null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu id-de kateqoriya tapilmadi"
            };
        }

        category.Name = model.Name;
        category.Description = model.Description;

        await _categoryWriteRepository.Update(category);
        await _categoryWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{category.Name} yenilendi"
        };
    }
}