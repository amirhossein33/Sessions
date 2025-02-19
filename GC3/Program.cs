class Program
{
    static void Main()
    {
        List<byte[]> dataList = [];

        for (int i = 0; i < 100; i++)
        {
            dataList.Add(new byte[1024 * 1024]); 
        }

        Console.WriteLine("Memory before GC: " + GC.GetTotalMemory(false));

        dataList.Clear();
        GC.Collect(); 
        GC.WaitForPendingFinalizers(); // انتظار برای اجرای Finalizer

        Console.WriteLine("Memory after GC: " + GC.GetTotalMemory(false));
    }
}
