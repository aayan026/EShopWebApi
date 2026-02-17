using Microsoft.AspNetCore.Mvc;
using EShop.Application.Repositories;
using EShop.Application.DTOS.Category;
using EShop.Domain.Entities.Concretes;
using AutoMapper;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IMapper mapper;

    public CategoryController(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> Add([FromBody] AddCategoryDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        AddCategoryDto categoryDto=mapper.Map<AddCategoryDto>(model);

        await _categoryWriteRepository.AddAsync(mapper.Map<Category>(model));

        return Ok(categoryDto);
    }

}
