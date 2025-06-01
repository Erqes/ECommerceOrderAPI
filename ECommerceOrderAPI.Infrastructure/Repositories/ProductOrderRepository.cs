using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderAPI.Infrastructure.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductOrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task Create(ProductOrder productOrder, CancellationToken cancellationToken)
        {
            await _context.ProductOrders.AddAsync(productOrder, cancellationToken);

        }
        public async Task Update(ProductOrder productOrder, CancellationToken cancellationToken)
        {
            _context.ProductOrders.Update(productOrder);

        }
        public async Task UpdateRange(ICollection<ProductOrder> productOrder, CancellationToken cancellationToken)
        {
            _context.ProductOrders.UpdateRange(productOrder);

        }
        public async Task<ProductOrder> Get(long id, CancellationToken cancellationToken)
        {
            return await _context.ProductOrders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<ProductOrder>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ProductOrders.ToListAsync(cancellationToken);
        }
        public async Task Delete(ProductOrder productOrder, CancellationToken cancellationToken)
        {
            _context.ProductOrders.Remove(productOrder);

        }
        public async Task CreateRange(ICollection<ProductOrder> productOrders, CancellationToken cancellationToken)
        {
            await _context.AddRangeAsync(productOrders, cancellationToken);

        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
