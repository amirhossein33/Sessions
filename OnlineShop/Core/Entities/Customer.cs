

namespace OnlineShop.Core.Entities
{

    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }


}
