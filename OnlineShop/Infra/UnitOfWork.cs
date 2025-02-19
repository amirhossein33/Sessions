namespace OnlineShop.Infra
{
    using global::OnlineShop.Core.Interfaces;
    using global::OnlineShop.Infra.OnlineShop.Infrastructure.Data;

    namespace OnlineShop.Infrastructure.UnitOfWork
    {
        public class UnitOfWork : IUnitOfWork
        {
            private readonly AppDbContext _context;

            public UnitOfWork(AppDbContext context, IOrderRepository orderRepository)
            {
                _context = context;
                Orders = orderRepository;
            }

            public IOrderRepository Orders { get; }

            public IRepository<Core.Entities.Customer> Customers => throw new NotImplementedException();

            IRepository<Core.Entities.Order> IUnitOfWork.Orders => throw new NotImplementedException();

            public IRepository<Core.Entities.Product> Products => throw new NotImplementedException();

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }

            public void Dispose()
            {
                _context.Dispose();
            }

            public Task<int> CompleteAsync()
            {
                throw new NotImplementedException();
            }

            public IRepository<T> Repository<T>() where T : Core.Entities.BaseEntity
            {
                throw new NotImplementedException();
            }

            Task<int> IUnitOfWork.SaveChangesAsync()
            {
                throw new NotImplementedException();
            }
        }
    }


}

