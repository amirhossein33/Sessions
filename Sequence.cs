using Microsoft.EntityFrameworkCore;
internal class MyContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    #region SequenceConfiguration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
            .StartsAt(10)
            .IncrementsBy(1);
    }
    #endregion
}

public class Order
{
    public int OrderId { get; set; }
    public int OrderNum { get; set; }
    public string Name { get; set; }
}