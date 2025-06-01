using ECommerceOrderAPI.Domain.Entities;

namespace ECommerceOrderAPI.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task<Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        Task Create(Order order, CancellationToken cancellationToken);
        Task Delete(Order order, CancellationToken cancellationToken);
        Task<Order> Get(long id, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task Update(Order order, CancellationToken cancellationToken);
    }
}