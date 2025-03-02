//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace StoreTransactionExample
//{
//    public class StoreService
//    {
//        private readonly StoreContext _context;

//        public StoreService(StoreContext context)
//        {
//            _context = context;
//        }

//        public async Task PlaceOrderAsync(Order order, List<OrderItem> orderItems)
//        {
//            using var transaction = await _context.Database.BeginTransactionAsync();

//            try
//            {
//                _context.Orders.Add(order);
//                await _context.SaveChangesAsync();

//                _context.OrderItems.AddRange(orderItems);

//                await _context.SaveChangesAsync();


//                await transaction.CommitAsync();
//            }
//            catch (Exception)
//            {

//                await transaction.RollbackAsync();
//                throw;
//            }
//        }
//    }
//    public class Program
//    {

//        public static async Task Main(string[] args)
//        {
//            using var context = new StoreContext();
//            var storeService = new StoreService(context);


//            var product1 = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
//            var product2 = await context.Products.FirstOrDefaultAsync(p => p.Name == "Mouse");

//            if (product1 == null || product2 == null)
//            {
//                Console.WriteLine("Products not found!");
//                return;
//            }

//            var order = new Order
//            {
//                OrderDate = DateTime.Now,
//                CustomerName = "John Doe",
//                TotalAmount = product1.Price + product2.Price // Simple calculation
//            };

//            var orderItems = new List<OrderItem>
//            {
//                new OrderItem { Product = product1, Quantity = 1 },
//                new() { Product = product2, Quantity = 2 }
//            };

//            try
//            {
//                await storeService.PlaceOrderAsync(order, orderItems);
//                Console.WriteLine("Order placed successfully!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//            }
//        }
//    }



//    public class StoreContext : DbContext
//    {
//        public DbSet<Product> Products { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<OrderItem> OrderItems { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StoreTransactions;Trusted_Connection=True;ConnectRetryCount=0");
//        }
//    }
//    public class Product
//    {
//        public int ProductId { get; set; }
//        public string Name { get; set; }
//        public decimal Price { get; set; }
//    }
//    public class Order
//    {
//        public int OrderId { get; set; }
//        public DateTime OrderDate { get; set; }
//        public string CustomerName { get; set; }
//        public decimal TotalAmount { get; set; }
//    }
//    public class OrderItem
//    {
//        public int OrderItemId { get; set; }
//        public int OrderId { get; set; }
//        public int ProductId { get; set; }
//        public int Quantity { get; set; }
//        public decimal TotalPrice => Quantity * Product.Price;

//        public Product Product { get; set; }
//        public Order Order { get; set; }
//    }
//}
