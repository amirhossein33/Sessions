using System;
using System.IO;
using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = @"D:\GarbageCollector.txt";

        StreamWriter writer = null;

        try
        {
            writer = new StreamWriter(filePath);
            Console.WriteLine("File has been written successfully.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The directory was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            if (writer != null)
            {
                writer.Dispose();
                Console.WriteLine("StreamWriter has been disposed manually.");
            }
        }
    }
}
