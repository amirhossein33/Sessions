using System;

public static class SplitQuerySample
{
    public static async Task ExecuteSplitQuerySample()
    {
        Console.WriteLine($">>>> Sample: {nameof(ExecuteSplitQuerySample)}");
        Console.WriteLine();

        await Helpers.RecreateAndPopulateDatabase();

        using var context = new CustomersContext();

        await ExecuteSplitQuery1(context);
        await ExecuteSplitQuery2(context);
        await ExecuteSplitQuery3(context);
    }

    private static async Task ExecuteSplitQuery1(CustomersContext context)
    {
        Console.WriteLine("Executing Split Query 1...");
        Console.WriteLine("LINQ query: 'context.Customers.Select(c => new { c, Orders = c.Orders.Where(o => o.Id > 1) })'");

        Console.WriteLine("Executed as a single query:");
        await ExecuteSingleQueryForOrders(context);

        Console.WriteLine("Executed as split queries:");
        await ExecuteSplitQueryForOrders(context);
    }

    private static async Task ExecuteSplitQuery2(CustomersContext context)
    {
        Console.WriteLine("Executing Split Query 2...");
        Console.WriteLine("LINQ query: 'context.Customers.Select(c => new { c, OrderDates = c.Orders.Where(o => o.Id > 1).Select(o => o.OrderDate) })'");

        Console.WriteLine("Executed as a single query:");
        await ExecuteSingleQueryForOrderDates(context);

        Console.WriteLine("Executed as split queries:");
        await ExecuteSplitQueryForOrderDates(context);
    }

    private static async Task ExecuteSplitQuery3(CustomersContext context)
    {
        Console.WriteLine("Executing Split Query 3...");
        Console.WriteLine("LINQ query: 'context.Customers.Select(c => new { c, OrderDates = c.Orders.Where(o => o.Id > 1).Select(o => o.OrderDate).Distinct() })'");

        Console.WriteLine("Executed as a single query:");
        await ExecuteSingleQueryForDistinctOrderDates(context);

        Console.WriteLine("Executed as split queries:");
        await ExecuteSplitQueryForDistinctOrderDates(context);
    }

    private static async Task ExecuteSingleQueryForOrders(CustomersContext context)
    {
        await context.Customers
            .Select(c => new { c, Orders = c.Orders.Where(o => o.Id > 1) })
            .ToListAsync();
    }

    private static async Task ExecuteSplitQueryForOrders(CustomersContext context)
    {
        await context.Customers
            .AsSplitQuery()
            .Select(c => new { c, Orders = c.Orders.Where(o => o.Id > 1) })
            .ToListAsync();
    }

    private static async Task ExecuteSingleQueryForOrderDates(CustomersContext context)
    {
        await context.Customers
            .Select(c => new
            {
                c,
                OrderDates = c.Orders
                    .Where(o => o.Id > 1)
                    .Select(o => o.OrderDate)
            })
            .ToListAsync();
    }

    private static async Task ExecuteSplitQueryForOrderDates(CustomersContext context)
    {
        await context.Customers
            .AsSplitQuery()
            .Select(c => new
            {
                c,
                OrderDates = c.Orders
                    .Where(o => o.Id > 1)
                    .Select(o => o.OrderDate)
            })
            .ToListAsync();
    }

    private static async Task ExecuteSingleQueryForDistinctOrderDates(CustomersContext context)
    {
        await context.Customers
            .Select(c => new
            {
                c,
                OrderDates = c.Orders
                    .Where(o => o.Id > 1)
                    .Select(o => o.OrderDate)
                    .Distinct()
            })
            .ToListAsync();
    }

    private static async Task ExecuteSplitQueryForDistinctOrderDates(CustomersContext context)
    {
        await context.Customers
            .AsSplitQuery()
            .Select(c => new
            {
                c,
                OrderDates = c.Orders
                    .Where(o => o.Id > 1)
                    .Select(o => o.OrderDate)
                    .Distinct()
            })
            .ToListAsync();
    }

    public static async Task LastColumnInOrderByRemovedWhenJoiningForCollection()
    {
        Console.WriteLine($">>>> Sample: {nameof(LastColumnInOrderByRemovedWhenJoiningForCollection)}");
        Console.WriteLine();

        await Helpers.RecreateAndPopulateDatabase();

        using var context = new CustomersContext();

        Console.WriteLine("Executing OrderBy Query...");
        await context.Customers
            .Select(e => new
            {
                e.Id,
                FirstOrder = e.Orders.Where(i => i.Id == 1).ToList()
            })
            .ToListAsync();
    }
}

public static class Helpers
{
    public static async Task RecreateAndPopulateDatabase()
    {
        using var context = new CustomersContext(quiet: true);

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await PopulateDatabase(context);
    }

    public static async Task PopulateDatabase(CustomersContext context)
    {
        context.AddRange(
            new Customer
            {
                Orders =
                {
                    new Order { OrderDate = new DateTime(2021, 7, 31) },
                    new Order { OrderDate = new DateTime(2021, 8, 1) },
                    new Order { OrderDate = new DateTime(2021, 8, 2) }
                }
            });

        await context.SaveChangesAsync();
    }
}

public class Customer
{
    public int Id { get; set; }
    public ICollection<Order> Orders { get; } = new List<Order>();
}

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

public class CustomersContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    private readonly bool _quiet;

    public CustomersContext(bool quiet = false)
    {
        _quiet = quiet;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreSample;ConnectRetryCount=0");

        if (!_quiet)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }
    }
}