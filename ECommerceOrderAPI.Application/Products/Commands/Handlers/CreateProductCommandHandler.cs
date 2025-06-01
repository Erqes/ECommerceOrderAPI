using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Application.Products.Commands;
using ECommerceOrderAPI.Domain.Entities;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Commands.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            if (await _productRepository.ExistsByNameAsync(command.ProductName, cancellationToken))
                throw new Exception("Product with that name already exists");
            var product = new Product()
            {
                ProductName = command.ProductName,
                Quantity = command.Quantity,
                Price=command.Price
            };
            await _productRepository.Create(product, cancellationToken);
            await _productRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
