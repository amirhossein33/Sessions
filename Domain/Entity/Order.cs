namespace Domain.Entity
{
    namespace Domain.Entities
    {
        public class Order : IEntity
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public ICollection<Product> Products { get; set; } = [];
        }
    }
}
