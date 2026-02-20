using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;
using EShop.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model)
        => Ok(await _productService.GetAllAsync(model));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _productService.GetByIdAsync(id));

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
        => Ok(await _productService.GetProductsByCategoryId(categoryId));

    [HttpPost]
    public async Task<IActionResult> Add(AddProductDto model)
    {
        var result = await _productService.AddAsync(model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AddProductDto model)
    {
        var result = await _productService.UpdateAsync(id, model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productService.DeleteAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
