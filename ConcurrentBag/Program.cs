using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting Financial Report Processing...\n");

        var pool = new FinancialProcessorPool(); 

        Parallel.For(0, 15, async (i) =>
        {
            var processor = pool.Get(); 
            var report = new FinancialReport($"Report {i}: Initial Data");

            try
            {
                processor.SetReport(report); 
                processor.AppendEntry($"Updated on {DateTime.UtcNow}"); 
                Console.WriteLine($" {processor.GetReportAsString()}");
                Console.WriteLine($" Available processors in pool: {pool.WorkerCount}");
                await Task.Delay(100);
            }
            finally
            {
                pool.Return(processor); 
                await Task.Delay(250);
            }
        });

        Console.WriteLine("\n Financial Report Processing Completed!");
        Console.ReadLine();
    }
}

internal class FinancialProcessorPool
{
    private ConcurrentBag<FinancialProcessor> _workerPool = new(); 

    public FinancialProcessorPool()
    {
        _workerPool.Add(new FinancialProcessor()); 
    }

    public FinancialProcessor Get() => _workerPool.TryTake(out var processor) ? processor : new FinancialProcessor();
    public void Return(FinancialProcessor processor) => _workerPool.Add(processor);
    public int WorkerCount => _workerPool.Count;
}


internal class FinancialProcessor
{
    private FinancialReport? _report;

    public void SetReport(FinancialReport report) => _report = report;
    public FinancialReport? GetReport() => _report;

    public void AppendEntry(string entry)
    {
        string newData = _report == null ? entry : _report.PlainText + Environment.NewLine + entry;
        _report = new FinancialReport(newData);
    }

    public string GetReportAsString() => _report?.PlainText ?? "";
}

public class FinancialReport
{
    private string _plainText;
    private byte[] _data;

    public FinancialReport(string plainText)
    {
        _plainText = plainText;
        _data = System.Text.Encoding.ASCII.GetBytes(plainText);
    }

    public string PlainText => _plainText;
    public byte[] ReportData => _data;
}
