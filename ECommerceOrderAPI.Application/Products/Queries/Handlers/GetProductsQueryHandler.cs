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
    public class GetProductsQueryHandler:IRequestHandler<GetProductsQuery,IEnumerable<GetProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<GetProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            return products.Select(q => new GetProductResponse
            {
                Id = q.Id,
                ProductName = q.ProductName,
                Price = q.Price
            });
        }
    }
}
