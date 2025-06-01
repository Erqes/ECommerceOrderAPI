using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerceOrderAPI.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task Create(Order order, CancellationToken cancellationToken)
        {
            await _context.Orders.AddAsync(order, cancellationToken);
        }
        public async Task Update(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Update(order);

        }
        public async Task<Order> Get(long id, CancellationToken cancellationToken)
        {
            return await _context.Orders.Include(po => po.ProductOrders).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }
        public async Task Delete(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Remove(order);
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await _context.Database.BeginTransactionAsync(cancellationToken);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
