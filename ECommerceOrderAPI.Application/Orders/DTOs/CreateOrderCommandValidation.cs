using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.Commands;
using FluentValidation;

namespace ECommerceOrderAPI.Application.Orders.DTOs
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage("Order must contain at least one item.");

            RuleForEach(x => x.OrderItems).SetValidator(new CreateOrderDTOValidation());
        }
    }

    public class CreateOrderDTOValidation : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
