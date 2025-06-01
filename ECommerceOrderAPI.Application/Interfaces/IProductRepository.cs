using ECommerceOrderAPI.Domain.Entities;

namespace ECommerceOrderAPI.Application.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product, CancellationToken cancellationToken);
        Task Delete(Product product, CancellationToken cancellationToken);
        Task<Product> Get(long id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken);
        Task<bool> ExistsByNameAsync(string productName, CancellationToken cancellationToken);
        Task<List<Product>> GetByIds(ICollection<long> ids, CancellationToken cancellationToken);
        Task Update(Product product, CancellationToken cancellationToken);
        Task UpdateRange(IEnumerable<Product> products, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}