using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Infrastructure.Repositories;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Commands.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(command.Id, cancellationToken);
            if (order == null)
                throw new Exception("Order not found");

            if(!order.ProductOrders.Any())
                throw new Exception("No products were found in order");

            var productOrders = order.ProductOrders.ToList();
            var productIds = productOrders.Select(po => po.ProductId).ToList();

            var products = await _productRepository.GetByIds(productIds, cancellationToken);

            foreach (var product in products)
            {
                var po = productOrders.FirstOrDefault(x => x.ProductId == product.Id);
                if (po != null)
                {
                    product.Quantity += po.Quantity;
                }
            }

            using var transaction = await _orderRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                await _productRepository.UpdateRange(products, cancellationToken);
                await _orderRepository.Delete(order, cancellationToken);
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
