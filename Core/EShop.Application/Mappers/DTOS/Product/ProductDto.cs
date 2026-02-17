using EShop.Application.Mappers.DTOS.Category;

namespace EShop.Application.DTOS.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? Stock { get; set; }
    public CategoryDto? CategoryName { get; set; }
}
