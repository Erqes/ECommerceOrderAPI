using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Domain.Entities;
using ECommerceOrderAPI.Infrastructure.Repositories;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Commands.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductOrderRepository _productOrderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, IProductOrderRepository productOrderRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _productOrderRepository = productOrderRepository;
        }
        public async Task<Unit> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(command.Id, cancellationToken);
            if (order == null)
                throw new Exception("Order not found");

            var existingProductOrders = order.ProductOrders.ToList();
            var requestedProductIds = command.DTOs.Select(i => i.ProductId).ToList();
            var newProductOrders = new List<ProductOrder>();
            var products = await _productRepository.GetByIds(requestedProductIds, cancellationToken);

            double newTotal = 0;
            var updatedProductOrders = new List<ProductOrder>();

            foreach (var dto in command.DTOs)
            {
                var product = products.FirstOrDefault(p => p.Id == dto.ProductId);
                if (product == null)
                    throw new Exception($"Product not found: {dto.ProductId}");

                var existing = existingProductOrders.FirstOrDefault(po => po.ProductId == dto.ProductId);

                int quantityChange = dto.Quantity - (existing?.Quantity ?? 0);
                if (product.Quantity < quantityChange)
                    throw new Exception($"Not enough stock for product {product.ProductName}");

                product.Quantity -= quantityChange;
                if (existing != null)
                {
                    existing.Quantity = dto.Quantity;
                    updatedProductOrders.Add(existing);
                }
                else
                {
                    var productOrder = new ProductOrder { OrderId = order.Id, ProductId = dto.ProductId, Quantity = dto.Quantity };
                    newProductOrders.Add(productOrder);
                }
                newTotal += product.Price * dto.Quantity;
            }

            order.TotalPrice = newTotal;

            using var transaction = await _orderRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                await _productRepository.UpdateRange(products, cancellationToken);
                await _productOrderRepository.UpdateRange(updatedProductOrders, cancellationToken);
                await _productOrderRepository.CreateRange(newProductOrders, cancellationToken);
                await _orderRepository.Update(order, cancellationToken);
                await _productRepository.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
            return Unit.Value;
        }
    }
}
