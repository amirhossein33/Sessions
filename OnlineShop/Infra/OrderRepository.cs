namespace OnlineShop.Infra
{
    using global::OnlineShop.Core.Entities;
    using global::OnlineShop.Infra.OnlineShop.Infrastructure.Data;
    using global::OnlineShop.Infra.OnlineShop.Infrastructure.UnitOfWork;
    using Microsoft.EntityFrameworkCore;



    namespace OnlineShop.Infrastructure.Repositories
    {
        public class OrderRepository : BaseRepository<Order>, IOrderRepository
        {
            public OrderRepository(AppDbContext context) : base(context) { }

            public async Task<Order> GetOrderWithDetailsAsync(Guid orderId)
            {
                // برای مثال، می‌توانیم اطلاعات بیشتر مانند `Customer` را به همراه `Order` بازیابی کنیم
                return await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == orderId);
            }
        }
    }



}
