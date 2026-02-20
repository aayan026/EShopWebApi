using AutoMapper;
using EShop.Application;
using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;
using EShop.Application.Repositories;
using EShop.Application.Services.Abstracts;
using EShop.Application.Validations.FluentValidation.Concrete;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository,ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> AddAsync(AddProductDto model)
        {

            var getall = await _productReadRepository.GetAllAsync();
            var isExist = getall.FirstOrDefault(x => x.Name == model.Name); // bunun yereine repositoryde getbyname yaz. ona gore ki bu sorgu butun productlari cekir ve sonra name-e gore filterleyir. getbyname ise sadece name-e gore sorgu atacaq ve daha performansli olacaq.

            if (isExist != null)
            {
                return new Response<bool>
                {
                    Success = false,
                    Message = "Bu adda product artıq movcuddur"
                };
            }

            var customer = await _categoryReadRepository.GetByIdAsync(model.CategoryId);
            if (customer == null)
                return new Response<bool> { Success = false, Message = "category tapılmadı" };

            var newProduct = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId
            };
            var validation = new ProductValidator();

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

            //butun servisler ancaq dto qaytarmalidir user terefe entity gondermey olmaz.
            //ona gore ki usere lazim olmayan ve ya gizli datalar ola biler. dto vasitesi ile sadece lazim olanlari gondeririy
            var dto = _mapper.Map<ProductDto>(newProduct);//new producti dto-ya cevir

            await _productWriteRepository.AddAsync(newProduct);
            await _productWriteRepository.SaveChangeAsync();

            return new Response<bool>
            {
                Data = true,
                Success = true,
                Message = $"{dto.Name} elave olundu"
            };
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var isExist = await _productReadRepository.GetByIdAsync(id);
            if (isExist == null)
            {
                return new Response<bool>
                {
                    Data = false,
                    Success = false,
                    Message = $"bu id-de product tapilmadi"
                };
            }
            await _productWriteRepository.Delete(id);
            await _productWriteRepository.SaveChangeAsync();

            return new Response<bool>
            {
                Data = true,
                Success = true,
                Message = $"{isExist.Name} silindi"
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(PaginationDTO model)
        {
            var products = await _productReadRepository.GetAllAsync();

            var paginated = products
                .Skip(model.Page * model.PageSize)
                .Take(model.PageSize)
                .ToList();

            return _mapper.Map<List<ProductDto>>(paginated); 
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            var dto = _mapper.Map<ProductDto>(product);
            return dto;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryId(int Categoryid)
        {
            var product = await _productReadRepository.GetProductsByCategoryId(Categoryid);
            var dto = _mapper.Map<List<ProductDto>>(product);
            return dto;
        }

        public async Task<Response<bool>> UpdateAsync(int id, AddProductDto model)
        {
            var product = await _productReadRepository.GetByIdAsync(id);

            if (product==null)
            {
                return new Response<bool>
                {
                    Data = false,
                    Success = false,
                    Message = $"bu id-de product tapilmadi"
                };
            }
            var customer = await _categoryReadRepository.GetByIdAsync(model.CategoryId);
            if (customer == null)
                return new Response<bool> { Success = false, Message = "category tapılmadı" };


            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Stock = model.Stock;
            product.CategoryId = model.CategoryId;

            var validation = new ProductValidator();

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
            //auto mapper ile:
            // var productWithMapper=_mapper.Map<Product>(model); bele yazmaq duzgun deyil cunki burda auto mapper yeni bir product yaradir update etmir.
            // yenisini yaradir deye update etmek istediyimiz productin id-si ile ust uste dusmur. ona gore manual yazmaq daha duzgundur 

            await _productWriteRepository.Update(product);
            await _productWriteRepository.SaveChangeAsync();

            return new Response<bool>
            {
                Data = true,
                Success = true,
                Message = $"{product.Name} yenilendi"
            };

        }
    }
}
