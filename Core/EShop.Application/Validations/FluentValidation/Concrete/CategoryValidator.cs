using EShop.Application.Validations.FluentValidation.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Validations.FluentValidation.Concrete;

public class CategoryValidator : GenericValidator<Domain.Entities.Concretes.Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Category Name boş ola bilməz")
        .MaximumLength(100).WithMessage("Category Name 100 simvoldan uzun ola bilməz");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description 500 simvoldan uzun ola bilməz");
    }

}

