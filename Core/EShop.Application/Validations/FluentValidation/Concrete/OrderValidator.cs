using EShop.Application.Mappers.DTOS.Order;
using EShop.Application.Validations.FluentValidation.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Validations.FluentValidation.Concrete
{
    public class OrderValidator :GenericValidator<CreateOrderDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer boş ola bilməz");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("OrderDate boş ola bilməz")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("OrderDate gələcəkdə ola bilməz");

            RuleFor(x => x.OrderNote)
                .NotNull().WithMessage("OrderNote boş ola bilməz");


        }
    }
}

