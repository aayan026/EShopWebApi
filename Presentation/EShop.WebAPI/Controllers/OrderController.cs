using EShop.Application.DTOS;
using EShop.Application.Mappers.DTOS.Order;
using EShop.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model)
        => Ok(await _orderService.GetAllAsync(model));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _orderService.GetByIdAsync(id));

    [HttpGet("with-customer")]
    public async Task<IActionResult> GetWithCustomer()
        => Ok(await _orderService.GetOrderWithCustomer());

    [HttpPost]
    public async Task<IActionResult> Add(CreateOrderDto model)
    {
        var result = await _orderService.AddAsync(model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, OrderDto model)
    {
        var result = await _orderService.UpdateAsync(id, model);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _orderService.DeleteAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
