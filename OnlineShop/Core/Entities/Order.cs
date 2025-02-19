using OnlineShop.Application.DTOs;

namespace OnlineShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; internal set; }

        public IEnumerable<OrderDto> Select(Func< Order, OrderDto> value)
        {
            throw new NotImplementedException();
        }
    }

}
