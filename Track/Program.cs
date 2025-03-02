using Microsoft.EntityFrameworkCore;
using Track;

public class Program
{
    public static async Task Main(string[] args)
    {
        using (var context = new OrderContext())
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        using (var context = new OrderContext())
        {
            context.Orders.Add(new Order { Name = "Test1" });
            context.Orders.Add(new Order { Name = "Test2" });
            await context.SaveChangesAsync();
        }

        using (var context = new OrderContext())
        {
            #region Tracking
            var order = await context.Orders.SingleOrDefaultAsync(o => o.OrderId == 1);
            order.Price = 5;
            await context.SaveChangesAsync();
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region NoTracking
            var orders = await context.Orders
                .AsNoTracking()
                .ToListAsync();
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region NoTrackingWithIdentityResolution
            var orders = await context.Orders
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region ContextDefaultTrackingBehavior
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var orders = await context.Orders.ToListAsync();
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region CustomProjection1
            var order = context.Orders
                .Select(
                    o =>
                        new { Order = o, ProductCount = o.Products.Count() });
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region CustomProjection2
            var order = context.Orders
                .Select(
                    o =>
                        new { Order = o, Product = o.Products.OrderBy(p => p.Price).LastOrDefault() });
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region CustomProjection3
            var order = context.Orders
                .Select(
                    o =>
                        new { Id = o.OrderId, o.Name });
            #endregion
        }

        using (var context = new OrderContext())
        {
            #region ClientProjection
            var orders = await context.Orders
                .OrderByDescending(order => order.Price)
                .Select(
                    order => new { Id = order.OrderId, Name = StandardizeName(order) })
                .ToListAsync();
            #endregion
        }
    }

    #region ClientMethod
    public static string StandardizeName(Order order)
    {
        var name = order.Name.ToLower();

        if (!name.StartsWith("http://"))
        {
            name = string.Concat("http://", name);
        }

        return name;
    }
    #endregion
}
