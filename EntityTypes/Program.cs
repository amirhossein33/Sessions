using EntityTypes.EntityTypes;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var context = new MyContextWithFunctionMapping();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        await context.Database.ExecuteSqlRawAsync(
            @"CREATE FUNCTION dbo.ProductsWithMultipleOrders()
                        RETURNS TABLE
                        AS
                        RETURN
                        (
                            SELECT p.Name, COUNT(o.ProductId) AS OrderCount
                            FROM Products AS p
                            JOIN Orders AS o ON p.ProductId = o.ProductId
                            GROUP BY p.ProductId, p.Name
                            HAVING COUNT(o.ProductId) > 3
                        )");

        #region ToFunctionQuery
        var query = from p in context.Set<ProductWithMultipleOrders>()
                    where p.OrderCount > 3
                    select new { p.Name, p.OrderCount };
        #endregion
        var result = await query.ToListAsync();
    }
}
