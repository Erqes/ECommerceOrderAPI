using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Interfaces;
using ECommerceOrderAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetByIds(ICollection<long> ids, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync(cancellationToken);
        }
        public async Task Create(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
        }
        public async Task<Product> Get(long id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
        public async Task Delete(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);

        }
        public async Task Update(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);

        }
        public async Task UpdateRange(IEnumerable<Product> products, CancellationToken cancellationToken)
        {
            _context.Products.UpdateRange(products);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> ExistsByNameAsync(string productName, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(p => p.ProductName == productName, cancellationToken);
        }
    }
}
