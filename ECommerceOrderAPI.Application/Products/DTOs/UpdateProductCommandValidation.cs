using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Products.Commands;
using FluentValidation;

namespace ECommerceOrderAPI.Application.Products.DTOs
{
    public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty();
            RuleFor(p => p.ProductName)
                    .NotEmpty();
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quanitity must be greater than 0.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
