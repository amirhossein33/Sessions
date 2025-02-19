using System.Collections.Immutable;

public record ImmutablePortfolio(int UserId, ImmutableDictionary<string, decimal> Investments)
{
    public ImmutablePortfolio Invest(string stock, decimal amount)
    {
        var updatedInvestments = Investments.SetItem(stock, Investments.GetValueOrDefault(stock, 0) + amount);
        return new ImmutablePortfolio(UserId, updatedInvestments);
    }

    public decimal TotalValue() => Investments.Values.Sum();
}

public class Program
{
    static async Task Main()
    {
        ImmutablePortfolio portfolio = new(1, ImmutableDictionary<string, decimal>.Empty);
        List<Task<ImmutablePortfolio>> tasks = new();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                return portfolio.Invest("AAPL", 100);
            }));
        }

        ImmutablePortfolio[] results = await Task.WhenAll(tasks);

        Console.WriteLine("Final Portfolio:");
        foreach (var result in results)
        {
            Console.WriteLine($"Total Value: {result.TotalValue()}");
        }
    }
}
/*

public class MutablePortfolio
{
    public int UserId { get; set; }
    public Dictionary<string, decimal> Investments { get; set; } = new();

    public void Invest(string stock, decimal amount)
    {
        if (Investments.ContainsKey(stock))
            Investments[stock] += amount;
        else
            Investments[stock] = amount;
    }

    public decimal TotalValue() => Investments.Values.Sum();
}

class Program
{
    static async Task Main()
    {
        MutablePortfolio portfolio = new() { UserId = 1 };
        List<Task> tasks = new();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                portfolio.Invest("AAPL", 100);
            }));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine($"Final Portfolio Value: {portfolio.TotalValue()}");
    }
}
*/
