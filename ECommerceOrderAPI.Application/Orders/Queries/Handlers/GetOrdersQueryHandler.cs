using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.DTOs;
using ECommerceOrderAPI.Infrastructure.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceOrderAPI.Application.Orders.Queries.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<GetOrdersResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<GetOrdersResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll(cancellationToken);
            if (!orders.Any())
                throw new Exception("No orders found.");
            var response =orders.Select(o=> new GetOrdersResponse()
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice
            }).ToList();
            return response;

        }
    }
}

