namespace Domain.Entity
{
    namespace Domain.Entities
    {
        public class Product : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int OrderId { get; set; }
        }
    }

}
