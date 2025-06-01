using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.DTOs;
using ECommerceOrderAPI.Infrastructure.Repositories;
using MediatR;
using static ECommerceOrderAPI.Application.Orders.DTOs.GetOrderResponse;

namespace ECommerceOrderAPI.Application.Orders.Queries.Handlers
{
    public class GetOrderQueryHandler:IRequestHandler<GetOrderQuery,GetOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<GetOrderResponse> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(query.Id,cancellationToken);
            if (order == null)
                throw new Exception("Order not found.");
            var response = new GetOrderResponse()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                OrderItems = order.ProductOrders.Select(po => new GetOrderResponse.OrderItem
                {
                    ProductId = po.ProductId,
                    Quantity = po.Quantity,
                }).ToList(),
            };
            return response;

        }
    }
}
