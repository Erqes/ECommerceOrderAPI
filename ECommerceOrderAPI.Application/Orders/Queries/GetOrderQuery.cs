using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Queries
{
    public class GetOrderQuery:IRequest<GetOrderResponse>
    {
        public GetOrderQuery(long id) =>Id = id;
        public long Id { get; set; }
    }
}
