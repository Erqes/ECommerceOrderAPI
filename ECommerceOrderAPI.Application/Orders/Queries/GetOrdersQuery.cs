using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Queries
{
    public class GetOrdersQuery:IRequest<IEnumerable<GetOrdersResponse>>
    {
    }
}
