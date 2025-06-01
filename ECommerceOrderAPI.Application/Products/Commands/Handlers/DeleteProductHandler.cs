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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _repository.Get(command.Id, cancellationToken);
            if (product == null) throw new Exception("There is no product with that Id");
            await _repository.Delete(product, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
