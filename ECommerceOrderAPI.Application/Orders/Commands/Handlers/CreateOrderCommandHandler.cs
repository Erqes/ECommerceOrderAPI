using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ECommerceOrderAPI.Domain.Entities;
using ECommerceOrderAPI.Application.Orders.Commands;
using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Infrastructure.Repositories;
namespace ECommerceOrderAPI.Application.Orders.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductOrderRepository _orderOrderRepository;

        public CreateOrderCommandHandler(IProductRepository productRepository, IOrderRepository orderRepository, IProductOrderRepository orderOrderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderOrderRepository = orderOrderRepository;
        }

        public async Task<Unit> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var productIds = command.OrderItems.Select(x => x.Id).ToList();
            var products = await _productRepository.GetByIds(productIds, cancellationToken);

            foreach (var item in command.OrderItems)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Id);
                if (product == null)
                    throw new Exception($"Product not found: {item.Id}");

                if (product.Quantity < item.Quantity)
                    throw new Exception($"Not enough stock for {product.ProductName}");
            }
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                TotalPrice = 0
            };
            foreach (var item in command.OrderItems)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Id);
                order.TotalPrice += product.Price * item.Quantity;
                product.Quantity -= item.Quantity;
            }
            using (var transaction = await _orderRepository.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    await _orderRepository.Create(order, cancellationToken);
                    await _orderOrderRepository.SaveChangesAsync(cancellationToken);

                    await _productRepository.UpdateRange(products, cancellationToken);


                    var productOrders = command.OrderItems.Select(p => new ProductOrder
                    {
                        OrderId = order.Id,
                        ProductId = p.Id,
                        Quantity = p.Quantity
                    }).ToList();

                    await _orderOrderRepository.CreateRange(productOrders, cancellationToken);
                    await _orderOrderRepository.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                }
                catch
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
            return Unit.Value;
        }
    }
}
