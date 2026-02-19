using EShop.Application.DTOS;
using EShop.Application.DTOS.Category;
using EShop.Application.Mappers.DTOS.Category;
using EShop.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model)
        => Ok(await _categoryService.GetAllAsync(model));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _categoryService.GetByIdAsync(id));

    [HttpGet("with-products")]
    public async Task<IActionResult> GetWithProducts()
        => Ok(await _categoryService.GetCategoryWithProduct());

    [HttpPost]
    public async Task<IActionResult> Add(AddCategoryDto model)
    {
        var result = await _categoryService.AddAsync(model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryDto model)
    {
        var result = await _categoryService.UpdateAsync(id, model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
