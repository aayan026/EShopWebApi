using AutoMapper;
using EShop.Application;
using EShop.Application.DTOS;
using EShop.Application.Mappers.DTOS.Order;
using EShop.Application.Repositories;
using EShop.Application.Services.Abstracts;
using EShop.Application.Validations.FluentValidation.Concrete;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories;

namespace EShop.Persistence.Services.Concretes;

public class OrderService : IOrderService
{
    private readonly IOrderReadRepository _orderReadRepository;
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly ICustomerReadRepository _customerReadRepository;

    private readonly IMapper _mapper;

    public OrderService(IOrderReadRepository orderReadRepository,IOrderWriteRepository orderWriteRepository,ICustomerReadRepository customerReadRepository,IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _orderWriteRepository = orderWriteRepository;
        _customerReadRepository = customerReadRepository;
        _mapper = mapper;
    }

    public async Task<Response<bool>> AddAsync(CreateOrderDto model)
    {
        var all = await _orderReadRepository.GetAllAsync();
        var isExist = all.FirstOrDefault(x => x.OrderNumber == model.OrderNumber);


        if (isExist != null)
        {
            return new Response<bool>
            {
                Success = false,
                Message = "Bu nomreli sifaris artiq movcuddur"
            };
        }
        var customer = await _customerReadRepository.GetByIdAsync(model.CustomerId);
        if (customer == null)
            return new Response<bool> { Success = false, Message = "Customer tapılmadı" };

        var newOrder = new Order
        {
            OrderNumber = model.OrderNumber,
            OrderDate = model.OrderDate,
            OrderNote = model.OrderNote,
            Total = model.Total,
            CustomerId = model.CustomerId
        };
        var validation = new OrderValidator();

        var result = validation.Validate(model);

        if (!result.IsValid)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
            };
        }
        await _orderWriteRepository.AddAsync(newOrder);
        await _orderWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{newOrder.OrderNumber} sifarisi elave olundu"
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var isExist = await _orderReadRepository.GetByIdAsync(id);

        if (isExist == null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu id-de sifaris tapilmadi"
            };
        }

        await _orderWriteRepository.Delete(id);
        await _orderWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{isExist.OrderNumber} silindi"
        };
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync(PaginationDTO model)
    {
        var orders = await _orderReadRepository.GetAllAsync();

        var paginated = orders
            .Skip(model.Page * model.PageSize)
            .Take(model.PageSize)
            .ToList();

        return _mapper.Map<List<OrderDto>>(paginated);
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        var order = await _orderReadRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrderWithCustomer()
    {
        var orders = await _orderReadRepository.GetOrderWithCustomer();

        return _mapper.Map<List<OrderDto>>(orders);
    }

    public async Task<Response<bool>> UpdateAsync(int id, CreateOrderDto model)
    {
        var order = await _orderReadRepository.GetByIdAsync(id);

        if (order == null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu id-de sifaris tapilmadi"
            };
        }
        var customer = await _customerReadRepository.GetByIdAsync(model.CustomerId);
        if (customer == null)
            return new Response<bool> { Success = false, Message = "Customer tapılmadı" };

        order.OrderNumber = model.OrderNumber;
        order.OrderDate = model.OrderDate;
        order.OrderNote = model.OrderNote;
        order.Total = model.Total;
        order.CustomerId = model.CustomerId;

        var validation = new OrderValidator();

        var result = validation.Validate(model);

        if (!result.IsValid)
        {
            return new Response<bool>
            {
                Data = false,
                Success=false,
                Message= string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
            };
        }

        await _orderWriteRepository.Update(order);
        await _orderWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{order.OrderNumber} yenilendi"
        };
    }
}