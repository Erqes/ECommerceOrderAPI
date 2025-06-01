using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Application.Products.DTOs;
using ECommerceOrderAPI.Application.Products.Queries;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Queries.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.Get(request.Id, cancellationToken);
            if (product == null)
                throw new ArgumentException("There is no product with this id.");
            var response = new GetProductResponse()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price= product.Price,
            };
            return response;
        }
    }
}
