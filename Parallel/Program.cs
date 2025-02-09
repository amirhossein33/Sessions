using System.Diagnostics;


public interface ISumCalculator
{
    long CalculateSum(int[] numbers);
}

public class SequentialSumCalculator : ISumCalculator
{
    public long CalculateSum(int[] numbers)
    {
        long sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }
}

public class ParallelSumCalculator : ISumCalculator
{
    public long CalculateSum(int[] numbers)
    {
        long sum = 0;
        var lockObject = new object(); 

        Parallel.For(0, numbers.Length, i =>
        {
            lock (lockObject) 
            {
                sum += numbers[i];
            }
        });

        return sum;
    }
}

public class Program
{
    public static void Main()
    {
        int[] numbers = Enumerable.Range(1, 10_000_000).ToArray(); 
        RunCalculation("Sequential", new SequentialSumCalculator(), numbers);
        RunCalculation("Parallel", new ParallelSumCalculator(), numbers);
    }

    static void RunCalculation(string method, ISumCalculator calculator, int[] numbers)
    {
        Console.WriteLine($"Starting {method} processing...");
        var stopwatch = Stopwatch.StartNew();
        long sum = calculator.CalculateSum(numbers);
        stopwatch.Stop();
        Console.WriteLine($"{method} Sum: {sum}");
        Console.WriteLine($"Time Taken ({method}): {stopwatch.ElapsedMilliseconds} ms\n");
    }
}
