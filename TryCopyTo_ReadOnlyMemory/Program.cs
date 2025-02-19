using System;

class Program
{
    static void Main()
    {
        string message = "ValidMessage";
        ReadOnlyMemory<char> messageMemory = message.AsMemory();

        char[] buffer = new char[20];
        Memory<char> destination = new(buffer);

        if (messageMemory.TryCopyTo(destination))
        {
            Console.WriteLine($"Message copied successfully: {new string(destination.ToArray())}");
        }
        else
        {
            Console.WriteLine("Failed to copy message: Not enough space.");
        }
    }
}
