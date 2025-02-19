using System;

class Program
{
    // متد برای Call by Value
    static void ModifyValue(int num)
    {
        num = 10; 
        Console.WriteLine("Inside ModifyValue method (Call by Value): " + num);
    }

    // متد برای Call by Reference
    static void ModifyReference(ref int num)
    {
        num = 10; 
        Console.WriteLine("Inside ModifyReference method (Call by Reference): " + num);
    }

    static void Main()
    {
        int value = 5;

        // Call by Value
        Console.WriteLine("Before ModifyValue (Call by Value): " + value);
        ModifyValue(value);  
        Console.WriteLine("After ModifyValue (Call by Value): " + value);

        Console.WriteLine();

        // Call by Reference
        Console.WriteLine("Before ModifyReference (Call by Reference): " + value);
        ModifyReference(ref value);  
        Console.WriteLine("After ModifyReference (Call by Reference): " + value);
    }
}
