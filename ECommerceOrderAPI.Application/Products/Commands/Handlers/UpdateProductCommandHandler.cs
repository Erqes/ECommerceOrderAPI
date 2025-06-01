using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Application.Products.Commands;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,Unit>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(command.Id, cancellationToken);
            if (product == null) throw new Exception("There is no product with this Id.");
            product.ProductName = command.ProductName;
            product.Quantity = command.Quantity;
            product.Price = command.Price;
            await _productRepository.Update(product, cancellationToken);
            await _productRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
