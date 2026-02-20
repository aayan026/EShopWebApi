using AutoMapper;
using EShop.Application;
using EShop.Application.DTOS;
using EShop.Application.Mappers.DTOS.Customer;
using EShop.Application.Repositories;
using EShop.Application.Services.Abstracts;
using EShop.Application.Validations.FluentValidation.Concrete;
using EShop.Domain.Entities.Concretes;
using FluentValidation;

namespace EShop.Persistence.Services.Concretes;

public class CustomerService : ICustomerService
{
    private readonly ICustomerReadRepository _customerReadRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMapper mapper)
    {
        _customerReadRepository = customerReadRepository;
        _customerWriteRepository = customerWriteRepository;
        _mapper = mapper;
    }

    public async Task<Response<bool>> AddAsync(CreateCustomerDto model)
    {
        var all = await _customerReadRepository.GetAllAsync();
        var isExist = all.FirstOrDefault(x => x.Email == model.Email);

        if (isExist != null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu email ile musteri artiq movcuddur"
            };
        }

        var newCustomer = new Customer
        {
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            ImageUrl = model.ImageUrl,
            Password = model.Password
        };

        var validator = new CustomerValidator();

        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
            };
        }

        await _customerWriteRepository.AddAsync(newCustomer);
        await _customerWriteRepository.SaveChangeAsync();

        var dto = _mapper.Map<CustomerDto>(newCustomer);


        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{dto.Name} elave olundu"
        };
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var isExist = await _customerReadRepository.GetByIdAsync(id);

        if (isExist == null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu id-de musteri tapilmadi"
            };
        }

        await _customerWriteRepository.Delete(id);
        await _customerWriteRepository.SaveChangeAsync();

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{isExist.Name} silindi"
        };
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync(PaginationDTO model)
    {
        var customers = await _customerReadRepository.GetAllAsync();

        var paginated = customers
            .Skip(model.Page * model.PageSize)
            .Take(model.PageSize)
            .ToList();

        return _mapper.Map<List<CustomerDto>>(paginated);
    }

    public async Task<CustomerDto> GetByIdAsync(int id)
    {
        var customer = await _customerReadRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<List<CustomerDto>> GetCustomerWithOrders()
    {
        var customers = await _customerReadRepository.GetCustomerWithOrders();
        return _mapper.Map<List<CustomerDto>>(customers);
    }

    public async Task<Response<bool>> UpdateAsync(int id, CreateCustomerDto model)
    {
        var customer = await _customerReadRepository.GetByIdAsync(id);

        if (customer == null)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = "Bu id-de musteri tapilmadi"
            };
        }

        customer.Name = model.Name;
        customer.Surname = model.Surname;
        customer.Email = model.Email;


        var validator = new CustomerValidator();

        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            return new Response<bool>
            {
                Data = false,
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.ErrorMessage))
            };
        }

        await _customerWriteRepository.Update(customer);
        await _customerWriteRepository.SaveChangeAsync();

        var dto = _mapper.Map<CustomerDto>(customer);

        return new Response<bool>
        {
            Data = true,
            Success = true,
            Message = $"{customer.Name} yenilendi"
        };
    }
}