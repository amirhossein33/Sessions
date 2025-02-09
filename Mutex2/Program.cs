public class Program
{
    static readonly Mutex mutex = new(); 
    public static void PayAtCounter(object customerId)
    {
        Console.WriteLine($" Customer {customerId} is waiting to pay...");

        mutex.WaitOne(); 
        try
        {
            Console.WriteLine($" Customer {customerId} is paying at the counter...");
            Thread.Sleep(2000); 
            Console.WriteLine($" Customer {customerId} has finished paying.");
        }
        finally
        {
            mutex.ReleaseMutex(); 
        }
    }
    public static void Main()
    {
        Console.WriteLine(" Mutex Synchronization Example\n");

        Thread[] customers = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            customers[i] = new Thread(PayAtCounter);
            customers[i].Start(i + 1);
        }
        foreach (var customer in customers)
        {
            customer.Join(); 
        }
    }
}