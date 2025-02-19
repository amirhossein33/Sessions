namespace Infrastructure.Repository
{
    using Application.Interfaces;
    using Domain.Entity.Domain.Entities;
    using global::Infrastructure.Context;

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }
      
    }
}
