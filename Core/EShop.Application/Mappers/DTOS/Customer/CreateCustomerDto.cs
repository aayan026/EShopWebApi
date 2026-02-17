namespace EShop.Application.Mappers.DTOS.Customer
{
    public class CreateCustomerDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}