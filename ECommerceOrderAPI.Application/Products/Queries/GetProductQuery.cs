using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Products.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Queries
{
    public class GetProductQuery:IRequest<GetProductResponse>
    {
        public GetProductQuery(long id) =>Id= id;
        public long Id { get; set; }
    }
}
