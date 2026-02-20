using FluentValidation;
using EShop.Application.DTOS.Category;
using EShop.Application.Validations.FluentValidation.Abstract;


namespace EShop.Application.Validations.FluentValidation.Concrete;

public class CategoryValidator : GenericValidator<AddCategoryDto>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Category Name boş ola bilməz")
        .MaximumLength(100).WithMessage("Category Name 100 simvoldan uzun ola bilməz");

        RuleFor(x => x.Description)
             .NotEmpty().WithMessage("Description Name boş ola bilməz")
            .MaximumLength(500).WithMessage("Description 500 simvoldan uzun ola bilməz");
    }
}

