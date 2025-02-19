using OnlineShop.Core.Entities;

namespace OnlineShop.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        Task<int> CompleteAsync();
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();

    }

}
