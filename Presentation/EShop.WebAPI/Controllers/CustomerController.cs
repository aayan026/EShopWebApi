using EShop.Application.DTOS;
using EShop.Application.Mappers.DTOS.Customer;
using EShop.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model)
        => Ok(await _customerService.GetAllAsync(model));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _customerService.GetByIdAsync(id));

    [HttpGet("with-orders")]
    public async Task<IActionResult> GetWithOrders()
        => Ok(await _customerService.GetCustomerWithOrders());

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDto model)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);

        var result = await _customerService.AddAsync(model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCustomerDto model)
    {
        var result = await _customerService.UpdateAsync(id, model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _customerService.DeleteAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
