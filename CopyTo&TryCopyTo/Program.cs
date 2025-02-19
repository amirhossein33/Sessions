using System;

class Program
{
    static void Main()
    {
    
        int[] ordersSource = { 101, 102, 103, 104, 105 };
        int[] ordersDestination = new int[5];
        int[] smallDestination = new int[3];
        //  CopyTo 
        try
        {
            ordersSource.CopyTo(ordersDestination, 0);
            Console.WriteLine("Orders copied successfully using CopyTo: " + string.Join(", ", ordersDestination));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CopyTo: " + ex.Message);
        }

        //  TryCopyTo 
        Memory<int> sourceMemory = new(ordersSource);
        Memory<int> smallMemory = new(smallDestination);

        if (sourceMemory.TryCopyTo(smallMemory))
        {
            Console.WriteLine("Orders copied successfully using TryCopyTo: " + string.Join(", ", smallDestination));
        }
        else
        {
            Console.WriteLine("TryCopyTo failed: Not enough space.");
        }
    }
}
