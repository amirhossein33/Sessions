using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // مثال استفاده از Task.WhenAll (ناهمگام)
        Task task1 = DoWorkAsync(1, 1000);
        Task task2 = DoWorkAsync(2, 2000);
        Task task3 = DoWorkAsync(3, 1500);

        // ناهمگام
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("All tasks completed using Task.WhenAll.");

        // مثال استفاده از Task.WaitAll (همگام)
        /*
        Task task4 = Task.Run(() => DoWork(4, 1000));
        Task task5 = Task.Run(() => DoWork(5, 2000));
        Task task6 = Task.Run(() => DoWork(6, 1500));

        //  همگام
        Task.WaitAll(task4, task5, task6);
        Console.WriteLine("All tasks completed using Task.WaitAll.");
        */

        // تفاوت‌ها:
        // 1. Task.WhenAll ناهمگام است و thread فعلی را مسدود نمی‌کند.
        // 2. Task.WaitAll همگام است و thread فعلی را مسدود می‌کند تا همه تسک‌ها کامل شوند.
        // 3. Task.WhenAll یک تسک برمی‌گرداند که می‌توانید با await منتظر آن بمانید.
        // 4. Task.WaitAll برای برنامه‌های همگام مناسب است، در حالی که Task.WhenAll برای برنامه‌های ناهمگام بهتر است.
    }

    // متد ناهمگام برای انجام کار
    static async Task DoWorkAsync(int id, int delay)
    {
        Console.WriteLine($"Task {id} starting...");
        await Task.Delay(delay);
        Console.WriteLine($"Task {id} completed.");
    }

    // متد همگام برای انجام کار
    static void DoWork(int id, int delay)
    {
        Console.WriteLine($"Task {id} starting...");
        Task.Delay(delay).Wait();
        Console.WriteLine($"Task {id} completed.");
    }
}