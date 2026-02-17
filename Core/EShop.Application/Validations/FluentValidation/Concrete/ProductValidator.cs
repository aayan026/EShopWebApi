using EShop.Application.Validations.FluentValidation.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Validations.FluentValidation.Concrete;

public class ProductValidator: GenericValidator<Domain.Entities.Concretes.Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product Name boş ola bilməz")
            .MaximumLength(100);

        RuleFor(x => x.Price)
            .NotNull().WithMessage("Price boş ola bilməz")
            .GreaterThanOrEqualTo(0).WithMessage("Price 0-dan kiçik ola bilməz");

        RuleFor(x => x.Stock)
            .NotNull().WithMessage("Stock boş ola bilməz")
            .GreaterThanOrEqualTo(0).WithMessage("Stock 0-dan kiçik ola bilməz");
    }
}