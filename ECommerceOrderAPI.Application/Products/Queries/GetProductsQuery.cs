using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Products.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Queries
{
    public class GetProductsQuery:IRequest<IEnumerable<GetProductResponse>>
    {
    }
}
