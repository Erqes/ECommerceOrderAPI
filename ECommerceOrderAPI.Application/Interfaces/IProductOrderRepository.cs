using ECommerceOrderAPI.Domain.Entities;

namespace ECommerceOrderAPI.Infrastructure.Repositories
{
    public interface IProductOrderRepository
    {
        Task Create(ProductOrder productOrder, CancellationToken cancellationToken);
        Task CreateRange(ICollection<ProductOrder> productOrders, CancellationToken cancellationToken);
        Task Delete(ProductOrder productOrder, CancellationToken cancellationToken);
        Task<ProductOrder> Get(long id, CancellationToken cancellationToken);
        Task<IEnumerable<ProductOrder>> GetAll(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task Update(ProductOrder productOrder, CancellationToken cancellationToken);
        Task UpdateRange(ICollection<ProductOrder> productOrder, CancellationToken cancellationToken);
    }
}