using AutoMapper;
using EShop.Application.DTOS.Category;
using EShop.Application.DTOS.Product;
using EShop.Application.Mappers.DTOS.Category;
using EShop.Application.Mappers.DTOS.Customer;
using EShop.Application.Mappers.DTOS.Order;
using EShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //create
            CreateMap<AddCategoryDto, Category>();
            CreateMap<AddProductDto, Product>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateCustomerDto, Customer>();
            //birinci yazdigimiz class ikinci yazdigimiz classa map olunur
            //get
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Customer, CustomerDto>();

        }
    }
}
