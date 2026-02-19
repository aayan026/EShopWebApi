using EShop.Application.Mappers.DTOS.Customer;
using EShop.Application.Validations.FluentValidation.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Validations.FluentValidation.Concrete
{
    public class CustomerValidator :AbstractValidator<CreateCustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name boş ola bilməz")
                .MaximumLength(50);

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname boş ola bilməz")
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email düzgün formatda olmalıdır");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password boş ola bilməz")
                .MinimumLength(6).WithMessage("Password ən az 6 simvol olmalıdır");
        }
    }
}

